using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using BlogSite.Service.Rules;
using Core.Exceptions;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exceptions;


namespace BlogSite.Service.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ReturnModel<UserResponseDto> Add(CreateUserRequest request)
    {
        try
        {
            User createdUser = _mapper.Map<User>(request);
            _userRepository.Add(createdUser);
            UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

            return new ReturnModel<UserResponseDto>()
            {
                Success = true,
                Message = "Kulanıcı eklendi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
    
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        try
        {
            List<User> users =  _userRepository.GetAll();
            List<UserResponseDto> responseList = _mapper.Map<List<UserResponseDto>>(users);

            return new ReturnModel<List<UserResponseDto>>()
            {
                Success = true,
                Message = "Kullanıcı listesi başarılı bir şekilde getirildi.",
                Data = responseList,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<List<UserResponseDto>>.HandleException(ex);
        }
   
    }

    public ReturnModel<UserResponseDto?> GetById(long id)
    {
        try
        {
            User? user =  _userRepository.GetById(id);
            UserResponseDto? response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto?>()
            {
                Success = true,
                Message = $"{id} numaralı kullanıcı başarılı bir şekilde getirildi.",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<UserResponseDto?>.HandleException(ex);
        }
    
    }

    public ReturnModel<UserResponseDto>Remove(long id)
    {
        try
        {
            User user = _userRepository.GetById(id);
            User deletedUser = _userRepository.Remove(user);
            UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

            return new ReturnModel<UserResponseDto>()
            {
                Success = true,
                Message = "Kullanıcı başarılı bir şekilde silindi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
    
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequest request)
    {
        try
        {
            User existingUser = _userRepository.GetById(request.Id);

            existingUser.Id = existingUser.Id;
            existingUser.Email= request.Email;
            existingUser.Username= request.Username;
            existingUser.Password= request.Password;
         

            User updatedUser =_userRepository.Update(existingUser);
            UserResponseDto dto = _mapper.Map<UserResponseDto>(updatedUser);

            return new ReturnModel<UserResponseDto>()
            {
                Success = true,
                Message = "Kullanıcı güncellendi.",
                Data = dto,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<UserResponseDto>.HandleException(ex);
        }
   
    }
}
