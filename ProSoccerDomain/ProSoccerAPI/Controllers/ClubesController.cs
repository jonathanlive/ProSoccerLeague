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
    public class ClubesController : ApiController
    {
        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();


        //Get Listar Clubes
        [HttpGet]
        [Route("Clubes")]
        public HttpResponseMessage ListarClubes()
        {
            var result = db.Clubes;
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        //Get Atualizar Clubes
        [HttpPut]
        [Route("Clubes")]
        public HttpResponseMessage AtualizarClube(Clube clube)
        {

            if(clube == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Clube informado possúi parâmetros incorretos");

            try
            {
                db.Entry<Clube>(clube).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = clube;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar Clube");
            }
            
        }


        //POST - Incluir Clube
        [HttpPost]
        [Route("Clubes")]
        public HttpResponseMessage IncluirClube(Clube clube)
        {

            if (clube == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Clube informado possúi parâmetros incorretos");

            try
            {
                db.Clubes.Add(clube);
                db.SaveChanges();

                var result = clube;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao incluir Clube");
            }

        }

        //DELETE - Deletar clube
        [HttpPost]
        [Route("Clubes")]
        public HttpResponseMessage DeletarClube(int ClubeId)
        {

            if (ClubeId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Clube informado possúi parâmetros incorretos");

            try
            {
                db.Clubes.Remove(db.Clubes.Find(ClubeId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Clube excluído com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao incluir Clube");
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