using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermillionSkate2.Models
{
    public static class AppSettings
    {
        public static string ApplicationTitle { get; set; } 

        public static string ApplicationFooter { get; set; }

        public static Contact ContactInfo { get; set; }

        public static Home HomeInfo { get; set; }

        public static About AboutInfo { get; set; }
    }

    public class Contact
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }

    public  class Home
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }

    public  class About
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }
}
