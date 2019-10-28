using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matriz3D.Procesos
{
    public class Validaciones
    {
        public string validarT(int? T)
        {
            if (T == null)
            {
                return "El valor de T no es valido.";
            }
            else if (T < 1 || T > 50)
            {
                return "T no cumple la restricción [1 <= T <= 50]";
            }

            return "";
        }

        public string validarNM(int? N, int? M)
        {
            if (N == null)
            {
                return "El valor de T no es valido.";
            }
            else if (N < 1 || N > 100)
            {
                return "N no cumple la restricción [1 <= N <= 100]";
            }
            else if (M < 1 || M > 1000)
            {
                return "M no cumple la restricción [1 <= N <= 1000]";
            }

            return "";
        }

        public string validarQuery(string q, int N)
        {
            if (q == "")
            {
                return "La Consulta no es valida.";
            }
            else
            {
                var vector = q.Split(' ');

                if (vector.Count() < 5 || vector.Count() > 7)
                {
                    return "Los parametros de la consulta no son validos.";
                }
                else
                {
                    if (vector[0].ToUpper() != "UPDATE" && vector[0].ToUpper() != "QUERY")
                    {
                        return "La consulta debe iniciar por UPDATE o QUERY.";
                    }
                    else if (vector[0].ToUpper() == "UPDATE") // Validamos la consulta UPDATE
                    {
                        int x, y, z, w;

                        if (!int.TryParse(vector[1], out x)) // Validamos el valor de X
                        {
                            return "El valor de X no es valido.";
                        }
                        else if (x < 1 || x > N)
                        {
                            return "X no cumple la restricción [1 <= x, y, z <= N]";
                        }
                        else if (!int.TryParse(vector[2], out y)) // Validamos el valor de Y
                        {
                            return "El valor de Y no es valido.";
                        }
                        else if (y < 1 || y > N)
                        {
                            return "Y no cumple la restricción [1 <= x, y, z <= N]";
                        }
                        else if (!int.TryParse(vector[3], out z)) // Validamos el valor de Z
                        {
                            return "El valor de Z no es valido.";
                        }
                        else if (z < 1 || z > N)
                        {
                            return "Z no cumple la restricción [1 <= x, y, z <= N]";
                        }
                        else if (!int.TryParse(vector[4], out w)) // Validamos el valor de W
                        {
                            return "El valor de W no es valido.";
                        }
                        else if (w < -1000000000 || w > 1000000000)
                        {
                            return "W no cumple la restricción [-10^9 <= W <= 10^9]";
                        }
                    }
                    else if (vector[0].ToUpper() == "QUERY") // Validamos la consulta QUERY
                    {
                        int x1, x2, y1, y2, z1, z2;

                        if (!int.TryParse(vector[1], out x1)) // Validamos el valor de X1
                        {
                            return "El valor de X1 no es valido.";
                        }
                        else if (!int.TryParse(vector[4], out x2)) // Validamos el valor de X2
                        {
                            return "El valor de X2 no es valido.";
                        }
                        else if (x1 < 1 || x1 > x2 || x2 > N)
                        {
                            return "X1 y X2 no cumplen la restricción [1 <= x1 <= x2 <= N]";
                        }                        
                        else if (!int.TryParse(vector[2], out y1)) // Validamos el valor de Y1
                        {
                            return "El valor de Y1 no es valido.";
                        }
                        else if (!int.TryParse(vector[5], out y2)) // Validamos el valor de Y2
                        {
                            return "El valor de Y2 no es valido.";
                        }
                        else if (y1 < 1 || y1 > y2 || y2 > N)
                        {
                            return "Y1 y Y2 no cumplen la restricción [1 <= y1 <= y2 <= N]";
                        }
                        else if (!int.TryParse(vector[3], out z1)) // Validamos el valor de Z1
                        {
                            return "El valor de Z1 no es valido.";
                        }
                        else if (!int.TryParse(vector[6], out z2)) // Validamos el valor de Z2
                        {
                            return "El valor de Z2 no es valido.";
                        }
                        else if (z1 < 1 || z1 > z2 || z2 > N)
                        {
                            return "Z1 y Z2 no cumplen la restricción [1 <= z1 <= z2 <= N]";
                        }
                    }
                }
            }

            return "";
        }


    }
}