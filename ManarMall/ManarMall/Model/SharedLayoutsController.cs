using ManarMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace ManarMall.Model
{
    public class SharedLayoutsController : SurfaceController
    {
       public ActionResult RenderHeaderContent()
       {
            //List<NavigationList> nav = GetNavigationModel();
            
            return PartialView("~/Views/Partials/SharedLayouts/HeaderContent.cshtml");
       }

        public ActionResult RenderFooterContent()
        {
            return PartialView("~/Views/Partials/SharedLayouts/FooterContent.cshtml");
        }


        public List<NavigationList> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]);
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List<NavigationList>
            {
        
                new NavigationList(new NavigationLinkInfo(pageInfo.Url ,  pageInfo.Name))
            };
            nav.AddRange(GetSubNavigationList(pageInfo));
            return nav;
        }

        public List<NavigationList> GetSubNavigationList(dynamic page)
        {
            NavigationList nv = new NavigationList();


            List<NavigationList> navList = null;
            var subPages = page.Children.Where("Visible");

            if (subPages != null && subPages.Any() && subPages.Count() > 0)
            {
                navList = new List<NavigationList>();
                foreach (var subPage in subPages)
                {
                    var listItem = new NavigationList(new NavigationLinkInfo(subPage.Url, subPage.Name));
                    {
                        nv.NavItems = GetSubNavigationList(subPage);
                    };

                    navList.Add(listItem);
                }

            }

            return navList;
        }

    }
}