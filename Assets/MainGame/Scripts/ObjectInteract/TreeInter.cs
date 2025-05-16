using UnityEngine;

public class TreeInter : MonoBehaviour, IInteractable
{
    public float fallDelay = 1.0f;
    public Rigidbody rb;
    private bool isInteract = false;
    public void Interact()
    {
        if(!isInteract){
            Debug.Log("Tree Interact");
            Invoke("Fall", fallDelay);
        }
        
    }

    void Fall()
    {
        Vector3 fallDirection = new Vector3(0, -1, 0); 
        rb.AddForce(fallDirection * 5000); 
        isInteract = true;
    }
}
