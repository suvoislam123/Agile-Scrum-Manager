using Microsoft.AspNetCore.Mvc.Filters;

namespace PMS_Software.Filters.ActionFilters
{
    public class SampleActionFilter : Attribute, IAsyncActionFilter
    {
        private string _name;
        public SampleActionFilter(string name)
        {
            _name = name;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Before");
            await Console.Out.WriteLineAsync("After");
        }
    }
}
