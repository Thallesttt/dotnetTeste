using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using TesteApplication.Model;

namespace TesteApplication.ControllersWebApi
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeApiController : ControllerBase,IDisposable
    {
        private bool disposedValue;

        [HttpGet()]
        public async Task<IEnumerable<Atividade>> GetDataActivity()
        {
            var retorno = new List<Atividade>();
            using (var acess_TbAtividade = new AtividadeContext())
            {
                retorno.AddRange(acess_TbAtividade.Atividades.ToList());
            }

            return retorno;
        }
        [HttpPost]
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
                acess_TbAtividade.Add(retorno);
                retorno.Id = acess_TbAtividade.Atividades.Last().Id + 1;
                acess_TbAtividade.SaveChanges();
            }
            
        }

        public DateTime Conversion(string timeTXT)
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
