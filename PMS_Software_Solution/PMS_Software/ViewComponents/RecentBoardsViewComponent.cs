
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Mvc;

namespace PMS_Software.ViewComponents
{
    public class RecentBoardsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Board> boards)
        {
            return View("RecentBoardList",boards);
        }
    }
}
