using CarShop.DataAccess.Data;
using CarShop.DataAccess.Repository.IRepository;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.DataAccess.Repository
{
    public class FuelTypeRepository : Repository<FuelType>, IFuelTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FuelTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FuelType fuelType)
        {
            var objFromDb = _db.FuelTypes.FirstOrDefault(s => s.Id == fuelType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = fuelType.Name;

            }
        }
    }
}
