namespace ContosoPizza.Models;

public class Dish
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<string>? Ingredients { get; set; }
}