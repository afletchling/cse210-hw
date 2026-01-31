public class Order
{
    private Customer _customer;
    private List<Product> _products = [];

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        List<string> packingList = [];

        _products.ForEach((Product product) =>
        {
            packingList.Add(product.GetPackingLabel());
        });

        return string.Join('\n', packingList);
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }

    public double GetTotal()
    {
        double total = _customer.IsInUSA() ? 5 : 35;

        _products.ForEach((Product product) =>
        {
            total += product.ComputePrice();
        });

        return total;
    }
}