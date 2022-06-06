using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Dish
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RestaurantId { get; set; }        // a dish can be owned by a single restaurant

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<DishMenu> DishMenus { get; set; }
    }
}
