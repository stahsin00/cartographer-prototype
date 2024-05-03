using System;

public abstract class Need
{
    public string Type { get; protected set; }

    private float current;
    public float Current 
    {
        get => current;
        protected set => current = Math.Clamp(value, 0, 1);
    }

    public virtual void Recover(float amount) {
        Current += amount;
    }

    public abstract void Decay();

    public abstract float ScoreNeed();
}
