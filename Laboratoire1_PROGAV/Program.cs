using System;

namespace Laboratoire1_PROGAV
{
    class Program
    {
        public const int nbTechs = 5;
        public const int tempsServiceMoyenClient= 10000;
        public const int probaArriveeClient =2;
        public const int tempsTour=1000;
        public const int probaFait=10;
        static void Main(string[] args)
        {
            HelpDesk centreAide = new HelpDesk();
            centreAide.Run();
  


        }
    }
}
