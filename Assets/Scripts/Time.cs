using UnityEngine;
using System.Collections;

public class Time : MonoBehaviour
{

    enum TimeOfDay
    {
        morning, day, evening, night
    }

    TimeOfDay timeOfDay = TimeOfDay.night;


    public float minutesPerCycle = 24;

    public float percentageOfDay;

    public delegate void MorningDelegate();
    public event MorningDelegate morningEvent; 


    public delegate void EveningDelegate();
    public event EveningDelegate eveningEvent;



    float secondPerCycle;

    void Start()
    {
        secondPerCycle = minutesPerCycle * 60;
        
    }

    public float time;

    void FixedUpdate()
    {
        time += UnityEngine.Time.deltaTime;

        percentageOfDay = (time % secondPerCycle) / secondPerCycle;

        UpdateTimeOfDay();
    }

    
    void UpdateTimeOfDay()
    {
        // Check for morning
        if (timeOfDay != TimeOfDay.morning && percentageOfDay < 0.30 && percentageOfDay > 0.20 )
        {
            if (morningEvent != null)
            {
                morningEvent();
                timeOfDay = TimeOfDay.morning;
            }
        }
        
        if (timeOfDay != TimeOfDay.evening && percentageOfDay > 0.70 && percentageOfDay < 0.80)
        {
            if (eveningEvent != null)
            {
                eveningEvent();
                timeOfDay = TimeOfDay.evening;
            }
        }


    }
}
