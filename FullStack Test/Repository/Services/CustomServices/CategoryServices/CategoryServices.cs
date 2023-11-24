using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.CustomServices.CategoryServices
{
    public class CategoryServices:ICategoryServices
    {
        private readonly IRepository<Category> _serviceCategory;
        private readonly MainDbContext _DbContext;

        public CategoryServices(IRepository<Category> category , MainDbContext dbContext)
        {
            _serviceCategory = category;
            _DbContext= dbContext;
        }

        public async Task<ICollection<CategoryViewModels>> GetAll()
        {
            ICollection<CategoryViewModels> categoryViewModel = new List<CategoryViewModels>();
            ICollection<Category> result = await _serviceCategory.GetAll();
            foreach (Category category in result)
            {
                CategoryViewModels categoryView = new()
                {
                 
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                categoryViewModel.Add(categoryView);
            }
            return categoryViewModel;
        }

        public async Task<CategoryViewModels> Get(int Id)
        {
            var result = await _serviceCategory.Get(Id);
            if (result == null)
                return null;
            else
            {
                CategoryViewModels categoryViewModel = new()
                {
                   
                    CategoryId= result.CategoryId,
                    CategoryName = result.CategoryName
                };
                return categoryViewModel;
            }
        }

        public Category GetLast()
        {
            return _serviceCategory.GetLast();
        }
        public Task<bool> Insert(CategoryInsertModel categoryInsertModel)
        {
            Category category = new()
            {
                Id=categoryInsertModel.CategoryId,
                CategoryName = categoryInsertModel.CategoryName,
                CategoryId= categoryInsertModel.CategoryId,
              
            };
            return _serviceCategory.Insert(category);
        }


        public async Task<bool> Update(CategoryUpdateModel categoryUpdateModel)
        {
            try
            {
                Category category = await _serviceCategory.Get(categoryUpdateModel.Id);
                if (category != null)
                {
                    // Update properties
                    category.CategoryName = categoryUpdateModel.CategoryName;

                    // Avoid updating primary key if possible
                    // category.CategoryId = categoryUpdateModel.CategoryId;

                    // Call the update method (assuming it's asynchronous)
                    var result = await _serviceCategory.Update(category);

                    return result;
                }
                else
                {
                    // Category not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error updating category: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> Delete(int Id)
        {
            try
            {
                Category category = await _serviceCategory.Get(Id);
                if (category != null)
                {
                    await _serviceCategory.Delete(category); // Assuming _serviceCategory.Delete is asynchronous
                                                             // If you're using Entity Framework, save changes to the database
                    await _DbContext.SaveChangesAsync(); // Replace with your actual database context

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error deleting category: {ex.Message}");
                return false;
            }
        }

        public Task<Category> Find(Expression<Func<Category, bool>> match)
        {
            return _serviceCategory.Find(match);
        }
    }
}
