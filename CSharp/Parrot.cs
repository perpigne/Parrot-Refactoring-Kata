using System;

namespace parrot
{
    public class Parrot
    {
        public Parrot(SpeedStrategy speedStrategy)
        {
            Strategy = speedStrategy;
        }

        private SpeedStrategy Strategy { get; }

        public double GetSpeed()
        {
            return Strategy.GetSpeed(this);
        }

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {

            var speedStrategy = new SpeedStrategy();
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    speedStrategy = new EuropeanSpeed();
                    break;
                case ParrotTypeEnum.AFRICAN:
                    speedStrategy = new AfricanSpeed(numberOfCoconuts);
                    break;

                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    speedStrategy = new NorwegianBlueSpeed(voltage, isNailed);
                    break;
            }

            return new Parrot(speedStrategy);
        }
    }

    public class NorwegianBlueSpeed : SpeedStrategy
    {
        private readonly double _voltage;
        private readonly bool _isNailed;

        public NorwegianBlueSpeed(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed(Parrot parrot)
        {
            return (_isNailed) ? 0 : GetBaseSpeed(_voltage);
        }

        public double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * BaseSpeed);
        }
    }

    public class AfricanSpeed : SpeedStrategy
    {
        private const double LoadFactor = 9.0;
        private const double MinSpeed = 0.0;

        private readonly int _numberOfCoconuts;

        public AfricanSpeed(int numberOfCoconuts)
        {
            this._numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed(Parrot parrot)
        {
            return Math.Max(MinSpeed, BaseSpeed - _numberOfCoconuts * LoadFactor);
        }
    }

    public class EuropeanSpeed : SpeedStrategy
    {
        public override double GetSpeed(Parrot parrot)
        {
            return BaseSpeed;
        }
    }

    public class SpeedStrategy
    {
        protected const double BaseSpeed = 12.0;

        public virtual double GetSpeed(Parrot parrot)
        {
            throw new Exception("Should be unreachable");
        }
    }
}
