using ProSoccerDomain;
using ProSoccerInfra;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProSoccerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class JogadoresController : ApiController
    {

        private Pro_Soccer_League_DataContext db = new Pro_Soccer_League_DataContext();

       
        //Método Get - Obter Jogadores
        [Route("Jogadores")]
        [HttpGet]
        public HttpResponseMessage ObterJogadores()

        {
            var result = db.Jogadores;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //Método Get - Obter Jogadores por time
        [Route("Clubes/{ClubeId}/Jogadores")]
        [HttpGet]
        public HttpResponseMessage ObterClubes(int ClubeId)
        {
            var result = db.Jogadores.Include("Clube").Where(x => x.ClubeId == ClubeId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //Método Post - Obter Jogadores por time
        [Route("Jogadores")]
        [HttpPost]
        public HttpResponseMessage CriarJogador(Jogador jogador)
        {
            if (jogador == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Jogador informado contém parâmetros incorretos");

            try
            {
                db.Jogadores.Add(jogador);
                db.SaveChanges();
                var result = jogador;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao incluir jogador");
            }

        }

        //Método Put - Atualizar Jogador
        [Route("Jogadores")]
        [HttpPut]
        public HttpResponseMessage AtualizarJogadores(Jogador jogador)
        {
            if(jogador == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Jogador informado contém parâmetros incorretos");

            try
            {
                db.Entry<Jogador>(jogador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = jogador;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao atualizar jogador");
            }

        }

        //Método Delete - Deletar Jogador
        [Route("Jogadores")]
        [HttpDelete]
        public HttpResponseMessage DeletarJogadores(int JogadorId)
        {
            if (JogadorId <= 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Jogador informado contém parâmetros incorretos");

            try
            {
                db.Jogadores.Remove(db.Jogadores.Find(JogadorId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Jogador Excluido");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao excluir jogador");
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