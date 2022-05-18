using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SMA.Data;
using SMA.Models;

namespace SMA.Controllers
{
    public class MedicamentosController : Controller
    {
        // Cria uma instância de acesso à base de dados.
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MedicamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public async Task<IActionResult> Index()
        {
            // Acesso à base de dados 'SELECT * FROM Medicamentos' e retorna para a View.  
            return View(await _context.Medicamentos.ToListAsync());
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Create
        // Usado no primeiros acesso à View.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Dosagem,Laboratorio,Observacoes,Foto")] Medicamento medicamento, IFormFile foto)
        {
            
            if (foto == null) { 
                medicamento.Foto = "FotoDefault.png";
            } else {
                if (!(foto.ContentType == "image/png" || foto.ContentType == "imagem/jpeg")) {  // Se não for um ficheiro de imagem...
                    // Mostra mensagem de erro e devolve o controlo da app à View.
                    ModelState.AddModelError("","Por favor, adicione um ficheiro .png ou .jpg");
                    return View(medicamento);
                } else {    // Se for ficheiro de imagem...
                    // Define um nome para a imagem
                    Guid id = Guid.NewGuid();
                    string nomeImagem       = medicamento.Id.ToString() + "_" + id.ToString();
                    string extensaoImagem   = Path.GetExtension(foto.FileName).ToLower();
                    nomeImagem += extensaoImagem;
                    medicamento.Foto = nomeImagem;
                }
            }

            // Validar se os dados providenciados pelo utilizador são bons.
            if (ModelState.IsValid)
            {
                try {
                    // Adiciona os dados do medicamento à base de dados.
                    _context.Add(medicamento);
                    await _context.SaveChangesAsync();
                } catch (Exception) {
                    // Mensagem de erro.
                    ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar os dados na base de dados.");
                    return View(medicamento);
                }

                if (foto != null) {
                    // Guarda o ficheiro de imagem no disco.
                    string diretoriaFicheiro = _webHostEnvironment.WebRootPath;
                    string imagemLocalizacao = Path.Combine(diretoriaFicheiro, "Fotos", medicamento.Foto);

                    // Verifica se a pasta 'Fotos' existe.
                    if (!Directory.Exists(imagemLocalizacao)) {
                        Directory.CreateDirectory(imagemLocalizacao);
                    }
                    
                    // Guarda o ficheiro de imagem no disco.
                    imagemLocalizacao = Path.Combine(imagemLocalizacao, medicamento.Foto);
                    using var stream = new FileStream(imagemLocalizacao, FileMode.Create);
                    await foto.CopyToAsync(stream);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Dosagem,Laboratorio,Observacoes,Foto")] Medicamento medicamento, IFormFile foto)
        {
            if (id != medicamento.Id)
            {
                return NotFound();
            }

            var idAnteriorMedicamento = HttpContext.Session.GetInt32("MedicamentoID");

            if (idAnteriorMedicamento == null) {
                ModelState.AddModelError("","ERRO!");
                return View(medicamento);
            }

            if (idAnteriorMedicamento != medicamento.Id) {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Id))
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
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            await _context.SaveChangesAsync();

            try {
                _context.Medicamentos.Remove(medicamento);
                await _context.SaveChangesAsync();
            } catch (Exception) {
            }
                       
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
          return _context.Medicamentos.Any(e => e.Id == id);
        }
    }
}
