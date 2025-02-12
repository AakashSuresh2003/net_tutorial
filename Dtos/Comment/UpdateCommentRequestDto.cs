using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_tutorial.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
    }
}