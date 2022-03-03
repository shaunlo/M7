using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M7.Models
{
    public interface IShoppingRepository
    {
        IQueryable<Shopping> Shoppings { get; }
        void SaveShopping(Shopping shopping);
    }
}
