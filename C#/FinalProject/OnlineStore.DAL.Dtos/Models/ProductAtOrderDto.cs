﻿namespace OnlineStore.DAL.Dtos.Models
{
    public class ProductAtOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
