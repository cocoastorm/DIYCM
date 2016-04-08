using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmWebApi.Test.Utility
{
    public class Utility
    {
        public static void RefreshDatabase()
        {
            File.Delete("DIYCM.sqlite");
            File.Copy("DIYCM-clean.sqlite", "DIYCM.sqlite", true);
        }
    }
}
