using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSite2._0.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void savePurchase(Purchase p)
        {
            context.AttachRange(p.Lines.Select(x => x.Book));

            if(p.PurchaseId == 0)
            {
                context.Purchases.Add(p);
            }

            context.SaveChanges();
        }
    }
}
