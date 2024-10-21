using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Responses;

public sealed record CommentResponseDto
{
    public Guid Id { get; init; }
    public string Text { get; init; } = null!;
}
