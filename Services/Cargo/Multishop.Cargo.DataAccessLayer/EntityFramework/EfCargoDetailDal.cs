using Multishop.Cargo.DataAccessLayer.Abstract;
using Multishop.Cargo.DataAccessLayer.Concrete;
using Multishop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoDetailDal:GenericRepository<CargoDetail>,ICargoDetailDal
	{
		public EfCargoDetailDal(CargoContext context):base(context)
		{

		}
	}
}
