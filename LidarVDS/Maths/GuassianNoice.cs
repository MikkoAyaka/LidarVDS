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
        var ran=_random.Next(1, 10);
        if (ran > 6)
        {
            var u1 = 1.0 - _random.NextDouble();
            var u2 = 1.0 - _random.NextDouble();
            var Noise = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var NormalNoise = mean + NormalDistribution(Math.Log(0.25+stdDev/5000),0.3,0.8) * Noise;
            return NormalNoise;
        }
        else
        {
            return 0;
        }
        
    }
    
    public double NormalDistribution(double x, double mean, double stdDev)
    {
        var coefficient = 1.0 / (Math.Sqrt(2 * Math.PI) * stdDev);
        var exponent = -Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2));
        return coefficient * Math.Exp(exponent);
    }
}