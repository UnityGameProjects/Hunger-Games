using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour
{

    Time time;
    public GameObject system;

    void OnEnable()
    {
        time = GameObject.FindObjectOfType<Time>();
        time.eveningEvent += OnEvening;
        time.morningEvent += OnMorning;
    }	

    void OnDisable()
    {
        time.eveningEvent -= OnEvening;
        time.morningEvent -= OnMorning;
    }

    public void OnEvening()
    {
        system.SetActive(true);
        Debug.Log("Evening");
    }

    public void OnMorning()
    {
        system.SetActive(false);
        Debug.Log("Morning");
    }
}
