using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    public GamePlayUI gamePlayUI;
    public float rayDistance = 10f;
    public Transform[] targets;
    public RectTransform[] arrows;
    public LayerMask layerMask;
    public LayerMask blockLayerMask;

    void Update()
    {
        DetectBoss(targets[0], arrows[0]);
        DetectBoss(targets[1], arrows[1]);
        DetectBoss(targets[2], arrows[2]);
    }
    public void DetectBoss(Transform tar, RectTransform arrow){
        Vector3 rayDirection = tar.position - transform.position;
        rayDirection.y = 0;

        float angle = -Vector3.SignedAngle(transform.forward, rayDirection.normalized, Vector3.up);
        
        arrow.rotation = Quaternion.Euler(0, 0, angle);

        Ray ray = new Ray(transform.position, rayDirection.normalized);

        RaycastHit hit;

        LayerMask combinedLayerMask = layerMask | blockLayerMask;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, combinedLayerMask))
        {
            if (((1 << hit.collider.gameObject.layer) & blockLayerMask) != 0)
            {
                arrow.gameObject.SetActive(false);
                return;
            }
            if (((1 << hit.collider.gameObject.layer) & layerMask) != 0)
            {
                arrow.gameObject.SetActive(true);
            }
        }

    }
}
