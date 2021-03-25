using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Dijkstra
    {

        public int TotalVertices = 9;

        private void VisualizarSolucao(int[] dist, int n)
        {
            Console.Write("DISTÂNCIA MINIMA\n");
            for (int i = 0; i < TotalVertices; i++)
            {
                Console.Write(i + " \t" + dist[i] + "\n");
            } 
        }

        private int CalcularDistanciaMinima(int[] dist, bool[] inclusoMenor)
        {
            // CONSIDERA O CUSTO MINIMO COMO O VALOR MÁXIMO ACEITADO POR UM INTEIRO
            int custoMinimo = int.MaxValue;
            int minimoIndex = -1;
            for (int v = 0; v < TotalVertices; v++)
            {
                // VERIFICA O VERTICE AINDA NÃO FOI PERCORRIDO COM O CONDICIONAL == FALSE E
                // VERIFICA SE A DISTANCIA DO VERTICE É MENOR DO QUE 
                if (inclusoMenor[v] == false && dist[v] <= custoMinimo)
                {
                    custoMinimo = dist[v]; // SETA A NOVA DISTÂNCIA COMO CUSTO MINIMO
                    minimoIndex = v; // SALVA O VERTICE EQUIVALENTE
                }
            }
            return minimoIndex;
        }

        

        public void Calcular(int[,] grafoAnalizado, int inicio, int Tamanho)
        {
            // ARRAY UTILIZADO PASA SALVAR A MENOR DISTÂNCIA DA
            // FONTE ATÉ I
            int[] arrayDistancia = new int[Tamanho];

            // ARRAY QUE VERIFICA SE O VERTICE ESTÁ INCLUSO NO CAMINHO MAIS CURTO
            bool[] inclusoMenor = new bool[TotalVertices];

            // PREENCHE O ARRAY COM O VALOR MÁXIMO DE DISTÂNCIA
            // SETA O ARRAY DE VERTICE INCLUSO NO MENOR CAMINHO COMO FALSO
            for (int i = 0; i < TotalVertices; i++)
            {
                arrayDistancia[i] = int.MaxValue;
                inclusoMenor[i] = false;
            }

            // DEFINE A DISTÂNCIA DO VERTICE A SI MESMO COMO ZERO
            arrayDistancia[inicio] = 0;

            // REALIZA UMA ITERAÇÃO SOBRE TODOS OS VERTICES PARA ENCONTRAR O MENOR CAMINHO DE TODOS
            // OS VÉRTICES DO GRAFO
            for (int count = 0; count < TotalVertices - 1; count++)
            {
                // CAPTURA O VERTICE DISTÂNCIA MINIMA DO CONJUNTO DE VERTICES NÃO VIZITADOS
                int u = CalcularDistanciaMinima(arrayDistancia, inclusoMenor);

                // MARCA A POSIÇÃO DO VERTICE DE MENOR INDICE COMO
                // JÁ ANALISADO
                inclusoMenor[u] = true;

                // ITERA SOBRE TODOS OS VERTICES DO GRAFO
                for (int verticeIteracao = 0; verticeIteracao < TotalVertices; verticeIteracao++)
                {
                    // ATUALIZA O ARRAY DE DISTÂNCIAS CASO A DISTANCIA DO VERTICE SEJA MAIOR QUE 0 -> EVITAR LOOP E
                    // CASO O INDICE DO ARRAY DE DISTANCIA SEJA DIFERENTE DE INFINITO E
                    // CASO A O VERTICE DE MENOR DISTANCIA U SEJA MENOR QUE O VERTICE ATUAL DA ITERAÇÃO
                    // CASO A SOMA DO INDICE DO ARRAY MAIS A O VERTICE DO
                    if (!inclusoMenor[verticeIteracao] && grafoAnalizado[u, verticeIteracao] != 0 
                        && arrayDistancia[u] != int.MaxValue 
                        && arrayDistancia[u] + grafoAnalizado[u, verticeIteracao] < arrayDistancia[verticeIteracao])
                    {
                        arrayDistancia[verticeIteracao] = arrayDistancia[u] + grafoAnalizado[u, verticeIteracao];
                    }
                }   
            }
            VisualizarSolucao(arrayDistancia, TotalVertices);
        }
    }
}
