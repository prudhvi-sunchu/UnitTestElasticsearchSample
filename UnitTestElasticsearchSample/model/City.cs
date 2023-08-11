using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestElasticsearchSample.model
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Population { get; set; }

        public City(int id, string name, string state, string country, string population)
        {
            ID = id;
            Name = name;
            State = state;
            Country = country;
            population = Population;
        }
    }
}
