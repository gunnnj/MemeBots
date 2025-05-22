using UnityEngine;

public class Ball : MonoBehaviour, IInteractable
{
    public float forceAmount = 500f; 
    public Rigidbody rb;
    public float dragAmount = 1f;
    private PlayerMovement player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }
      
    public void Interact()
    {
        Debug.Log("PushBall");
        Vector3 pushDirection = (rb.transform.position-player.transform.position).normalized; 
        rb.AddForce(pushDirection * forceAmount); 
    }
    void Update()
    {
        // Giảm tốc độ của bóng
        if (rb.linearVelocity.magnitude > 0.1f) // Nếu tốc độ vẫn còn
        {
            rb.linearVelocity -= rb.linearVelocity.normalized * dragAmount * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = Vector3.zero; // Dừng bóng
        }
    }
}
