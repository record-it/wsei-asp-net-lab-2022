namespace lab_9.Models;

public interface IClockProvider
{
    DateTime Now();

    DateTime Epoch();
}