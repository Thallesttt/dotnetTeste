using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using TesteApplication.Model;

namespace TesteApplication.ControllersWebApi
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeApiController : ControllerBase
    {
        [HttpGet()]
        public async Task<IEnumerable<dynamic>> GetDataActivity()
        {
            var retorno = new List<Object>();
            using (var acess_TbAtividade = new AtividadeContext())
            {
                retorno.Add(acess_TbAtividade.Atividades.ToList());
            }

            return retorno;
        }
        [HttpPost]
        public async Task<Atividade> SetAtividadeManually(String Inicio, String Fim)
        {
            var TimeInicio = Conversion(Inicio);
            var TimeFim = Conversion(Fim);

            var retorno = new Atividade
            {
                DataInicial = TimeInicio.Date,
                HoraInicial = TimeInicio.TimeOfDay,

                DataFinal = TimeFim.Date,
                HoraFinal = TimeFim.TimeOfDay,
            };
            return retorno;
        }

        public DateTime Conversion(string timeTXT)
        {
            return Convert.ToDateTime(timeTXT);
        }

    }
}
