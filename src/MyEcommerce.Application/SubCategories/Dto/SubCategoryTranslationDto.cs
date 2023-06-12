using Abp.AutoMapper;
using MyEcommerce.Entities.SubCategories;

namespace MyEcommerce.SubCategories.Dto;

[AutoMap(typeof(SubCategoryTranslation))]
public class SubCategoryTranslationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
}
