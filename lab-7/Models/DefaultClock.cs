namespace lab_7.Views.Book;

public class DefaultClock: IClockProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }

    public DateTime Epoch()
    {
        return DateTime.UnixEpoch;
    }
}