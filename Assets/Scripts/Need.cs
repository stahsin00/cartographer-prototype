public abstract class Need
{
    public string Type { get; protected set; }
    public float Current { get; protected set; }

    public abstract void Decay();
}
