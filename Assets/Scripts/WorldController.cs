using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public const int SHIP_SIZE = 16;

    public Ship ship;

    private static WorldController instance;
    public static WorldController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            ship = new Ship(SHIP_SIZE);
        }
    }
}
