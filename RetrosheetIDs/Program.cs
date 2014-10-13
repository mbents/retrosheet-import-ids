using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace RetrosheetIDs
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataString;
            var webClient = new WebClient();
            using (var stream = webClient.OpenRead("http://www.retrosheet.org/retroID.htm"))
            {
                using (var sReader = new StreamReader(stream))
                {
                    string html = sReader.ReadToEnd();
                    // Get only the string between the <pre> tags and remove whitespace
                    dataString = html.Substring(html.IndexOf("<pre>") + 5, (html.IndexOf("</pre>") - html.IndexOf("<pre>") - 5)).Trim();
                }
            }

            var stringArray = dataString.Split(new char[] { '\n' });
            var list = new List<string>();
            bool firstLine = true;
            foreach (var line in stringArray)
            {
                if (firstLine)
                {
                    list.Add(line);
                    firstLine = false;
                }
                else
                {
                    var lineArray = line.Split(new char[] { ',' });
                    StringBuilder formattedLine = new StringBuilder();
                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        string item = lineArray[i];
                        if (i == 3)
                        {
                            var date = Convert.ToDateTime(item);
                            // Debut date needs to be in this format to import into MySQL database
                            item = string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
                        }
                        else
                            item = string.Format("{0},", item);
                        formattedLine.Append(item);
                    }
                    list.Add(formattedLine.ToString());
                }
            }
            File.WriteAllLines("C:\\retrosheet\\ids\\rs_ids.csv", list);
        }
    }
}
