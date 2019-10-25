using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartScreen.Contracts
{
    public class Menu
    {
        public string Title { get; set; }

        public List<ItemMenu> Items { get; set; }

        public bool isFaq { get; set; }

    }
}
