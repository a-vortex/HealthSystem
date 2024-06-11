using HealthSystem.Models.User;

public class Bill
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal Value { get; private set; }
    public string? Description { get; private set; }
    public Customer Customer { get; private set; } = new Customer();
    // public PaymentMethod PaymentMethod { get; private set; }

    public Bill()
    {
        Date = DateTime.Now;
        DueDate = DateTime.Now.AddDays(30);
    }
    public Bill(decimal value, string description, Customer customer)
    {
        Value = value;
        Description = description;
        Customer = customer;
        Date = DateTime.Now;
        DueDate = DateTime.Now.AddDays(30);
    }
    
    public void PayBill()
    {
        // PaymentMethod.PayBill(this);
    }
}