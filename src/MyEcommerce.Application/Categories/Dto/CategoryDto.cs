﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyEcommerce.Entities.Categories;
using System;
using System.Collections.Generic;

namespace MyEcommerce.Categories.Dto;

[AutoMap(typeof(Category))]
public class CategoryDto  : EntityDto<Guid>
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; }
    public bool IsActive { get; set; }

    public List<CategoryTranslationDto> Translations { get; set; }
}
