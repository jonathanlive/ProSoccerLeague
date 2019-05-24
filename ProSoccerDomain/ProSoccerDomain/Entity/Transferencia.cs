using System;

namespace ProSoccerDomain.Entity
{
    public class Transferencia
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public int LanceMin{ get; set; }
        public int Comprar { get; set; }
        public int LanceAtual { get; set; }
        public int ClubeSaidaId { get; set; }
        public int ClubeEntradaId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataLance{  get; set; }

        public virtual Jogador Jogador { get; set; }
    }
}
