namespace NumericalMethods
{
    public static class Interpolation
    {
        public static double Lagrange(double x, params Point2D[] points)
        {
            var result = 0.0;
            var n = points.Length - 1;
            
            for (var i = 0; i <= n; i++)
            {
                var li = LagrangePartL(x, i, n, points);
                var fi = points[i].y;
                var step = li * fi;

                result += step;
            }

            return result;
        }


        private static double LagrangePartL(double x, int i, int n, params Point2D[] points)
        {
            var result = 1.0;
            
            for (var j = 0; j <= n; j++)
            {
                if (i == j) continue;
                
                var xi = points[i].x;
                var xj = points[j].x;
                var numerator = x - xj;
                var denominator = xi - xj;
                var step = numerator / denominator;

                result *= step;
            }

            return result;
        }
    }
}