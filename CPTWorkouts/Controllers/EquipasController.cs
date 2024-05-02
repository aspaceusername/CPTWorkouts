using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPTWorkouts.Data;
using CPTWorkouts.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Storage;

namespace CPTWorkouts.Controllers
{
    public class EquipasController : Controller
    {
        private readonly CPTWorkoutsContext _context;
        /// <summary>
        /// um objecto que contem todos os dados do servidor
        /// data from the environment of our server
        /// </summary>
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        public EquipasController(CPTWorkoutsContext context, IWebHostEnvironment iWebHostEnvironment)
        {
            _context = context;
            _iWebHostEnvironment =  iWebHostEnvironment;
        }

        // GET: Equipas
        public async Task<IActionResult> Index()
        {
            //procura por equipas na database
            //vai retornar ao view as equipas numa lista
            //SELECT *
            //FROM courses
            //ORDER by name
            //estamos a selecionar as equipas e fazer uma lista
            //e representa cada registo, é como escrever f(x) é só uma variável
            // e=>e, a primeira letra representa todos os registos na tabela, e de todos os registos escolhemos um "e=>e" e depois tiramos lhe o atributo "e=>e.Name"
            return View(await _context.Equipas.OrderBy(e=>e.Name).ToListAsync());
            // This command is written in LINQ
        }

        // GET: Equipas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipas = await _context.Equipas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipas == null)
            {
                return NotFound();
            }

            return View(equipas);
        }

        // GET: Equipas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Equipas equipas, IFormFile LogoImage )
        {
            /*Algoritmo
             * We have a file?
             * -no
             * -> criar mensagem de erro
             * --> retornar controlo para o view
             * -yes
             * -> é uma imagem?
             * --> não: assign a default logo image to equipa
             * --> sim: definir o nome da imagem
             * ---> adicionar nome à base de dados
             * ---> sabe the logo image on the disk drive
             */

            if (ModelState.IsValid)
            {
                //auxiliary vars para definir o nome da imagem logotipo das equipas
                // vamos usar o viewid do utilizador (Guid) todos os utilizadores têm um
                string logoName = "";
                bool hasImage = false;

                if (LogoImage == null)
                {
                    ModelState.AddModelError("",
                        "No image provided"
                        );
                    return View(equipas);
                }
                else {
                    //temos uma file mas é imagem??
                    if (LogoImage.ContentType != "image/png" || LogoImage.ContentType != "image/jpeg") {
                        //para verificar usamos o mime type
                        //https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types

                        //não é imagem
                        //logo vamos definir um default logo image to course
                        equipas.Logotype = "noLogoEquipas.png";
                    }
                    else {
                        //é uma imagem
                        hasImage = true;

                        //define logo's name
                        Guid g = Guid.NewGuid();
                        logoName = g.ToString().ToLowerInvariant();
                        string extension=Path.GetExtension(LogoImage.FileName).ToLowerInvariant();
                        logoName += extension;
                        equipas.Logotype = logoName;
                    }
                }
                _context.Add(equipas);
                await _context.SaveChangesAsync();

                // if we have an image, let's save it
                if (hasImage){
                    // define the place to store the logo's image
                    string imageLocation = _iWebHostEnvironment.WebRootPath;
                    // vou guardar num ficheiro, para organizar
                    imageLocation = Path.Combine(imageLocation, "Imagens");
                    // the folder imagens exists?
                    if (!Directory.Exists(imageLocation))
                    {
                        Directory.CreateDirectory(imageLocation);
                    }
                    //add the image name to folder's location
                    Path.Combine(imageLocation,logoName);
                    //save file to server disc drive usando o ponteiro "stream", stream aponta para o ficheiro.
                    using var stream = new FileStream(imageLocation,FileMode.Create);
                    await LogoImage.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(equipas);
        }

        // GET: Equipas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipas = await _context.Equipas.FindAsync(id);
            if (equipas == null)
            {
                return NotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logotype")] Equipas equipas)
        {
            if (id != equipas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipasExists(equipas.Id))
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
            return View(equipas);
        }

        // GET: Equipas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipas = await _context.Equipas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipas == null)
            {
                return NotFound();
            }

            return View(equipas);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipas = await _context.Equipas.FindAsync(id);
            if (equipas != null)
            {
                _context.Equipas.Remove(equipas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipasExists(int id)
        {
            return _context.Equipas.Any(e => e.Id == id);
        }
    }
}
