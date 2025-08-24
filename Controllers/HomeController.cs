using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spender.Models;
using Spender.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Spender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


       private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()

        {
           var expenses = _context.Expenses.ToList();
           var totalExpense = expenses.Sum(e => e.Value);
           ViewBag.TotalExpense = totalExpense;
            return View(expenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEditForm(Expense model)
        {
            if (model!= null && model.description.Length < 3)
            {
                ModelState.AddModelError("description", "Description too short!");
            }
            if(ModelState.IsValid){ 
              _context.Expenses.Add(model);
                _context.SaveChanges();
            return RedirectToAction("Expenses");
            }
            return View("CreateEditExpense", model);
        }
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
             _context.Expenses.Remove(expense);
             _context.SaveChanges();
            }
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
