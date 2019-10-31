using Microsoft.AspNetCore.Mvc;
using StartScreen.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;

namespace StartScreen.Service
{
    public class StartScreenService
    {

        private string menuClass = "subjects-box";
        private string spanClass = "subject-phrase";
        private string itemClass = "subject-item";
        public StartScreenService()
        {
        }

        public string GenerateHtml(StartScreenObjects startScreen)
        {

            startScreen.GeneratePayloads();
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                foreach (Menu menu in startScreen.Menus)
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

        public string ExportHtml(StartScreenObjects startScreen)
        {

            startScreen.GeneratePayloads();
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                foreach (Menu menu in startScreen.Menus)
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
