using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Conversador
{
    public class Familia
    {
        public void respfamilia()
        {
            ReconocimientoVoz rv = new ReconocimientoVoz();
            TextoaVoz tv = new TextoaVoz();
            //Generador de numeros Aleatorios
            Random r = new Random(DateTime.Now.Millisecond);

            //leer datos de un txt para llenar el arreglo
            StreamReader filep = new StreamReader(@"familiaPreg.txt");
            string x = filep.ReadToEnd();
            string[] vectorPFamilia = x.Split(new char[] { '\n' });

            StreamReader filepes = new StreamReader(@"familiaPregEs.txt");
            string xx = filepes.ReadToEnd();
            string[] vectorPFamiliaEs = xx.Split(new char[] { '\n' });
            //vector respuestas

            StreamReader filer = new StreamReader(@"familiaResp.txt");
            string y = filer.ReadToEnd();
            string[] vectorRFamilia = y.Split(new char[] { '\n' });

            StreamReader fileres = new StreamReader(@"familiaRespEs.txt");
            string yy = fileres.ReadToEnd();
            string[] vectorRFamiliaEs = yy.Split(new char[] { '\n' });

            string flag = "0";
            string Conv;
            Console.WriteLine("=============================================================================");
            Console.WriteLine("WELCOME TO YOUR TRAVEL CONVERSER // BIENVENIDO A SU CONVERSADOR SOBRE FAMILIA");
            Console.WriteLine("=============================================================================");
            string[] CdespedidaEsp = { "adios", "hasta pronto", "hasta luego", "adios, que tenga bonito dia", "adios que tenga bonita noche", "hasta la proxima", "adios que le baya bien" };

            string[] Cdespedida = { "Bye.",
"See you soon.", "See you later.", "Goodbye have a nice day.",
 "Goodbye have a nice night.", "Until next time.",
 "Goodbye good luck.","Goodbye." };

            do
            {
                //preguntas
                int nAvPF = r.Next(0, vectorPFamilia.Length);
                Console.WriteLine("Machine: {0}", vectorPFamilia[nAvPF]);
                tv.SynthesisToSpeakerAsync(vectorPFamilia[nAvPF]).Wait();
                Console.WriteLine("Maquina: {0}", vectorPFamiliaEs[nAvPF]);
                Console.Write("User: ");
                rv.RecognizeSpeechAsync().Wait();
                Conv = rv.Conv;
                //Console.Write("Usuario: ");

                for (int i = 0; i < Cdespedida.Length; i++)
                    if (Conv == Cdespedida[i])
                    {
                        flag = "1";
                        Despedida des = new Despedida();
                        des.Cdespedida();
                    }

                //respuestas
                int nAvRF = r.Next(0, vectorRFamilia.Length);
                Console.WriteLine("Machine: {0}", vectorRFamilia[nAvRF]);
                tv.SynthesisToSpeakerAsync(vectorRFamilia[nAvRF]).Wait();
                Console.WriteLine("Maquina: {0}", vectorRFamiliaEs[nAvRF]);
                Console.Write("User: ");
                rv.RecognizeSpeechAsync().Wait();
                Conv = rv.Conv;
                //Console.Write("Usuario: ");

                for (int i = 0; i < Cdespedida.Length; i++)
                    if (Conv == Cdespedida[i])
                        flag = "1";
            }
            while (flag == "0");
            Despedida desp = new Despedida();
            desp.Cdespedida();
        }
    }
}
