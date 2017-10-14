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

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed; 
        }

        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return GetBaseSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (_isNailed) ? 0 : GetBaseSpeed(_voltage);
            }

            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(MaxSpeed, voltage * GetBaseSpeed());
        }

        private double GetLoadFactor()
        {
            return LoadFactor;
        }

        private double GetBaseSpeed()
        {
            return BaseSpeed;
        }
    }
}
