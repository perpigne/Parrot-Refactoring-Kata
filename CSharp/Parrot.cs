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

        public SpeedStrategy Strategy { get; }

        public ParrotTypeEnum Type { get; }

        public int NumberOfCoconuts { get; }

        public bool IsNailed { get; }

        public double Voltage { get; }

        public double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        public double GetLoadFactor()
        {
            return 9.0;
        }

        public double GetBaseSpeed()
        {
            return 12.0;
        }
    }

    public class SpeedStrategy
    {
        public double GetSpeed(Parrot parrot)
        {

            switch (parrot.Type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return parrot.GetBaseSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, parrot.GetBaseSpeed() - parrot.GetLoadFactor() * parrot.NumberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return (parrot.IsNailed) ? 0 : parrot.GetBaseSpeed(parrot.Voltage);
            }

            throw new Exception("Should be unreachable");
        }
    }
}
