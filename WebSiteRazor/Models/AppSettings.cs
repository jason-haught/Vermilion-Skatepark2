using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VermillionSkatePark.Models
{
    public enum ConnectionStringNames : long
    {
        PagesDataContextSQL = 0,
        PagesDataContextSQLLite = 1
    }

    public sealed class AppSettings
    {
        private static readonly Lazy<AppSettings> _lazyInstance =
            new Lazy<AppSettings>(() => new AppSettings());

        public static AppSettings Instance
        {
            get
            {
                return _lazyInstance.Value;
            }
        }

        public string ApplicationTitle { get; set; }

        public string ApplicationFooter { get; set; }

        public Contact ContactInfo { get; set; }

        public Home HomeInfo { get; set; }

        public About AboutInfo { get; set; }

        public Dictionary<ConnectionStringNames, string> ConnectionStrings { get; set; }

        private AppSettings()
        {
        }
    }

    public class Contact
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }

    public class Home
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }

    public class About
    {
        public string Title { get; set; }

        public string Message { get; set; }
    }
}