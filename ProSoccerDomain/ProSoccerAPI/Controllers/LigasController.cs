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
    public class LigasController : ApiController
    {

        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();

        // GET - Listar Ligas
        [HttpGet]
        [Route("Ligas")]
        public HttpResponseMessage ListarLigas()
        {
            var result = db.Ligas;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //POST - Incluir ligas
        [HttpPost]
        [Route("Ligas")]
        public HttpResponseMessage IncluirLigas(Liga liga)
        {
            if (liga == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao incluir liga");

            try
            {

                db.Ligas.Add(liga);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, liga);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao incluir liga");
            }
        }

        //PUT - Atualizar Ligas
        [HttpPut]
        [Route("Ligas")]
        public HttpResponseMessage AtualizarLigas(Liga liga)
        {
            if (liga == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar liga");

            try
            {
                db.Entry<Liga>(liga).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, liga);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao atualizar liga");
            }
        }

        //Delete - Deletar Ligas
        [HttpDelete]
        [Route("Ligas")]
        public HttpResponseMessage DeletarPatrocinadores(int LigaId)
        {
            if (LigaId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar liga");

            try
            {
                db.Ligas.Remove(db.Ligas.Find(LigaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Liga deletado com sucesso");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao deletar liga");
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