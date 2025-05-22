using UnityEngine;

public class BotRun : BaseMove, IPlayerRun
{
    public Animator animator;

    public override void Start()
    {
        base.Start();
        animator.SetBool("isRun",true);
    }
    public override void Update()
    {
        base.Update();
    }
    public void PlayerDead(Vector3 posBoss)
    {
        Debug.Log("die");
    }
}
