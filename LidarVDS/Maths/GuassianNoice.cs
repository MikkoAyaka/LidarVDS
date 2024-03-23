using System;

namespace LidarVDS.Maths;

public class GuassianNoice: AbstractAlgorithm<double,double>
{
    private static readonly GuassianNoice instance = new();
    private GuassianNoice() {}
    public static GuassianNoice Instance
    {
        get
        {
            return instance;
        }
    }

    private Random _random = new();
    public override double Accept(double x)
    {
        // TODO 吴骏、王霖康
        return 0.1;
    }
}