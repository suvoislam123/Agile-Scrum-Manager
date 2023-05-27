using Microsoft.AspNetCore.Mvc.Rendering;

namespace PMS_Software.ViewModels
{
    public class CreateTeamViewModel
    {
        public string Name { get; set; }
        public string? AdminUserName { get; set; }
        public List<string> SelectedUserIds { get; set; }
        public List<SelectListItem>? SuggestedUsers { get; set; }
    }
}
