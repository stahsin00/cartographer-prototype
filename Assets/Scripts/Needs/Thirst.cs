using System;

public class Thirst : Need
{
    private const float DECAY_RATE = 0.001f;

    public Thirst() {
        Type = "Thirst";
        Current = 1f;
    }

    public override void Decay()
    {
        Current -= DECAY_RATE;
    }

    public override float ScoreNeed()
    {
        float k = 5;
        return (float)(-(1-Math.Exp(-k * Current)) + 1);
    }
}
