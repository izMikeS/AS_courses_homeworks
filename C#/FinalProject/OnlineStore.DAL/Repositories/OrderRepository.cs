using OnlineStore.Common;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DAL.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(OrderDto entity)
        {
                Context.Orders.Add(entity.ToEntityModel());
                Context.SaveChanges();
        }

        public void Delete(int id)
        {
                Context.Orders.Remove(Context.Orders.Single(e => e.Id == id));
                Context.SaveChanges();
        }

        public List<OrderDto> GetAll(int skip, int take)
        {
                return Context.Orders
                    .OrderBy(p => p.Date)
                    .Skip(skip).Take(take)
                    .ToList().Select(c => c.ToDataDto())
                    .ToList();
        }

        public OrderDto GetById(int id)
        {
                return Context.Orders.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(OrderDto entity)
        {
                var order = Context.Orders.Single(c => c.Id == entity.Id);

                order.CustomerId = entity.CustomerId;
                order.Date = entity.Date;
                order.Status = entity.Status;

                Context.SaveChanges();
        }

        public OrderDto GetCustomerCart(int customerId)
        {
            return Context.Orders.FirstOrDefault(o => o.CustomerId == customerId &&
                                                o.Status == OrderStatus.Cart.ToString())?.ToDataDto();
        }

        public List<OrderDto> GetAllByStatus(OrderStatus status, int skip, int take)
        {
            return Context.Orders.Where(o => o.Status == status.ToString())
                .OrderBy(p => p.Date)
                .Skip(skip).Take(take)
                .ToList().Select(c => c.ToDataDto())
                .ToList();
        }

        public List<OrderDto> GetByCustomer(int customerId, int skip, int take)
        {
            return Context.Orders.Where(o => o.CustomerId == customerId)
                .OrderBy(p => p.Date)
                .Skip(skip).Take(take)
                .ToList().Select(c => c.ToDataDto())
                .ToList();
        }

        public List<OrderDto> GetByCustomerAndStatus(OrderStatus status, int customerId, int skip, int take)
        {
            return Context.Orders.Where(o => o.Status == status.ToString()
                                        && o.CustomerId == customerId)
                           .OrderBy(p => p.Date)
                           .Skip(skip).Take(take)
                           .ToList().Select(c => c.ToDataDto())
                           .ToList();
        }
    }
}
