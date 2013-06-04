using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Randomizer.Utils
{
    public enum RandomOrgV1Base
    {
        Binary,
        Octal,
        Decimal,
        Hexa
    }

    public class RandomOrgV1
    {
        public Uri RequestAddress { get; set; }

        public RandomOrgV1()
        {
            RequestAddress = new Uri("http://random.org/");
        }

        public RandomOrgV1 IntegerRequest(int min, int max)
        {
            RequestAddress = new Uri(RequestAddress, "/integers");
            RequestAddress = new Uri(RequestAddress, FormatQueryString(min, max));
            return this;
        }

        protected Uri FormatQueryString(int min, int max)
        {
            return new Uri(String.Format("/?num=1&min={0}&max={1}&col=1&base=10&format=plain&rnd=new", min, max));
        }

        public Task<string> Request()
        {
            return null;
        }

        public string FormatBase(RandomOrgV1Base format)
        {
            switch(format)
            {
                case RandomOrgV1Base.Binary:
                    return "base2";
                case RandomOrgV1Base.Decimal:
                    return "base10";
                case RandomOrgV1Base.Octal:
                    return "base8";
                case RandomOrgV1Base.Hexa:
                    return "base16";
                default:
                    return "base10";
            }
        }
    }
}
