using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lecture_3.Models;
public class UserDetails{
    [HiddenInput]
    public int? PersonId { get; set; }                                          //wartości przyjmujące null są  domyślnie pomijane w walidacji
    
    [Display(Name = "Imię")]                                                    //Łańcuch etykiety nad polem 
    [Required(ErrorMessage= "Musisz podać imię")]                               //pole nie może być null i łańcuch nie może być pusty
    [MinLength(3, ErrorMessage = "Musi mieć co najmnieć trzy znaki")]           
    public string Name { get; set; }
    
    [EmailAddress]
    [Display(Name = "Adres email")]
    [DataType(DataType.EmailAddress)]                                              
    public String Email { get; set; }
    
    [Display(Name = "Hasło")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "Telefon")]
    [DataType(DataType.PhoneNumber)]
    public string Telephone { get; set; }
    
    [Display(Name="Data urodzin")]
    [DataType(DataType.Date)]                                                      //w formularzu  będzie można wpisać tylko datę     
    public DateTime DateOfBirth { get; set; }
    [Display(Name = "Pensja")]
    [DataType(DataType.Currency)]                                               
    [Range(minimum:0, maximum: 100_000)]                                           //zakres poprawnych wartości 
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]     //wartość z dwoma miejscami po przecinku
    public decimal Salary { get; set; }
    
    [Url]
    [Display(Name = "Strona WWW")]
    public string? Website { get; set; }
    
    [Display(Name="Czy akceptujesz spam?")]
    public bool SendSpam { get; set; }                                              //typ bool utworzy w formularzu pole typu checkbox 
    
    [Display(Name = "Liczba kotów")]
    public int? NumberOfCats { get; set; }                                          //pole ocpcjonalne, walidator zaakceptuje null w tym polu
    
    [Display(Name = "Ulubiony kolor")]
    public IEnumerable<string> FavoriteColor { get; set; }                          //dla pola typu IEnumarable tag select będzie miał atrybut 'multiple' - wielokrotny wybór
    
    public IFormFile? Selfie { get; set; }                                          //pole opcjonalne, walidator zaakceptuje null w tym polu

    public override string ToString()
    {
        return $"{nameof(PersonId)}: {PersonId}, {nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(Telephone)}: {Telephone}, {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(Salary)}: {Salary}, {nameof(Website)}: {Website}, {nameof(SendSpam)}: {SendSpam}, {nameof(NumberOfCats)}: {NumberOfCats}, {nameof(FavoriteColor)}: {FavoriteColor}, {nameof(Selfie)}: {Selfie}";
    }
}

