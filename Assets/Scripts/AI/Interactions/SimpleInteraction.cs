public class SimpleInteraction : Interaction
{
    public SimpleInteraction(string name) : base()
    {
        Name = name;
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
