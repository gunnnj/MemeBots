using System.Threading.Tasks;
using UnityEngine;

public class BotOdindindun : BaseMove
{
    public Animator animator;
    public GameObject body;
    private const string animAttack = "isAttack";
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public async void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Attack Player");
            agent.SetDestination(other.transform.position);
            other.GetComponent<PlayerMovement>()?.PlayerDead(transform.position);
            animator.SetBool(animAttack,true);
            await Task.Delay(100);
            animator.SetBool(animAttack,false);
            await Task.Delay(500);
            body.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
