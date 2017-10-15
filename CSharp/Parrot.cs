using System;

namespace parrot
{
    public class Parrot
    {
        private const double LoadFactor = 9.0;
        private const double BaseSpeed = 12.0;
        private const double MaxSpeed = 24.0;

        readonly ParrotTypeEnum _type;
        readonly int _numberOfCoconuts;
        readonly double _voltage;
        readonly bool _isNailed;

        internal Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed; 
        }

        protected Parrot()
        {
            
        }

        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return BaseSpeed;
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (_isNailed) ? 0 : Math.Min(MaxSpeed, _voltage * BaseSpeed);
            }

            throw new Exception("Should be unreachable");
        }

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                default:
                    return new Parrot(type, numberOfCoconuts, voltage, isNailed);
            }
        }
    }

    public class EuropeanParrot : Parrot
    {
    }
}
