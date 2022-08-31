using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TesteApplication;
using TesteApplication.Constantes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteApplication.Model
{
    public class AtividadeContext : DbContext, IDisposable
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConstantesModel.recoverStringConection().Result);
        }
        public DbSet<Atividade>? Atividades { get; set; }
    }
    [Table("tb_atividade")]
    public class Atividade
    {
        [Key()]
        [Column("id")]
        public virtual Int64 Id{get;set;}
        [Column("data_hora_inicio")]
        public virtual DateTime DataHoraInicial { get; set; }
        [Column("data_hora_final")]        
        public virtual DateTime DataHoraFinal { get; set; }
        
    }
}