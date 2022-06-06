namespace ASP_Project.Entities
{
    public class RestaurantPartnership
    {
        public string RestaurantId { get; set; }     // the entity framework knows to identify ID as primary key, in this situation, we need a key from 2 IDs 
        public string PartnershipId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Partnership Partnership { get; set; }
    }
}
