using System;

namespace LidarVDS.Maths;

public class GeometryOverlapFactor: AbstractAlgorithm<double,double>
{
    private static readonly GeometryOverlapFactor instance = new();
    private GeometryOverlapFactor() {}
    public static GeometryOverlapFactor Instance
    {
        get
        {
            return instance;
        }
    }
    public override double Accept(double x)
    {
        var l1 = GetL1(_trDistance, _thetaT, _thetaR);
        var l2 = GetL2(_trDistance, _thetaT, _thetaR);
        if (x <= l1)
        {
            return 0;
        }
        else if (x >= l2 * 0.9)
        {
            return 1;
        }
        var D1R = _dt / 2 + _thetaT * x;
        var D1R2 = _dt / 2 + _thetaT * x * x;
        var D2R = _dr / 2 + _thetaR * x;
        var D2R2 = _dt / 2 + _thetaR * x * x;
        var temp1 = (float)((_trDistance * _trDistance + D1R * D1R - D2R * D2R) / (2 * D1R * _trDistance));
        var a1R = 2 * MathF.Acos(temp1);
        var temp2 = (float)((_trDistance * _trDistance + D2R * D2R - D1R * D1R) / (2 * D2R * _trDistance));
        var a2R = 2 * MathF.Acos(temp2);
        var result = (D2R2 * (a2R - MathF.Sin(a2R)) + D1R2 * (a1R - MathF.Sin(a1R))) /
                     (2 * Math.PI * D1R2);
        return result;
    }
    private static double GetL1(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) + Math.Tan(thetaT));
    }

    private static double GetL2(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) - Math.Tan(thetaT));
    }
    /**
     * 发射光束直径
     */
    private double _dt = 62.5 * Math.Pow(10, -6);
    /**
     * 接收光束直径
     */
    private double _dr = 50 * Math.Pow(10, -3);
    private double _thetaT = 0.715 * Math.Pow(10, -3);

    private double _thetaR = 1.2 * Math.Pow(10, -3);

    private double _trDistance = 300 * Math.Pow(10, -3);
}