using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTimer : MonoBehaviour
{

    public float timerLengthInSeconds = 5.0f;
    private float currentTimer = 0.0f;


    void Start()
    {
        currentTimer = timerLengthInSeconds;
        Debug.Log("Timer started at " + System.DateTime.Now.ToString("mm:ss.FF"));
    }


    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer = currentTimer - Time.deltaTime;
            if (currentTimer <= 0)
            {
                OnTimerFinish();
            }
        }

    }


    void OnTimerFinish()
    {
        Debug.Log("Timer stopped at " + System.DateTime.Now.ToString("mm:ss.FF"));
    }

}
