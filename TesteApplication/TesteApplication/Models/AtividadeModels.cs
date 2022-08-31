namespace TesteApplication.Models
{
    public class AtividadeListModel
    {
        public virtual Int64? Id { get; set; }
        
        public virtual DateTime DataHoraInicial { get; set; }                    
        public virtual DateTime DataHoraFinal { get; set; }

    }

    public class AtividadeCadastroModel
    {
        public virtual String DataInicialString { get; set; }
        public virtual String DataFinalString { get; set; }
    }
}
