using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto?> GetById(Guid id);
    ReturnModel<CommentResponseDto> Add(CreateCommentRequest create);

    ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment);

    ReturnModel<CommentResponseDto> Remove(Guid id);
}
