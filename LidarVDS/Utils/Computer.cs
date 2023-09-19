using System;
using System.Diagnostics;
using MathNet.Numerics;

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
    private static double Ar = 3.1415926 / 1600;
    /**
     * 接收发射望远镜的间距(米)
     */
    private static double D = 0.01;
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
    private static double Lambda = 905 * Math.Pow(10,-9);
    /**
     * 普朗克常数
     */
    private static double H = 6.62607015 * Math.Pow(10, -34);
    /** 
     * 核心能见度反演算法
     * 输入：x 能见度 粒子散射系数
     * 输出：y
     */
    public static double MainAlg(double x,double viewDistance,double scatteringValue)
    {
        var yr = x * x / (x + D) * (x + D);
        var ta = Math.Exp(-3.912 * x / viewDistance);
        var pr = P0 * (C * T / 2) * (Ar / (x * x)) * yr * scatteringValue * ta * ta * Tt * Tr;
        var nsr = ((Eta * Lambda) / (H * C)) * pr * T;
        return Math.Log10(nsr);
    }
}