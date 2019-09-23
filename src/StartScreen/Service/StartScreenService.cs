using Microsoft.AspNetCore.Mvc;
using StartScreen.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartScreen.Service
{
    public class StartScreenService
    {
        public StartScreenObjects _startScreen { get; set; }

        public StartScreenService(StartScreenObjects startScreen)
        {
            _startScreen = startScreen;
        }


    }
}
