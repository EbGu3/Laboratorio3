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
            Dictionary<char, int> TablaOrdenada = new Dictionary<char, int>();
            Stack<Nodo> PilaOrdenada = new Stack<Nodo>();
            ArbolHuffman arbol = new ArbolHuffman();

            string[] Text = { "ABRACADABRA" };
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
                Temp.data.CodigoPrefijo = "";
                ListaAOrdenar.Add(Temp);
                
            }

            //Ordenando Lista Probabilidad para recorrido
            IEnumerable<Nodo> OrdenarLista = ListaAOrdenar.OrderBy(Probabilidad => Probabilidad.data.Probabilidad);
            foreach (var item in OrdenarLista)
            {
                TablaOrdenada.Add(item.data.Caracter, item.data.Frecuencia);
            }

            //Ordenando Pila Crear ArbolHuffman
            PilaOrdenada = arbol.Ordenar(ListaAOrdenar);
            arbol.CrearArbol(PilaOrdenada);

            //Obtener caracter y CodigoPrefijo Compresion

            Nodo Temp1 = new Nodo();
            Temp1 = arbol.Retornar();

            arbol.InOrden(Temp1);

            

            //Retonar el total de caracteres en el texto
             Console.WriteLine("El tamaño del texto es:" + Caracteres.ToString());
             Console.ReadLine();
        }


    }


}
