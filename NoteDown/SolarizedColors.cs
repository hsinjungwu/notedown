using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NoteDown
{
    internal static class SolarizedColors
    {
        public static Color BackGroundColor = GetColor("#002b36");
        private static Color Default = GetColor("#93a1a1");
        private static Color yellow = GetColor("#b58900");
        private static Color orange = GetColor("#cb4b16");
        private static Color red = GetColor("#dc322f");
        private static Color magenta = GetColor("#d33682");
        private static Color violet = GetColor("#6c71c4");
        private static Color blue = GetColor("#268bd2");
        private static Color cyan = GetColor("#2aa198");
        private static Color green = GetColor("#859900");

        private static Color GetColor(string s)
        {
            ColorConverter cv = new ColorConverter();
            return (Color)cv.ConvertFromString(s);
        }

        public static Color GetHightightColor(string s)
        {
            if (string.IsNullOrEmpty(s)) return SolarizedColors.Default;

            Color c = GetHightightColorByTag(s);
            if (c != Color.Black) return c;

            if (KeyWord.Contains(s)) return SolarizedColors.green;
            else return SolarizedColors.Default;
        }

        private static Color GetHightightColorByTag(string s)
        {
            MarkdownTag tag = Markup.GetStyle(s);
            switch (tag)
            {
                case MarkdownTag.FirstHeader:
                case MarkdownTag.SecondHeader:
                    return SolarizedColors.orange;

                case MarkdownTag.Bolid:
                case MarkdownTag.Italic:
                    return SolarizedColors.red;

                case MarkdownTag.PlainText:
                    return SolarizedColors.cyan;

                default:
                    return Color.Black;
            }
        }

        private static List<string> KeyWord = new List<string>
        {
            "int", "double", "decimal"
        };
    }
}