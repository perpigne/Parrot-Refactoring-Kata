package parrot;

import org.junit.Test;

import static junit.framework.Assert.assertEquals;

public class ParrotTest {

    @Test
    public void getSpeedOfEuropeanParrot() {
        Parrot parrot = Parrot.createEuropeanParrot();
        assertEquals(parrot.getSpeed(), 12.0);
    }

    @Test
    public void getSpeedOfAfricanParrot_With_One_Coconut() {
        Parrot parrot = Parrot.createAfricanParrot(1);
        assertEquals(parrot.getSpeed(), 3.0);
    }

    @Test
    public void getSpeedOfAfricanParrot_With_Two_Coconuts() {
        Parrot parrot = Parrot.createAfricanParrot(2);
        assertEquals(parrot.getSpeed(), 0.0);
    }

    @Test
    public void getSpeedOfAfricanParrot_With_No_Coconuts() {
        Parrot parrot = Parrot.createAfricanParrot(0);
        assertEquals(parrot.getSpeed(), 12.0);
    }

    @Test
    public void getSpeedNorwegianBlueParrot_nailed() {
        Parrot parrot = Parrot.createNorwegianParrot(0, true);
        assertEquals(parrot.getSpeed(), 0.0);
    }

    @Test
    public void getSpeedNorwegianBlueParrot_not_nailed() {
        Parrot parrot = Parrot.createNorwegianParrot(1.5, false);
        assertEquals(parrot.getSpeed(), 18.0);
    }

    @Test
    public void getSpeedNorwegianBlueParrot_not_nailed_high_voltage() {
        Parrot parrot = Parrot.createNorwegianParrot(4,false);
        assertEquals(parrot.getSpeed(), 24.0);
    }
}
