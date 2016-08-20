using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    Time time;

    Light light;

    float sunInitialIntensity;

    void Awake()
    {
        time = GameObject.FindObjectOfType<Time>();
        light = GetComponent<Light>();

        sunInitialIntensity = light.intensity;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(360 * time.percentageOfDay - 90, 170f, 0f));


        float currentTimeOfDay = time.percentageOfDay;

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        light.intensity = sunInitialIntensity * intensityMultiplier;
    }


}
