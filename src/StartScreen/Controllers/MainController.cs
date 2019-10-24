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

namespace StartScreen.Controllers
{
    public class MainController : Controller
    {

        public static StartScreenObjects startScreen = new StartScreenObjects();
        public IActionResult Index()
        {
            var itens = new List<ItemMenu>();
            for (int i = 0; i < 5; i++) { itens.Add(new ItemMenu { Text = "XXXX" }); }

            var menus = new List<Menu>();
            menus.Add(new Menu { Items = itens, Title = "2ª Via" });

            menus.Add(new Menu { Items = new List<ItemMenu>(), Title = "Menu 1" });

            menus.Add(new Menu { Items = new List<ItemMenu>(), Title = "Menu 2" });

            startScreen.Menus = menus;

            startScreen.GeneratePayloads();

            ViewBag.Menus = startScreen.Menus;
            ViewBag.Template = GenerateHtml(startScreen);
            ViewBag.Title = "Central de atendimento do cliente";
            ViewBag.SubTitle = "Como podemos te ajudar";
            ViewBag.MainColor = "#d0e0e3ff";
            return View();
        }

        [HttpPost("update")]
        public IActionResult Generate([FromForm] StartScreenObjects request)
        {
            if (!String.IsNullOrEmpty(request.TextSubMenu))
            {
                var item = new ItemMenu { Text = request.TextSubMenu };
                item.SetPayload();
                startScreen.Menus.Where(x => x.Title.Equals(request.SelectMenu)).FirstOrDefault().Items.Add(item);

            }
            else
            {
                var menu = new Menu { Title = request.TextMenu, Items = new List<ItemMenu>() };
                startScreen.Menus.Add(menu);

            }

            ViewBag.Template = GenerateHtml(startScreen);
            ViewBag.MainColor = request.MainColor;
            ViewBag.Menus = startScreen.Menus;

            return View("Index");
        }
        [HttpPost("menu")]
        public IActionResult Menu(string title)
        {
            if (!String.IsNullOrEmpty(title))
            {
                var menu = new Menu { Title = title.ToString(), Items = new List<ItemMenu>() };
                startScreen.Menus.Add(menu);
            }

            ViewBag.Template = GenerateHtml(startScreen);
            ViewBag.Menus = startScreen.Menus;

            return View("Index");
        }
        public string GenerateHtml(StartScreenObjects startScreem)
        {
            StringWriter stringWriter = new StringWriter();
            var menuClass = "subjects-box";
            var spanClass = "subject-phrase";
            var itemClass = "subject-item";
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                //Generate container div control  
                /*
                  <div class="subjects-box">
                <span class="subject-phrase">MAIS FREQUENTES</span>
                <div>
                    <div class="subject-item"><span payload="Conhecer os carros">CONHECER OS CARROS</span></div>
                 
                 */
                foreach (Menu menu in startScreem.Menus)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, menuClass);
                    writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, spanClass);
                    writer.RenderBeginTag(HtmlTextWriterTag.Span); // begin span
                    writer.Write(menu.Title);
                    writer.RenderEndTag(); // end span
                    foreach (ItemMenu item in menu.Items)
                    {

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, itemClass);
                        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin div

                        writer.AddAttribute("payload", item.Payload);
                        writer.RenderBeginTag(HtmlTextWriterTag.Span);//begin span
                        writer.Write(item.Text.ToUpper());
                        writer.RenderEndTag(); // end span
                        writer.RenderEndTag(); // end div
                    }
                    writer.RenderEndTag(); // end #1
                }
            }

            return stringWriter.ToString();
        }
    }
}