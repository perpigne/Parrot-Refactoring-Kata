using System;

namespace parrot
{
    public class Parrot
    {
        protected const double BaseSpeed = 12.0;
        readonly ParrotTypeEnum _type;
        readonly double _voltage;
        readonly bool _isNailed;

        protected Parrot(ParrotTypeEnum type, double voltage, bool isNailed)
        {
            _type = type;
            _voltage = voltage;
            _isNailed = isNailed; 
        }

        public virtual double GetSpeed()
        {
            switch (_type)
            {
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
                    return new Parrot(type, voltage, isNailed);
            }
        }
    }

    public class AfricanParrot : Parrot
    {
        private const double LoadFactor = 9.0;
        private readonly int _numberOfCoconuts;

        public AfricanParrot(int numberOfCoconuts) : base(ParrotTypeEnum.AFRICAN, 0, false)
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
        public EuropeanParrot() : base(ParrotTypeEnum.EUROPEAN, 0, false)
        {
        }

        public override double GetSpeed()
        {
            return BaseSpeed;
        }
    }
}
