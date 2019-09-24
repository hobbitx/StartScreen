using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartScreen.Contracts
{
    public class StartScreenObjects
    {
        public List<Menu> Menus { get; set; }

        public string MainColor { get; set; }

        public string BackColor { get; set; }

        public string ButtonColor { get; set; }

        public string SelectMenu { get; set; }

        public string TextMenu { get; set; }

        public string TextSubMenu { get; set; }

        public void GeneratePayloads()
        {
            foreach (Menu menu in Menus)
            {
                foreach (ItemMenu item in menu.Items)
                {
                    item.SetPayload();
                }
            }

        }
    }
}
