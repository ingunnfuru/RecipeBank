using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class DishService
{
    static List<Dish> Dishes { get; }
    static int nextId = 4;
    static DishService()
    {
        Dishes = new List<Dish>
        {
            new Dish { Id = 1, Name = "Pizza", Ingredients = new List<string>() {"pizzabunn", "ost", "tomatsaus", "skinke", "ananas"}},
            new Dish { Id = 2, Name = "Lasagne", Ingredients = new List<string>() {"lasagneplater", "ost", "tomatsaus", "gulrot", "squarsh"}},
            new Dish { Id = 3, Name = "Luftmiddag" }
        };
    }

    //Ingredients = ["pizzabunn", "ost", "tomatsaus", "skinke", "ananas"]
    //Ingredients = new List<string>() {"lasagneplater", "ost", "tomatsaus", "gulrot", "squarsh"} 

    public static List<Dish> GetAll() => Dishes;

    public static Dish? Get(int id) => Dishes.FirstOrDefault(p => p.Id == id);

    public static void Add(Dish dish)
    {
        dish.Id = nextId++;
        Dishes.Add(dish);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Dishes.Remove(pizza);
    }

    public static void Update(Dish dish)
    {
        var index = Dishes.FindIndex(p => p.Id == dish.Id);
        if(index == -1)
            return;

        Dishes[index] = dish;
    } 
}