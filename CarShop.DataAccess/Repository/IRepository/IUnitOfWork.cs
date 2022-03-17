using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleTypeRepository VehicleType { get; }
        IFuelTypeRepository FuelType { get; }
        IProductRepository Product { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
