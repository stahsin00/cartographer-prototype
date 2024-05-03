using System;

public class Hunger : Need
{
    private const float DECAY_RATE = 0.01f;

    public Hunger() : base() {
        Type = "Hunger";
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
