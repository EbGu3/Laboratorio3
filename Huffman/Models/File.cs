using System;
using System.IO;
using System.Collections.Generic;
namespace Huffman.Models
{
    public class File
    {
        public Dictionary<char,int > TablaFrecuencia { get; set; }
        
        public void ReadFile(string Path)
        {
          

            using (StreamReader sr = new StreamReader(Path))
            {
                string[] LineLeida = new string[1];
                var position = 0;
                var Linea = 0;
                

                while (!sr.EndOfStream)
                {
                    LineLeida[Linea] = sr.ReadLine();
                    char[] character = new char[LineLeida[Linea].Length];
                    character = LineLeida[Linea].ToCharArray();

                    while(position <= character.Length)
                    {
                        if(TablaFrecuencia.ContainsKey(character[position]))
                        {
                            var Frecuencia = TablaFrecuencia[character[position]] + 1;
                            TablaFrecuencia.Remove(character[position]);
                            TablaFrecuencia.Add(character[position], Frecuencia);
                        }
                        {
                            var Frecuencia = 1;
                            TablaFrecuencia.Remove(character[position]);
                            TablaFrecuencia.Add(character[position], Frecuencia);
                        }
                    }

                }

            }
        }

        public void Calculate_Probability()
        {

        }
    }
}
