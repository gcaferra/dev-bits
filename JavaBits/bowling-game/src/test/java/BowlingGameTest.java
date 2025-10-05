import junit.framework.TestCase;

public class BowlingGameTest extends TestCase {
    private Game g;
    @Override
    protected void setUp() {
        g = new Game();
    }

    public void  testGutterGame() {
        rollMany(0, 20);

        assertEquals(0, g.score());
    }

    public void testAllOne() {
        rollMany(1, 20);

        assertEquals(20, g.score());
    }

    public void testOneSpare() {
        g.roll(5);
        g.roll(5);
        g.roll(3);
        rollMany(0, 17);

        assertEquals(16, g.score());
    }

    public void testOneStrike() {
        g.roll(10);
        g.roll(3);
        g.roll(4);
        rollMany(16,0);

        assertEquals(24, g.score());
    }

    public void testPerfectGame() {
        rollMany(10,12);
        assertEquals(300, g.score());
    }

    private void rollMany(int pins, int rollCount) {
        for (int i = 0; i < rollCount; i++)
            g.roll(pins);
    }

}
