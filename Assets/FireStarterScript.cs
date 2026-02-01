using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class FireStarterScript : MonoBehaviour
{
    private List <GameObject> fireStarterList = new List<GameObject>();
    public bool isOnFire = false;
    public Rigidbody rockRigidBody;
    
    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
                fireStarterList.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(StartFire(0));
    }
    

    public IEnumerator StartFire(int i)
    {
        if (fireStarterList.Count != i)
        {
            fireStarterList[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(StartFire(i + 1));   
        }
        else
        {
            AllFiresLightUp();
            StopAllCoroutines();
        }
    }

    void AllFiresLightUp()
    {
        rockRigidBody.GetComponent<BigRock>().StartRolling();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireTorch") && !isOnFire)
        {
            StartCoroutine(StartFire(0));
        }
    }
}
