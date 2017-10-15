using System;

namespace parrot
{
    public abstract class Parrot
    {
        protected const double BaseSpeed = 12.0;


        public abstract double GetSpeed();

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(voltage, isNailed);
                default:
                    throw new Exception("Don't know parrot of type " + type);
            }
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly double _voltage;
        private readonly bool _isNailed;

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed()
        {
            return (_isNailed) ? 0 : GetBaseSpeed(_voltage);
        }

        protected double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * BaseSpeed);
        }
    }

    public class AfricanParrot : Parrot
    {
        private const double LoadFactor = 9.0;
        private readonly int _numberOfCoconuts;

        public AfricanParrot(int numberOfCoconuts)
        {
            this._numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
        }
    }

    public class EuropeanParrot : Parrot
    {
        public override double GetSpeed()
        {
            return BaseSpeed;
        }
    }
}
