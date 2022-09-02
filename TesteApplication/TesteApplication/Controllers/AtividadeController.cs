using Microsoft.AspNetCore.Mvc;
using TesteApplication.ControllersWebApi;
using TesteApplication.Models;

namespace TesteApplication.Controllers
{
    public class AtividadeController:Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Cadastro(Int64? Id) 
        {
            return View();
        }
        [HttpPost()]
        public async Task<ActionResult> Cadastro(AtividadeCadastroModel model )
        {
            using (var api = new AtividadeApiController()) 
            {
                 await api.Save(model);
            }
            return View(model);
        }



    }
}
