using BookLibrary.Web.Dtos;
using BookLibrary.Web.Services.BookLibrary;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers;
public class BookLibraryController : Controller
{
    private readonly IBookLibraryService _service;

    public BookLibraryController(IBookLibraryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _service.GetAllBooksAsync();
        return View(values);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _service.GetByIdBookAsync(id);
        return View(book);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateBookDto model)
    {
        await _service.UpdateBookAsync(model);
        return RedirectToAction("Index");
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto model)
    {
        await _service.CreateBookAsync(model);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteBookAsync(id);
        return RedirectToAction("Index", "BookLibrary");
    }
}
