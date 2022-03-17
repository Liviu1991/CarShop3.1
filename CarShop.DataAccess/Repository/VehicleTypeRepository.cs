using CarShop.DataAccess.Data;
using CarShop.DataAccess.Repository.IRepository;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.DataAccess.Repository
{
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public VehicleTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(VehicleType vehicleType)
        {
            var objFromDb = _db.VehicleTypes.FirstOrDefault(s => s.Id == vehicleType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = vehicleType.Name;
               
            }
        }
    }
}
