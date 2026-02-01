using UnityEngine;

public class LightDiscShoot : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask reflectionMask;

    [SerializeField] private Rigidbody rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        lineRenderer.useWorldSpace = true;
    }
    // Update is called once per frame
    /*void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Reflection"))
            {
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hit.point);
                lineRenderer.positionCount = 3;
                Vector3 direction = hit.point + Vector3.Reflect(ray.direction, hit.normal);
                lineRenderer.SetPosition(2,  hit.point + Vector3.Reflect(ray.direction, hit.normal) * 50f);
            }
            else
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hit.point);
            }
        }
    }*/
    void Update()
    {
        CastRay(transform.position, transform.forward);
    }

    void CastRay(Vector3 startPos, Vector3 startDir)
    {
        lineRenderer.SetPosition(0, startPos);

        Vector3 currentPos = startPos;
        Vector3 currentDir = startDir.normalized;
        
            if (Physics.Raycast(currentPos, currentDir, out RaycastHit hit))
            {
                lineRenderer.SetPosition(1, hit.point);

                // odbicie zwierciadlane
                
                if(hit.transform.TryGetComponent(typeof(Reflection), out var reflection))
                {
                    currentDir = Vector3.Reflect(currentDir, hit.normal).normalized;
                    reflection.GetComponent<Reflection>().HitByFire(hit.point,currentDir);
                }
            }
    }

    public void OnHolding()
    {
        rigidBody.freezeRotation = false;
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX;
    }

    public void OnReleased()
    {
        rigidBody.freezeRotation = true;
    }
    
}
