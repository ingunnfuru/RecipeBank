using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
//kan hentes på localhost:{port}/dish
public class DishController : ControllerBase
{
    //konstruktør
    public DishController()
    {
    }

    // GET all action
    [HttpGet] //responderer da kun til HTTP Get verb
    public ActionResult<List<Dish>> GetAll() => //returnerer en ActionResult instanse av typen List<Pizza> . 
    //ActionResult er baseklassen for alle action-resultater i ASP.NET Core
        DishService.GetAll();

    // GET by Id action  //url: .../pizza/id-verdien
    [HttpGet("{id}")]
    public ActionResult<Dish> Get(int id)
    {
        var dish = DishService.Get(id);

        if(dish == null)
            return NotFound();

        return dish;
}

    // POST action
    [HttpPost]
    public IActionResult Create(Dish dish)
    {            
        DishService.Add(dish);
        return CreatedAtAction(nameof(Get), new { id = dish.Id }, dish);
    }

    //The [HttpPost] attribute maps HTTP POST requests sent to http://localhost:5000/pizza by using the Create() method. 
    //This method returns an IActionResult response.
    //IActionResult lets the client know if the request succeeded and provides the ID of the newly created pizza. Rspons 201 (created) eller 400 (badRequest)

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Dish dish)
    {
        if (id != dish.Id)
            return BadRequest();
            
        var existingDish = DishService.Get(id);
        if(existingDish is null)
            return NotFound();
    
        DishService.Update(dish);           
    
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var dish = DishService.Get(id);
    
        if (dish is null)
            return NotFound();
        
        DishService.Delete(id);
    
        return NoContent();
    }
}

