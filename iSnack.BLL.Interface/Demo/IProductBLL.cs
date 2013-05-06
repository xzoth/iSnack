using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSnack.Service.Data.Demo;

namespace iSnack.BLL.Interface.Demo
{
    public interface IProductBLL : IBaseBLL
    {
        IList<ProductEntity> GetAll();

        ProductEntity GetByID(Guid id);

        IList<ProductEntity> GetByCategory(string strCategory);

        bool Update(ProductEntity entity);

        bool Create(ProductEntity entity);

        bool Delete(Guid id);
    }
}
