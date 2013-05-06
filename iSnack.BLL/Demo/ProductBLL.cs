using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSnack.BLL.Interface.Demo;
using iSnack.Service.Data.Demo;
using iSnack.Common.Attribute;
using iSnack.BLL.Exception;

namespace iSnack.BLL.Demo
{
    public class ProductBLL : BaseBLL, IProductBLL
    {
        private IList<ProductEntity> dataStore = new List<ProductEntity>()
                                                {
                                                    new ProductEntity() { ID = Guid.NewGuid(), Name = "XBOX360二代", Category = "游戏机", Price = 3699.9M},
                                                    new ProductEntity() { ID = Guid.NewGuid(), Name = "蓝光无线游戏鼠标", Category = "电脑配件", Price = 29M },
                                                    new ProductEntity() { ID = Guid.NewGuid(), Name = "HD视网膜高清摄像头", Category="电脑配件", Price=689M }
                                                };

        public IList<ProductEntity> GetByCategory(string strCategory)
        {
            var result = from p in dataStore
                         where p.Category.Contains(strCategory)
                         select p;
            return result.ToList();
        }

        public IList<ProductEntity> GetAll()
        {
            return dataStore;
        }

        [Log(LogLevel.Debug)]
        [Exception(BLLException.B200002)]
        public ProductEntity GetByID(Guid id)
        {
            return dataStore.Single(entity => entity.ID == id);
        }

        [Log(LogLevel.Debug)]
        public bool Update(ProductEntity entity)
        {
            var product = GetByID(entity.ID);
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Category = entity.Category;
            product.Remark = entity.Remark;

            return true;
        }

        [Log(LogLevel.Debug)]
        public bool Create(ProductEntity entity)
        {
            entity.ID = Guid.NewGuid();
            dataStore.Add(entity);

            return true;
        }

        [Log(LogLevel.Debug)]
        public bool Delete(Guid id)
        {
            var entity = GetByID(id);
            dataStore.Remove(entity);

            return true;
        }
    }
}
