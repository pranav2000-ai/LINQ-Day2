class Item
{
    public string? Name { get; set; }
    public double price{ get; set; }
    public Item(string Name, double price){
        this.Name = Name;
        this.price = price;
    }
}