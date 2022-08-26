using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService) =>
        _recipesService = recipesService;

    [HttpGet]
    public async Task<List<Recipe>> Get() =>
        await _recipesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Recipe>> Get(string id)
    {
        var book = await _recipesService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Recipe newRecipe)
    {
        await _recipesService.CreateAsync(newRecipe);

        return CreatedAtAction(nameof(Get), new { id = newRecipe._id.Oid }, newRecipe);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Recipe updatedRecipe)
    {
        var recipe = await _recipesService.GetAsync(id);

        if (recipe is null)
        {
            return NotFound();
        }

        updatedRecipe._id.Oid = recipe._id.Oid;

        await _recipesService.UpdateAsync(id, updatedRecipe);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var recipe = await _recipesService.GetAsync(id);

        if (recipe is null)
        {
            return NotFound();
        }

        await _recipesService.RemoveAsync(id);

        return NoContent();
    }
}