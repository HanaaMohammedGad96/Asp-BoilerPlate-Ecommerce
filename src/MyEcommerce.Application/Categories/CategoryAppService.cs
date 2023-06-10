using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using MyEcommerce.Categories.Dto;
using MyEcommerce.Entities.Categories;
using MyEcommerce.Helpers;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MyEcommerce.Categories;

public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid, GetAllCategoriesInput, CreateCategoryInput, UpdateCategoryInput>, ICategoryAppService
{
    private readonly IWebHostEnvironment _environment;

    public CategoryAppService(IWebHostEnvironment environment, IRepository<Category, Guid> repository) : base(repository)
    {
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    protected override IQueryable<Category> CreateFilteredQuery(GetAllCategoriesInput input)
    {
        return base.CreateFilteredQuery(input).Where(t => t.IsActive == input.IsActive);
    }

    public override async Task<CategoryDto> CreateAsync(CreateCategoryInput input)
    {
        string wwwPath = _environment.WebRootPath;

        if (string.IsNullOrEmpty(wwwPath))
            throw new BadHttpRequestException("invalid path");

        var path = await FileUploader.Upload(input?.Image, wwwPath);

        if (path == null)
            throw new BadHttpRequestException("invalid path");
        input.ImagePath = path;

        return await base.CreateAsync(input);
    }

}
