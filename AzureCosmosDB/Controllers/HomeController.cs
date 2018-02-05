using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using AzureCosmosDB.Models;
using Microsoft.Azure.Documents.Linq;

namespace AzureCosmosDB.Controllers
{
    public class HomeController : Controller
    {
        private const string EndpointUrl = @"https://testcosmosdbazure.documents.azure.com:443/";
        private const string PrimaryKey = @"jXfystFixvH5YNRZxkBi4M2uW07moYNIQ9Mda9jku8d30z8511Flq90p20DOqkO9IYi8ns5wdOoxdk1ZxrPkzg==";
        private DocumentClient client;

        public ActionResult Index()
        {
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
            IQueryable<Helloworld> dataQuery = client.CreateDocumentQuery<Helloworld>(
                                               UriFactory.CreateDocumentCollectionUri(
                                               "testDB1", "helloworld1"), queryOptions);
            string value = "";
            foreach (var x in dataQuery)
            {
                value = x.Message;
                break;

            }
            ViewBag.Helloworld = value;




            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}