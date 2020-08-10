using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Contracts;
using OnlineStore.Common;
using System;
using System.Web.Mvc;

namespace OnlineStore.WebPLL.Controllers
{
    public class ProductAtOrderController : Controller
    {
        private readonly IProductAtOrderService _productAtOrderService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public ProductAtOrderController(IProductAtOrderService p, ICustomerService c,
            IOrderService o)
        {
            _productAtOrderService = p;
            _customerService = c;
            _orderService = o;
        }

        [Authorize]
        public ActionResult Create(int productId, int count, string returnUrl)
        {
                var user = _customerService.GetByAuthId(User.Identity.GetUserId());
                var order = _orderService.GetCustomerCart(user.Id);

                if(order == null)
                {
                    _orderService.Create(new BLL.Dtos.Models.OrderDto
                    {
                      Date = DateTime.Now,
                      Status = OrderStatus.Cart.ToString(),
                      CustomerId = user.Id
                    });

                    order = _orderService.GetCustomerCart(user.Id);
                }

                    var productAtOrder = _productAtOrderService.GetByProductAndOrder(productId, order.Id);
                    
                    if (productAtOrder != null)
                    {
                        productAtOrder.Count += count;
                        _productAtOrderService.Update(productAtOrder);
                    }
                    else
                    {
                        _productAtOrderService.Create(new BLL.Dtos.Models.ProductAtOrderDto
                        {
                            OrderId = order.Id,
                            Count = count,
                            ProductId = productId
                        });
                    }

                return RedirectToAction("Details", "Order", new { id = order.Id, returnUrl });
        }
    }
}