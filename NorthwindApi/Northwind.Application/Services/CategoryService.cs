using AutoMapper;
using Northwind.Application.DTOs;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Categories.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryDto.CategoryId);
            if (category != null)
            {
                _mapper.Map(categoryDto, category);
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
