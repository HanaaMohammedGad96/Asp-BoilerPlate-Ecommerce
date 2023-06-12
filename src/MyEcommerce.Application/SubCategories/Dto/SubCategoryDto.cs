﻿using Abp.AutoMapper;
using MyEcommerce.Entities.SubCategories;
using System.Collections.Generic;

namespace MyEcommerce.SubCategories.Dto;

[AutoMap(typeof(SubCategory))]
public class SubCategoryDto
{
    public string ImagePath { get; set; }
    public bool IsActive { get; set; }

    public List<SubCategoryTranslationDto> Translations { get; set; }
}
