using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string Text, Guid PostId, long UserId);
