using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookSite2._0.Models
{
    public class EFBookSiteRepository : IBookSiteRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookSiteRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
