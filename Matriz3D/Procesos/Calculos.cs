using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matriz3D.Procesos
{
    public class Calculos
    {
        public int[,,] crearMatriz3D(int N)
        {
            return new int[N,N,N];
        }

        public string ejecutarConsulta(int[,,] matriz3D, string query, int N)
        {
            var vector = query.Split();
            int x, y, z, w;
            int x1, x2, y1, y2, z1, z2;

            long sumatoria = 0;
            
            if (vector[0].ToUpper() == "UPDATE")
            {
                x = int.Parse(vector[1]) - 1;
                y = int.Parse(vector[2]) - 1;
                z = int.Parse(vector[3]) - 1;
                w = int.Parse(vector[4]);

                matriz3D[x, y, z] = w;

                return "Datos de la Matriz actualizados";
            }
            else if (vector[0].ToUpper() == "QUERY")
            {
                x1 = int.Parse(vector[1]) - 1;                
                y1 = int.Parse(vector[2]) - 1;
                z1 = int.Parse(vector[3]) - 1;
                x2 = int.Parse(vector[4]) - 1;
                y2 = int.Parse(vector[5]) - 1;
                z2 = int.Parse(vector[6]) - 1;

                for (int px = 0; px < N; px++)
                {
                    for (int py = 0; py < N; py++)
                    {
                        for (int pz = 0; pz < N; pz++)
                        {
                            if ((px >= x1 && px <= x2) && (py >= y1 && py <= y2) && (pz >= z1 && pz <= z2))
                            {
                                sumatoria += matriz3D[px, py, pz];
                            }
                        }
                    }
                }

                return query + " = " + sumatoria.ToString(); 
            }

            return "";
        }
    }
}