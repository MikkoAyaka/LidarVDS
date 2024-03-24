using System;

namespace LidarVDS.Maths;

public class GuassianNoice
{
    private static readonly GuassianNoice instance = new();
    public static GuassianNoice Instance
    {
        get
        {
            return instance;
        }
    }
    private Random _random = new();
    public double Accept(double mean,double stdDev)
    {
        double u1 = 1.0 - _random.NextDouble();
        double u2 = 1.0 - _random.NextDouble();
        double normalDistribution = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * normalDistribution;
    }
    
    public double NormalDistribution(double x, double mean, double stdDev)
    {
        double coefficient = 1.0 / (Math.Sqrt(2 * Math.PI) * stdDev);
        double exponent = -Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2));
        return coefficient * Math.Exp(exponent);
    }

}