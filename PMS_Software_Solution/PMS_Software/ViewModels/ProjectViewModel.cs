using ServiceContracts.DTO.ProjectDTO;

namespace PMS_Software.ViewModels
{
    public class ProjectViewModel
    {
        public List<ProjectResponse> ProjectsAsWoner{ get; set; }
        public List<ProjectResponse> ProjectsAsLead { get;set; }

    }
}
