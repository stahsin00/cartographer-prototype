using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Dictionary<string, string> configs; // TODO

    public InteractionManager()
    {
        LoadConfigurations();
    }

    private void LoadConfigurations()
    {
        // TODO : Load common interactions from JSON file
    }

    public SimpleInteraction CreateInteraction(string type)
    {
        // TODO
        string config = configs[type];
        return new SimpleInteraction(config);
    }
}
