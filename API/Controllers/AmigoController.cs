using API.Models;
using API.Service;
using Core.Model;
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
        [Route("listar")]
        [HttpGet]
        public IHttpActionResult Listar() {

            var amigos = AmigoService.Listar();
            if(amigos != null) {
                return Ok(amigos);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [Route("registrar")]
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
        [Route("buscar")]
        [HttpGet]
        public IHttpActionResult FindById(int id) {
            var amigo = AmigoService.Buscar(id);

            return Ok(amigo);
        }

        [AllowAnonymous]
        [Route("editar")]
        [HttpPost]
        public IHttpActionResult EditById(int id, AmigoBindModel inputModel) {
            var amigo = new AmigoBindModel().CriarAmigo(inputModel);
            amigo.Id = id;

            var amigo_editado = AmigoService.Editar(amigo);
            return Ok(amigo_editado);
        }

        [AllowAnonymous]
        [Route("deletar")]
        [HttpDelete]
        public IHttpActionResult DeleteById(int id) {
            AmigoService.Apagar(id);

            return Ok();
        }
    }
}