using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagment.Data;
using LibraryManagment.Models;
using LibraryManagment.Repositories;
using LibraryManagment.Services;

namespace LibraryManagment.Controllers
{
    //This is only for GitHub check
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookrepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookrepository = bookRepository;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookrepository.GetAllbook();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookrepository.GetBookById(id.Value);


            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Author,Genre,PublishDate,Copies,ImagePath")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookrepository.AddBookAysnc(book);

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookrepository.GetBookById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Author,Genre,PublishDate,Copies")] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _bookrepository.Updatebook(book);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await BookExists(book.ID)))
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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookrepository.GetBookById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookrepository.Deletebook(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(int id)
        {
            return (await _bookrepository.GetBookById(id)) != null;
        }
    }
}
