using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private int value = 1;
    [SerializeField] private GameObject collectFX;

    [Header("Camera Feedback")]
    private CameraFOVController cam;

    private void Start()
    {
        // Cache reference once (better than calling every time)
        cam = FindObjectOfType<CameraFOVController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // 💰 Add coins
        CoinManager.Instance.AddCoins(value);

        // 🎥 Camera feedback (shake + FOV kick)
        if (cam != null)
        {
            cam.PlayCollectFeedback();
        }

        // ✨ Optional VFX
        if (collectFX != null)
        {
            Instantiate(collectFX, transform.position, Quaternion.identity);
        }

        // ❌ Destroy coin
        Destroy(gameObject);
    }

    private void Update()
    {
      
        //transform.Rotate(Vector3.up * 200f * Time.deltaTime);
    }
}