using System.Threading.Tasks;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    public float forceAmount = 500f; 
    public Rigidbody rb;
    private PlayerMovement player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }
    public async void Interact()
    {
        Debug.Log("Push");
        Vector3 pushDirection = (rb.transform.position-player.transform.position).normalized; 
        rb.AddForce(pushDirection * forceAmount); 
        await Task.Delay(700);
        rb.isKinematic = true;
        await Task.Delay(100);
        rb.isKinematic = false;
        
    }
}
