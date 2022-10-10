using MissyMenuApi.Services;
using Microsoft.AspNetCore.Mvc;
using MissyMenuApi.Models;

namespace MissyMenuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalController : ControllerBase
    {
    private readonly GlobalService _globalService;

    public GlobalController(GlobalService globalService) =>
        _globalService = globalService;

    [HttpGet]
    public async Task<List<Global>> Get() =>
        await _globalService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Global>> Get(string id)
    {
        var book = await _globalService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Global newGlobal)
    {
        await _globalService.CreateAsync(newGlobal);

        return CreatedAtAction(nameof(Get), new { id = newGlobal._id.Oid }, newGlobal);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Global updatedglobal)
    {
        var global = await _globalService.GetAsync(id);

        if (global is null)
        {
            return NotFound();
        }

        updatedglobal._id.Oid = global._id.Oid;

        await _globalService.UpdateAsync(id, updatedglobal);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var global = await _globalService.GetAsync(id);

        if (global is null)
        {
            return NotFound();
        }

        await _globalService.RemoveAsync(id);

        return NoContent();
    }
}
