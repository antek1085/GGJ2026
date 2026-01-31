using UnityEngine;

public class Reflection : MonoBehaviour
{
    public GameObject reflectionPoint;
    public bool isHitted = false;
    public LayerMask layerMask;
    public LineRenderer lineRenderer;

    private Vector3 fireDestination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, reflectionPoint.transform.position);
        lineRenderer.SetPosition(1, reflectionPoint.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (isHitted)
        {
            ReflectFire();
        }
        else
        {
            lineRenderer.SetPosition(1, reflectionPoint.transform.position);
        }
        isHitted = false;
    }

    void ReflectFire()
    {
        if (Physics.Raycast(reflectionPoint.transform.position, fireDestination, out RaycastHit hit))
        {
            var destination = reflectionPoint.transform.forward.normalized;
            destination = Vector3.Reflect(destination,hit.normal).normalized;
            
            
            if(hit.transform.TryGetComponent(typeof(Reflection), out var reflection))
            {
                reflection.GetComponent<Reflection>().HitByFire(hit.point,destination);
            } 
            lineRenderer.SetPosition(1, hit.point);
        }
        
    }

    public void HitByFire(Vector3 transform, Vector3 direction)
    {
        lineRenderer.SetPosition(0, reflectionPoint.transform.position);
        reflectionPoint.transform.position = transform;
        fireDestination = direction;
        isHitted = true;
    }
    
}
