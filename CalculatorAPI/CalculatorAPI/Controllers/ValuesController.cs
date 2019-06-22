using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalculatorAPI.Models;
using System.Xml.Serialization;

namespace CalculatorAPI.Controllers
{
    public class ValuesController : ApiController
    {
        CalculatorManager manager = new CalculatorManager();


        [Route("{controler}")]
        [HttpPost]
        public IHttpActionResult Post([FromUri]string Name, [FromUri]int Number1, [FromUri]int Number2)
        {
            Models.Action a = new Models.Action(Name, Number1, Number2);
            if (manager.WriteAction(a) != 0)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("{controler}")]
        public Models.Action Get([FromUri]int id)
        {
            return manager.GetActionById(id);
        }

        [HttpGet]
        [Route("{controler}")]
        public List<Models.Action> Get()
        {
            return manager.GetActions();
        }


        [Route("{controler}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if (manager.DeleteAction(id) != 0)
                return Ok();
            return BadRequest("Gone");
        }




        [HttpGet]
        [Route("{controler}/{id}")]
        public Models.Action GetByIdRequest(int id)
        {
            return manager.GetActionById(id);
        }

        [Route("{controler}/{Name}/{Number1}/{Number2}")]
        [HttpPost]
        public IHttpActionResult PostByRequest(string Name, int Number1, int Number2)
        {
            //http://localhost:55273/api/PostUri/?Id=1&Name=Plus&Number1=1&Number2=2
            Models.Action a = new Models.Action(Name, Number1, Number2);
            if (manager.WriteAction(a) != 0)
                return Ok();
            return BadRequest();
        }

        [Route("{controler}/JSON")]
        [HttpPost]
        public IHttpActionResult PostJSON([FromBody]Models.Action action)
        {
            

            if (manager.WriteAction(action) != 0)
                return Ok();
            return BadRequest();
            
        }
        [Route("{controler}/XML")]
        [HttpPost]
        public void PostXML([FromBody]Models.Action action)
        {
            

        }


        [Route("{controler}/Custom")]
        [HttpGet]
        public string GetHeaders([FromBody]Models.Action action)
        {
            var headers = Request.Headers;
            var header = headers.GetValues("Cache-Control").First();
            return header;
        }

    }
}
