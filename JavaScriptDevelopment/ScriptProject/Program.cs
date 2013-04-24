using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace ScriptProject
{
    [IgnoreNamespace]
    public class Program
    {
        public static void Main()
        {
        }

        private static void addElementToPerrent(string selector, string element)
        {
            var el = Document.CreateElement(element);
            el.TextContent = "this is new";
            var se = Document.CreateElement(selector);
            se.AppendChild(el);
        }

        public void CreateDivElements(int number)
        {
            for (int i = 0; i < number; i++)
            {
                var doc = Document.CreateElement("div");
                doc.Style.Width = Random(20, 100) + "px";
                doc.Style.Height = Random(20, 100) + "px";
                doc.Style.BackgroundColor = RandomColor();
                doc.Style.Color = RandomColor();
                doc.Style.Position =
                    GetOwnPropertyNames(typeof (Position))[int.Parse(Random(1, 4))].ToString().Replace("$1", "");

                var strong = Document.CreateElement("strong");
                strong.TextContent = "div";

                doc.AppendChild(strong);
            }
        }

        public string RandomColor()
        {
            return "rgba(" + Random(0, 255) + Random(0, 255) + Random(0, 255) + (int.Parse(Random(1, 10))/10);
        }

        public string Random(int min, int max)
        {
            return Math.Floor(Math.Random()*(max - min + 1) + min).ToString();
        }

        public enum Position
        {
            Static,
            Absolute,
            Fixed,
            Relative
        }
    }
}