using UnityEngine;

public class MovingBody : MonoBehaviour
{
    [SerializeField] private float startSpeed = 5f;
    [SerializeField] private float maxSpeed = 25f;
    [SerializeField] private float acceleration = 2f;

    private float currentSpeed;
    public float CurrentSpeed => currentSpeed;

    private void Start()
    {
        currentSpeed = startSpeed;
    }

    private void Update()
    {
        // ⏫ Gradually increase speed
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, startSpeed, maxSpeed);

        // 🚗 Move ground
        transform.position -= Vector3.forward * currentSpeed * Time.deltaTime;
    }
}