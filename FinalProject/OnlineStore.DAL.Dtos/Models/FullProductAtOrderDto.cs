namespace OnlineStore.DAL.Dtos.Models
{
    public class FullProductAtOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
