namespace PMS_Software.ViewModels
{
    public class IssueViewModel
    {
        public string Name {get; set;}
        public string Description { get; set;}  
        public CommentViewModel? CommentViewModel { get; set;}
    }
}
