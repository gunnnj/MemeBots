using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class DoorRoll : MonoBehaviour, IInteractable
{
    public GameObject doorRoll;
    public float originY;
    public float height = 10f;
    public bool isInteract = false;
    void Start()
    {
        originY = doorRoll.transform.position.y;
    }
    public async void Interact()
    {
        if(!isInteract){
            isInteract = true;
            Debug.Log("door down");
            doorRoll.transform.DOMoveY(originY+height,1f).SetEase(Ease.Linear);
            await Task.Delay(3000);
            Debug.Log("door up");
            doorRoll.transform.DOMoveY(originY,1f).SetEase(Ease.Linear);
            await Task.Delay(2000);
            isInteract = false;
        }
    }
}
