using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lecture_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lecture_3.Controllers
{
    public class UserController : Controller
    {
        private static Dictionary<int, UserDetails> users = new Dictionary<int, UserDetails>()
        {
            {1, new UserDetails() {PersonId = 1, Name = "Adam", Email = "adam@wsei`.edu.pl"}},
            {2, new UserDetails() {PersonId = 2, Name = "Ewa", Email = "adam@wsei.edu.pl"}},
            {3, new UserDetails() {PersonId = 3, Name = "Karol", Email = "adam@wsei.edu.pl"}}
        };

        private static int idGen = 4;

        //grupy kolorów
        static SelectListGroup g1 = new SelectListGroup() {Name = "Jasne"};
        static SelectListGroup g2 = new SelectListGroup() {Name = "Ciemne"};

        private static UserDetails user;

        //lista elementów dla tag'a 'select', który umożliwia wybór koloru
        private static List<SelectListItem> colors = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "żółty", Value = "żółty", Selected = false, Group = g1},
            new SelectListItem() {Text = "biały", Value = "biały", Selected = false, Group = g1},
            new SelectListItem() {Text = "pomarańczowy", Value = "pomrańczowy", Selected = false, Group = g1},
            new SelectListItem() {Text = "niebieski", Value = "niebieski", Selected = true, Group = g2},
            new SelectListItem() {Text = "fioletowy", Value = "fioletowy", Selected = false, Group = g2},
            new SelectListItem() {Text = "granatowy", Value = "granatowy", Selected = false, Group = g2},
        };

        private readonly ILogger<UserController> _logger;

        // GET: User
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View(users.Values);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (users.ContainsKey(id))
            {
                return View(users[id]);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Colors = colors; //kolekcja dla pola select - wybór ulubionego koloru
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                userDetails.PersonId = idGen++;                                         //generowanie id
                users.Add(userDetails.PersonId ?? 0, userDetails);                      //powodzenie walidacji oznacza dodanie użytkwonika do kolekcji users
                return RedirectToAction(nameof(Index));                                 //powrót do listy użytkowników
            }
            _logger.Log(LogLevel.Information, userDetails.ToString());
            ViewBag.Colors = colors;                                                    //tu też nalezy przekazać kolekcję kolorów dla pola select
            return View();                                                              //ponowne wyświetlenie formularza 'Create' z danymi i komunikatami błędów
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                //TODO do uzupełnienia 
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}