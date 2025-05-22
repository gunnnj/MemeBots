using System;
using UnityEngine;

public class PlayerInteration : MonoBehaviour, IInteractable
{
    public GamePlayUI gamePlayUI;
    public bool isTrigger;
    public bool isInteract;

    void Start()
    {
        gamePlayUI.onHand=()=>Interact();
    }

    public void Interact()
    {
        if(isTrigger){
            isInteract = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable")){
            GamePlayUI.displayHand?.Invoke(true);
            isTrigger = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Interactable")){
            if(gamePlayUI.onHand != null && isInteract){
                other.GetComponent<IInteractable>().Interact();
                isInteract = false;
            }
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable")){
            GamePlayUI.displayHand?.Invoke(false);
            isTrigger = false;
            isInteract = false;
        }
    }
}
