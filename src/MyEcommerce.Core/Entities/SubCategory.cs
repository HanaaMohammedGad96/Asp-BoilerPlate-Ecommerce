using System;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyEcommerce.Entities.Categories;

namespace MyEcommerce.Entities;

[Table("AppSubCategories")]
public class SubCategory : Entity<Guid>, IAudited, IPassivable
{
    public const int MaxNameLength = 256;
    public const int MaxDescriptionLength = 64 * 1024; //64KB

    [Required]
    [StringLength(MaxNameLength)]
    public string NameArabic { get; set; }


    [Required]
    [StringLength(MaxNameLength)]
    public string NameEnglish { get; set; }


    [StringLength(MaxDescriptionLength)]
    public string DescriptionArabic { get; set; }


    [StringLength(MaxDescriptionLength)]
    public string DescriptionEnglish { get; set; }


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

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();

}
