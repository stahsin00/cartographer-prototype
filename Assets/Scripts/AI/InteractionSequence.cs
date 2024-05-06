using System.Collections.Generic;

public abstract class InteractionSequence : Interaction
{
    public Queue<Interaction> subTasks;

    public InteractionSequence() : base()
    {
        subTasks = new Queue<Interaction>();
    }
}
