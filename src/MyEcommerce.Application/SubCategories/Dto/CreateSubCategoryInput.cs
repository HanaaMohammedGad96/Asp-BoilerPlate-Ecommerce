using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using MyEcommerce.Entities.SubCategories;
using System;
using System.Collections.Generic;

namespace MyEcommerce.SubCategories.Dto;

[AutoMap(typeof(SubCategory))]
public class CreateSubCategoryInput 
{
    public Guid CategoryId { get; set; }
    public IFormFile Image { get; set; }
    //[SwaggerExclude]
    public string ImagePath { get; set; }
    public bool IsActive { get; set; }

    public List<SubCategoryTranslationDto> Translations { get; set; }
}
