using Entities;
using Entities.Account;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO.BoardDTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProjectServices
{
    public class BoardService : IBoardService
    {
        private readonly PMS_DBContext _pMS_DBContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public BoardService(PMS_DBContext pMS_DBContext, SignInManager<ApplicationUser> signInManager)
        {
            _pMS_DBContext = pMS_DBContext;
            _signInManager = signInManager;
        }

        public async Task<Board> AddBoardAsync(BoardAddRequest boardAddRequest, ClaimsPrincipal user)
        {
            Board board = boardAddRequest.ToBoard();
            Sprint sprint1 = new Sprint()
            {
                Id = Guid.NewGuid(),
                Name = "Sprint1",
                Description = "This is primary Description",
                BoardId = board.Id,
            };
            board.Sprints = new List<Sprint>() { sprint1 };
            board.Backlog = new Backlog()
            {
                Id = Guid.NewGuid(),
                boardId = board.Id
            };
            board.ProjectLead = user.Identity.Name;
            await _pMS_DBContext.Boards.AddAsync(board);
            await _pMS_DBContext.SaveChangesAsync();
            return board;
        }

        public async Task AddIssueAtSprint(Guid sprintId,Issue issue)
        {
            issue.State = IssueStateOptions.ToDo.ToString();
            var sprint = await _pMS_DBContext.Sprints
                        .Include(sp => sp.Issues)
                        .FirstOrDefaultAsync(sp => sp.Id == sprintId);
            if (sprint != null)
            {
                _pMS_DBContext.Entry(sprint).State = EntityState.Modified;
                _pMS_DBContext.Issues.Add(issue);
                try
                {
                    await _pMS_DBContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Handle concurrency conflict
                }
            }

        }
        public async Task AddTempIssueAtBoard(Guid boardId, TempIssue tempIssue)
        {
            var board =await  _pMS_DBContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);
            if(board != null)
            {
                _pMS_DBContext.TempIssues.Add(tempIssue);
                await _pMS_DBContext.SaveChangesAsync();
            }
        }

        /*public Task<Board> AddBoardAsync(BoardAddRequest boardAddRequest, ClaimsPrincipal user)
        {
            Board board = boardAddRequest.ToBoard();
            var userName = user.Identity.Name;
            return board;
        }*/
        public async Task<IEnumerable<Board>> GetBoardsByProjectId(Guid projectId)
        {
            var project = _pMS_DBContext.Projects
                           .Include(p=>p.Boards)
                           .FirstOrDefault(p=>p.Id == projectId);

            IEnumerable<Board> boards = project.Boards;
            return boards;
        }
        public ICollection<Sprint> GetSprintsByBoardId(Guid boardId)
        {
            var sprints = _pMS_DBContext.Boards
            .Where(board => board.Id == boardId)
            .SelectMany(board => board.Sprints)
            .ToList();

            return sprints;
        }
        public async Task<List<Issue>> GetIssuesBySprintId(Guid sprinId)
        {
            var sprintWithIssues = await _pMS_DBContext.Sprints
                .Include(i => i.Issues)
                .FirstOrDefaultAsync(s=>s.Id == sprinId);
            var issues = sprintWithIssues.Issues;
            return issues.ToList();
        }

        public async Task<Issue> DeleteIssueByIssueId(Guid Id)
        {
            var issue = await _pMS_DBContext.Issues.FirstOrDefaultAsync(i=>i.Id==Id);
            if(issue != null)
            {
                _pMS_DBContext.Issues.Remove(issue);
                await _pMS_DBContext.SaveChangesAsync();
            }
            return issue;
        }

        public async Task<ICollection<TempIssue>> GetTempIssuesByBoardId(Guid boardId)
        {
            var tempIssues =await  _pMS_DBContext.TempIssues
                .Where(i => i.BoardId == boardId)
                .ToListAsync();
            return tempIssues;
        }

        public async Task<List<Issue>> AddIssues(List<Issue> issues)
        {
            await _pMS_DBContext.Issues.AddRangeAsync(issues);
            await _pMS_DBContext.SaveChangesAsync();
            return issues;
        }

        public async Task<List<TempIssue>> AddtempIssues(List<TempIssue> tempIssues)
        {
            await _pMS_DBContext.TempIssues.AddRangeAsync(tempIssues);
            await _pMS_DBContext.SaveChangesAsync();
            return tempIssues;
        }
    }
}
