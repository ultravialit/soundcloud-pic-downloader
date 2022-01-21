using System;
using System.Net;
using System.Text.RegularExpressions;

namespace soundcloud_pic_downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 75;
            int number = 0;
            string filename;
            while (true)
            {
                Console.Write("enter soundcloud/weheartit link: ");
                string adress = Console.ReadLine();
                if (adress != "")
                {
                    using (WebClient web = new WebClient())
                    {
                        try
                        {
                            string scr = web.DownloadString(adress);
                            var match = Regex.Match(scr, "\"twitter\\:image\"\\s+content=\"([^\"]+)");
                            if (!match.Success)
                            {
                                Console.WriteLine("Failed to get data link");
                            }
                            else
                            {
                                number++;
                                string output = match.Groups[1].Value;
                                string datatime = DateTime.Now.ToString("yyyy-MM-dd");
                                filename = "[" + number + "] " + datatime + ".jpg";
                                web.DownloadFile(output, filename);
                                Console.Clear();
                                Console.WriteLine("pic saved with name " + filename);
                            }
                        }
                        catch (WebException)
                        {
                            Console.WriteLine("ohh sorry, we can't download your link, maybe some invalid link provided?");
                        }

                    };

                }
                else
                {
                    Console.WriteLine("Your link is empty, try again");
                }

            }

        }
    }
}

