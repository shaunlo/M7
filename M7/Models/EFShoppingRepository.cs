using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M7.Models
{
    public class EFShoppingRepository : IShoppingRepository
    {
        private BookstoreContext context;
        public EFShoppingRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Shopping> Shoppings => context.Shoppings
            .Include(x => x.Lines).ThenInclude(x => x.Book);
        public void SaveShopping(Shopping shopping)
        {
            context.AttachRange(shopping.Lines.Select(x => x.Book));
            
            if (shopping.ShoppingId == 0)
            {
                context.Shoppings.Add(shopping);
            }
            context.SaveChanges();
        }
    }
}
