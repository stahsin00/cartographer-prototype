using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObject : IInteractable
{
    List<Advertisement> advertisements;

    public List<Advertisement> GetAdvertisements()
    {
        return advertisements;
    }
}
