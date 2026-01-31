using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class FireStarterScript : MonoBehaviour
{
    private List <VisualEffect> fireStarterList = new List<VisualEffect>();
    public bool isOnFire = false;
    public Rigidbody rockRigidBody;
    
    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).gameObject.TryGetComponent<VisualEffect>(out VisualEffect vfx))
                fireStarterList.Add(vfx);
        }
    }
    

    public IEnumerator StartFire(int i)
    {
        if (fireStarterList.Count != i)
        {
            fireStarterList[i].enabled = true;
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
        rockRigidBody.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireTorch") && !isOnFire)
        {
            StartCoroutine(StartFire(0));
        }
    }
}
