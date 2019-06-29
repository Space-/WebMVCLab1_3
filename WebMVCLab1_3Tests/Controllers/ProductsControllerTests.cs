using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPILab1_3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WebAPILab1_3.Models;

namespace WebAPILab1_3.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void GetProductsByIdTest()
        {
            // replace your URI
            //            var client = new RestClient("http://localhost:65411/api/products/1");
            //            var request = new RestRequest(Method.GET);
            //            request.AddHeader("postman-token", "350c30d9-33dc-2a75-e6ca-824fecdd599d");
            //            request.AddHeader("cache-control", "no-cache");
            //            IRestResponse response = client.Execute(request);
        }

        [TestMethod()]
        public void GetProductsByIdTestCase2()
        {
            //            // arrange
            //            var expected = 1;
            //
            //            var client = new RestClient("http://localhost:65411/api/products/1");
            //            var request = new RestRequest(Method.GET);
            //            request.AddHeader("postman-token", "350c30d9-33dc-2a75-e6ca-824fecdd599d");
            //            request.AddHeader("cache-control", "no-cache");
            //
            //            // act
            //            // Execute<T> 執自動進行反序列化
            //            var response = client.Execute<Product>(request);
            //            // assert
            //            //            response.Data. < --自己點點看，強型別才有辦法驗證
            //            Assert.AreEqual(expected, response.Data.ProductID);
        }

        public void GetProductsByIdTestCase_MyCase()
        {
            var client = new RestClient("http://localhost:65411/api/Products");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("content-length", "87");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "localhost:65411");
            request.AddHeader("Postman-Token", "22fb5a4c-da97-431b-a3b0-66acc7f67d58,8dbe5b57-3d20-4edb-9b93-fa32e23d0283");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"ProductID\": 7,\n\t\"ProductName\": \"Bruce\",\n    \"SupplierID\": 5,\n    \"UnitPrice\": 100\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}