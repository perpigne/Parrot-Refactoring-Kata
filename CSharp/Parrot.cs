using System;

namespace parrot
{
    public class Parrot
    {
        public Parrot(int numberOfCoconuts, double voltage, bool isNailed, SpeedStrategy speedStrategy)
        {
            Strategy = speedStrategy;
            NumberOfCoconuts = numberOfCoconuts;
            Voltage = voltage;
            IsNailed = isNailed; 
        }

        private SpeedStrategy Strategy { get; }

        public int NumberOfCoconuts { get; }

        public bool IsNailed { get; }

        public double Voltage { get; }

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

            return new Parrot(numberOfCoconuts, voltage, isNailed, speedStrategy);
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
            return Math.Min(24.0, voltage * GetBaseSpeed());
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
            return Math.Max(MinSpeed, GetBaseSpeed() - _numberOfCoconuts * LoadFactor);
        }
    }

    public class EuropeanSpeed : SpeedStrategy
    {
        public override double GetSpeed(Parrot parrot)
        {
            return GetBaseSpeed();
        }
    }

    public class SpeedStrategy
    {

        public virtual double GetSpeed(Parrot parrot)
        {
            throw new Exception("Should be unreachable");
        }

        public double GetBaseSpeed()
        {
            return 12.0;
        }
    }
}
