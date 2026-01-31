using System;
using UnityEngine;

public class MaskWorldEvent : MonoBehaviour
{
    public static MaskWorldEvent instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }

    public event Action<bool> onMaskGrab;

    public void MaskGrab(bool didGrab)
    {
        if (onMaskGrab != null)
        {
            onMaskGrab(didGrab);
        }
    }
}
