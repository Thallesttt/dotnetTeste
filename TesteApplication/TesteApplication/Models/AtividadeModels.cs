namespace TesteApplication.Models
{
    public class AtividadeListModel
    {
        public Int64? Id { get; set; }
        public String DataHoraInicial { get; set; }
        public String DataHoraFinal { get; set; }
        public Double Minutos_Diferenca { get;set;}
        public Int64 Ano_Referencia { get;set;}

    }

    public class AtividadeCadastroModel
    {
        public virtual String DataInicialString { get; set; }
        public virtual String DataFinalString { get; set; }
    }
}
