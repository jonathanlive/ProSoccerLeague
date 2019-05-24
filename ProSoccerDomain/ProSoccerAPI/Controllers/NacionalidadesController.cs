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
    public class NacionalidadesController : ApiController
    {
        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();


        // GET - Listar Nacionalidades
        [HttpGet]
        [Route("Nacionalidades")]
        public HttpResponseMessage ListarNacionalidades()
        {
            var result = db.Nacionalidades;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //POST - Incluir nacionalidades
        [HttpPut]
        [Route("Nacionalidades")]
        public HttpResponseMessage IncluirNacionalidades(Nacionalidade nacionalidade)
        {
            if (nacionalidade == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao incluir nacionalidade");

            try
            {

                db.Nacionalidades.Add(nacionalidade);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, nacionalidade);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao incluir nacionalidade");
            }
        }

        //PUT - Atualizar nacionalidades
        [HttpPost]
        [Route("Nacionalidades")]
        public HttpResponseMessage AtualizarNacionalidades(Nacionalidade nacionalidade)
        {
            if (nacionalidade == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar nacionalidade");

            try
            {
                db.Entry<Nacionalidade>(nacionalidade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, nacionalidade);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao atualizar nacionalidade");
            }
        }

        //Delete - Deletar Nacionalidades
        [HttpDelete]
        [Route("Nacionalidades")]
        public HttpResponseMessage DeletarNacionalidades(int NacionalidadeId)
        {
            if (NacionalidadeId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar nacionalidade");

            try
            {
                db.Nacionalidades.Remove(db.Nacionalidades.Find(NacionalidadeId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Nacionalidade deletado com sucesso");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao deletar nacionalidade");
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