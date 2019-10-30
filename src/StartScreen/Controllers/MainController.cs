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

        public static int count = 0;
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
        [HttpGet("menu")]
        public IActionResult Menu()
        {
            int count = startScreen.Menus.Count;
            var menu = new Menu { Title = "Menu " + count, Items = new List<ItemMenu>() };
            startScreen.Menus.Add(menu);
            ViewBag.Template = GenerateHtml(startScreen);
            ViewBag.Menus = startScreen.Menus;

            return View("Index");
        }
        [HttpGet("faq")]
        public IActionResult Faq()
        {
            var menu = new Menu { Title = "FAQ ", isFaq = true, Items = new List<ItemMenu>() };
            startScreen.Menus.Add(menu);
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
                 <div class="ask-question-section">
                <input id="question-input" class="ask-question-input" placeholder="Digite a sua dúvida aqui" type="text" name="question" value="" />
                <div id="click-question" class="question-image-box">
                    <div payload="question:question-input" class="question-image search-image"></div>
                </div>
            </div>
                 
                 */
                foreach (Menu menu in startScreem.Menus)
                {
                    if (menu.isFaq)
                    {

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, menuClass);
                        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, spanClass);
                        writer.RenderBeginTag(HtmlTextWriterTag.Span); // begin span
                        writer.Write(menu.Title);

                        writer.RenderEndTag(); // end input
                        writer.RenderEndTag(); // end input
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "ask-question-section");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1

                       

                        writer.AddAttribute("id", "question-input");
                        writer.AddAttribute("value", "");
                        writer.AddAttribute("placeholder", "Digite a sua dúvida aqui");
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "ask-question-input");
                        writer.RenderBeginTag(HtmlTextWriterTag.Input); // Begin input
                        writer.RenderEndTag(); // end input
                        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin div2

                        writer.AddAttribute("payload", "question:question-input");
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "question-image search-image");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin div3
                        writer.RenderEndTag(); // end div3

                        writer.RenderEndTag(); // end div2

                        writer.RenderEndTag(); // end #1
                    }
                    else
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
            }

            return stringWriter.ToString();
        }
    }
}