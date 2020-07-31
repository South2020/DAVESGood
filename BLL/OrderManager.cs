using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderManager : BaseBLL<Order>
    {
        public OrderManager() : base(new OrderService())
        {

        }
    }
}
