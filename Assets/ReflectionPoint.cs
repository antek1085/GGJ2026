using UnityEngine;

public class ReflectionPoint : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    bool isSpawned = false;
    public void OnHit()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
