using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using ProjetoDatabaseAPI.Models;

namespace ProjetoDatabaseAPI.Controllers
{
    [BasicAuthentication]
    public class DatabaseController : ApiController
    {
        static string connectionString = Properties.Settings.Default.ConnectionString;

        [Route("api/sensor/{id:int}")]
        public IEnumerable<Sensor> GetSensorById(long id)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Sensor WHERE Id=@id", conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sensor sensor = new Sensor
                    {

                        id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                        temperature = (reader["Temperature"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Temperature"]),
                        humidity = (reader["Humidity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Humidity"]),
                        battery = (reader["Battery"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Battery"]),
                        timestamp = (reader["Timestamp"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Timestamp"])
                    };
                    sensors.Add(sensor);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return sensors;
        }

        [Route("api/sensor")]
        public IEnumerable<Sensor> GetSensor()
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Sensor ORDER BY id", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sensor sensor = new Sensor {

                        id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]),
                        temperature = (reader["Temperature"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Temperature"]),
                        humidity = (reader["Humidity"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Humidity"]),
                        battery = (reader["Battery"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Battery"]),
                        timestamp = (reader["Timestamp"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Timestamp"])
                    };
                    sensors.Add(sensor);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return sensors;
        }
    

        [Route("api/alert")]
        public IHttpActionResult GetAlerta()
        {
            Alerta alerta = new Alerta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT * FROM Alerta";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        alerta.SensorId = (int)reader["Sensorid"];
                        alerta.TemperatureAlert = (int)reader["TemperatureAlert"];
                        alerta.HumidityAlert = (int)reader["HumidityAlerta"];
                    }
                    reader.Close();
                    conn.Close();

                    if (alerta != null)
                    {
                        return Ok(alerta);
                    }
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [Route("api/sensor/insert")]
        public IHttpActionResult PostSensor(Sensor sensor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Sensor(Id,Temperature,Humidity,Battery,Timestamp) values(@id,@temperature,@humidity,@battery,@timestamp);");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", (int)sensor.id);
                cmd.Parameters.AddWithValue("@temperature", (float)sensor.temperature);
                cmd.Parameters.AddWithValue("@humidity", (float)sensor.humidity);
                cmd.Parameters.AddWithValue("@battery", (int)sensor.battery);
                cmd.Parameters.AddWithValue("@timestamp", (int)sensor.timestamp);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result == 0)
                  {
                     return NotFound();
                  }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("api/sensor/update/{id}/{timestamp}")]
        public IHttpActionResult PutSensor(Sensor sensor, int id, float timestamp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Sensor SET  Id = @id, Temperature = @temperature, Humidity = @humidity, Battery = @battery, Timestamp = @timestamp WHERE Id = @idreceive AND Timestamp = @timestampreceive;");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", (int)sensor.id);
                cmd.Parameters.AddWithValue("@temperature", (float)sensor.temperature);
                cmd.Parameters.AddWithValue("@humidity", (float)sensor.humidity);
                cmd.Parameters.AddWithValue("@battery", (int)sensor.battery);
                cmd.Parameters.AddWithValue("@timestamp", (int)sensor.timestamp);
                cmd.Parameters.AddWithValue("@idreceive", id);
                cmd.Parameters.AddWithValue("@timestampreceive", timestamp);
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result == 0)
                  {
                     return NotFound();
                  }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("api/sensor/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sensor WHERE Id=@id", conn);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@id", id);
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result == 0)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
