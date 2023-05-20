using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using NLog.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppLoginEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService service;
        IMapper mapper;
        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<Category> categories = await service.getAllCategoriesAsync();
            if (categories != null)
            {
                IEnumerable<CategoryDTO> categoriesDTO = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
                return Ok(categoriesDTO);
            }
            return BadRequest("No categories 😢");
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            Category category = mapper.Map<CategoryDTO, Category>(categoryDTO);
            Category categoryCreated = await service.addCategoryAsync(category);
            if (categoryCreated != null)
            {
                CategoryDTO categoryDTOCreated = mapper.Map<Category, CategoryDTO>(categoryCreated);
                return CreatedAtAction(nameof(Get), new { id = categoryDTOCreated.Id }, categoryDTOCreated);
            }
            return BadRequest();
        }
    }
}
