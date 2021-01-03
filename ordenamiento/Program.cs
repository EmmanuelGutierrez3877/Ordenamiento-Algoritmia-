using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            long m1=0,m2=0,m3=0,m4=0;

            for (long j = 10; j <= 100000000; j = j * 10)
            {
                m1 = 0;
                m2 = 0;
                m3 = 0;
                m4 = 0;
                for (long i = 1; i <= 10; i++)
                {
                    Arreglo ar1 = new Arreglo((int)j);
                    m1 = m1 + ar1.InsercionDirecta();
                    m2 = m2 + ar1.MetodoBurbuja();
                    m3 = m3 + ar1.ShakerShort();
                    m4 = m4 + ar1.BurbujaMejorada();
                }

                m1 = m1 / 10;
                m2 = m2 / 10;
                m3 = m3 / 10;
                m4 = m4 / 10;

                Console.Write("Tamaño del arreglo : " + j + "\n");
                Console.Write("      insercion    : " + m1 + "\n");
                Console.Write("      Burbuja      : " + m2 + "\n");
                Console.Write("    Sheker Short   : " + m3 + "\n");
                Console.Write("  Burbuja Mejorada : " + m4 + "\n\n");

            }
            Console.Read();
        }

    }

    public class Arreglo: List<long>{

        

        public Arreglo(long tam) {
            
            Random rnd = new Random();
            for (long i = 0; i < tam; i++) {
                this.Add(rnd.Next(1, (int)tam));
            }
        }

        public void imprimir() {
            for(long i = 0; i < this.Count; i++)
            {
                Console.Write(this[(int)i] + " - ");
            }
            Console.Write("\n\n");
            
        }

        public long InsercionDirecta()
        {
            long auxili;
            long j;
            long costo =0;

            for (long i = 0; i < this.Count; i++)
            {
                costo=costo+4;
                auxili = this[(int)i];
                j = i - 1;
                while (j >= 0 && this[(int)j] > auxili)
                {
                    this[(int)j + 1] = this[(int)j];
                    j--;
                    costo = costo + 4;
                }
                this[(int)j + 1] = auxili;
            }
            return costo;
        }

        public long MetodoBurbuja()
        {
            long t;
            long costo = 0;


            for (long a = 1; a < Count; a++)
            {
                costo = costo + 2;
                for (long b = Count - 1; b >= a; b--)
                {
                    costo = costo + 2;
                    if (this[(int)b - 1] > this[(int)b])
                    {
                        costo = costo + 5;
                        t = this[(int)b - 1];
                        this[(int)b - 1] = this[(int)b];
                        this[(int)b] = t;
                    }
                }
            }
            return costo;
        }

        public long ShakerShort() {
            long costo = 0;

            long n = Count-1;
            long izq = 1;
            long k = n;
            long aux;
            long der = n;

            do
            {
                for (long i = der; i >= izq; i--)
                {
                    costo=costo+2;
                    if (this[(int)i - 1] > this[(int)i])
                    {
                        costo = costo + 6;
                        aux = this[(int)i - 1];
                        this[(int)i - 1] = this[(int)i];
                        this[(int)i] = aux;
                        k = (int)i;
                    }
                }
                izq = k + 1;
                for (long i = izq; i <= der; i++)
                {
                    costo = costo + 2;
                    if (this[(int)i - 1] > this[(int)i])
                    {
                        costo = costo + 6;
                        aux = this[(int)i - 1];
                        this[(int)i - 1] = this[(int)i];
                        this[(int)i] = aux;
                        k = 1;
                    }
                }
                der = k - 1;
                costo++;
            }
            while (der >= izq);

            return costo;
        }

        public long BurbujaMejorada()
        {
            long costo = 0;

            long AUX, N, K;
            bool Bandera = false;
            N = Count;
            K = 0;
            while (Bandera == false && (K <= N - 2))
            {
                costo = costo + 4;
                Bandera = true;
                for (long J = 0; J < (N - K - 1); J++)
                {
                    costo = costo + 5;
                    if (this[(int)J] > this[(int)J + 1])
                    {
                        costo = costo + 6;
                        AUX = this[(int)J];
                        this[(int)J] = this[(int)J + 1];
                        this[(int)J + 1] = AUX;
                        Bandera = false;
                    }
                }
                K = K + 1;
            }
            
            return costo;
        }


    }

}


