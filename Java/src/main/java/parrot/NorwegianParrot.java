package parrot;

public class NorwegianParrot extends Parrot {
    public static final double MAX_SPEED = 24.0;

    private final double voltage;
    private final boolean isNailed;

    NorwegianParrot(double voltage, boolean isNailed) {
        this.voltage = voltage;
        this.isNailed = isNailed;
    }

    public double getSpeed() {
        return (isNailed) ? 0 : getBaseSpeed();
    }

    private double getBaseSpeed() {
        return Math.min(MAX_SPEED, voltage * BASE_SPEED);
    }
}
