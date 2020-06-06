using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtilsNET;

namespace _8.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ApiController : Controller
    { 
        private Models.Repository rep;

        public ApiController(Models.Repository rep)
        {
            this.rep = rep;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return new ObjectResult(rep.GetAll());
        }

        [HttpGet]
        [Route("GetOne")]
        public IActionResult GetOne(int id)
        {
            return new ObjectResult(rep.Find(id));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            Data dt = new Data();
            dt.Id = id;
            var found = rep.Find(id);
            rep.Delete(dt);

            return new ObjectResult(found);
        }

        [HttpPost]
        [Route("AddNew")]
        public IActionResult AddNew([FromBody] Data data)
        {
            data.BDate = DateTime.Now;
            return new ObjectResult(rep.Insert(data));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Data data)
        {
            data.BDate = DateTime.Now;
            return new ObjectResult(rep.Update(data));
        }
    }
}