using Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.CommentDTO
{
    public  class CommentShowResponse
    {
        public string commentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser User { get; set; }
    }
}
