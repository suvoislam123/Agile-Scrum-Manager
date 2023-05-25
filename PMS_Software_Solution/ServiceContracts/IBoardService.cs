using Entities.ProjectEntities;
using ServiceContracts.DTO.BoardDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetBoardsByProjectId(Guid projectId);
        /*Task<Board> AddBoardAsync(BoardAddRequest boardAddRequest, ClaimsPrincipal user);*/
        Task<Board> AddBoardAsync(BoardAddRequest boardAddRequest, ClaimsPrincipal user);
        ICollection<Sprint> GetSprintsByBoardId(Guid boardId);
        Task AddIssueAtSprint(Guid sprintId, Issue issue);
        Task AddTempIssueAtBoard(Guid boardId, TempIssue tempIssue);
        Task<List<Issue>> GetIssuesBySprintId(Guid sprinId);
        Task<Issue> DeleteIssueByIssueId(Guid Id);
    }
}
