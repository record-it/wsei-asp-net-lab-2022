using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lecture_4.Models;

public class Publisher
{
    [HiddenInput]
    public int Id { get; set; }
    
    [MaxLength(length: 50, ErrorMessage = "Zbyt długa nazwa wydawnictwa")]
    public string Name { get; set; } 
    
    
    public string? Address { get; set; }

    public ISet<Book> Books { get; set; }
}