using ExerciciosVixTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExerciciosVixTeam.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            var empresaModel = new EmpresaModel();
            if (ViewData["DadosEmpresa"] != null)
            {
                empresaModel = (EmpresaModel)ViewData["DadosEmpresa"];
            }
            return View(empresaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Cadastro([Bind("Codigo, Nome, NomeFantasia, CNPJ")] EmpresaModel empresaModel)
        {
            ViewData["DadosEmpresa"] = empresaModel;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
