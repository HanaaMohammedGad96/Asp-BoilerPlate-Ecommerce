using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using MyEcommerce.Events.Category;

namespace MyEcommerce.EventHandler.Category;

public class CategoryCreatedHandler : IEventHandler<CategoryCreatedEvent>  , ITransientDependency
{
    public void HandleEvent(CategoryCreatedEvent eventData)
    {
        System.Console.WriteLine("======================================================================");
        System.Console.WriteLine($"Hello I am CategoryCreatedHandler the id of created Category id => {eventData.CategoryId}");
        System.Console.WriteLine("======================================================================");
    }
}
