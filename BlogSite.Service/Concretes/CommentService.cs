using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
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

namespace BlogSite.Service.Concretes;

public class CommentService : ICommentService

{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest request)
    {
        try
        {
            Comment createdComment = _mapper.Map<Comment>(request);
            _commentRepository.Add(createdComment);
            CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

            return new ReturnModel<CommentResponseDto>()
            {
                Success = true,
                Message = "Yorum eklendi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);
        }
   
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        try
        {
            List<Comment> comments =  _commentRepository.GetAll();
            List<CommentResponseDto> responseList = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>()
            {
                Success = true,
                Message = "Yorum listesi başarılı bir şekilde getirildi.",
                Data = responseList,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<List<CommentResponseDto>>.HandleException(ex);
        }
   
    }

    public ReturnModel<CommentResponseDto?> GetById(Guid id)
    {
        try 
        { 
        
            Comment? comment =  _commentRepository.GetById(id);
            CommentResponseDto? response = _mapper.Map<CommentResponseDto>(comment);

            return new ReturnModel<CommentResponseDto?>()
            {
                Success = true,
                Message = $"{id} numaralı yorum başarılı bir şekilde getirildi.",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CommentResponseDto?>.HandleException(ex);
        }
      
    }

    public ReturnModel<CommentResponseDto> Remove(Guid id)
    {
        try
        {
            Comment comment = _commentRepository.GetById(id);
            Comment deletedComment =  _commentRepository.Remove(comment);
            CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);

            return new ReturnModel<CommentResponseDto>()
            {
                Success = true,
                Message = "Kullanıcı başarılı bir şekilde silindi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);
        }
   
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest request)
    {
        try
        {
            Comment existingComment = _commentRepository.GetById(request.Id);

            existingComment.Id = existingComment.Id;
            existingComment.Text = request.Text;

         

            Comment updatedComment = _commentRepository.Update(existingComment);
            CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);

            return new ReturnModel<CommentResponseDto>()
            {
                Success = true,
                Message = "Yorum güncellendi.",
                Data = dto,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CommentResponseDto>.HandleException(ex);
        }
  
    }
}
