using ProSoccerDomain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProSoccerInfra.Mapping
{
    public class TransferenciaMap : EntityTypeConfiguration<Transferencia>
    {
        public TransferenciaMap()
        {
            ToTable("Transferencia");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Jogador);
        }
    }
}
