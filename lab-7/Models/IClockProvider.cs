namespace lab_7.Views.Book;

public interface IClockProvider
{
    DateTime Now();

    DateTime Epoch();
}