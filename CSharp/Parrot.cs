using System;

namespace parrot
{
    public class Parrot
    {
        private const double LoadFactor = 9.0;
        protected const double BaseSpeed = 12.0;
        readonly ParrotTypeEnum _type;
        readonly int _numberOfCoconuts;
        readonly double _voltage;
        readonly bool _isNailed;

        protected Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed; 
        }

        public virtual double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (_isNailed) ? 0 : GetBaseSpeed(_voltage);
            }

            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * BaseSpeed);
        }

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts);
                default:
                    return new Parrot(type, numberOfCoconuts, voltage, isNailed);
            }
        }
    }

    public class AfricanParrot : Parrot
    {
        public AfricanParrot(int numberOfCoconuts) : base(ParrotTypeEnum.AFRICAN, numberOfCoconuts, 0, false)
        {
        }
    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot() : base(ParrotTypeEnum.EUROPEAN, 0, 0, false)
        {
        }

        public override double GetSpeed()
        {
            return BaseSpeed;
        }
    }
}
