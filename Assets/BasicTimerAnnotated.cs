using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTimerAnnotated : MonoBehaviour
{

    // How long should the timer take before it goes off?
    // This is a _public_ variable so that we can control it from the editor,
    // and a _float_ so that we have fine control over the length.
    // We use seconds because that's going to be the most natural,
    // since Time.deltaTime is a measurement in seconds.
    public float timerLengthInSeconds = 5.0f;


    // What is the current amount of time left?
    // This is a _private_ variable because it's for internal use only,
    // meaning we don't want any other script to be able to change it.
    // It's a _float_ for type compatibility with both timerLengthInSeconds
    // as well as Time.deltaTime.
    private float currentTimer = 0.0f;



    // Start() is a Unity event called once, before any Update() calls.
    // It's used for initialization.
    void Start()
    {

        // We can measure time either by counting up from zero to timerLengthInSeconds,
        // or down from timerLengthInSeconds to zero. It will take the same amount of time
        // no matter which direction we go. In this example, we start at timerLengthInSeconds
        // and go down. So, here in the Start() method, we set currentTimer to timerLengthInSeconds.
        currentTimer = timerLengthInSeconds;


        // For the sake of illustration, we'll use real time to determine how long this timer takes.
        Debug.Log("Timer started at " + System.DateTime.Now.ToString("mm:ss.FF"));

    }


    // Update() is called once per frame.
    // The amount of time since the previous frame can always be found in Time.deltaTime.
    // So if we chip off that value, that Time.deltaTime, from our currentTimer,
    // then we will reach zero on the first frame after timerLengthInSeconds has passed.
    void Update()
    {
        
        // The construction of this code is important. The first check asks
        // the question "Is the timer still running?" by seeing if there is 
        // still any time on the timer.
        if (currentTimer > 0)
        {

            // If we get into here, it means that there is still time on the timer,
            // so we can chip off Time.deltaTime from it, that being the amount
            // of time that's passed since the last frame.
            currentTimer = currentTimer - Time.deltaTime;

            // Now we check the timer again. Note that we are still within the
            // code branch that started with asking "Is the timer still running?"
            // Now we're asking, in essence, "Is this the first time that currentTimer
            // has reached zero?"
            if (currentTimer <= 0)
            {
                // If we get into here, then yes, this is the first time that currentTimer
                // has reached zero. We know it's the first time because we started
                // by making sure that currentTimer *was* larger than zero at the start of
                // this frame. The timer is now done, so we can call a "handler" function
                // that describes what the timer going off should do.
                OnTimerFinish();
            }
        }

    }


    // This is broken out into its own function just for the sake of organization.
    // As the name suggests, its purpose is to be called when the timer is done.
    void OnTimerFinish()
    {
        // For now we'll just debug the final time so we can verify that 
        // the timer works as expected.
        Debug.Log("Timer stopped at " + System.DateTime.Now.ToString("mm:ss.FF"));
    }

}
