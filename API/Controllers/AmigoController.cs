using API.Models;
using API.Service;
using Core.Repository;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;

namespace API.Controllers {

    [Authorize]
    [RoutePrefix("api/amigo")]
    public class AmigoController : ApiController {

        private IAmigo AmigoService = ServiceLocator.GetInstanceOf<AmigoRepository>();

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Register(AmigoBindModel model) {
            var amigo = new AmigoBindModel().CriarAmigo(model);
            var cadastrou = AmigoService.Salvar(amigo);
            if(cadastrou != null) {
                return Ok();
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult FindById(int id) {
            var amigo = AmigoService.Buscar(id);

            return Ok(amigo);
        }
    }
}