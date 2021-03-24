using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Vertice
    {
        public string Nome { get; }

        public Vertice(string Nome)
        {
            this.Nome = Nome;
        }

        readonly List<Aresta> _Arestas = new List<Aresta>();

        public void Atribuir(Aresta no)
        {
            _Arestas.Add(no);
        }


        public IEnumerable<Aresta> Arestas => _Arestas;

        public void ConectarArestas(Vertice n_vertice, string NomeAresta)
        {
            Aresta.Criar(n_vertice, this, NomeAresta);
        }
    }
}
