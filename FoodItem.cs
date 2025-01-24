namespace Mission3;

// Class for FoodItem objects
public class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateOnly ExpirationDate { get; set; }

    // Constructor for gathering inputs and using them to make the object
    public FoodItem(string name, string category, int quantity, DateOnly expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
}