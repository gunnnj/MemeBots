using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BaseMove : MonoBehaviour
{
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float distance = 7f;
    protected NavMeshAgent agent;
    protected Coroutine coroutine;
    protected Vector3 target; 
    private float targetChangeTimer;
    private float targetChangeInterval = 5f;
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RandomTarget();
    }
    public virtual void Update()
    {
        RaycastHit hit;
        Vector3 position = transform.position; 


        if (Physics.SphereCast(position, 5f, transform.forward, out hit, distance, layerMask))
        {
            agent.SetDestination(hit.transform.position);
        }
        else{
            // if(coroutine==null){
            //     coroutine = StartCoroutine(SetDestination());
            // }
            targetChangeTimer -= Time.deltaTime;

            if (targetChangeTimer <= 0f)
            {
                RandomTarget();
                targetChangeTimer = targetChangeInterval;
            }
            if(Vector3.Distance(transform.position, target)<0.1f){
                RandomTarget();
            }
            
        }
    }
    public IEnumerator SetDestination()
    {
        RandomTarget();
        yield return new WaitForSeconds(4f);
        coroutine = null;
    }

    public void RandomTarget(){
        do{
            Vector3 randomDirection = Random.insideUnitSphere; 
            randomDirection.y = 0;
            target = transform.position + randomDirection.normalized * distance;
        }
        while(!IsPointOnNavMesh(target));
        agent.SetDestination(target); 
    }
    public bool IsPointOnNavMesh(Vector3 point)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(point, out hit, distance, NavMesh.AllAreas);
    }
}
