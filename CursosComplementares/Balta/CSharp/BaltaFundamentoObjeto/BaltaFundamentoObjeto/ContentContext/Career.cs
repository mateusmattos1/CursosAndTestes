using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaFundamentoObjeto.ContentContext
{
    public class Career : Content
    {
        public IList<CareerItem> Items { get; set; }
        public int TotalCourses => Items.Count; // Expression body
       
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }
    }
}
