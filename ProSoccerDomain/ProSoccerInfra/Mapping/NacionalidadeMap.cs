using ProSoccerDomain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class NacionalidadeMap : EntityTypeConfiguration<Nacionalidade>
    {
        public NacionalidadeMap()
        {
            ToTable("Nacionalidade");

            HasKey(x => x.Id);
            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(50);

        }

    }
}
