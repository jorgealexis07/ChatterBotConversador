using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversador
{
    public class MenuSelector
    {
        public void Menu()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            Comida objc = new Comida();
            Familia objf = new Familia();
            Viajes objv = new Viajes();

            Console.WriteLine("Random selection on the topic to talk: // Seleccion aleatoria sobre el tema a charlar:");
            int nRs = r.Next(1, 3);
            //menu selector
            if (Convert.ToString(nRs) == "1")
            {
                objf.respfamilia();
            }
            else if (Convert.ToString(nRs) == "2")
            {
                objv.respviajes();
            }
            else if (Convert.ToString(nRs) == "3")
            {
                objc.respcomida();
            }
        }
    }
}
