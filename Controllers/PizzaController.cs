using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
//kan hentes på localhost:{port}/pizza
public class PizzaController : ControllerBase
{
    //konstruktør
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet] //responderer da kun til HTTP Get verb
    public ActionResult<List<Pizza>> GetAll() => //returnerer en ActionResult instanse av typen List<Pizza> . 
    //ActionResult er baseklassen for alle action-resultater i ASP.NET Core
        PizzaService.GetAll();

    // GET by Id action  //url: .../pizza/id-verdien
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
}

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    //The [HttpPost] attribute maps HTTP POST requests sent to http://localhost:5000/pizza by using the Create() method. 
    //This method returns an IActionResult response.
    //IActionResult lets the client know if the request succeeded and provides the ID of the newly created pizza. Rspons 201 (created) eller 400 (badRequest)

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        PizzaService.Update(pizza);           
    
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
    
        return NoContent();
    }
}

