﻿using System;
using System.Net;
using System.Net.Http;
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
    public enum BaseEnum
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
            if (min > max)
                throw new RandoOrgMinGreaterThanMaxException();

            RequestAddress = new Uri(RequestAddress, "/integers");
            RequestAddress = this.FormatQueryString(min, max);
            return this;
        }

        public Uri FormatQueryString(int min, int max)
        {
            return new Uri(RequestAddress, String.Format("?num=1&min={0}&max={1}&col=1&base=10&format=plain&rnd=new", min, max));
        }

        public async Task<string> Request()
        {
            string content = String.Empty;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(RequestAddress.ToString());

                content = await response.Content.ReadAsStringAsync();
            }

            return content.Replace("\r\n", string.Empty);
        }

        public string FormatBase(BaseEnum format)
        {
            switch(format)
            {
                case BaseEnum.Binary:
                    return "base2";
                case BaseEnum.Decimal:
                    return "base10";
                case BaseEnum.Octal:
                    return "base8";
                case BaseEnum.Hexa:
                    return "base16";
                default:
                    return "base10";
            }
        }
    }
}
