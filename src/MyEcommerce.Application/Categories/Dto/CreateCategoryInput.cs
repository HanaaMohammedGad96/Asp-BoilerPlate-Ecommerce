using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using MyEcommerce.Entities.Categories;
using System.Collections.Generic;

namespace MyEcommerce.Categories.Dto;

[AutoMap(typeof(Category))]
public class CreateCategoryInput
{
    public IFormFile Image { get; set; }
    //[SwaggerExclude]
    public string ImagePath { get; set; }
    public bool IsActive { get; set; }

    public List<CategoryTranslationDto> Translations { get; set; }
}
