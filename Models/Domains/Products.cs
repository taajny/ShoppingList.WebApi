using System;
using System.Collections.Generic;

namespace ShoppingList.WebApi.Models.Domains
{
    public partial class Products
    {
        public Products()
        {
            ListPosition = new HashSet<ListPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<ListPosition> ListPosition { get; set; }
    }
}
