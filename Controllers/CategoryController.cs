using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Data;
using shop.Models;

namespace shop.Controllers
{
    [Route("v1/Categories")]
    public class CategoryController : ControllerBase
    {
        

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            return Ok(await context.Categories.AsNoTracking().ToArrayAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
         [AllowAnonymous]
        public async Task<ActionResult<Category>> GetById(int id, [FromServices] DataContext context)
        {
            return Ok(await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
         [Authorize(Roles="employee")]
        public async Task<ActionResult<Category>> Post([FromBody]Category model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {

                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles="employee")]
        public async Task<ActionResult<Category>> Put( [FromServices] DataContext context,[FromBody] Category model, int id)
        {
            if (model.Id == id)
                return Ok(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch 
            {
                
              return NotFound(new { message = "categoria nao encontrada" });
            }

            
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles="employee")]

        public async Task<ActionResult<string>> Delete(int id, [FromServices] DataContext context)
        {
            var cat = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(cat == null){
               return NotFound(new { message = "categoria nao encontrada" });
            }

            try
            {
                context.Categories.Remove(cat);
                await context.SaveChangesAsync();
                return Ok("Delete");

            }
            catch 
            {
                
                return BadRequest(ModelState);
            }
            
        }


    }
}