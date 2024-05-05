using System.Collections.Generic;

public class TaskSequence : Task
{
    public Queue<Task> subTasks;

    public TaskSequence(string name) : base(name)
    {
        subTasks = new Queue<Task>();
    }
}
