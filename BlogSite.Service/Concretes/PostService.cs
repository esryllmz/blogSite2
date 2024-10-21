﻿
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();

        _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);


        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message= string.Empty,
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto?> GetById(Guid id)
    {
        var post = _postRepository.GetById(id);

        var response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto> Remove(Guid id)
    {
        Post post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Remove(post);

        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Silindi.",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost)
    {


        Post post = _postRepository.GetById(updatePost.Id);
        post.CategoryId = post.CategoryId;
        post.Content = updatePost.Content;
        post.Title = updatePost.Title;
        post.AuthorId=post.AuthorId;
        post.CreatedDate = post.CreatedDate;



        Post updatedPost = _postRepository.Update(post);

        PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);
        return new ReturnModel<PostResponseDto>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = System.Net.HttpStatusCode.OK,
            Success = true
        };


    }
}