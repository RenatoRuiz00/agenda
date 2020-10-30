using Agenda.Models;
using Agenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgendaService _agendaService;

        public HomeController(AgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        public IActionResult Index()
        {
            return View(_agendaService.Buscar());
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, string telefone, string logradouro, string numero, string bairro, string cidade)
        {
            Pessoa pessoa = new Pessoa
            {
                Nome = nome,
                Telefone = telefone,
                Logradouro = logradouro,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade
            };
            _agendaService.Salvar(pessoa);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            return View(_agendaService.BuscarPorId(id.Value));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _agendaService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            return View(_agendaService.BuscarPorId(id.Value));
        }

        [HttpPost]
        public IActionResult Edit(Pessoa pessoa)
        {
            _agendaService.Update(pessoa);
            return RedirectToAction("Index");
        }
    }
}
