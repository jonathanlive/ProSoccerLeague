using ProSoccerDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class ClubeMap : EntityTypeConfiguration<Clube>
    {
        public ClubeMap()
        {
            ToTable("Clube");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            Property(x => x.Reputacao).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Logo).HasColumnType("varchar").HasMaxLength(30);

            HasOptional(x => x.Nacionalidade);
            HasOptional(x => x.Patrocinador);
            HasOptional(x => x.Estadio);
            HasOptional(x => x.Liga);
        }
    }
}
