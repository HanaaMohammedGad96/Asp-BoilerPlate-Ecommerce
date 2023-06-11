using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyEcommerce.Entities.Categories;
using System;

namespace MyEcommerce.Categories.Dto;

[AutoMap(typeof(Category))]
public class UpdateCategoryInput : CreateCategoryInput, IEntityDto<Guid>
{
    public Guid Id { get; set; }
}
