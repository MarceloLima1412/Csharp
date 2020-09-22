using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDatabaseAPI.Models
{
    public class Alerta
    {
        public int SensorId { get; set; }
        public int TemperatureAlert { get; set; }
        public int HumidityAlert { get; set; }

    }
}