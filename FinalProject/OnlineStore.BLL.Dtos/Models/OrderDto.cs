namespace OnlineStore.BLL.Dtos.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public System.DateTime Date { get; set; }

    }
}
