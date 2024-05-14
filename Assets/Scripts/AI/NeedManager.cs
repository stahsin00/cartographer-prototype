using System.Collections.Generic;

// TODO : not sure if needed lol
public class NeedManager
{
    private List<Need> needs;

    public NeedManager() {
        needs = new List<Need>();
    }

    public void AddNeed(Need need) {
        needs.Add(need);
    }
}
