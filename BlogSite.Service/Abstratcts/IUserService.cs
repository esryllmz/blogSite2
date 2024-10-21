using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts;

public interface IUserService
{
    ReturnModel<List<UserResponseDto>> GetAll();
    ReturnModel<UserResponseDto?> GetById(long id);
    ReturnModel<UserResponseDto> Add(CreateUserRequest create);

    ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser);

    ReturnModel<UserResponseDto> Remove(long id);
}
