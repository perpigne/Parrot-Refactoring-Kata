using System;

namespace parrot
{
    public class Parrot
    {
        public Parrot(ISpeedStrategy speedStrategy)
        {
            Strategy = speedStrategy;
        }

        private ISpeedStrategy Strategy { get; }

        public double GetSpeed()
        {
            return Strategy.GetSpeed();
        }


        public static Parrot NorwegianBlue(double voltage, bool isNailed)
        {
            return new Parrot(new NorwegianBlueSpeed(voltage, isNailed));
        }

        public static Parrot African(int numberOfCoconuts)
        {
            return new Parrot(new AfricanSpeed(numberOfCoconuts));
        }

        public static Parrot European()
        {
            return new Parrot(new EuropeanSpeed());
        }
    }

    public class NorwegianBlueSpeed : ISpeedStrategy
    {
        protected const double BaseSpeed = 12.0;
        private readonly double _voltage;
        private readonly bool _isNailed;

        public NorwegianBlueSpeed(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public double GetSpeed()
        {
            return (_isNailed) ? 0 : GetBaseSpeed(_voltage);
        }

        public double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * BaseSpeed);
        }
    }

    public class AfricanSpeed : ISpeedStrategy
    {
        private const double LoadFactor = 9.0;
        private const double MinSpeed = 0.0;
        protected const double BaseSpeed = 12.0;

        private readonly int _numberOfCoconuts;

        public AfricanSpeed(int numberOfCoconuts)
        {
            this._numberOfCoconuts = numberOfCoconuts;
        }

        public double GetSpeed()
        {
            return Math.Max(MinSpeed, BaseSpeed - _numberOfCoconuts * LoadFactor);
        }
    }

    public class EuropeanSpeed : ISpeedStrategy
    {
        protected const double BaseSpeed = 12.0;

        public double GetSpeed()
        {
            return BaseSpeed;
        }
    }

    public interface ISpeedStrategy
    {
        double GetSpeed();
    }

}
