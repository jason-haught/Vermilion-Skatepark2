using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermillionSkate2.Models
{
    /// <summary>
    /// Reads and Writes to Json file for Page info
    /// </summary>
    public class PagesDataModel
    {
        public string PageName { get; set; }

        public List<string> DivData { get; set; }
    }
}
