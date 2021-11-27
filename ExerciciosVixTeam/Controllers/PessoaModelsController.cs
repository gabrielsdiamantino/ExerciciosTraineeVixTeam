using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExerciciosVixTeam.Data;
using ExerciciosVixTeam.Models;

namespace ExerciciosVixTeam.Controllers
{
    public class PessoaModelsController : Controller
    {
        private readonly ExerciciosVixTeamContext _context;

        public PessoaModelsController(ExerciciosVixTeamContext context)
        {
            _context = context;
        }

        // GET: PessoaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaModel.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AlterarStatus(int id)
        {
            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            if (pessoaModel.Status.Equals("Ativo"))
            {
                pessoaModel.Status = "Inativo";
            }
            else
            {
                pessoaModel.Status = "Ativo";
            }
            _context.Update(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PessoaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return View(pessoaModel);
        }

        // GET: PessoaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Email,DataNascimento,QuantidadeFilhos,Salario")] PessoaModel pessoaModel)
        {
            var pessoaEmail = _context.PessoaModel.Where(x => x.Email.Equals(pessoaModel.Email) && x.Codigo != pessoaModel.Codigo);
            if(pessoaEmail.Count() > 0)
            {
                ModelState.AddModelError("Regra de Negócio", "E-mail já Cadastrado!");
                return View(pessoaModel);
            }

            DateTime x = DateTime.Parse("01/01/1990");
            if (pessoaModel.DataNascimento < x)
            {
                ModelState.AddModelError("Regra de Negócio", "Data de Nascimento não pode ser inferior a 01/01/1990.");
                return View(pessoaModel);
            }

            pessoaModel.Status = "Ativo";
                _context.Add(pessoaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
            return View(pessoaModel);
        }
      

    // GET: PessoaModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }
            return View(pessoaModel);
        }


        

        // POST: PessoaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nome,Email,DataNascimento,QuantidadeFilhos,Salario,Status")] PessoaModel pessoaModel)
        {
            if (id != pessoaModel.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //aqui
                var editPessoa = pessoaModel.Status;
                if(editPessoa == "Inativo")
                {
                    ModelState.AddModelError("Regra de Negócio", "Pessoas com Status INATIVO não podem ser editadas.");
                    return View(pessoaModel);
                }
              
               DateTime x = DateTime.Parse("01/01/1990"); 
               if (pessoaModel.DataNascimento < x)
                {
                    ModelState.AddModelError("Regra de Negócio", "Data de Nascimento não pode ser inferior a 01/01/1990.");
                    return View(pessoaModel);
                }
                try
                {
                    _context.Update(pessoaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaModelExists(pessoaModel.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaModel);
        }

        // GET: PessoaModels/Delete/5

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PessoaModel = await _context.PessoaModel
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (PessoaModel == null)
            {
                return NotFound();
            }

            return View(PessoaModel);
        }

        // POST: PessoaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var pessoaModel = await _context.PessoaModel.FindAsync(id);
            _context.PessoaModel.Remove(pessoaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       


    private bool PessoaModelExists(int id)
        {
            return _context.PessoaModel.Any(e => e.Codigo == id);
        }


    }
}
