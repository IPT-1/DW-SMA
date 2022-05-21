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
        
        // Variável que vai conter os dados do servidor.
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MedicamentosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            if (id == null)
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
        /// <summary>
        /// Método usado para recuperar os dados enviados pelos utilizadores.
        /// </summary>
        /// <param name="medicamento"></param>
        /// <param name="foto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Nome,Dosagem,Laboratorio,Observacoes,Foto")] Medicamento medicamento, 
            IFormFile foto) {
            
            /**
             * Algoritmo para processar ao ficheiro com a imagem.
             * 
             * Se imagem = nulo
             *      atribui a imagem default ao medicamento
             * Senão
             *      ficheiro é imagem?
             *      Se não for
             *          criar mensagem de erro
             *          devolver control da app à View
             *      Se for
             *          definir o nome a atribuir à imagem
             *          atribuir aos dados do novo medicamento o nome do ficheiro da imagem
             *          guardar a imagem no disco rígido do servido
             */

            // Verifica se tem ficheiro e se não tiver atribui imagem default.
            if (foto == null) {
                medicamento.Foto = "Default.png";
            } else {

                // Verifica se é ficheiro e imagem.
                if (!(foto.ContentType == "image/png" || foto.ContentType == "image/jpeg")) {
                    // Se não for imagem mostra erro.
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    // Devolve o controlo da app à View.
                    return View(medicamento);
                } else { 
                    // Se for imagem define o nome da foto.
                    Guid guid = Guid.NewGuid();
                    string nomeFoto     = medicamento.Id + "_" + guid.ToString();
                    string extensaoFoto = Path.GetExtension(foto.FileName).ToLower();
                    nomeFoto += extensaoFoto;
                    // Atribuir ao medicamento o nome da sua foto.
                    medicamento.Foto = nomeFoto;
                }

            }

            // Avalia se os dados fornecidos pelo utilizador estão de acordo com o Model
            if (ModelState.IsValid) {

                try {
                    // Adicionar os dados à Base de Dados.
                    _context.Add(medicamento);
                    // Sincronizar os dados.
                    await _context.SaveChangesAsync();
                } catch (Exception ex) {
                    // Criar uma mensagem de erro.
                    ModelState.AddModelError("", "Ocorreu um erro com a operação de guardar os dados do medicamento " + medicamento.Nome);
                    // Devolver o controlo da app à View.
                    return View(medicamento);
                }

                // #############################
                // Guardar o ficheiro da foto. #
                // #############################
                if (foto != null) {
                    // Cria um caminho para o ficheiro.
                    string nomeLocalizacaoFicheiro = _webHostEnvironment.WebRootPath;
                    nomeLocalizacaoFicheiro = Path.Combine(nomeLocalizacaoFicheiro, "Fotos");
                    // Verifica se a pasta 'Fotos' não existe. Se não existe cria a pasta.
                    if (!Directory.Exists(nomeLocalizacaoFicheiro)) {
                        Directory.CreateDirectory(nomeLocalizacaoFicheiro);
                    }
                    // Nome do documento a guardar.
                    string nomeDaFoto = Path.Combine(nomeLocalizacaoFicheiro, medicamento.Foto);
                    // Cria o objeto que vai manipular o ficheiro.
                    using var stream = new FileStream(nomeDaFoto, FileMode.Create);
                    // Guarda o ficheiro no disco rígido.
                    await foto.CopyToAsync(stream);
                }

                // Devolver o controlo da app à View.
                return RedirectToAction("Index");

            }

            return View(medicamento);

        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return RedirectToAction("Index");
            }

            // Criação de uma variável de sessão para guardar o id do medicamento e assegurar que os dados não são alterados por engano.
            HttpContext.Session.SetInt32("MedicamentoID", medicamento.Id);

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
