using System;
using System.Diagnostics;
using LidarVDS.Maths;
using LidarVDS.Resources.Values;
using MathNet.Numerics;

namespace LidarVDS.Maths;

public class AtmosphericExtinctionCoeff: AbstractAlgorithm<double,double>
{
    private static readonly AtmosphericExtinctionCoeff instance = new();
    public static AtmosphericExtinctionCoeff Instance
    {
        get
        {
            return instance;
        }
    }
    public override double Accept(double x)
    {
        //然后求微分，并*-0.5
        var sigmaH = -0.5 * Derivative(Sr_Calculate, x);
        return sigmaH;
        /*return Sr_Calculate(x);*/
    } 
    double Sr_Calculate(double x)
    {
        var pr = EchoParticleGenerator.Instance.Pr_Calculate(x);
        if (pr == 0)
        {
            return 0;
        }
        //对激光雷达回波信号进行距离校准得到距离校正信号PRR
        var prr = pr * x * x;
        //然后上式取自然对数，得到对数距离校正信号S(r)
        var sr = Math.Log(prr);
        
        /*lock (this)
        {   
            Debug.WriteLine("===============");
            Debug.WriteLine("pr = "+pr);
            Debug.WriteLine("prr = "+prr);
            Debug.WriteLine("sr = "+sr);
        }*/
        
        return sr;
    }
    double Derivative(Func<double,double> f, double x)
    {
        return Differentiate.FirstDerivative(f, x);
    }
    
}