using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NoteDown
{
    internal enum MarkdownTag { None, FirstHeader, SecondHeader, Bolid, Italic, PlainText }

    internal static class Markup
    {
        public static MarkdownTag GetStyle(string s)
        {
            if (Regex.IsMatch(s, @"^#[^#]")) return MarkdownTag.FirstHeader;
            else if (Regex.IsMatch(s, @"^#{2}[^#]")) return MarkdownTag.SecondHeader;
            else if (Regex.IsMatch(s, @"^\*{2}.+\*{2}$")) return MarkdownTag.Bolid;
            else if (Regex.IsMatch(s, @"^\*[^*].+[^*]\*$")) return MarkdownTag.Italic;
            else if (Regex.IsMatch(s, @"^`.+`")) return MarkdownTag.PlainText;
            else return MarkdownTag.None;
        }

        public static Font GetFont(string s)
        {
            string fontFamily = "Consolas";
            float fontSize = 14;
            GraphicsUnit gu = GraphicsUnit.Point;

            FontStyle fontStyle = FontStyle.Regular;
            MarkdownTag style = GetStyle(s);

            switch (style)
            {
                case MarkdownTag.FirstHeader:
                    fontSize = 30;
                    break;

                case MarkdownTag.SecondHeader:
                    fontSize = 20;
                    break;

                case MarkdownTag.Bolid:
                    fontStyle = FontStyle.Bold;
                    break;

                case MarkdownTag.Italic:
                    fontStyle = FontStyle.Italic;
                    break;

                default:
                    break;
            }
            return new Font(fontFamily, fontSize, fontStyle, gu);
        }
    }
}