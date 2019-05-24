using ProSoccerDomain;
using ProSoccerDomain.Entity;
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
    public class TransferenciasController : ApiController
    {
        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();

        // GET - Listar Transferências
        [HttpGet]
        [Route("Transferencias")]
        public HttpResponseMessage ListarTransferencias()
        {
            var result = db.Transferencias;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //POST - Incluir Transferencia
        [HttpPost]
        [Route("Transferencias")]
        public HttpResponseMessage IncluirTransferencia(Transferencia transferencia)
        {
            if (transferencia == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao incluir transferencia");

            try
            {
                db.Transferencias.Add(transferencia);
                Jogador jogador = db.Jogadores.Find(transferencia.JogadorId);
                jogador.ClubeId = 1;
                db.Entry<Jogador>(jogador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, transferencia);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao incluir transferencia");
            }
        }

        //PUT - Atualizar transferencia
        [HttpPut]
        [Route("Transferencias")]
        public HttpResponseMessage AtualizarTransferencia(Transferencia transferencia)
        {
            if (transferencia == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar transferencia");

            try
            {
                db.Entry<Transferencia>(transferencia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, transferencia);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao atualizar transferencia");
            }
        }

        //Delete - Deletar da transferência e transferir jogador
        [HttpDelete]
        [Route("Transferencias")]
        public HttpResponseMessage DeletarTransferencia(int TransferenciaId)
        {
            if (TransferenciaId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parâmetros incorretos ao atualizar trasferencia");

            try
            {
                Transferencia transferencia = db.Transferencias.Find(TransferenciaId);
                Jogador jogador = db.Jogadores.Find(transferencia.JogadorId);
                jogador.ClubeId = transferencia.ClubeEntradaId;
                db.Entry<Jogador>(jogador).State = System.Data.Entity.EntityState.Modified;
                db.Transferencias.Remove(transferencia);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Transferência realizada com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha ao efetuar transferencia");
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