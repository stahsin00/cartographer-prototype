using System;

public class Energy : Need
{
    public Energy() {
        Type = "Energy";
        Current = 1f;
    }

    public override void Decay()
    {
        Current -= Current * 0.1f;
    }

    public override float ScoreNeed()
    {
        float k = 5;
        return (float)(-(1-Math.Exp(-k * Current)) + 1);
    }
}
