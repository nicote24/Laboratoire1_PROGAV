using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratoire1_PROGAV
{
    class Client
    {
        int id;

        public Client(int id)
        {
            this.id = id;
        }

        public int Id { get { return id; } }
    }
}
