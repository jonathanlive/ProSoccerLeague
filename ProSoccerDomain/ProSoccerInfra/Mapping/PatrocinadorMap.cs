using ProSoccerDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class PatrocinadorMap : EntityTypeConfiguration<Patrocinador>
    {
        public PatrocinadorMap()
        {
            ToTable("Patrocinador");

            HasKey(x => x.Id);
            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(30);

        }

    }
}
