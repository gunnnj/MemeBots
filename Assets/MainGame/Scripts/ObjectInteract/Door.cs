using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject door;
    public float rotationY = 100f;

    void Start()
    {
        // rotationY = door.transform.rotation.y;
    }
    public async void Interact()
    {
        Debug.Log("Door");
        
        door.transform.DORotate(new Vector3(0,rotationY,0),1f,RotateMode.Fast);

        await Task.Delay(2000);

        door.transform.DORotate(new Vector3(0,-90f,0),1f,RotateMode.Fast);
    }
}
