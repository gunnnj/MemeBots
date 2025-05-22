using UnityEngine;

public class Domino : MonoBehaviour, IInteractable
{
    public float forceAmount = 500f; 
    public Rigidbody rb;
    public void Interact()
    {
        Vector3 pushDirection = new Vector3(-1,0,0);
        rb.AddForce(pushDirection * forceAmount); 
    }
}
