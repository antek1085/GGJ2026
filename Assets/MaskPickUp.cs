using DG.Tweening;
using UnityEngine;

public class MaskPickUp : MonoBehaviour
{
    public Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPickUp()
    {
        transform.DOMove(target.position, 1f);
        target.gameObject.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
