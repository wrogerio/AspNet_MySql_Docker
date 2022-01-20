using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlNet.Models;

namespace MySqlNet.Controllers
{
    public class HomeController : Controller
    {
        private ProdContext _context;

        public HomeController(ProdContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var prod = _context.Produtos.ToList();
            return View(prod);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
