package parrot;

public abstract class Parrot {

    public static final double BASE_SPEED = 12.0;
    public static final double LOAD_FACTOR = 9.0;
    public static final double MAX_SPEED = 24.0;



    public static Parrot createNorwegianParrot(double voltage, boolean isNailed) {
        return new NorwegianParrot(voltage, isNailed);
    }

    public static Parrot createAfricanParrot(int numberOfCoconuts) {
        return new AfricanParrot(numberOfCoconuts);
    }

    public static Parrot createEuropeanParrot() {
        return new EuropeanParrot();
    }

    public abstract double getSpeed();


}
