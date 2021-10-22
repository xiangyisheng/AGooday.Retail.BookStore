using AGooday.Retail.BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGooday.Retail.BookStore.Customers
{
    public class Customer : BaseAggregateRoot
    {
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
