package parrot;

public class AfricanParrot extends Parrot {
    public static final double LOAD_FACTOR = 9.0;

    protected int numberOfCoconuts = 0;

    AfricanParrot(int numberOfCoconuts) {
        this.numberOfCoconuts = numberOfCoconuts;
    }

    public double getSpeed() {
        return Math.max(0, BASE_SPEED - LOAD_FACTOR * numberOfCoconuts);
    }
}
