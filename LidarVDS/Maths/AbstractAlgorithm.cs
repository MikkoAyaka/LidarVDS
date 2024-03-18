namespace LidarVDS.Maths;

public abstract class AbstractAlgorithm<TX,TY>
{
    public abstract TY Accept(TX x);
}