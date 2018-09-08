using System.Collections.Generic;
using System.Linq;

namespace HPNC_Website.Models
{
    public class NavigationListItem
    {
        public string Text { get; set; }
        public NavigationLink Link { get; set; }
        public List<NavigationListItem> Items { get; set; }
        public bool HasChildren { get { return Items != null && Items.Any() && Items.Count > 0; } }

        public NavigationListItem()
        { }

        public NavigationListItem(NavigationLink link)
        {
            Link = link;
        }

        public NavigationListItem(string text)
        {
            Text = text;
        }
    }
}