using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratoire1_PROGAV
{
    class QueueClients
    {
        int cptClients;
        List<Client> lstClientAttente;
        private readonly object lock1;

        public QueueClients()
        {
            lock1 = new object();
            lstClientAttente = new List<Client>();
            cptClients = 0;
        }

        public void AjouterClient()
        {
            lock (lock1)
            { 
                cptClients++;
                lstClientAttente.Add(new Client(cptClients));
            }
        }

        public int RetrirerClient()
        {
            int noClient;
            lock (lock1)
            {
                if (lstClientAttente.Count > 0)
                { 
                    noClient = lstClientAttente[0].Id;
                    lstClientAttente.RemoveAt(0);
                    return noClient;
                }
                else
                {
                    return 0;
                }

            }
        }


        public int GetNbClient()
        {
            return lstClientAttente.Count;
        }

        public void AfficherClients()
        {
            for(int i=0;i<lstClientAttente.Count;i++)
            {
                Console.WriteLine("client" + lstClientAttente[i].Id + " en attente d'aide");
            }
        }

        

    }
}
