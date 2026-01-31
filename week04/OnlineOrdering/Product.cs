public class Product
{
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public double ComputePrice()
    {
        return Math.Round(_price * _quantity * 100) / 100;
    }

    public string GetPackingLabel()
    {
        return $"{_name} - {_id} - ${_price}: {_quantity}x";
    }
}