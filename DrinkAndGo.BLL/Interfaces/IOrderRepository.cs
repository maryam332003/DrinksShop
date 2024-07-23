using DrinkAndGo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkAndGo.BLL.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

    }

}
