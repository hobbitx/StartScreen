using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Microsoft.AspNetCore.Mvc;
using RazorEngine;
using StartScreen.Contracts;
using StartScreen.Service;

namespace StartScreen.Controllers
{
    public class MainController : Controller
    {
        public static StartScreenObjects startScreen = new StartScreenObjects();
        public readonly StartScreenService _startScreenService;
        public MainController(StartScreenService screenService)
        {
            _startScreenService = screenService;
        }

        public IActionResult Index()
        {
            var itens = new List<ItemMenu>();
            for (int i = 0; i < 4; i++)
            {
                itens.Add(new ItemMenu { Id = i, Text = "Submenu " + i });
            }

            var menus = new List<Menu>();
            menus.Add(new Menu { Id = 0, Items = itens, Title = "Menu 1" });

            menus.Add(new Menu { Id = 1, Items = new List<ItemMenu>(), Title = "Menu 2" });

            startScreen.Menus = menus;
            startScreen.Title = "Central de atendimento do cliente";

            startScreen.OfferQuestion = "Como podemos te ajudar";

            ViewBag.Menus = startScreen.Menus;
            ViewBag.Template = _startScreenService.GenerateHtml(startScreen);
            ViewBag.Title = startScreen.Title;
            ViewBag.SubTitle = startScreen.OfferQuestion;
            ViewBag.MainColor = "#d0e0e3ff";

            return View();
        }
        [HttpGet("submenu")]
        public IActionResult Submenu(int id)
        {
            int count = startScreen.Menus.ElementAt(id).Items.Count;
            startScreen.Menus.ElementAt(id).Items.Add(new ItemMenu { Id = count, Text = "Submenu" });
            recode();

            return View("Index");
        }
        [HttpGet("deletesubmenu")]
        public IActionResult DeleteSubMenu(int id, int menuId)
        {
            startScreen.Menus.ElementAt(menuId).Items.RemoveAt(id); recode();

            return View("Index");
        }
        [HttpGet("deletemenu")]
        public IActionResult DeleteMenu(int id)
        {

            startScreen.Menus.RemoveAt(id);
            recode();

            return View("Index");
        }

        [HttpGet("menu")]
        public IActionResult Menu()
        {
            int count = startScreen.Menus.Count;
            var menu = new Menu { Id = count, Title = "Menu " + (count +1), Items = new List<ItemMenu>() };
            startScreen.Menus.Add(menu);
            recode();

            return View("Index");
        }
        [HttpGet("faq")]
        public IActionResult Faq()
        {
            int count = startScreen.Menus.Count;
            var menu = new Menu { Id = count + 1, Title = "FAQ ", isFaq = true, Items = new List<ItemMenu>() };
            startScreen.Menus.Add(menu);
            recode();
            return View("Index");
        }
        [HttpGet("Offer")]
        public void Offer(string offerquestion)
        {
            startScreen.OfferQuestion = offerquestion;
            recode();
        }
        [HttpGet("Title")]
        public void Title(string title)
        {
            startScreen.Title = title;
            recode();
        }


        private void recode()
        {
            ViewBag.Template = _startScreenService.GenerateHtml(startScreen);
            ViewBag.Menus = startScreen.Menus;
            ViewBag.Title = startScreen.Title;
            ViewBag.SubTitle = startScreen.OfferQuestion;

        }
    }
}