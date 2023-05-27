using Entities.ProjectEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.BoardDTO
{
    public class AddIssuesByExeleRequest
    {
        public string SelectedSprintId { get; set; }
        public string BoardId { get; set; }   
        public IFormFile ExcelFile { get; set; }
    }
}
