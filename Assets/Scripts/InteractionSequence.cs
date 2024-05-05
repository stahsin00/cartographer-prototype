using System.Collections.Generic;

public class InteractionSequence : Interaction
{
    public Queue<Interaction> subTasks;

    public InteractionSequence(string name) : base(name)
    {
        subTasks = new Queue<Interaction>();
    }
}
