using ASP_Project.Entities;
using System.Linq;

namespace ASP_Project.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        private ASP_ProjectContext db;
        public BeverageRepository(ASP_ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Beverage> GetBeveragesIQueryable()
        {
            var beverages = db.Beverages
                .OrderBy(x => x.Id);

            return beverages;
        }

        public void Create(Beverage beverage)
        {
            db.Beverages.Add(beverage);

            db.SaveChanges();
        }

        public void Update(Beverage beverage)
        {
            db.Beverages.Update(beverage);

            db.SaveChanges();
        }

        public void Delete(Beverage beverage)
        {
            db.Beverages.Remove(beverage);

            db.SaveChanges();
        }
    }
}
