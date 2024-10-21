using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
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

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest request)
    {
        try
        {
            Category createdCategory = _mapper.Map<Category>(request);
            _categoryRepository.Add(createdCategory);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

            return new ReturnModel<CategoryResponseDto>()
            {
                Success = true,
                Message = "Kategori eklendi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
        }
   
    }

    public ReturnModel<List<CategoryResponseDto>>GetAll()
    {
        try
        {
            List<Category> categories =_categoryRepository.GetAll();
            List<CategoryResponseDto> responseList = _mapper.Map<List<CategoryResponseDto>>(categories);

            return new ReturnModel<List<CategoryResponseDto>>()
            {
                Success = true,
                Message = "Kategori listesi başarılı bir şekilde getirildi.",
                Data = responseList,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<List<CategoryResponseDto>>.HandleException(ex);
        }
    
    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        try
        {
            Category? category = _categoryRepository.GetById(id);
            CategoryResponseDto? response = _mapper.Map<CategoryResponseDto>(category);

            return new ReturnModel<CategoryResponseDto?>()
            {
                Success = true,
                Message = $"{id} numaralı kategori başarılı bir şekilde getirildi.",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CategoryResponseDto?>.HandleException(ex);
        }
   
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        try
        {
            Category category = _categoryRepository.GetById(id);
            Category deletedCategory = _categoryRepository.Remove(category);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

            return new ReturnModel<CategoryResponseDto>()
            {
                Success = true,
                Message = "Kategori başarılı bir şekilde silindi",
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
        }
  
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest request)
    {
        try
        {
            Category existingCategory = _categoryRepository.GetById(request.Id);

            existingCategory.Id=existingCategory.Id;
            existingCategory.Name=request.Name;


            Category updatedCategory = _categoryRepository.Update(existingCategory);
            CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);

            return new ReturnModel<CategoryResponseDto>()
            {
                Success = true,
                Message = "Kategori güncellendi.",
                Data = dto,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return ExceptionHandler<CategoryResponseDto>.HandleException(ex);
        }
    
    }
}
