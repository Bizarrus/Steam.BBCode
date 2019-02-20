using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Steam.BBCode.Components;

namespace Steam.BBCode {
    public class BBCode {
        private List<Component> components;

        public BBCode() {
            this.components = new List<Component>();
        }

        internal List<Component> Parse(string code) {
            bool opened = false;
            bool tag = false;
            List<string> res = new List<string>();

            char[] data = code.ToCharArray();
            List<char> str = new List<char>();

            for (int position = 0; position < data.Length; position++) {
                if (data[position] == '[') {
                    string result = "";
                    foreach (char c in str) {
                        result += c;
                    }
                    res.Add(result);
                    str = new List<char>();

                    opened = true;
                    string bbcode = "";
                    string cont = "";

                    for (; position < data.Length; ) {
                        if (data[position] == ']') {
                            opened = false;
                            tag = true;
                            bbcode += data[position++];
                            break;
                        }

                        bbcode += data[position];
                        ++position;
                    }

                    if (tag) {
                        int taglength = bbcode.Length - 1;

                        for (; position < data.Length;) {
                            if (data[position] == '[' && data[position + 1] == '/') {
                                tag = false;
                                position += taglength + 3;
                                break;
                            }

                            cont += data[position];
                            ++position;
                        }
                    }

                    res.Add(bbcode + cont);
                }

                if (position < data.Length) {
                    str.Add(data[position]);
                }
            }

            foreach (string a in res) {
                if (a.Trim().Length == 0) {
                    continue;
                }

                Regex regex = new Regex("\\[(\\w+)(?:[= ]([^\\]]+))?]((?:.|[\r\n])*?)"); //\\[/\\1]
                MatchCollection results = regex.Matches(a);

                if (!regex.IsMatch(a)) {
                    this.ParseComponent(null, null, a);
                } else {
                    foreach (Match match in results) {
                        this.ParseComponent(match.Groups[1].Value, null, a.Replace("[" + match.Groups[1].Value  + "]", ""));
                    }
                }
            }

            return this.components;
        }

        private void ParseComponent(string tag, string attributes, string value) {
            value               = this.FormatHTML(value);

            if (tag != null) {
                tag = tag.ToLower();
            }

            Component element   = null;

            switch (tag) {
                case "u":
                    element = new Underline();
                    break;
                case "i":
                    element = new Italic();
                    break;
                case "b":
                    element = new Bold();
                    break;
                case "strike":
                    element = new Strike();
                    break;
                case "h1":
                    element = new Title();
                    break;
                case "url":
                    element = new URL();
                    break;
                case "spoiler":
                    element = new Spoiler();
                    break;
                case "noparse":
                    element = new NoParse();
                    break;
                case "code":
                    element = new Code();
                    break;
                case "quote":
                    element = new Quote();
                    break;
                case "olist":
                    element = new List();
                    break;
                case "list":
                    element = new List();
                    break;
                case "img":
                    element = new Image();
                    break;
                default:
                    element = new PlainText();
                    break;
            }

            if (element != null) {
                element.Create(value, attributes);
                /*if (global.options.newLine) {
                    result = result.toString().replace(/\r ?\n / g, '<br />')
        
                   }*/
                this.components.Add(element);
            }
        }

        private string FormatHTML(string value) {
            value = Regex.Replace(value, @"&", "&amp;");
            value = Regex.Replace(value, @"<", "&lt;");
            value = Regex.Replace(value, @">", "&gt;");
            value = Regex.Replace(value, "\"", "&quot;");

            return value;
        }

        private string ReplaceEnds(string value) {
            string[] search = new string[] {
                "[/h1]",
                "[/b]",
                "[/u]",
                "[/i]",
                "[/strike]",
                "[/spoiler]",
                "[/noparse]",
                "[/url]",
                "[/list]",
                "[/olist]",
                "[/quote]",
                "[/code]",
            };

            foreach (string s in search) {
                value = Regex.Replace(value, s, @"");
            }

            return value;
        }
    }
}
