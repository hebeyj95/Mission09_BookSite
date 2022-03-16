using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSite2._0.Infrastructure;
using BookSite2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSite2._0.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookSiteRepository repo { get; set; }
        public PurchaseModel (IBookSiteRepository temp, Basket b)
        {
            repo = temp;

            basket = b;
        }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

    }
}
