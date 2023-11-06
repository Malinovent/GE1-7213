using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Singleton Implementation
    public static TimeManager Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private bool isTimeSlowed = false;
    private float timeSlowDuration;

    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(isTimeSlowed)
        {
            currentTime += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1, timeSlowDuration * Time.deltaTime);

            if(currentTime > timeSlowDuration)
            {
                isTimeSlowed = false;
                currentTime = 0;
                Time.timeScale = 1;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void TimeSlow(float intensity, float duration)
    {
        Time.timeScale = intensity;
        timeSlowDuration = duration;
        isTimeSlowed = true;
    }


}
