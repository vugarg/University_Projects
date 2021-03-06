using System;

public class PrimeGenerator
{
    private Random _random;

    public PrimeGenerator(Random random)
    {
        _random = random;            
    }

    public ulong Next()
    {
        return Next(UInt64.MaxValue);
    }

    public ulong Next(ulong maxValue)
    {
        return Next(0, maxValue);
    }

    public ulong Next(ulong minValue, ulong maxValue)
    {
        if (maxValue < minValue)
            throw new ArgumentException();
            
        return (ulong)(_random.NextDouble() * (maxValue - minValue)) + minValue;
    }
}