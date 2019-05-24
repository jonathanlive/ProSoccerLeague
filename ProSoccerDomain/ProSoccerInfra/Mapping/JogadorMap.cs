using ProSoccerDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class JogadorMap : EntityTypeConfiguration<Jogador>
    {
        public JogadorMap()
        {
            ToTable("Jogador");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            Property(x => x.Sobrenome).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            Property(x => x.Posicao).HasColumnType("varchar").HasMaxLength(3).IsRequired();
            Property(x => x.Perna).HasColumnType("varchar").HasMaxLength(1).IsRequired();

            HasRequired(x => x.Clube);
            HasOptional(x => x.Nacionalidade);

        }
    }
}
