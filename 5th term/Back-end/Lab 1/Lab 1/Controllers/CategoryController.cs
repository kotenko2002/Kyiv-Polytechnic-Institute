using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Lab_1.Models;
using Lab_1.Data;

namespace Lab_1.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Empty request body");
            }

            if (DbContext.Categories.Any(item => item.Id == category.Id))
            {
                return BadRequest("Category with such Id already exists");
            }

            DbContext.Categories.Add(category);
            return Ok("Success");
        }

        [HttpGet("items")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = DbContext.Categories;
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }
    }
}
