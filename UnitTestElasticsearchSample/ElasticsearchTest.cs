using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestElasticsearchSample
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ElastisearchTest
    {
        [TestMethod]
        public void GetResultTest()
        {
            Elasticsearch objSearch = new Elasticsearch();
            var result = objSearch.GetResult();

            Assert.IsTrue(result.FirstOrDefault<model.City>(x => x.Name == "delhi") != null);
            Assert.IsTrue(result.FirstOrDefault<model.City>(x => x.Name == "mumbai") != null);
            Assert.IsTrue(result.FirstOrDefault<model.City>(x => x.Name == "chenai") != null);
            //Assert.IsTrue(result.FirstOrDefault<model.City>(x => x.Name == "kolkata") != null);
        }

        [TestMethod]
        public void AddNewIndexTest()
        {
            Elasticsearch objSearch = new Elasticsearch();

            objSearch.AddNewIndex(new model.City(1, "delhi", "delhi", "India", "9.879 million"));
            objSearch.AddNewIndex(new model.City(2, "mumbai", "Maharashtra", "India", "11.98 million"));
            objSearch.AddNewIndex(new model.City(3, "chenai", "Tamil Nadu", "India", "4.334 million"));
            objSearch.AddNewIndex(new model.City(4, "kolkata", "W. Bengal", "India", "4.573 million"));
            objSearch.AddNewIndex(new model.City(4, "Banglore", "Karnataka", "India", "4.302 million"));
            objSearch.AddNewIndex(new model.City(4, "Pune", "Maharashtra", "India", "2.538 million"));
        }
    }
}
