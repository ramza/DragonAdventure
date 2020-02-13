using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour
{

    public Light sun;
    public float secondsInFullDay = 120f;
    float currentTimeOfDay;
    [HideInInspector]
    public float timeMultiplier = 1f;

    private Color fogColor;
    private Color startColor;
    public float fogIncrement = 0.001f;
    float sunInitialIntensity;

    void Start()
    {
        startColor = RenderSettings.fogColor;
        fogColor = startColor;
        RenderSettings.fog = true;
        sunInitialIntensity = sun.intensity;
        currentTimeOfDay = GameManager.Instance.currentTimeOfDay;
    }


    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        GameManager.Instance.currentTimeOfDay = currentTimeOfDay;
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 100, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            RenderSettings.fogColor = Color.black;
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            fogColor = new Color(fogColor.r + fogIncrement, fogColor.g + fogIncrement, fogColor.b + fogIncrement);
            RenderSettings.fogColor = fogColor;
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if(currentTimeOfDay <= 0.27f)
        {
            RenderSettings.fogColor = startColor;
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            fogColor = new Color(fogColor.r - fogIncrement, fogColor.g - fogIncrement, fogColor.b - fogIncrement);
  
            RenderSettings.fogColor = fogColor;
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}