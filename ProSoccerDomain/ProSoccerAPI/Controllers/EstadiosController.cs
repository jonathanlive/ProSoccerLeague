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
    public class EstadiosController : ApiController
    {
        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();

        // GET - Listar Estadios
        [HttpGet]
        [Route("Estadios")]
        public HttpResponseMessage ListarEstadios()
        {
            var result = db.Estadios;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //POST - Incluir Estadio
        [HttpPost]
        [Route("Estadios")]
        public HttpResponseMessage IncluirEstadio(Estadio estadio)
        {
            if (estadio == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Parâmetros incorretos ao Incluir Estádio");

            try
            {

                db.Estadios.Add(estadio);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, estadio);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao incluir estádio");
            }
        }

        //PUT - Atualizar Estadios
        [HttpPut]
        [Route("Estadios")]
        public HttpResponseMessage AtualizarEstadio(Estadio estadio)
        {
            if (estadio == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar Estádio");

            try
            {
                db.Entry<Estadio>(estadio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, estadio);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao atualizar estádio");
            }
        }

        //Delete - Deletar Estadios
        [HttpDelete]
        [Route("Estadios")]
        public HttpResponseMessage DeletarEstadio(int EstadioId)
        {
            if (EstadioId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar Estádio");

            try
            {
                db.Estadios.Remove(db.Estadios.Find(EstadioId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Estádio deletado com sucesso");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao deletar estádio");
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