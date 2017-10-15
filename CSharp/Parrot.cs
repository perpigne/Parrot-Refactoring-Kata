using System;
using System.Runtime.CompilerServices;

namespace parrot
{
    public abstract class Parrot
    {
        protected const double BaseSpeed = 12.0;


        public abstract double GetSpeed();


        public static Parrot CreateNorwegianBlueParrot(double voltage, bool isNailed)
        {
            return new NorwegianBlueParrot(voltage, isNailed);
        }

        public static Parrot CreateAfricanParrot(int numberOfCoconuts)
        {
            return new AfricanParrot(numberOfCoconuts);
        }

        public static Parrot CreateEuropeanParrot()
        {
            return new EuropeanParrot();
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        protected const double MaxSpeed = 24.0;
        private readonly double _voltage;
        private readonly bool _isNailed;

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed()
        {
            return (_isNailed) ? 0 : Math.Min(MaxSpeed, _voltage * BaseSpeed);
        }
    }

    public class AfricanParrot : Parrot
    {
        protected const double LoadFactor = 9.0;
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
