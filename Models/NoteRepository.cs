namespace NotesApp.Models;

public class NoteRepository
{
    private static List<Note> _notes = new List<Note>
    {
        new Note { Id = 1, Title = "Welcome!", Content = "This is your first note. You can edit or delete it.", Category = "General", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        new Note { Id = 2, Title = "Shopping List", Content = "Milk, Eggs, Bread, Butter", Category = "Personal", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        new Note { Id = 3, Title = "Project Ideas", Content = "Build a notes app with ASP.NET MVC", Category = "Work", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
    };
    private static int _nextId = 4;

    public List<Note> GetAll() => _notes.OrderByDescending(n => n.UpdatedAt).ToList();

    public Note? GetById(int id) => _notes.FirstOrDefault(n => n.Id == id);

    public void Add(Note note)
    {
        note.Id = _nextId++;
        note.CreatedAt = DateTime.Now;
        note.UpdatedAt = DateTime.Now;
        _notes.Add(note);
    }

    public bool Update(Note updated)
    {
        var note = _notes.FirstOrDefault(n => n.Id == updated.Id);
        if (note == null) return false;
        note.Title = updated.Title;
        note.Content = updated.Content;
        note.Category = updated.Category;
        note.UpdatedAt = DateTime.Now;
        return true;
    }

    public bool Delete(int id)
    {
        var note = _notes.FirstOrDefault(n => n.Id == id);
        if (note == null) return false;
        _notes.Remove(note);
        return true;
    }

    public List<string> GetCategories() => new() { "General", "Personal", "Work", "Study", "Ideas" };
}
