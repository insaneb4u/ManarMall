using Examine;
using Examine.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class SearchPageController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult searchdata(RenderModel model, string searchTerm)
        {
             searchTerm = "din";
            var searcher = ExamineManager.Instance.SearchProviderCollection["ContactsSearcher"];

            if (searcher == null)
                return null;

            var searchCriteria = searcher.CreateSearchCriteria(BooleanOperation.Or);

            ISearchCriteria query = searchCriteria.RawQuery(searchTerm);
            IOrderedEnumerable<SearchResult> searchResults = searcher.Search(query).OrderByDescending(x => x.Score);

            return View(searchResults);
        }
    }
}