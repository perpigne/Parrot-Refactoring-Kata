using System;
using System.Runtime.CompilerServices;

namespace parrot
{
    public abstract class Parrot
    {
        protected const double BaseSpeed = 12.0;


        public abstract double GetSpeed();


        public static Parrot NorwegianBlue(double voltage, bool isNailed)
        {
            return new NorwegianBlueParrot(voltage, isNailed);
        }

        public static Parrot African(int numberOfCoconuts)
        {
            return new AfricanParrot(numberOfCoconuts);
        }

        public static Parrot European()
        {
            return new EuropeanParrot();
        }
    }

    internal class NorwegianBlueParrot : Parrot
    {
        protected const double MaxSpeed = 24.0;
        private readonly double _voltage;
        private readonly bool _isNailed;

        internal NorwegianBlueParrot(double voltage, bool isNailed)
        {
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed()
        {
            return (_isNailed) ? 0 : Math.Min(MaxSpeed, _voltage * BaseSpeed);
        }
    }

    internal class AfricanParrot : Parrot
    {
        protected const double LoadFactor = 9.0;
        private readonly int _numberOfCoconuts;

        internal AfricanParrot(int numberOfCoconuts)
        {
            this._numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
        }
    }

    internal class EuropeanParrot : Parrot
    {
        public override double GetSpeed()
        {
           return BaseSpeed;
        }
    }
}
