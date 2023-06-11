using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.Authorization;
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
    private readonly IRepository<Category, Guid> _repository;
    private readonly IWebHostEnvironment _environment;
    private readonly ILanguageManager _languageManager;

    public CategoryAppService(IWebHostEnvironment environment, IRepository<Category, Guid> repository, ILanguageManager languageManager) : base(repository)
    {
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        _languageManager = languageManager ?? throw new ArgumentNullException(nameof(languageManager));
    }

    [AbpAuthorize(PermissionNames.Pages_Products)]
    protected override IQueryable<Category> CreateFilteredQuery(GetAllCategoriesInput input)
    {
        var lang = _languageManager.CurrentLanguage.Name;

        var query = base.CreateFilteredQuery(input).Where(t => t.IsActive == input.IsActive);

        // Include translations based on user language
        query = query.Include(t => t.Translations.Where(tr => tr.Language == lang));

        return query;

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
