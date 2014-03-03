using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NoteDown
{
    internal enum MarkdownTag { None, FirstHeader, SecondHeader, Bold, Italic, PlainText }

    internal static class Markup
    {
        public static MarkdownTag GetStyle(string s)
        {
            if (Regex.IsMatch(s, @"^#[^#]")) return MarkdownTag.FirstHeader;
            else if (Regex.IsMatch(s, @"^#{2}[^#]")) return MarkdownTag.SecondHeader;
            else if (Regex.IsMatch(s, @"^\*{2}[^*]+\*{2}$")) return MarkdownTag.Bold;
            else if (Regex.IsMatch(s, @"^_{2}[^_]+_{2}$")) return MarkdownTag.Bold;
            else if (Regex.IsMatch(s, @"^\*[^*]+\*$")) return MarkdownTag.Italic;
            else if (Regex.IsMatch(s, @"^_[^_]+_$")) return MarkdownTag.Italic;
            else if (Regex.IsMatch(s, @"^`[^`]+`$")) return MarkdownTag.PlainText;
            else return MarkdownTag.None;
        }

        public static bool IsNumber(string s)
        {
            return Regex.IsMatch(s, @"^(-?\d+)(\.\d+)?(f|d|m|U|UL|L)?$");
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
                    fontSize *= 3;
                    fontStyle = FontStyle.Italic | FontStyle.Underline;
                    break;

                case MarkdownTag.SecondHeader:
                    fontSize *= 1.5f;
                    fontStyle = FontStyle.Bold | FontStyle.Underline;
                    break;

                case MarkdownTag.Bold:
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