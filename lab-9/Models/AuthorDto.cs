namespace lab_9.Models;

public class AuthorDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string PESEL { get; init; }

    public static AuthorDto from(Author author)
    {
        return new AuthorDto()
            {Id = author.Id, LastName = author.LastName, FirstName = author.FirstName, PESEL = author.PESEL};
    }
}