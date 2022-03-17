using CarShop.DataAccess.Data;
using CarShop.DataAccess.Repository.IRepository;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            VehicleType = new VehicleTypeRepository(_db);
            FuelType = new FuelTypeRepository(_db);
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IVehicleTypeRepository VehicleType { get; private set; }
        public IFuelTypeRepository FuelType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
