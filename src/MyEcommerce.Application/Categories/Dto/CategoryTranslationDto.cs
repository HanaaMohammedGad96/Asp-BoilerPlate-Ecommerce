using Abp.AutoMapper;
using MyEcommerce.Entities.Categories;

namespace MyEcommerce.Categories.Dto;

[AutoMap(typeof(CategoryTranslation))]
public class CategoryTranslationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
}
