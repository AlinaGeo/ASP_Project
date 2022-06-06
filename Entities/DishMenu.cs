namespace ASP_Project.Entities
{
    public class DishMenu
    {
        public string DishId { get; set; }
        public string MenuId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
