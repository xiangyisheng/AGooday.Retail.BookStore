using AGooday.Retail.BookStore.Customers;
using AGooday.Retail.BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGooday.Retail.BookStore.Orders
{
    public class Order : BaseEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public OrderType OrderType { get; set; }
        /// <summary>
        /// 关联客户ID
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// 客户对象
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 订单详情集合
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
