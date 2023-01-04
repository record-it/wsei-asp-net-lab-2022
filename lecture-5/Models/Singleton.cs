namespace lecture_5.Models;

public class Singleton
{
    private readonly AppDBContext _context;
    public int Counter { get; set; }

    public Singleton(int init, AppDBContext context)
    {
        Counter = init;
        _context = context;
    }
    public Singleton(int init)
    {
        Counter = init;
    }
}