package parrot;

public class NorwegianParrot extends Parrot {
    private final double voltage;
    private final boolean isNailed;

    public NorwegianParrot(double voltage, boolean isNailed) {
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
