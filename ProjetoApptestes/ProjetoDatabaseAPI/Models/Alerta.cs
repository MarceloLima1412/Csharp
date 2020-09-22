using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDatabaseAPI.Models
{
 //   [BasicAuthentication]
    public class Alerta
    {
        public int id { get; set; }
        public float temperature { get; set; }
        public float humidity { get; set; }
        public int timestamp { get; set; }
        public char signal { get; set; }
        public int value { get; set; }

    }
}