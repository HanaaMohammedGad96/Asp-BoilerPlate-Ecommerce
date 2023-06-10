using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEcommerce.Entities;

[Table("AppProducts")]
public class Product : Entity<Guid>, IAudited, ISoftDelete
{
    public const int MaxNameLength = 256;
    public const int MaxShortDescriptionLength = 50 * 1024;
    public const int MaxDescriptionLength = 90 * 1024;

    [Required]
    [StringLength(MaxNameLength)]
    public string NameArabic { get; set; }


    [Required]
    [StringLength(MaxNameLength)]
    public string NameEnglish { get; set; }


    [StringLength(MaxShortDescriptionLength)]
    public string ShortDescriptionArabic { get; set; }


    [StringLength(MaxShortDescriptionLength)]
    public string ShortDescriptionEnglish { get; set; } 
    
    
    [StringLength(MaxDescriptionLength)]
    public string DescriptionArabic { get; set; }


    [StringLength(MaxDescriptionLength)]
    public string DescriptionEnglish { get; set; }

    public decimal Price { get; set; }
    public int CountInStock { get; set; }

    public long? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
    public long? LastModifierUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(SubCategoryId))]
    public SubCategory SubCategoryOfProduct { get; set; }
    public Guid SubCategoryId { get; set; }

    public ICollection<ProductImage> ImagesOfProduct { get; set; } = new HashSet<ProductImage>();
}
