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
        
        cam = FindObjectOfType<CameraFOVController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        
        CoinManager.Instance.AddCoins(value);

        
        if (cam != null)
        {
            //cam.PlayCollectFeedback();
        }

        
        if (collectFX != null)
        {
            Instantiate(collectFX, transform.position, Quaternion.identity);
        }

        
        Destroy(gameObject);
    }

    private void Update()
    {
      
        //transform.Rotate(Vector3.up * 200f * Time.deltaTime);
    }
}