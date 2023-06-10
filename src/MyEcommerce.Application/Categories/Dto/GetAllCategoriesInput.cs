using Abp.Application.Services.Dto;

namespace MyEcommerce.Categories.Dto;

public class GetAllCategoriesInput :PagedAndSortedResultRequestDto
{
    public bool IsActive { get; set; }
}
