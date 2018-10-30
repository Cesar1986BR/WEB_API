using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DevSore.Domain;
using DevStore.Infra.DataContext;

namespace DevStore.Api.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ProductController : ApiController
    {
        private DevStoreDataContext db = new DevStoreDataContext();

        [Route("products")]
        public  HttpResponseMessage GetProducts()
        {
            var result = db.Product.Include("Category").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var result = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByategories(int categoryId)
        {
            var result = db.Product.Include("Category").Where(x=> x.CateogoryId == categoryId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);    
        }

    }
}