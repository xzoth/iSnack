using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iSnack.Web.API.Models;
using iSnack.Web.API.Attribute;
using EmitMapper;
using iSnack.Web.API.iSnackServiceReference;

namespace iSnack.Web.API.Controllers
{
    //[HTTPBasicAuthorizeAttribute]
    public class ProductController : ApiController
    {
        // GET api/product        
        public IList<Product> Get()
        {
            ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
            var productList = productService.GetAll();
            var result = ObjectMapperManager.DefaultInstance.GetMapper<List<ProductEntity>, List<Product>>().Map(productList);
            return result;
        }

        [NonAction]
        public IList<Product> GetAll()
        {
            ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
            var productList = productService.GetAll();
            var result = ObjectMapperManager.DefaultInstance.GetMapper<List<ProductEntity>, List<Product>>().Map(productList);

            return result;
        }

        // GET api/product/5
        public Product Get([FromUri]Guid id)
        {
            ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();

            ProductEntity product = productService.GetByID(id);
            var result = ObjectMapperManager.DefaultInstance.GetMapper<ProductEntity, Product>().Map(product);

            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return result;
        }

        [HttpGet]
        public IEnumerable<Product> GetProductByCategory([FromUri]string category)
        {
            ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
            var productList = productService.GetByCategory(category);
            var result = ObjectMapperManager.DefaultInstance.GetMapper<List<ProductEntity>, List<Product>>().Map(productList);

            return result;
        }

        // POST api/product
        public HttpResponseMessage Post(Product item)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

            if (item != null && ModelState.IsValid)
            {
                ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
                var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Product, ProductEntity>();
                var product = mapper.Map(item);
                bool isSucc = productService.Create(product);

                if (isSucc)
                {
                    //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, item);
                    //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.ID }));
                    response = Request.CreateResponse(HttpStatusCode.Created, new { success = true });
                }
            }

            return response;
        }

        // PUT api/product/5
        public HttpResponseMessage Put([FromUri]Guid id, Product product)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            if (product == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                if (ModelState.IsValid && id == product.ID)
                {
                    ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
                    var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Product, ProductEntity>();
                    var newProduct = mapper.Map(product);
                    bool isSucc = productService.Update(newProduct);
                    if (isSucc)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, product);
                    }
                }
            }

            return response;
        }

        // DELETE api/product/5
        public HttpResponseMessage Delete([FromUri]Guid id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);

            ProductServiceClient productService = new iSnackServiceReference.ProductServiceClient();
            ProductEntity product = productService.GetByID(id);
            if (product == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                bool isSucc = productService.Delete(id);
                if (isSucc)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, product);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}
