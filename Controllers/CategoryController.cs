using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Data;
using Microsoft.AspNetCore.Authorization;

[Route("v1/categories")]
public class CategoryController : ControllerBase {

    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
    public async Task<ActionResult<List<Category>>> Get(
        [FromServices] DataContext context
    )
    {
       var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
    }

    [HttpGet]
    [Route("{id:int}")] //restrição na rota permitindo apenas numeros inteiros;
    public async Task<ActionResult<Category>> GetById(
        int id,
        [FromServices] DataContext context
    )
    {
        var categories = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return categories;
    }

    [HttpPost]
    [Route("")]
                          //função FromBody serve para dizer que to buscando uma categoria no corpo da requisição;
    public async Task<ActionResult<List<Category>>> Post(
        [FromBody]Category model,
        [FromServices] DataContext context
        )
        {

        if (!ModelState.IsValid)//Verifica se o que tem no ModelState está válido;
            return BadRequest(ModelState);//se não estiver válido retorna um BadRequest;

        try{
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new {message = "Não foi possível criar a categoria!"});
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Put(
        int id, 
        [FromBody]Category model,
        [FromServices]DataContext context
        )
        {

        //Verifica se o id informado é o mesmo do modelo;
        if(id != model.Id)
            return NotFound(new {message = "Categoria não encontrada!"});

        //Verifica se os dados são válidos;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new {message = "Este registro já foi atualizado"});
        }
        catch(Exception)
        {
            return BadRequest(new {message = "Não foi possível atualizar a categoria"});   
        }
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete(
        int id,
        [FromServices]DataContext context
    )
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new {message = "Categoria não encontrada"});
        
        try
        {
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(new {message = "Categoria removida com sucesso"});
        }
        catch(Exception)
        {
            return BadRequest(new {message = "Não foi possível excluir a categoria"});
        }
    }
}