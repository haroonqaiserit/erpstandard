using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    public class tblUOMViewModel
    {
        public List<tblUOM> UOM { get; set; }
        public Pager Pager { get; set; }
        public string dtSearch { get; set; }
        public int clmNameOrder { get; set; }
    }
}
