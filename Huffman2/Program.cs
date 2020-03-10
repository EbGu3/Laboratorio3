using System;
using System.Collections.Generic;
using System.Linq;
using Huffman2.Modelos;

namespace Huffman2
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            Dictionary<char, int> TablaFrecuencia = new Dictionary<char, int>();
            List<Nodo> ListaAOrdenar = new List<Nodo>();
            Stack<Nodo> ListaOrdenada = new Stack<Nodo>();
            ArbolHuffman arbol = new ArbolHuffman();

            string[] Text = { "Cuentos que no son cuentos" };
            var i = 0;
            char[] Linea = Text[i].ToCharArray();
            var pos = 0;
            var TOTAL = 0;
            double Caracteres = 0;

            //Llenar Diccionario
            while (pos < Linea.Length)
            {
                if(TablaFrecuencia.ContainsKey(Linea[pos]) == true)
                {
                    var Frecuencia = TablaFrecuencia[Linea[pos]] + 1;
                    TablaFrecuencia.Remove(Linea[pos]);
                    TablaFrecuencia.Add(Linea[pos], Frecuencia);

                }
                else
                {
                    TablaFrecuencia.Add(Linea[pos], 1);
                }
                pos++;
                Caracteres++;
            }

            //Insertando a Lista
            foreach (var item in TablaFrecuencia)
            {
                Nodo Temp = new Nodo();
                Temp.data.Caracter = item.Key;
                Temp.data.Frecuencia = item.Value;
                Temp.data.Probabilidad = (Convert.ToDouble(item.Value) / Caracteres);
                ListaAOrdenar.Add(Temp);
                
            }
            //Ordenando LISTA Probabilidad

            //IEnumerable<Nodo> OrdenarLista = ListaAOrdenar.OrderBy(Probabilidad => Probabilidad.data.Probabilidad);
       
             
            ListaOrdenada = arbol.Ordenar(ListaAOrdenar);

            foreach (var item in ListaOrdenada)
            {
                Console.WriteLine(item.data.Caracter + " | " + item.data.Frecuencia + " | " + item.data.Probabilidad);
            }


            arbol.CrearArbol(ListaOrdenada);

            

             Console.WriteLine("El tamaño del texto es:" + Caracteres.ToString());

            //Cacular Probabilidad

            Console.ReadLine();
        }


    }


}
