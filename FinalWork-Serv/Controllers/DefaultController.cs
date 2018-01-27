using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalWork_Serv.Models;
using System.Data;

namespace FinalWork_Serv.Controllers
{
    public class DefaultController : ApiController
    {
        SQLCommand command = new SQLCommand();

        /// <summary>
        /// Показать всех
        /// </summary>
        [Route("getlist")]
        public List<Employee> Get()
        {
            return command.ViewList();
        }

        /// <summary>
        /// Показать одного работника
        /// </summary>
        [Route("getlist/{id}")]
        public Employee Get(int id)
        {
            return command.ViewEmployee(id);
        }

        /// <summary>
        /// Добавить работника
        /// </summary>
        [Route("add")]
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            command.InsertEmployee(value);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
