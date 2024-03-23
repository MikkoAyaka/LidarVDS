using System;
using System.Diagnostics;
using LidarVDS.Resources.Values;
using Microsoft.Research.DynamicDataDisplay;

namespace LidarVDS.Maths;

public class EchoParticleGenerator: AbstractAlgorithm<double,double>
{ 
 private static readonly EchoParticleGenerator instance = new();
    private EchoParticleGenerator() {}
    public static EchoParticleGenerator Instance
    {
        get
        {
            return instance;
        }
    }

    public double Pr_Calculate(double x)
    {
     var c = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.LightSpeed).NowValue;
     var _tr = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.TransmittanceReceive).NowValue;
     var _tt = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.TransmittanceEmit).NowValue;
     var _ar = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.AreaReceive).NowValue;
     var _t = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.PulseWidth).NowValue;
     var _p0 = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.LaserPower).NowValue;
     
     Double yr = GeometryOverlapFactor.Instance.Accept(x,GeometryOverlapFactor.AlgTypeEnum.Theory);
     var ta = Math.Exp(-3.912 * x / _viewDistance);
     var pr = _p0 * (c * _t / 2) * (_ar / (x * x)) * yr * _scatteringValue * ta * ta * _tt * _tr;
     return pr;
    }
    public override double Accept(double x)
    {
     var c = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.LightSpeed).NowValue;
     var h = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.PlanckConstant).NowValue;
     var _lambda = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.Wavelength).NowValue;
     var _eta = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.QuantumEfficiency).NowValue;
     var _t = LidarArgumentsRepository.GetInstance().GetArguments(LidarArgumentNameEnum.PulseWidth).NowValue;
     
     var pr = Pr_Calculate(x);
     var nsr = ((_eta * _lambda) / (h * c)) * pr * _t;
     var result = nsr;
     if (result.IsNaN()) result = 0;
     if(result.IsInfinite()) result = Double.MinValue;
     return result;
    }
    

    private double _viewDistance = 7000;
    private double _scatteringValue = 0.0005;


}