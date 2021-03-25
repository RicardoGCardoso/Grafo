using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Grafo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] MatrizAdjacencia;
            int count = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            List<Vertice> _verticesGrafo = new List<Vertice>();
            List<string> _TodasArestas = new List<string>();
            string[] lines = System.IO.File.ReadAllLines("Arquivo.txt");
            foreach (string line in lines)
            {
                _TodasArestas.Add(line.ToArray()[3].ToString());
                if (_verticesGrafo.Where(x => x.Nome == line.ToArray()[0].ToString()).FirstOrDefault() == null)
                {
                    Vertice novo = new Vertice(line.ToArray()[0].ToString());
                    _verticesGrafo.Add(novo);
                }
                if (_verticesGrafo.Where(x => x.Nome == line.ToArray()[5].ToString()).FirstOrDefault() == null)
                {
                    _verticesGrafo.Add(new Vertice(line.ToArray()[5].ToString()));
                }
                count++;
            }

            MatrizAdjacencia = new int[count, count];


            Console.WriteLine("TODOS OS VÉRTICES DO GRAFO!");
            foreach (Vertice obj in _verticesGrafo)
            {
                Console.WriteLine(obj.Nome);
            }
            
            foreach (string line in lines)
            {
                Vertice no = _verticesGrafo.Where(x => x.Nome == line.ToArray()[0].ToString()).FirstOrDefault();
                Vertice no2 = _verticesGrafo.Where(x => x.Nome == line.ToArray()[5].ToString()).FirstOrDefault();
                if (no.Arestas.Where(y => y.No1.Nome == no.Nome && y.No2.Nome == no2.Nome).FirstOrDefault() == null)
                {
                    no.ConectarArestas(no2, line.ToArray()[3].ToString(), Convert.ToInt32(line.ToArray()[3].ToString()));
                }
                else if (no2.Arestas.Where(y => y.No1.Nome == no.Nome && y.No2.Nome == no2.Nome).FirstOrDefault() == null)
                    no2.ConectarArestas(no, line.ToArray()[3].ToString(), Convert.ToInt32(line.ToArray()[3].ToString()));
            }
            //------------------------------------------------------------------------------------
            // MATRIZ DE ADJACENCIA
            //------------------------------------------------------------------------------------
            Console.WriteLine("\n\tMATRIZ DE ADJACÊNCIA");
            foreach (Vertice obj in _verticesGrafo)
                Console.Write("\t" + obj.Nome);
            Console.WriteLine("\n");

            int i = 0, j = 0;
            foreach (Vertice obj in _verticesGrafo)
            {
                Console.Write(obj.Nome);
                foreach (Vertice second in _verticesGrafo)
                {
                    Aresta aux = obj.Arestas.Where(x => x.No1.Nome == second.Nome || x.No2.Nome == second.Nome).FirstOrDefault();
                    if (aux != null && obj.Nome != second.Nome)
                    {
                        MatrizAdjacencia[i, j] = aux.Peso;
                        Console.Write("\t1");
                    }
                    else
                    {
                        MatrizAdjacencia[i, j] = 0;
                        Console.Write("\t0");
                    }
                    aux = null;
                    j++;
                }
                i++;
                j = 0;
                Console.WriteLine("\n");
            }

            //------------------------------------------------------------------------------------
            // MATRIZ DE INCIDÊNCIA
            //------------------------------------------------------------------------------------
            Console.WriteLine("\n\tMATRIZ DE INCIDÊNCIA");
            Console.Write(" ");
            foreach (string obj in _TodasArestas)
                Console.Write(" " + obj);
            Console.WriteLine("\n");
            foreach (Vertice obj in _verticesGrafo)
            {
                Console.Write(obj.Nome);
                foreach (string second in _TodasArestas)
                {
                    if (obj.Arestas.Where(x => x.NomeAresta == second).FirstOrDefault() != null)
                        Console.Write(" S");
                    else
                        Console.Write(" N");
                }
                Console.WriteLine("\n");
            }


            Vertice _GrauMaior = _verticesGrafo.OrderByDescending(y => y.Arestas.Count()).FirstOrDefault();
            Console.WriteLine("VÉRTICE DE MAIOR GRAU: " + _GrauMaior.Nome + "\n");
            
            //Console.WindowHeight = 800;
            
            foreach (Vertice obj in _verticesGrafo)
            {
                Console.Write(obj.Nome + " - GRAU: "+ obj.Arestas.Count() +" - VIZINHO: ");
                foreach (Aresta _aresta in obj.Arestas)
                {
                    if(_aresta.No2.Nome != obj.Nome)
                        Console.Write("\t" + _aresta.No2.Nome);
                    else
                        Console.Write("\t" + _aresta.No1.Nome);
                }
                Console.WriteLine("\n");
            }
            
            for(int a = 0; a < count; a++)
            {
                for(int b = 0; b < count; b++)
                {
                    Console.Write("\t" + MatrizAdjacencia[a, b]);
                }
                Console.Write("\n");
            }

            Dijkstra minimo = new Dijkstra();
            minimo.TotalVertices = count-1;
            minimo.Calcular(MatrizAdjacencia, 0, count-1);

            Console.ReadLine();
            //Console.Write(obj.Nome + " - " + obj.Arestas.f);
            //Console.WriteLine("VIZINHOS: ")

            /**
             *      1       3
             * A ------ e ---C
             * |        |   /
             * | 6    4 |  /2
             * |        | /
             * B------- D/
             *      8
             *      
             *      A = 0
             *      E = 1
             *      B = 2
             *      D = 3
             *      C = 4
             *      
             **/
        }
    }
}
