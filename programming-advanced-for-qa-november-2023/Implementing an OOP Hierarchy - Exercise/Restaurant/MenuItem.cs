namespace ExerciseOopHierarchy;

public abstract class MenuItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public MenuItem(string name, string description, decimal price)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Description} - ${this.Price}";
    }
}
