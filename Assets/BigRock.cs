using System;
using System.Collections;
using UnityEngine;

public class BigRock : MonoBehaviour
{
    public Rigidbody rb;
    public void StartRolling()
    {
        rb.useGravity = true;
        StartCoroutine(ForcePush());
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Door")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject,1f);
        }
    }
    IEnumerator ForcePush()
    {
        yield return new WaitForSeconds(1f);
        rb.AddForce(transform.forward * -10f);
    }
}
