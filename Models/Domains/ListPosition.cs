using System;
using System.Collections.Generic;

namespace ShoppingList.WebApi.Models.Domains
{
    public partial class ListPosition
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public bool IsBuyed { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }

        public virtual Products Product { get; set; }
        public virtual ShoppingLists ShoppingList { get; set; }
    }
}
