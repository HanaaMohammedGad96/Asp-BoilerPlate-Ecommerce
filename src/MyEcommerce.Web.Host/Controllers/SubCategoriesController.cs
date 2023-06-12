using System;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyEcommerce.Entities.SubCategories;
using System.Threading.Tasks;

namespace MyEcommerce.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoriesController : AbpController
    {
        private readonly IRepository<SubCategory, Guid> _subCategoryRepository;

        public SubCategoriesController(IRepository<SubCategory, Guid> subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var subCategory = await _subCategoryRepository.GetAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubCategory subCategory)
        {
            await _subCategoryRepository.InsertAsync(subCategory);
            await CurrentUnitOfWork.SaveChangesAsync();

            return Ok(subCategory.Id);
        }
    }
}
