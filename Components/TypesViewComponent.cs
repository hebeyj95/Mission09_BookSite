using BookSite2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSite2._0.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookSiteRepository repo { get; set; }

        public TypesViewComponent (IBookSiteRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }

    }
}
