using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Entities.Categories;

public class CategoryTranslation :Entity, IEntityTranslation<Category>
{
    public const int MaxNameLength = 256;
    public const int MaxDescriptionLength = 64 * 1024; //64KB

    [Required]
    [StringLength(MaxNameLength)]
    public string Name { get; set; }

    [StringLength(MaxDescriptionLength)]
    public string Description { get; set; }
    public int CoreId { get; set; }
    public Category Core { get; set; }
    public string Language { get; set; }
}
