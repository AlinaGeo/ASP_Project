namespace ASP_Project.Entities
{
    public class Location
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }      // won't appear in the db, it is just for our eyes, to make relations between the tables
    }
}
