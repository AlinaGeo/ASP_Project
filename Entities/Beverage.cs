using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Beverage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RestaurantId { get; set; }        // a beverage can be owned by a single restaurant

        public virtual Menu Menu { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<DishMenu> DishMenus { get; set; }
    }
}
