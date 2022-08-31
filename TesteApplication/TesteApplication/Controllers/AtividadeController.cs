using Microsoft.AspNetCore.Mvc;
using TesteApplication.ControllersWebApi;
using TesteApplication.Models;

namespace TesteApplication.Controllers
{
    public class AtividadeController:Controller
    {
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult Cadastro(Int64? Id) 
        {
            return View();
        }
        [HttpPost()]
        public async Task<ActionResult> Cadastro(AtividadeCadastroModel model )
        {
            using (var api = new AtividadeApiController()) 
            {
                 await api.SetAtividadeManually(model.DataInicialString, model.DataFinalString);
            }
            return View(model);
        }



    }
}
