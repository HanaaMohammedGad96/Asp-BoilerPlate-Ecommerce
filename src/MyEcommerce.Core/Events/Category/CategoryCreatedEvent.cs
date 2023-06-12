using Abp.Events.Bus;
using MyEcommerce.Entities.Categories;
using System;

namespace MyEcommerce.Events.Category;

public class CategoryCreatedEvent  : EventData
{
    public Guid CategoryId { get; set; }

    public CategoryCreatedEvent(Guid id)
    => CategoryId = id;
}
