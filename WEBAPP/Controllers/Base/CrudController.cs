using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPP.Controllers.Base;

public abstract class CrudController<T> : ControllerBase where T : class, IEntity, new()
{
    protected readonly IRepository<T> Repository;

    protected CrudController(IRepository<T> repository) => 
        Repository = repository;
    
    [HttpGet]
    public virtual async Task<List<T>> Get() =>
        await Repository.GetAsync();
    
    [HttpGet("{id:length(24)}")]
    public virtual async Task<ActionResult<T>> Get(string id)
    {
        var e = await Repository.GetAsync(id);

        if (e is null)
            return NotFound();

        return e;
    }
    
    [HttpPost]
    public virtual async Task<IActionResult> Create(T e)
    {
        await Repository.CreateAsync(e);

        return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
    }
    
    [HttpPut("{id:length(24)}")]
    public virtual async Task<IActionResult> Update(string id, T updated)
    {
        var e = await Repository.GetAsync(id);

        if (e is null)
            return NotFound();

        updated.Id = e.Id;

        await Repository.UpdateAsync(id, updated);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public virtual async Task<IActionResult> Delete(string id)
    {
        var e = await Repository.GetAsync(id);

        if (e is null)
            return NotFound();

        await Repository.RemoveAsync(id);

        return NoContent();
    }
}