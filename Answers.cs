using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Answers
{
    
    public static void Main()
    {
        //Question 1
        int[] arr = { 10, 101, 99, 458, 1001 };
        var result = arr.Where(ele => (ele > 100 && ele < 1000)).Select(ele => Math.Pow(ele, 3));
        // or 
        var res = from ele in arr where (ele > 100 && ele < 1000) select ele * ele * ele;
        Console.WriteLine(string.Join(',', result));
        Console.WriteLine("-----------------------");

        List<Order> OrderList;
        List<Item> ItemList;

        PopulateLists(out OrderList, out ItemList);

        PrintList(OrderList);

        //Question 3
        List<Order> NewOrderList = OrderList.OrderByDescending(ele => ele.Date).ThenByDescending(ele => ele.Quantity).ToList();
        PrintList(NewOrderList);
        Console.WriteLine("-----------------------");


        //Question 4
        List<Order> NewOrderListQuery = (from ele in OrderList orderby ele.Date descending, ele.Quantity descending select ele).ToList();
        PrintList(NewOrderListQuery);
        Console.WriteLine("-----------------------");


        //Question 5/6
        var PriceList = (from order in OrderList
                         join item in ItemList on order.ItemName equals item.Name
                         orderby order.Date.Month, order.Date.Date descending
                         select new { order.ID, order.ItemName, order.Date, TotalPrice = order.Quantity * item.price });

        foreach (var entry in PriceList)
        {
            Console.WriteLine($"{entry.ID}  {entry.ItemName}  {entry.Date} {entry.TotalPrice}");
        }

    }

    private static void PopulateLists(out List<Order> OrderList, out List<Item> ItemList)
    {
        OrderList = new List<Order>();
        ItemList = new List<Item>();
        OrderList.Add(new Order(1, "a", "12/10/22", 40)); ItemList.Add(new Item("a", 5.0));
        OrderList.Add(new Order(2, "b", "13/10/22", 40)); ItemList.Add(new Item("b", 7.5));
        OrderList.Add(new Order(3, "c", "12/10/22", 50)); ItemList.Add(new Item("c", 2.0));
        OrderList.Add(new Order(4, "d", "11/10/22", 70)); ItemList.Add(new Item("d", 10.0));
        OrderList.Add(new Order(5, "e", "12/10/22", 87)); ItemList.Add(new Item("e", 6.0));
        OrderList.Add(new Order(6, "f", "5/9/22", 54)); ItemList.Add(new Item("f", 2.5));
        OrderList.Add(new Order(7, "g", "4/9/22", 44)); ItemList.Add(new Item("g", 3.5));
        OrderList.Add(new Order(8, "h", "10/8/22", 85)); ItemList.Add(new Item("h", 4.5));
    }

    private static void PrintList(List<Order> OrderList)
    {
        foreach (Order item in OrderList)
        {
            Console.WriteLine($"{item.Date}  {item.Quantity}");
        }
    }
}