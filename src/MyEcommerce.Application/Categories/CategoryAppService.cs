using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyEcommerce.Categories.Dto;
using MyEcommerce.Entities.Categories;
using System;
using System.Threading.Tasks;

namespace MyEcommerce.Categories;

public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid>, ICategoryAppService
{
    public CategoryAppService(IRepository<Category, Guid> repository) : base(repository)
    {
    }
}
