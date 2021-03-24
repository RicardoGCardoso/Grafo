﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Aresta
    {
        public string NomeAresta { get; set; }
        public Vertice No1 { get; }
        public Vertice No2 { get; }

        public Aresta(Vertice no1, Vertice no2, string Nome)
        {
            this.NomeAresta = Nome;
            No1 = no1;
            no1.Atribuir(this);
            No2 = no2;
            no2.Atribuir(this);
        }

        public static Aresta Criar(Vertice node1, Vertice node2, string Nome)
        {
            return new Aresta(node1, node2, Nome);
        }
    }
}
