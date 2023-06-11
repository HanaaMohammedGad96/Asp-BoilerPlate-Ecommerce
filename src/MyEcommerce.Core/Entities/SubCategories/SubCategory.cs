using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using MyEcommerce.Entities.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyEcommerce.Entities.SubCategories;

[Table("AppSubCategories")]
public class SubCategory : Entity<Guid>, IAudited, IPassivable  , IMultiLingualEntity<SubCategoryTranslation>
{
    [Required(ErrorMessage = "Please choose category image")]
    public string ImagePath { get; set; }

    public long? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
    public long? LastModifierUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public bool IsActive { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }

    public ICollection<SubCategoryTranslation> Translations { get; set; } = new HashSet<SubCategoryTranslation>();
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();

}