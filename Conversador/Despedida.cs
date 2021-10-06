using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversador
{
    public class Despedida
    {
        public void Cdespedida()
        {
            TextoaVoz tv = new TextoaVoz();
            string[] CdespedidaEsp = { "adios", "hasta pronto", "hasta luego", "adios, que tenga bonito dia", "adios que tenga bonita noche", "hasta la proxima", "adios que le baya bien" };
            //ingles
            string[] Cdespedida = {
"bye",
"see you soon", "see you later", "goodbye, have a nice day",
 "Goodbye have a nice night", "until next time",
 "Goodbye, good luck" };
            Random r = new Random(DateTime.Now.Millisecond);
            int nAcd = r.Next(0, Cdespedida.Length);
            Console.WriteLine("Machine: {0}", Cdespedida[nAcd]);
            tv.SynthesisToSpeakerAsync(Cdespedida[nAcd]).Wait();
            Console.WriteLine("Maquina: {0}", CdespedidaEsp[nAcd]);
            
        }
    }
}

