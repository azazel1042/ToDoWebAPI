using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //Dependency injection işlemi?
        private readonly IConfiguration _configuration;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IConfiguration configuration,ILogger<DepartmentController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        //public DepartmentController(ILogger<DepartmentController> logger)
        //{
        //    _logger = logger;
        //}

        //entity framework ile vt den veri çekilmesi
        [HttpGet]//get isteği ile tüm verilerin dönderilmesi.
        public JsonResult Get()
        {
            
            string query = @"select DepartmentId,DepartmentName from Department";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DepartmentAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            
            _logger.LogInformation("<<Get requesti gönderildi>>");
            return new JsonResult(table);
        }

        [HttpGet("{id}")]//id ile get isteği uygulanması.
        public JsonResult Get(int id)
        {
            string query = @"select DepartmentId,DepartmentName from Department where DepartmentId=@DepartmentId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DepartmentAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            _logger.LogInformation(table.ToString()+" " +id+ " <<id ile get requesti gönderildi>>");
            return new JsonResult(table);
        }

        [HttpPost]//ekleme metodu.
        public JsonResult Post(Department dep)
        {
            string query = @"insert into Department (DepartmentName) values (@DepartmentName)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DepartmentAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            _logger.LogInformation(dep.DepartmentId+" "+dep.DepartmentName + " <<post requesti gönderildi>>");

            return new JsonResult("Added Successfully");
        }

        [HttpPut]//güncelleme metodu
        public JsonResult Put(Department dep)
        {
            string query = @"
            update Department set
            DepartmentName=@DepartmentName
            where DepartmentId=@DepartmentId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DepartmentAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            _logger.LogInformation(dep.DepartmentId+" "+dep.DepartmentName + " <<put requesti gönderildi>>");

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]//id ile delete metodu
        public JsonResult Delete(int id)
        {
            string query = @"
            delete from Department where DepartmentId=@DepartmentId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DepartmentAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            _logger.LogInformation(table.ToString() + " " + id + " <<id ile delete requesti gönderildi>>");

            return new JsonResult("Deleted Successfully");
        }
        }
}
