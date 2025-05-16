using System.Threading.Tasks;
using UnityEngine;

public class BotCapuchino : BaseMove
{
    public Animator animator;
    private const string animAttack = "isAttack";
    // private const string animWalk = "isWalk";
    private float originSpeed;
    public override void Start()
    {
        base.Start();
        originSpeed = agent.speed;
    }
    public override void Update()
    {
        base.Update();
    }
    async void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Attack Player");
            agent.SetDestination(other.transform.position);
            other.GetComponent<PlayerMovement>()?.PlayerDead(transform.position);
            await Task.Delay(500);
            agent.speed = 0;
            animator.SetBool(animAttack,true);
            await Task.Delay(100);
            animator.SetBool(animAttack,false);
            await Task.Delay(1500);
            RandomTarget();
            agent.speed = originSpeed;
        }
    }

    public void LookToTarget(){
        Vector3 dir = (target-transform.position).normalized;
        dir.y = 0;
        Quaternion quaternion = Quaternion.LookRotation(dir);
        transform.rotation = quaternion;
        Debug.Log("Quay");
    }
}
