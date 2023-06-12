using Abp.Application.Services.Dto;
using System;

namespace MyEcommerce.SubCategories.Dto;
public class UpdateSubCategoryInput : CreateSubCategoryInput, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
