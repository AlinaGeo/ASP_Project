using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BeverageId { get; set; }

        public virtual Beverage Beverages { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<DishMenu> DishMenus { get; set; }
    }
}
