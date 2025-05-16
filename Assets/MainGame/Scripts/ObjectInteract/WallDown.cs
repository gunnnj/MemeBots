using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class WallDown : MonoBehaviour, IInteractable
{
    public GameObject wall;
    public float originY;
    public float height = 10f;
    public bool isInteract = false;

    void Start()
    {
        originY = wall.transform.position.y;
    }
    public async void Interact()
    {
        if(!isInteract){
            isInteract = true;
            Debug.Log("Wall down");
            wall.transform.DOMoveY(originY-height,2f).SetEase(Ease.Linear);
            await Task.Delay(3000);
            Debug.Log("Wall up");
            wall.transform.DOMoveY(originY,2f).SetEase(Ease.Linear);
            await Task.Delay(2000);
            isInteract = false;
        }
        
    }
}
