using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarMall.Models
{

    public class Tweets
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
    public class NavigationLinkInfo
        {
            public string Text { get; set; }
            public string Url { get; set; }
            public bool NewWindow { get; set; }
            public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Name { get; set; }
        public string Title { get; set; }

            public NavigationLinkInfo() { }

            public NavigationLinkInfo(string url = null , string text = null , bool  newwindow = false, string title = null)
            {
                Text = text;
                Url = url;
                NewWindow = newwindow;
                Title = title;

            }

         



        }

        public class NavigationList
        {
            public string Text { get; set; }
            public NavigationLinkInfo Link { get; set; }
            public List<NavigationList> NavItems { get; set; }
            public bool HasSubNavigation { get { return NavItems != null && NavItems.Any() && NavItems.Count > 0; } }

            public NavigationList() { }

            public NavigationList(NavigationLinkInfo link) { Link = link; }

        }



    
}