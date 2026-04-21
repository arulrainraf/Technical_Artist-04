using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraFOVController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cineCam;
    [SerializeField] private MovingBody movingBody;

    [Header("FOV Settings")]
    [SerializeField] private float minFOV = 60f;
    [SerializeField] private float maxFOV = 100f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Shake Settings")]
    [SerializeField] private float shakeIntensity = 1.5f;
    [SerializeField] private float shakeDuration = 0.15f;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        noise = cineCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (cineCam == null || movingBody == null) return;

        
        float t = Mathf.InverseLerp(0f, maxSpeed, movingBody.CurrentSpeed);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, t);

        cineCam.Lens.FieldOfView = Mathf.Lerp(
            cineCam.Lens.FieldOfView,
            targetFOV,
            Time.deltaTime * smoothSpeed
        );
    }

    
    public void PlayCollectFeedback()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());

        
        cineCam.Lens.FieldOfView += 2f;
    }

    private IEnumerator ShakeRoutine()
    {
        if (noise == null) yield break;

        noise.AmplitudeGain = shakeIntensity;
        noise.FrequencyGain = shakeIntensity;

        float timer = 0f;

        while (timer < shakeDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        noise.AmplitudeGain = 0f;
        noise.FrequencyGain = 0f;
    }
}