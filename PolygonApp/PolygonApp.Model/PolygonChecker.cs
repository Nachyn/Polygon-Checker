using System;
using System.Collections.Generic;
using System.Windows;

namespace PolygonApp.Model
{
    public static class PolygonChecker
    {
        public static bool IsPointInsidePolygon(List<Point> polygon, Point point)
        {
            if (polygon == null || polygon.Count < 1)
            {
                throw new ArgumentException("Polygon cannot be empty");
            }

            //ru.wikibooks.org/wiki/Реализации_алгоритмов/Задача_о_принадлежности_точки_многоугольнику
            int i1, i2, n, N, s, s1, s2, s3, flag = 0;

            N = polygon.Count;
            for (n = 0; n < N; n++)
            {
                flag = 0;
                i1 = n < N - 1 ? n + 1 : 0;

                while (true)
                {
                    i2 = i1 + 1;
                    if (i2 >= N)
                    {
                        i2 = 0;
                    }

                    if (i2 == (n < N - 1 ? n + 1 : 0))
                    {
                        break;
                    }

                    s = (int) Math.Abs(polygon[i1].X * (polygon[i2].Y - polygon[n].Y)
                                       + polygon[i2].X * (polygon[n].Y - polygon[i1].Y)
                                       + polygon[n].X * (polygon[i1].Y - polygon[i2].Y));

                    s1 = (int) Math.Abs(polygon[i1].X * (polygon[i2].Y - point.Y)
                                        + polygon[i2].X * (point.Y - polygon[i1].Y)
                                        + point.X * (polygon[i1].Y - polygon[i2].Y));

                    s2 = (int) Math.Abs(polygon[n].X * (polygon[i2].Y - point.Y)
                                        + polygon[i2].X * (point.Y - polygon[n].Y)
                                        + point.X * (polygon[n].Y - polygon[i2].Y));

                    s3 = (int) Math.Abs(polygon[i1].X * (polygon[n].Y - point.Y)
                                        + polygon[n].X * (point.Y - polygon[i1].Y)
                                        + point.X * (polygon[i1].Y - polygon[n].Y));

                    if (s == s1 + s2 + s3)
                    {
                        flag = 1;
                        break;
                    }

                    i1 += 1;

                    if (i1 >= N)
                    {
                        i1 = 0;
                    }
                }

                if (flag == 0)
                {
                    break;
                }
            }

            return flag != 0;
        }
    }
}