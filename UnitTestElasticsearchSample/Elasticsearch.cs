using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestElasticsearchSample.model;

namespace UnitTestElasticsearchSample
{
    public class Elasticsearch
    {
        ElasticClient client = null;
        public Elasticsearch()
        {
            var uri = new Uri("http://localhost:9200/");
            var settings = new ConnectionSettings(uri);
            client = new ElasticClient(settings);
            settings.DefaultIndex("city");
        }
        public List<City> GetResult()
        {
            var indexExistsResponse = client.Indices.Exists("city");
            if (indexExistsResponse.Exists)
            {
                var response = client.Search<City>(s => s.Index("city"));
                return response.Documents.ToList();
            }
            return null;
        }

        public List<City> GetResult(string condition)
        {
            var indexExistsResponse = client.Indices.Exists("city");
            if (indexExistsResponse.Exists)
            {
                var query = condition;

                var searchResponse = client.Search<City>(s => s
                    .Index("city")
                    .From(0)
                    .Size(10)
                    .Query(qry => qry
                        .Bool(b => b
                            .Must(m => m
                                .QueryString(qs => qs
                                    .DefaultField("_all")
                                    .Query(query))))));

                return searchResponse.Documents.ToList();
            }
            return null;
        }

        public void AddNewIndex(City model)
        {
            client.IndexAsync<City>(model, null);
        }
    }
}