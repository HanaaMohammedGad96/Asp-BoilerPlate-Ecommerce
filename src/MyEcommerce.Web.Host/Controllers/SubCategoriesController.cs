using System;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyEcommerce.Entities.SubCategories;
using System.Threading.Tasks;
using MyEcommerce.SubCategories.Dto;
using Abp.Localization;
using Microsoft.AspNetCore.Hosting;
using MyEcommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Abp.Authorization;
using MyEcommerce.Authorization;

namespace MyEcommerce.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoriesController : AbpController
    {
        private readonly IRepository<SubCategory, Guid> _subCategoryRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly string _language;

        public SubCategoriesController(IWebHostEnvironment environment, IRepository<SubCategory, Guid> subCategoryRepository, ILanguageManager languageManager)
        {
            _subCategoryRepository = subCategoryRepository;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _language = languageManager.CurrentLanguage.Name;
        }

        [HttpGet("{id}")]
        [AbpAuthorize(PermissionNames.Pages_SubCategory)]
        public async Task<IActionResult> Get(Guid id)
        {
            var subCategory = await _subCategoryRepository
                .GetAllIncluding(t => t.Translations)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            var subCategoryDto = ObjectMapper.Map<SubCategoryDto>(subCategory);
            subCategoryDto.Translations = ObjectMapper.Map<List<SubCategoryTranslationDto>>(
                subCategory.Translations.Where(tr => tr.Language == _language));

            return Ok(subCategoryDto);
        }

        [HttpPost]
        [AbpAuthorize(PermissionNames.Pages_CreateSubCategory)]
        public async Task<IActionResult> Create([FromForm] CreateSubCategoryInput input)
        {
            string wwwPath = _environment.WebRootPath;

            if (string.IsNullOrEmpty(wwwPath))
                throw new BadHttpRequestException("invalid path");

            var path = await FileUploader.Upload(input?.Image, wwwPath);

            if (path == null)
                throw new BadHttpRequestException("invalid path");
            input.ImagePath = path;

            var subCategory = ObjectMapper.Map<SubCategory>(input);

            await _subCategoryRepository.InsertAsync(subCategory);
            await CurrentUnitOfWork.SaveChangesAsync();

            return Ok(subCategory.Id);
        }
    }
}
