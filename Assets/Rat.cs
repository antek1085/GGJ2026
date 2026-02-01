using System;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public int numberOfRats;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawnPoint;

    void Start()
    {
        numberOfRats += 1;
    }
    public void OnHitRat()
    {
        numberOfRats -= 1;
        if (numberOfRats <= 0)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
