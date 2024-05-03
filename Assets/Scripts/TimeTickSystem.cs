using System;
using System.Collections;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    private static TimeTickSystem instance;
    public static TimeTickSystem Instance { get { return instance; } }

    private bool isRunning;

    private int speed = 1;

    public event Action OnTick;

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

            isRunning = true;
            StartCoroutine(InternalClock());
        }
    }

    IEnumerator InternalClock() {
        while (isRunning) {
            OnTick?.Invoke();
            yield return new WaitForSeconds(1f / speed);
        }
    }

    void Pause() {
        isRunning = false;
    }

    void Unpause() {
        isRunning = true;
    }
}
