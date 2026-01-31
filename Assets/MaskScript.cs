using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MaskScript : MonoBehaviour
{
    [SerializeField] XRGrabInteractable grabInteractable;
    [SerializeField] GameObject maskSocket;
    Rigidbody rigidBody;
    void Start()
    {
        grabInteractable.selectEntered.AddListener(OnMaskGrab);
        grabInteractable.selectExited.AddListener(OnMaskRelease);
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
    
    void OnMaskGrab(SelectEnterEventArgs arg0)
    {
        MaskWorldEvent.instance.MaskGrab(true);
        rigidBody.constraints = RigidbodyConstraints.None;
    } 
    void OnMaskRelease(SelectExitEventArgs arg0)
    {
        MaskWorldEvent.instance.MaskGrab(false);
        transform.DOMove(maskSocket.transform.position, 1);
        transform.DORotate(maskSocket.transform.eulerAngles, 1);
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
