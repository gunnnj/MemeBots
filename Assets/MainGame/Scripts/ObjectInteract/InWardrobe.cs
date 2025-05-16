using UnityEngine;

public class InWardrobe : MonoBehaviour, IInteractable
{
    public GamePlayUI gamePlayUI;
    public PlayerMovement player;
    public Transform posIn;
    public Transform posOut;
    

    void Start()
    {
        gamePlayUI = FindFirstObjectByType<GamePlayUI>();
        player = FindFirstObjectByType<PlayerMovement>();

    }
    public void Interact()
    {
        player.SetPosition(posIn,posOut);
    }
}
