using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSnack.Service.Interface.Demo;
using iSnack.Service.Data.Demo;
using iSnack.BLL.Interface.Demo;

namespace iSnack.Service.Demo
{
    public class ProductService : IProductService
    {
        public IList<ProductEntity> GetByCategory(string strCategory)
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.GetByCategory(strCategory);
        }

        public IList<ProductEntity> GetAll()
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.GetAll();
        }

        public ProductEntity GetByID(Guid id)
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.GetByID(id);
        }

        public bool Update(ProductEntity entity)
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.Update(entity);
        }

        public bool Create(ProductEntity entity)
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.Create(entity);
        }

        public bool Delete(Guid id)
        {
            var bll = BLLFactory.GetBLLByType<IProductBLL>();
            return bll.Delete(id);
        }
    }
}
