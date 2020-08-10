using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.Common;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRep;

        public OrderService(IOrderRepository o)
        {
            _orderRep = o;
        }

        public void Create(OrderDto entity)
        {
            _orderRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _orderRep.Delete(id);
        }

        public OrderDto GetById(int id)
        {
            return _orderRep.GetById(id).ToDto();
        }

        public void Update(OrderDto entity)
        {
            _orderRep.Update(entity.ToDataDto());
        }

        public List<OrderDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _orderRep.GetAll(skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public OrderDto GetCustomerCart(int customerId)
        {
            return _orderRep.GetCustomerCart(customerId)?.ToDto();
        }

        public List<OrderDto> GetAllByStatus(OrderStatus status, int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _orderRep.GetAllByStatus(status, skipTake.skip, skipTake.take).Select(o => o.ToDto()).ToList();
        }

        public List<OrderDto> GetAllByStatusAndCustomer(OrderStatus? status = null, int? customerId = null,
            int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            List<OrderDto> outputList;

            if (!status.HasValue && !customerId.HasValue)
            {
                outputList =  _orderRep.GetAll(skipTake.skip, skipTake.take)
                    .Select(p => p.ToDto()).ToList();
            }
            else if(status.HasValue && !customerId.HasValue)
            {
                outputList = _orderRep.GetAllByStatus(status.Value,
                    skipTake.skip, skipTake.take)
                    .Select(o => o.ToDto()).ToList();
            }
            else if(!status.HasValue && customerId.HasValue)
            {
                outputList = _orderRep.GetByCustomer(customerId.Value,
                    skipTake.skip, skipTake.take)
                                        .Select(o => o.ToDto()).ToList();
            }
            else
            {
                outputList = _orderRep.GetByCustomerAndStatus(status.Value,
                    customerId.Value, skipTake.skip, skipTake.take)
                                        .Select(o => o.ToDto()).ToList();
            }

            return outputList;
        }
    }
}
