using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;

namespace NotesApp.Controllers;

public class NotesController : Controller
{
    private static readonly NoteRepository _repo = new NoteRepository();

    // READ - List all notes
    public IActionResult Index(string? search, string? category)
    {
        var notes = _repo.GetAll();

        if (!string.IsNullOrEmpty(search))
            notes = notes.Where(n =>
                n.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                n.Content.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!string.IsNullOrEmpty(category))
            notes = notes.Where(n => n.Category == category).ToList();

        ViewBag.Search = search;
        ViewBag.Category = category;
        ViewBag.Categories = _repo.GetCategories();
        ViewBag.TotalCount = _repo.GetAll().Count;
        return View(notes);
    }

    // READ - View single note
    public IActionResult Details(int id)
    {
        var note = _repo.GetById(id);
        if (note == null) return NotFound();
        return View(note);
    }

    // CREATE - Show form
    public IActionResult Create()
    {
        ViewBag.Categories = _repo.GetCategories();
        return View();
    }

    // CREATE - Handle form submission
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Note note)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _repo.GetCategories();
            return View(note);
        }
        _repo.Add(note);
        TempData["Success"] = "Note created successfully!";
        return RedirectToAction(nameof(Index));
    }

    // UPDATE - Show edit form
    public IActionResult Edit(int id)
    {
        var note = _repo.GetById(id);
        if (note == null) return NotFound();
        ViewBag.Categories = _repo.GetCategories();
        return View(note);
    }

    // UPDATE - Handle edit submission
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Note note)
    {
        if (id != note.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _repo.GetCategories();
            return View(note);
        }
        _repo.Update(note);
        TempData["Success"] = "Note updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    // DELETE - Confirm delete page
    public IActionResult Delete(int id)
    {
        var note = _repo.GetById(id);
        if (note == null) return NotFound();
        return View(note);
    }

    // DELETE - Handle deletion
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repo.Delete(id);
        TempData["Success"] = "Note deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
