using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEcommerce.Entities.SubCategories;

[Table("AppSubCategoryTranslations")]
public class SubCategoryTranslation : Entity, IEntityTranslation<SubCategory>
{
    public const int MaxNameLength = 256;
    public const int MaxDescriptionLength = 64 * 1024; //64KB

    [Required]
    [StringLength(MaxNameLength)]
    public string Name { get; set; }

    [StringLength(MaxDescriptionLength)]
    public string Description { get; set; }
    public int CoreId { get; set; }
    public SubCategory Core { get; set; }
    public string Language { get; set; }
}
