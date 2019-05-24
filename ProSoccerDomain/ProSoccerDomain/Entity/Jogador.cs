namespace ProSoccerDomain
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int? NacionalidadeId { get; set; }
        public int Classificacao { get; set; }
        public string Posicao { get; set; }
        public string Perna { get; set; }
        public int Forca { get; set; }
        public int Tecnica { get; set; }
        public int Velocidade { get; set; }
        public int Manejo { get; set; }
        public enum Habilidades { Fintas, Empenhado }
        public int ClubeId { get; set; }

        public virtual Clube Clube { get; set; }
        public virtual Nacionalidade Nacionalidade { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
