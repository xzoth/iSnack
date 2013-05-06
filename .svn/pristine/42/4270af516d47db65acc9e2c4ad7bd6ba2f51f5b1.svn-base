using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using iSnack.Service.Data.Demo;

namespace iSnack.Service.Interface.Demo
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IList<ProductEntity> GetAll();

        [OperationContract]
        ProductEntity GetByID(Guid id);

        [OperationContract]
        IList<ProductEntity> GetByCategory(string strCategory);

        [OperationContract]
        bool Update(ProductEntity entity);

        [OperationContract]
        bool Create(ProductEntity entity);

        [OperationContract]
        bool Delete(Guid id);
    }
}
