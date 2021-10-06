using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversador
{
    public class Comida
    {
        public void respcomida()
        {
            ReconocimientoVoz rv = new ReconocimientoVoz();
            TextoaVoz tv = new TextoaVoz();
            //Generador de numeros Aleatorios
            Random r = new Random(DateTime.Now.Millisecond);

            //leer datos de un txt para llenar el arreglo
            System.IO.StreamReader filep = new System.IO.StreamReader(@"comidaPreg.txt");
            string x = filep.ReadToEnd();
            string[] vectorPComida = x.Split(new char[] { '\n' });

            System.IO.StreamReader filepes = new System.IO.StreamReader(@"comidaPregEs.txt");
            string xx = filepes.ReadToEnd();
            string[] vectorPComidaEs = xx.Split(new char[] { '\n' });

            //vector respuestas
            System.IO.StreamReader filer = new System.IO.StreamReader(@"comidaResp.txt");
            string y = filer.ReadToEnd();
            string[] vectorRComida = y.Split(new char[] { '\n' });

            System.IO.StreamReader fileres = new System.IO.StreamReader(@"comidaRespEs.txt");
            string yy = fileres.ReadToEnd();
            string[] vectorRComidaEs = yy.Split(new char[] { '\n' });

            string flag = "0";
            string Conv;
            Console.WriteLine("=============================================================================");
            Console.WriteLine("WELCOME TO YOUR TRAVEL CONVERSER // BIENVENIDO A SU CONVERSADOR SOBRE COMIDA");
            Console.WriteLine("=============================================================================");

            string[] CdespedidaEsp = { "adios", "hasta pronto", "hasta luego", "adios, que tenga bonito dia", "adios que tenga bonita noche", "hasta la proxima", "adios que le baya bien" };

            string[] Cdespedida = { "Bye.",
"See you soon.", "See you later.", "Goodbye have a nice day.",
 "Goodbye have a nice night.", "Until next time.",
 "Goodbye good luck.","Goodbye." };
            do
            {
                //preguntas
                int nAvPC = r.Next(0, vectorPComida.Length);
                Console.WriteLine("Machine: {0}", vectorPComida[nAvPC]);
                tv.SynthesisToSpeakerAsync(vectorPComida[nAvPC]).Wait();
                Console.WriteLine("Maquina: {0}", vectorPComidaEs[nAvPC]);
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
                int nAvRC = r.Next(0, vectorRComida.Length);
                Console.WriteLine("Machine: {0}", vectorRComida[nAvRC]);
                tv.SynthesisToSpeakerAsync(vectorRComida[nAvRC]).Wait();
                Console.WriteLine("Maquina: {0}", vectorRComidaEs[nAvRC]);
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

