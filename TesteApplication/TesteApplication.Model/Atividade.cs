using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteApplication.Model
{
    public class AtividadeContext : DbContext, IDisposable
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=ec2-3-223-242-224.compute-1.amazonaws.com;Port=5432;Database=d8r844l1vrco3k;User Id=hrliruvvvubbix;Password=7ca45f2fa826df9600434c606ed89ce44db14740ba906f452ddc3dfd9598a8f4;");
        }
        public DbSet<Atividade>? Atividades { get; set; }
    }
    [Table("tb_atividade")]
    public class Atividade
    {
        [Key()]
        [Column("id")]
        public virtual Int64 Id{get;set;}
        [Column("data_inicio")]
        public virtual DateTime DataInicial { get; set; }
        [Column("hora_inicio")]
        public virtual TimeSpan HoraInicial { get; set; }
        [Column("data_final")]
        public virtual DateTime DataFinal { get; set; }
        [Column("hora_final")]
        public virtual TimeSpan HoraFinal { get; set; }
    }
}