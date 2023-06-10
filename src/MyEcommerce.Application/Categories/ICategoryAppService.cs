using Abp.Application.Services;
using MyEcommerce.Categories.Dto;
using System;

namespace MyEcommerce.Categories;

public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, Guid>
{
}
