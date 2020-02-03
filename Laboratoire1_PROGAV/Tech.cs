using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Laboratoire1_PROGAV
{
    class Tech
    {
        private QueueClients lst;
        private Random rnd;
        public Tech(string nom)
        {
            Nom = nom;
            rnd = new Random();
            IsWorking = false;
        }

        public string Nom
        {
            get; set;
        }
        public bool IsWorking
        {
            get; set;
        }

        public int NoClient
        {
            get; set;
        }

        public void SetLstClients(QueueClients lst)
        {
            this.lst = lst;
        }
        public void Run()
        {
            while (true)
            { 
                    NoClient=lst.RetrirerClient();
                    if (NoClient != 0) { 
                    IsWorking = true;

                    int tempsService = (int)(-Program.tempsServiceMoyenClient * Math.Log(1 - rnd.NextDouble()));

                    Thread.Sleep(tempsService);

                    IsWorking = false;
                    }

            }

        }
    }
}
