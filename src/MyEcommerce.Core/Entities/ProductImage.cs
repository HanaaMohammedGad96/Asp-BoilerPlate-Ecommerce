using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEcommerce.Entities;

[Table("AppProductImages")]
public class ProductImage : Entity<Guid>, IAudited
{

    [Required(ErrorMessage = "Please enter the path of the image")]
    public string ImagePath { get; set; }

    [Required(ErrorMessage = "Please enter the name of the image")]
    public string ImageName { get; set; }

    public bool IsMain { get; set; }

    public long? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
    public long? LastModifierUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    public Guid ProductId { get; set; }

    public ProductImage() { }
    public ProductImage(Guid productId, string name, string path, bool IsMain = false)
    {
        ProductId = productId;
        ImageName = name;
        ImagePath = path;
        IsMain    = IsMain;
    }
}
