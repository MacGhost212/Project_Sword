using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    public Light lightSource;
    private float initialIntensity;
    private float targetIntensity = 7f;
    private float transitionTime = 1f;
    private float timer = 0f;
    private bool isIncreasing = true;

    private void Start()
    {
        initialIntensity = lightSource.intensity;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isIncreasing)
        {
            lightSource.intensity = Mathf.Lerp(initialIntensity, targetIntensity, timer / transitionTime);

            if (timer >= transitionTime)
            {
                timer = 0f;
                isIncreasing = false;
            }
        }
        else
        {
            lightSource.intensity = Mathf.Lerp(targetIntensity, initialIntensity, timer / transitionTime);

            if (timer >= transitionTime)
            {
                timer = 0f;
                isIncreasing = true;
            }
        }
    }
}
