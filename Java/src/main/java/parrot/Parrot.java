package parrot;

public class Parrot {

    public static final double BASE_SPEED = 12.0;
    public static final double LOAD_FACTOR = 9.0;
    public static final double MAX_SPEED = 24.0;
    private ParrotTypeEnum type;
    private double voltage;
    private boolean isNailed;


    protected Parrot() {
    }

    protected Parrot(ParrotTypeEnum _type, double voltage, boolean isNailed) {
        this.type = _type;
        this.voltage = voltage;
        this.isNailed = isNailed;
    }

    public static Parrot createParrot(ParrotTypeEnum parrotType, int numberOfCoconuts, double voltage, boolean isNailed) {
        switch (parrotType) {
            case EUROPEAN:
                return new EuropeanParrot();
            case AFRICAN:
                return new AfricanParrot(numberOfCoconuts);
            default:
                return new Parrot(parrotType, voltage, isNailed);

        }

    }

    public double getSpeed() {
        switch (type) {
            case NORWEGIAN_BLUE:
                return (isNailed) ? 0 : getBaseSpeed(voltage);
        }
        throw new RuntimeException("Should be unreachable");
    }

    private double getBaseSpeed(double voltage) {
        return Math.min(MAX_SPEED, voltage * BASE_SPEED);
    }


}
