namespace ProSoccerDomain
{
    public class Clube
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? NacionalidadeId { get; set; }
        public int? EstadioId { get; set; }
        public int? PatrocinadorId { get; set; }
        public string Reputacao { get; set; }
        public int? LigaId { get; set; }
        public int Titulos { get; set; }
        public string Logo { get; set; }
        public int ValorOrcamento { get; set; }
        public int ValorClube { get; set; }

        public virtual Nacionalidade Nacionalidade { get; set; }
        public virtual Estadio Estadio { get; set; }
        public virtual Patrocinador Patrocinador { get; set; }
        public virtual Liga Liga { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }

    }
}