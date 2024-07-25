using Multishop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Concrete
{
	public class CargoOperationManager : ICargoOperationService
	{
		ICargoOperationDal _cargoOperaitonDal;
		public CargoOperationManager(ICargoOperationDal cargoOperaitonDal)
		{
			_cargoOperaitonDal = cargoOperaitonDal;
		}

		public void TDelete(int id)
		{
			_cargoOperaitonDal.Delete(id);
		}

		public List<CargoOperation> TGetAll()
		{
			return _cargoOperaitonDal.GetAll();
		}

		public CargoOperation TGetById(int id)
		{
			return _cargoOperaitonDal.GetById(id);
		}

		public void TInsert(CargoOperation entity)
		{
			_cargoOperaitonDal.Insert(entity);
		}

		public void TUpdate(CargoOperation entity)
		{
			_cargoOperaitonDal.Update(entity);
		}
	}
}
