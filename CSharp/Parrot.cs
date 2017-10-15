using System;

namespace parrot
{
    public class Parrot
    {
        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            Strategy = new SpeedStrategy();
            Type = type;
            NumberOfCoconuts = numberOfCoconuts;
            Voltage = voltage;
            IsNailed = isNailed; 
        }

        private SpeedStrategy Strategy { get; }

        internal ParrotTypeEnum Type { get; }

        public int NumberOfCoconuts { get; }

        public bool IsNailed { get; }

        public double Voltage { get; }

        public double GetSpeed()
        {
            return Strategy.GetSpeed(this);
        }
    }

    public class SpeedStrategy
    {

        public double GetSpeed(Parrot parrot)
        {

            switch (parrot.Type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return GetBaseSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * parrot.NumberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (parrot.IsNailed) ? 0 : GetBaseSpeed(parrot.Voltage);
            }

            throw new Exception("Should be unreachable");
        }

        public double GetBaseSpeed()
        {
            return 12.0;
        }

        public double GetLoadFactor()
        {
            return 9.0;
        }

        public double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * this.GetBaseSpeed());
        }
    }
}
