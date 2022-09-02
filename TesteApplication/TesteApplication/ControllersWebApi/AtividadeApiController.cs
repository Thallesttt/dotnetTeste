using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using TesteApplication.Model;
using TesteApplication.Models;

namespace TesteApplication.ControllersWebApi
{
    [ApiController]
    [Produces("Application/json")]
    [Route("[controller]")]
    public class AtividadeApiController : ControllerBase, IDisposable
    {
        private bool disposedValue;

        [HttpGet("GetRecords")]
        public async Task<IEnumerable<AtividadeListModel>> GetRecords()
        {
            var retorno = new List<AtividadeListModel>();
            using (var acess_TbAtividade = new AtividadeContext())
            {
                acess_TbAtividade.Atividades.ToList().ForEach(p =>
                retorno.Add(Get(p))
                );

            }

            return retorno;
        }

        [HttpPost("Save")]
        public async Task Save(AtividadeCadastroModel model)
        {
            using (var acess_TbAtividade = new AtividadeContext())
            {

                Atividade obj = Bind(model);

                obj.Id = acess_TbAtividade.Atividades.Last().Id + 1; ;
                acess_TbAtividade.Add(obj);

                acess_TbAtividade.SaveChanges();
            }
        }
        //https://localhost:44388/AtividadeApi/GetRecordById
        [HttpGet("GetRecordById")]
        public async Task<Atividade> GetRecordById(Int64? Id)
        {
            Atividade retorno = null;
            using (var acess_TbAtividade = new AtividadeContext())
            {
                var atividade = acess_TbAtividade.Atividades.ToList().Find(p => p.Id == Id);
                retorno = atividade;
            }
            return retorno;
        }

        [HttpGet("SetAtividadeManually")]
        public async Task SetAtividadeManually(String Inicio, String Fim)
        {
            var TimeInicio = Conversion(Inicio);
            var TimeFim = Conversion(Fim);

            var retorno = new Atividade
            {
                DataHoraInicial = TimeInicio,
                DataHoraFinal = TimeFim
            };
            using (var acess_TbAtividade = new AtividadeContext())
            {
                retorno.Id = acess_TbAtividade.Atividades.Last().Id + 1;

                acess_TbAtividade.Add(retorno);
                acess_TbAtividade.SaveChanges();
            }

        }

        private Atividade Bind(AtividadeCadastroModel model)
        {
            var retorno = new Atividade
            {
                DataHoraFinal = Conversion(model.DataFinalString),
                DataHoraInicial = Conversion(model.DataInicialString),
            };
            return retorno;
        }
        private AtividadeListModel Get(Atividade model)
        {
            var retorno = new AtividadeListModel
            {
                Id = model.Id,
                DataHoraFinal = model.DataHoraFinal.ToString("dd/MM/yyyy HH:mm:ss"),
                DataHoraInicial = model.DataHoraInicial.ToString("dd/MM/yyyy HH:mm:ss"),
                Minutos_Diferenca = (model.DataHoraFinal - model.DataHoraInicial).TotalMinutes,
                Ano_Referencia = model.DataHoraFinal.Year,
            };
            return retorno;
        }

        private DateTime Conversion(string timeTXT)
        {
            return Convert.ToDateTime(timeTXT);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AtividadeApiController()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
