using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concretes;

public class EfCommentRepository: EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Comment> GetAllByPostId(Guid PostId)
    {
        List<Comment> comments = Context.Comments.Where(x => x.PostId == PostId).ToList();
        return comments;
    }

    public List<Comment> GetAllByTitleContains(string text)
    {
        List<Comment> comments = Context.Comments
              .Where(x => x.Text.Contains(text, StringComparison.InvariantCultureIgnoreCase))
              .ToList();

        return comments;
    }

    public List<Comment> GetAllByUserId(long UserId)
    {
        List<Comment> comments = Context.Comments.Where(x => x.UserId == UserId).ToList();
        return comments;
    }
}
