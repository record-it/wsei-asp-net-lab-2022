namespace lab_9.Models;

public interface IStickyNotesService
{
    public StickyNoteEntity FindOneByUrl(String url);
    public StickyNoteEntity FinOneById(int id);
    public List<StickyNoteEntity> FindAll();
    public List<StickyNoteEntity> FindPage(int page, int size);
    public bool Create(StickyNoteEntity entity);
    public bool DeleteById(int id);
    public bool ChangeExpiration(DateTime expiration, int i);
}