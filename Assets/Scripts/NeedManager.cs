using System.Collections.Generic;

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
