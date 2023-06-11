using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyEcommerce.Entities.Categories;

[Table("AppCategories")]
public class Category : Entity<Guid>, IAudited, IPassivable , IMultiLingualEntity<CategoryTranslation>
{
    [Required(ErrorMessage = "Please choose category image")]
    public string ImagePath { get; set; }

    public long? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
    public long? LastModifierUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public bool IsActive { get; set; }

    public ICollection<CategoryTranslation> Translations { get; set; }
    public ICollection<SubCategory> SubCategories { get; set; }
}
