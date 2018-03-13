﻿using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Xml;

namespace Apteka.Helpers
{
    public class RusNumber
    {
        private static readonly string[] Hunds =
        {
            "", "сто ", "двести ", "триста ", "четыреста ",
            "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };

        private static readonly string[] Tens =
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };

        public static string Str(int val, bool male, string one, string two, string five)
        {
            string[] frac20 =
            {
                "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
                "семь ", "восемь ", "девять ", "десять ", "одиннадцать ",
                "двенадцать ", "тринадцать ", "четырнадцать ", "пятнадцать ",
                "шестнадцать ", "семнадцать ", "восемнадцать ", "девятнадцать "
            };

            var num = val % 1000;
            if (0 == num) return string.Empty;
            if (num < 0) throw new ArgumentOutOfRangeException(nameof(val), "Параметр не может быть отрицательным");
            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            var r = new StringBuilder(Hunds[num / 100]);

            if (num % 100 < 20)
            {
                r.Append(frac20[num % 100]);
            }
            else
            {
                r.Append(Tens[num % 100 / 10]);
                r.Append(frac20[num % 10]);
            }

            r.Append(Case(num, one, two, five));

            if (r.Length != 0) r.Append(" ");
            return r.ToString();
        }

        public static string Case(int val, string one, string two, string five)
        {
            var t = val % 100 > 20 ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return one;
                case 2:
                case 3:
                case 4: return two;
                default: return five;
            }
        }
    };

    internal struct CurrencyInfo
    {
        public bool Male;
        public string SeniorOne;
        public string SeniorTwo;
        public string SeniorFive;
        public string JuniorOne;
        public string JuniorTwo;
        public string JuniorFive;
    };

    public class RusCurrencySectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            foreach (XmlNode curr in section.ChildNodes)
            {
                if (curr.Name == "currency")
                {
                    XmlNode senior = curr["senior"];
                    XmlNode junior = curr["junior"];
                    RusCurrency.Register(
                        curr.Attributes["code"].InnerText,
                        (curr.Attributes["male"].InnerText == "1"),
                        senior.Attributes["one"].InnerText,
                        senior.Attributes["two"].InnerText,
                        senior.Attributes["five"].InnerText,
                        junior.Attributes["one"].InnerText,
                        junior.Attributes["two"].InnerText,
                        junior.Attributes["five"].InnerText);
                }
            }
            return null;
        }
    };

    public class RusCurrency
    {
        private static readonly HybridDictionary Currencies = new HybridDictionary();

        static RusCurrency()
        {
            Register("RUR", true, "рубль", "рубля", "рублей", "копейка", "копейки", "копеек");
            Register("EUR", true, "евро", "евро", "евро", "евроцент", "евроцента", "евроцентов");
            Register("USD", true, "доллар", "доллара", "долларов", "цент", "цента", "центов");
        }

        public static void Register(string currency, bool male,
            string seniorOne, string seniorTwo, string seniorFive,
            string juniorOne, string juniorTwo, string juniorFive)
        {
            CurrencyInfo info;
            info.Male = male;
            info.SeniorOne = seniorOne; info.SeniorTwo = seniorTwo; info.SeniorFive = seniorFive;
            info.JuniorOne = juniorOne; info.JuniorTwo = juniorTwo; info.JuniorFive = juniorFive;
            Currencies.Add(currency, info);
        }

        public static string Str(double val)
        {
            return Str(val, "RUR");
        }

        public static string Str(double val, string currency)
        {
            if (!Currencies.Contains(currency))
                throw new ArgumentOutOfRangeException(nameof(currency), "Валюта \"" + currency + "\" не зарегистрирована");

            var info = (CurrencyInfo)Currencies[currency];
            return Str(val, info.Male,
                info.SeniorOne, info.SeniorTwo, info.SeniorFive,
                info.JuniorOne, info.JuniorTwo, info.JuniorFive);
        }

        public static string Str(double val, bool male,
            string seniorOne, string seniorTwo, string seniorFive,
            string juniorOne, string juniorTwo, string juniorFive)
        {
            var minus = false;
            if (val < 0) { val = -val; minus = true; }

            var n = (int)val;
            var remainder = (int)((val - n + 0.005) * 100);

            var r = new StringBuilder();

            if (0 == n) r.Append("0 ");
            r.Append(n % 1000 != 0 
                ? RusNumber.Str(n, male, seniorOne, seniorTwo, seniorFive) 
                : seniorFive);

            n /= 1000;

            r.Insert(0, RusNumber.Str(n, false, "тысяча", "тысячи", "тысяч"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллион", "миллиона", "миллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллиард", "миллиарда", "миллиардов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллион", "триллиона", "триллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллиард", "триллиарда", "триллиардов"));
            if (minus) r.Insert(0, "минус ");

            r.Append(remainder.ToString("00 "));
            r.Append(RusNumber.Case(remainder, juniorOne, juniorTwo, juniorFive));

            //Делаем первую букву заглавной
            r[0] = char.ToUpper(r[0]);

            return r.ToString();
        }
    };
};