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

        [Route("getlist")]
        public List<Employee> Get()
        {
            return command.ViewList();
        }

        [Route("getlist/{id}")]
        public Employee Get(int id)
        {
            return command.ViewEmployee(id);
        }
    }
}
