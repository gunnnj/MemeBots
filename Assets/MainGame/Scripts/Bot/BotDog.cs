using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class BotDog : BaseMove
{
    public Animator animator;
    private const string animAttack = "isAttack";
    private const string animWalk = "isWalk";
    private float originSpeed;

    public override void Start()
    {
        base.Start();
        originSpeed = agent.speed;
        animator.SetBool(animWalk,true);
    }

    public override void Update()
    {
        base.Update();
    }

    private async void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Attack Player");
            agent.SetDestination(other.transform.position);
            other.GetComponent<PlayerMovement>()?.PlayerDead(transform.position);
            await Task.Delay(500);
            agent.speed = 0;
            animator.SetBool(animAttack,true);
            await Task.Delay(1500);
            animator.SetBool(animAttack,false);
            agent.speed = originSpeed;
        }
    }
}
