using CarShop.DataAccess.Data;
using CarShop.DataAccess.Repository.IRepository;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.Make = product.Make;
                objFromDb.Model = product.Model;
                objFromDb.Price = product.Price;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Description = product.Description;
                objFromDb.BodyType = product.BodyType;
                objFromDb.FirstRegistration = product.FirstRegistration;
                objFromDb.VehicleTypeId = product.VehicleTypeId;
                objFromDb.Gear = product.Gear;
                objFromDb.FuelTypeId = product.FuelTypeId;
                
            }
        }
    }
}
