using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public static class StandardVariables
    {
        public static string CompanyName { get; set; } = "SAIRA INDUSTRIES (PVT) LTD.";
        public static int CompNo { get; set; } = 1;
        public static int BranchNo { get; set; } = 1;
        public static string BLetter { get; set; } = "L";
        public static DateTime SaveDate { get; set; } = DateTime.Now;
    }
}
