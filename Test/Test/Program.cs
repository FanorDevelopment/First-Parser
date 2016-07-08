using System;
using System.IO;
using HtmlAgilityPack;
using System.Net;

namespace Test
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			string siteName = "http://kinopoisk.ru";
			WebClient client = new WebClient ();
			HtmlDocument HD = new HtmlDocument ();
			HD.LoadHtml(client.DownloadString(siteName));
			string[] ext = {".jpg", ".jpeg", ".gif", ".png"};
			Console.WriteLine("Пиздим картинки с кинопоиска? 1 - да, 2 - нет");
			int v = Convert.ToInt32(Console.ReadLine());
			if (v == 2)
				return;
			else
			{
				for (int i = 0; i <= ext.Length; i+=1)
				
				{
					GetImages(ext[i], HD, client);
				}
			}


		}

		public static void GetImages(string ext, HtmlDocument ht, WebClient cl)
		{
			string filePath = "/usr/local/parsed/";
			int r = 0;
			var nodes =	ht.DocumentNode.SelectNodes("//img");
			foreach (var a in nodes) 
			{
				if (a.Attributes["src"].Value.EndsWith(ext)) 
				{
					r += 1;
					string p = filePath + r + ext;
					cl.DownloadFile(a.Attributes["src"].Value, p);

				}
			}
		}
	}

}
