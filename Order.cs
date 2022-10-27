class Order
{
    public int ID { get; set; }
    public string? ItemName { get; set; }
    public DateTime Date { get; set; }
    public float Quantity { get; set; }

    public Order(int ID, string ItemName, string Date_string, float Quantity)
    {
        this.ID = ID;
        this.ItemName = ItemName;
        this.Date = DateTime.Parse(Date_string);
        this.Quantity = Quantity;
    }

}