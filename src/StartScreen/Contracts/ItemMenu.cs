using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartScreen.Contracts
{
    public class ItemMenu
    {
        public string Text { get; set; }

        public string Payload { get; set; }

        public void SetPayload()
        {
           
            this.Payload = this.Text;

        }
    }
}
