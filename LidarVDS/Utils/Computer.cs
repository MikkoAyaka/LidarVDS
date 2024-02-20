using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;
using MathNet.Numerics;
using Microsoft.Research.DynamicDataDisplay;

namespace LidarVDS.Utils;

public class Computer
{
    /**
     * 激光功率(瓦)
     */
    private static double P0 = 0.11;

    /**
     * 光速(米/秒)
     */
    private static double C = 299792458;

    /**
     * 脉冲宽度(秒)
     */
    private static double T = 0.0000001;

    /**
     * 接收望远镜面积(平方米)
     */
    private static double Ar = Math.PI / 1600;

    /**
     * 存疑 发射望远镜透过率(0.0~1.0)
     */
    private static double Tt = 1.0;

    /**
     * 接收望远镜透过率(0.0~1.0)
     */
    private static double Tr = 0.5;

    /**
     * 量子效率(0.0~1.0)
     */
    private static double Eta = 0.38;

    /**
     * 波长(m)
     */
    private static double Lambda = 905 * Math.Pow(10, -9);

    /**
     * 普朗克常数
     */
    private static double H = 6.62607015 * Math.Pow(10, -34);

    /**
     * 发射光束直径
     */
    private static double Dt = 62.5 * Math.Pow(10, -6);

    private static double ThetaT = 0.715 * Math.Pow(10, -3);

    /**
     * 接收光束直径
     */
    private static double Dr = 50 * Math.Pow(10, -3);

    private static double ThetaR = 1.2 * Math.Pow(10, -3);

    private static double trDistance = 300 * Math.Pow(10, -3);


    // TODO 如果三角形三条边不能组成三角形，那么 cos 不成立，即D1R D2R 的值出现异常
    // TODO 只需要简单通过半径判断是否重合即可确定是否能组成三角形

    public static Dictionary<Double, Double> MainAlg(double viewDistance, double scatteringValue, double maxLength)
    {
        var l1 = GetL1(trDistance, ThetaT, ThetaR);
        var l2 = GetL2(trDistance, ThetaT, ThetaR);
        Debug.WriteLine("L1:" + l1);
        Debug.WriteLine("L2:" + l2);
        var resultList = new Dictionary<Double, Double>();
        for (int x = 1; x < maxLength; x++)
        {
         Double yr;
            if (x <= l1)
            {
                yr = 0;
            }
            else if (x >= l2 * 0.9)
            {
                yr = 1;
            }
            else
            {
             yr = YrAlg(x);
            }
            var ta = Math.Exp(-3.912 * x / viewDistance);
            var pr = P0 * (C * T / 2) * (Ar / (x * x)) * yr * scatteringValue * ta * ta * Tt * Tr;
            var nsr = ((Eta * Lambda) / (H * C)) * pr * T;
            // var result = Math.Log10(nsr);
            var result = nsr;
            if (result.IsNaN()) result = 0;
            if(result.IsInfinite()) result = Double.MinValue;
            resultList[x] = result;
            Debug.WriteLine("x="+x+" result="+result);
        }

        return resultList;
    }

    public static double GetL1(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) + Math.Tan(thetaT));
    }

    public static double GetL2(double l, double thetaT, double thetaR)
    {
        return l / (Math.Tan(thetaR) - Math.Tan(thetaT));
    }

    public static double YrAlg(double r)
    {
        var D1R = Dt / 2 + ThetaT * r;
        var D1R2 = Dt / 2 + ThetaT * r * r;
        var D2R = Dr / 2 + ThetaR * r;
        var D2R2 = Dt / 2 + ThetaR * r * r;
        float temp1 = (float)((trDistance * trDistance + D1R * D1R - D2R * D2R) / (2 * D1R * trDistance));
        var a1R = 2 * MathF.Acos(temp1);
        float temp2 = (float)((trDistance * trDistance + D2R * D2R - D1R * D1R) / (2 * D2R * trDistance));
        var a2R = 2 * MathF.Acos(temp2);
        double result = (D2R2 * (a2R - MathF.Sin(a2R)) + D1R2 * (a1R - MathF.Sin(a1R))) /
                        (2 * Math.PI * D1R2);
        Console.WriteLine("yr:"+result);
        return result;
    }
}