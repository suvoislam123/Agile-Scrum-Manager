using Entities;
using Entities.Account;
using Entities.ProjectEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO.BoardDTO;
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
            board.ProjectLead = user.Identity.Name;
            await _pMS_DBContext.Boards.AddAsync(board);
            await _pMS_DBContext.SaveChangesAsync();
            return board;
        }

        public async Task AddIssueAtSprint(Guid sprintId,Issue issue)
        {
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
    }
}
