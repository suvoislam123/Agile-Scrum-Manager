using Entities.ProjectEntities;


namespace Entities.ProjectEntities
{
    public  class Backlog
    {
        public Guid Id { get; set; }
        public Guid boardId { get; set; }
        public Board Board { get; set; }
        public ICollection<TempIssue> TempIssues { get; set; }

    }
}
