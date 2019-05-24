using ProSoccerDomain;
using ProSoccerDomain.Entity;
using ProSoccerInfra.Mapping;
using System;
using System.Data.Entity;

namespace ProSoccerInfra
{
    //[DbConfigurationType(typeof(MySqlConfiguration))]
    public class Pro_Soccer_League_DataContext : DbContext
    {
        //Server=sql10.freemysqlhosting.net;Database=sql10276929;Uid=sql10276929;Pwd=dFxJYT9whi;
        //Provider=sql10.freemysqlhosting.net;Data Source=sql10276929;User Id=sql10276929;Password=dFxJYT9whi;
       
        public Pro_Soccer_League_DataContext() :base("ProSoccer")
        {
            Database.SetInitializer<Pro_Soccer_League_DataContext>(new Pro_Soccer_League_DataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Nacionalidade> Nacionalidades { get; set; }
        public DbSet<Patrocinador> Patrocinadores { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogadorMap());
            modelBuilder.Configurations.Add(new ClubeMap());
            modelBuilder.Configurations.Add(new EstadioMap());
            modelBuilder.Configurations.Add(new LigaMap());
            modelBuilder.Configurations.Add(new PatrocinadorMap());
            modelBuilder.Configurations.Add(new NacionalidadeMap());
            modelBuilder.Configurations.Add(new TransferenciaMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Pro_Soccer_League_DataContextInitializer :  DropCreateDatabaseIfModelChanges<Pro_Soccer_League_DataContext>
    {

        protected override void Seed(Pro_Soccer_League_DataContext context)
        {
            //Adicionando as nacionalidades
            context.Nacionalidades.Add(new Nacionalidade {Nome = "Brasil" });
            context.Nacionalidades.Add(new Nacionalidade {Nome = "Espanha" });
            context.Nacionalidades.Add(new Nacionalidade { Nome = "Itália" });
            context.Nacionalidades.Add(new Nacionalidade { Nome = "Argentina" });
            context.SaveChanges();
            //Adicionando as Ligas
            context.Ligas.Add(new Liga {Nome = "Liga Nacional",Premiacao = 10000000 });
            context.Ligas.Add(new Liga {Nome = "Mundial", Premiacao = 20000000 });
            context.Ligas.Add(new Liga {Nome = "Estadual", Premiacao = 500000 });
            context.SaveChanges();
            //Adicionando os patrocinadores
            context.Patrocinadores.Add(new Patrocinador {Nome = "Crefisa",Verba_anual = 1000000 });
            context.Patrocinadores.Add(new Patrocinador {Nome = "Nike", Verba_anual = 1500000 });
            context.Patrocinadores.Add(new Patrocinador { Nome = "Emirates", Verba_anual = 1500000 });
            context.Patrocinadores.Add(new Patrocinador { Nome = "Adidas", Verba_anual = 1500000 });
            context.SaveChanges();
            //Adicionando estadios
            context.Estadios.Add(new Estadio {Nome = "Arena Corinthians", Capacidade = 45000});
            context.Estadios.Add(new Estadio {Nome = "Allins Park", Capacidade = 42000 });
            context.Estadios.Add(new Estadio { Nome = "Morumbi", Capacidade = 40000 });
            context.SaveChanges();
            //Adicionando clubes
            context.Clubes.Add(new Clube { Nome = "Mercado de Transferencias" });
            context.Clubes.Add(new Clube { Nome = "Real Madrid", Reputacao = "Internacional", Titulos = 2, NacionalidadeId = 1, EstadioId = 2, LigaId = 1, PatrocinadorId = 2, ValorOrcamento = 10000000 });
            context.Clubes.Add(new Clube { Nome = "Barcelona", Reputacao = "Internacional", Titulos = 4, NacionalidadeId = 2, EstadioId = 1, LigaId = 1, PatrocinadorId = 1, ValorOrcamento = 10000000 });
            context.Clubes.Add(new Clube { Nome = "Corinthians", Reputacao = "Internacional", Titulos = 7, NacionalidadeId = 1, EstadioId = 2, LigaId = 1, PatrocinadorId = 2, ValorOrcamento = 10000000 });
            context.SaveChanges();
            //Adicionando Jogadores
            context.Jogadores.Add(new Jogador {Nome = "Pedro",Sobrenome = "Henrique", Idade = 24, NacionalidadeId = 1,Posicao = "MC", ClubeId = 3,  Classificacao = 79, Forca = 10,Velocidade = 13,Tecnica = 7,Perna = "D"  } );
            context.Jogadores.Add(new Jogador {Nome = "Mario",Sobrenome = "Fernandes", Idade = 24, NacionalidadeId = 2,Posicao = "ATA" , ClubeId = 4, Classificacao = 77, Forca = 12,Velocidade = 17, Tecnica = 9, Perna = "E" });
            context.SaveChanges();
            //Formalizando transferencias
            context.Transferencias.Add(new Transferencia {JogadorId = 1,LanceMin =1500 , Comprar = 50000,ClubeSaidaId = 2, DataInclusao = DateTime.Now });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
