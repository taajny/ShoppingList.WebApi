using System;
using System.Collections.Generic;

namespace ShoppingList.WebApi.Models.Domains
{
    public partial class ShoppingLists
    {
        public ShoppingLists()
        {
            ListPosition = new HashSet<ListPosition>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<ListPosition> ListPosition { get; set; }
    }
}
