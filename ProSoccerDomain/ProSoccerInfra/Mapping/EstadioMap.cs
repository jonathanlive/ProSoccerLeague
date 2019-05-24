using ProSoccerDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class EstadioMap : EntityTypeConfiguration<Estadio>
    {
        public EstadioMap()
        {
            ToTable("Estadio");

            HasKey(x => x.Id);
            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(30);

        }
    }
}
