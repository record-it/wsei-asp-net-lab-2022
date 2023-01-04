namespace lab_9.Models;

public class CategoryEntity
{
    public int Id { get; set; }
    
    public String Title { get; set; } 
    
    public ISet<StickyNoteEntity> StickyNotes { get; set; }
}