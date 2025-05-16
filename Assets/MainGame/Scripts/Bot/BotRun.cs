using UnityEngine;

public class BotRun : BaseMove
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
}
