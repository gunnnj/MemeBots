using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class BotCrocodiloControl : BaseMove
{
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
            await Task.Delay(1500);
            RandomTarget();
            agent.speed = originSpeed;
        }
    }
}
