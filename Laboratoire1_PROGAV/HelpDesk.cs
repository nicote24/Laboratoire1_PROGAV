using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratoire1_PROGAV
{
    class HelpDesk
    {
        Random rnd;
        private string[] noms = { "Alice", "Bob", "Charlie", "Diane", "Eve" };
        List<Tech> techs;
        QueueClients clients;
        private static IWebProxy _webproxy;
        string fait;

        public HelpDesk()
        {
            rnd = new Random();
            clients = new QueueClients();
            CreerTechs();
            fait = "";
        }




        public void CreerTechs()
        {
            techs = new List<Tech>();
            for(int i = 0; i < Program.nbTechs; i++)
            {
                techs.Add(new Tech(noms[i]));
                techs[i].SetLstClients(clients);
                Thread thread = new Thread(new ThreadStart(techs[i].Run));
                thread.Start();
            }
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(Program.tempsTour);

                if (rnd.Next(1, Program.probaArriveeClient + 1) == 1)
                    clients.AjouterClient();
                if(rnd.Next(1,Program.probaFait+1)==2)
                    HttpGetAsync(@"http://numbersapi.com/");

                Affichage();
            }
        }

        public void Affichage()
        {
            Console.Clear();
            Console.WriteLine("LES TECHNICIENS :");
            Console.WriteLine("");
            foreach(Tech techinicien in techs)
            {
                if (techinicien.IsWorking == true)
                {
                    Console.WriteLine("Le technicien " + techinicien.Nom + " est présentement avec le client" + techinicien.NoClient);
                }
                else
                {
                    Console.WriteLine("le Technicien "+techinicien.Nom+" est libre");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("LISTE DES CLIENTS");
            Console.WriteLine("");
            clients.AfficherClients();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("fait divers :   " + fait);
          
        }

        public async Task HttpGetAsync(string url, Encoding encoding = null)
        {
            var wc = new WebClient
            {
                Proxy = _webproxy,
                Encoding = encoding ?? Encoding.UTF8
            };
            //if (encoding != null)
            //{
            //    wc.Encoding = encoding;
            //}
            fait =await wc.DownloadStringTaskAsync(url+"/"+ rnd.Next(1, 100));
        }



    }
}
