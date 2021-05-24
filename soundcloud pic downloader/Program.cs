using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace soundcloud_pic_downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("enter soundcloud link to the music: ");
                string adress = Console.ReadLine();
                string filename;
                WebClient web = new WebClient();
                string scr = web.DownloadString(adress);

                var match = Regex.Match(scr, "\"twitter\\:image\"\\s+content=\"([^\"]+)"); // thanks  earskilla
                if (!match.Success)
                {
                    Console.WriteLine("!match.Success");
                }
                else
                {
                    string output = match.Groups[1].Value;
                    string datatime = DateTime.Now.ToString("yyyy-MM-dd");
                    filename = datatime + ".jpg";
                    web.DownloadFile(output, filename);
                    Console.Clear();
                    Console.WriteLine("pic saved " + output + " with name " + filename);
                }


            }



        }
    }
}

