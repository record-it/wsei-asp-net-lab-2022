using Microsoft.AspNetCore.Identity;

namespace lab_9.Models;

public class StickyNoteEntity
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime Created { get; set; }
    
    public String Url { get; set; }
    
    public DateTime Expiration { get; set; }
    
    public IdentityUser User { get; set; }
    
    public ISet<TagEntity> Tags { get; set; }
    
    public CategoryEntity Category { get; set; }
}