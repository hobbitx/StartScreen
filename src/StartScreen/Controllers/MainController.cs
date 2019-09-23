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
        public IActionResult Index()
        {
            StartScreenObjects startScreem = new StartScreenObjects();
            var itens = new ItemMenu[1];
            itens[0] = new ItemMenu { Text = "Anime chan" };
            var menus = new Menu[1];
            menus[0] = new Menu { Items = itens, Title = "Teste" };

            startScreem.Menus = menus;

            startScreem.GeneratePayloads();

           var x=  GenerateHtml(startScreem);
            ViewBag.Template = x;

            return View();
        }

        [HttpPost]
        public IActionResult Generate([FromForm] StartScreenObjects startScreem)
        {
            var itens = new ItemMenu[1];
            itens[0] = new ItemMenu { Text = "Anime chan" };
            var menus = new Menu[1];
            menus[0] = new Menu { Items = itens, Title = "Teste" };

            startScreem.Menus = menus;

            startScreem.GeneratePayloads();

            GenerateHtml(startScreem);


            return View();
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
                    foreach (ItemMenu item in menu.Items) {

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