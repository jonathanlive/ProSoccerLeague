using ProSoccerDomain;
using ProSoccerInfra;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProSoccerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class PatrocinadoresController : ApiController
    {
        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();

        // GET - Listar Patrocinadores
        [HttpGet]
        [Route("Patrocinadores")]
        public HttpResponseMessage ListarPatrocinadores()
        {
            var result = db.Patrocinadores;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //POST - Incluir patrocinador
        [HttpPost]
        [Route("Patrocinadores")]
        public HttpResponseMessage IncluirPatrocinador(Patrocinador patrocinador)
        {
            if (patrocinador == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao incluir patrocinador");

            try
            {

                db.Patrocinadores.Add(patrocinador);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, patrocinador);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao incluir patrocinador");
            }
        }

        //PUT - Atualizar Patrocinadores
        [HttpPut]
        [Route("Patrocinadores")]
        public HttpResponseMessage AtualizarPatrocinadores(Patrocinador patrocinador)
        {
            if (patrocinador == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar patrocinador");

            try
            {
                db.Entry<Patrocinador>(patrocinador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, patrocinador);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao atualizar patrocinador");
            }
        }

        //Delete - Deletar Patrocinadores
        [HttpDelete]
        [Route("Patrocinadores")]
        public HttpResponseMessage DeletarPatrocinadores(int PatrocinadorId)
        {
            if (PatrocinadorId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar patrocinador");

            try
            {
                db.Patrocinadores.Remove(db.Patrocinadores.Find(PatrocinadorId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Patrocinador deletado com sucesso");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao deletar patrocinador");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}