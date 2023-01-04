namespace lab_9.Models;

public class TagEntity
{
    public int Id { get; set; }
    
    public string TagName { get; set; }
    
    public ISet<StickyNoteEntity> StickyNotes { get; set; }
}