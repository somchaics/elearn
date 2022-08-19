
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
//using System.Data.SqlClient; //sqlserver
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using reg.Models;

namespace reg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _iconfiguration;
        public UserController(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }

        // GET
        [HttpGet("{apikey}")]
        public JsonResult Get(string apikey) //all
        {
            if (apikey!=keyval.value) return new JsonResult("ApiKey InValid.");
           
            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = @"SELECT * From user";
            MySqlDataReader myReader;
            DataTable tb = new DataTable();

            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myReader = myCommand.ExecuteReader();
                    tb.Load(myReader);
                    myReader.Close();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult(tb);
        }

        // GET
        [HttpGet("{apikey}/{email}")]
        public JsonResult Get(string apikey, string email)
        {
            if (apikey != keyval.value) return new JsonResult("ApiKey InValid.");

            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = @"SELECT * From user where email = " + email;
            MySqlDataReader myReader;
            DataTable tb = new DataTable();

            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myReader = myCommand.ExecuteReader();
                    tb.Load(myReader);
                    myReader.Close();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult(tb);
        }

        // GET 
        [HttpGet("{apikey}/{idcard}/{id}")]
        public JsonResult Get(string apikey, string idcard, int id)
        {
            if (apikey != keyval.value) return new JsonResult("ApiKey InValid.");

            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = @"SELECT * From user where idcard = " + idcard;
            MySqlDataReader myReader;
            DataTable tb = new DataTable();

            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myReader = myCommand.ExecuteReader();
                    tb.Load(myReader);
                    myReader.Close();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult(tb);
        }

        // GET 
        [HttpGet("{apikey}/{name}/{id1}/{id2}")]
        public JsonResult Get(string apikey, string name, int id1, int id2)
        {
            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = @"SELECT  * From user where name = " + name;
            MySqlDataReader myReader;
            DataTable tb = new DataTable();

            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myReader = myCommand.ExecuteReader();
                    tb.Load(myReader);
                    myReader.Close();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult(tb);
        }

        // POST api/<UserController>
        [HttpPost("{apikey}")]
        public JsonResult Addnew(string apikey, [FromBody] User user)
        {
            if (apikey != keyval.value) return new JsonResult("ApiKey InValid.");

            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
           
            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = "INSERT INTO User (email, name, phone, idcard, lineid, status, psw) VALUES('" +
                        user.email + "','" +
                        user.name + "','" +
                        user.phone + "','" +
                        user.idcard + "','" +
                        user.lineid + "','" +
                        user.status + "','" +
                        user.psw + "')"; 
                      
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult("Add  User Success.");
        }
    

        // PUT api/<UserController>/5
        [HttpPut("{apikey}/{id}")]
        public JsonResult Update(string apikey, string id, [FromBody] User user)
        {
            if (apikey != keyval.value) return new JsonResult("ApiKey InValid.");

            var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
       
            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = "UPDATE User SET name = '" + user.email +
                            "', phone= '"+ user.phone +
                           "', idcard= '" + user.idcard+
                            "', lineid= '" + user.lineid +
                            "', status= '" + user.status + 
                            "', psw= '" + user.psw + 
                            "' WHERE email = '" + user.email + "'";
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult("Update Success");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{apikey}/{id}")]
        public JsonResult Delete(string apikey, string id)
        {
            if (apikey != keyval.value) return new JsonResult("ApiKey InValid.");

            MySqlConnection conn;
            string ConnectionString = _iconfiguration.GetConnectionString("regappcon");

            string query = "DELETE FROM User WHERE email = '" + id + "'";
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, conn))
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                return new JsonResult(ex.Message);
            }
            return new JsonResult("Delete Success");
        }
              

    }
}
