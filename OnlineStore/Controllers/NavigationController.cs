using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStoreRepository;

namespace OnlineStore.Controllers
{
    public class NavigationController : Controller
    {
        private ITypesRepository _repository;

        public NavigationController(ITypesRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repository.GetAll().ToArray()
                .Select(type => type.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }

    }
}