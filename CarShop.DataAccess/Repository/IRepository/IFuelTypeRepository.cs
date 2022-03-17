using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.DataAccess.Repository.IRepository
{
    public interface IFuelTypeRepository : IRepository<FuelType>
    {
        void Update(FuelType fuelType);
    }
}
