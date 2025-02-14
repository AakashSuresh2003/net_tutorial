using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_tutorial.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}