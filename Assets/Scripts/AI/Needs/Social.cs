using System;

public class Social : Need
{
    private const float DECAY_RATE = 0.01f;

    public Social() : base() {
        Type = "Social";
        Current = 1f;
    }

    public override void Decay()
    {
        Current -= DECAY_RATE;
    }

    public override float ScoreNeed()
    {
        if (Current > 0.5f) {
            float k = 5;
            return (float)(-(1-Math.Exp(-k * Current)) + 1);
        } else {
            return 0.9f;
        }
    }
}
