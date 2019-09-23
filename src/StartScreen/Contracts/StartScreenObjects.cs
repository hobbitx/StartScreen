using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartScreen.Contracts
{
    public class StartScreenObjects
    {
        public Menu[] Menus { get; set; }

        public void GeneratePayloads()
        {
            foreach(Menu menu in Menus)
            {
                foreach(ItemMenu item in menu.Items)
                {
                    item.SetPayload();
                }
            }

        }
    }
}
