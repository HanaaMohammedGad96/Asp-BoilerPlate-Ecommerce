using Microsoft.AspNetCore.Http;
using MyEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MyEcommerce.Helpers;

public static class ProductImageUploader
{
    public static async Task<ProductImage> UpdateProductImage(ProductImage productImage, IFormFile image, string webRootPath)
    {
        if (image == null)
            throw new ArgumentNullException();

        if (image.FileName == null || image.FileName.Length == 0)
            throw new ArgumentNullException();

        var path = Path.Combine(webRootPath, "Images/", image.FileName);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            await image.CopyToAsync(stream);
            stream.Close();
        }
        productImage.ImageName = image.FileName;
        productImage.ImagePath = path;

        return productImage;
    }

    public static async Task<IEnumerable<ProductImage>> UploadProductImages(Guid productId, List<IFormFile> images, string webRootPath)
    {
        List<ProductImage> productImages = new List<ProductImage>();

        if (images == null)
            throw new ArgumentNullException();

        foreach (var image in images)
        {
            if (image.FileName == null || image.FileName.Length == 0)
                throw new ArgumentNullException();

            var path = Path.Combine(webRootPath, "Images/", image.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
                stream.Close();
            }

            productImages.Add(new ProductImage(productId, image.FileName, path));
        }

        return productImages;
    }
}
