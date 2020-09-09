using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] private Light2D vision = null;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float minRadius = 5f;
    [SerializeField] private float maxRadius = 30f;

    private void FixedUpdate()
    {
        if (vision.pointLightOuterRadius > minRadius)
            vision.pointLightOuterRadius -= fadeSpeed * Time.deltaTime;
    }

    public void IncreaseVision(float value) => vision.pointLightOuterRadius = Mathf.Clamp(vision.pointLightOuterRadius + value, minRadius, maxRadius);
}
