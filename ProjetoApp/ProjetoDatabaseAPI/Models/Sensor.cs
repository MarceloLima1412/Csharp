using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDatabaseAPI.Models
{
    public class Sensor
    {
        public int id { get; set; }
        public float temperature { get; set; }
        public float humidity { get; set; }
        public int battery { get; set; }
        public int timestamp { get; set; }
    }
}