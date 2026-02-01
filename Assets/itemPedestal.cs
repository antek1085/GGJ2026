using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class itemPedestal : MonoBehaviour
{
    public XRInteractorTag interactor;

    [SerializeField] int itemIDNeeded;
    public static int placedright;

    int itemId;
    
    void Start()
    {
        interactor.selectEntered.AddListener(ItemEntered);
        interactor.selectExited.AddListener(ItemExited);
    }
    void ItemExited(SelectExitEventArgs arg0)
    {
        if (placedright == itemId)
        {
            placedright -= 1;
        }
    }
    void ItemEntered(SelectEnterEventArgs arg0)
    {
        itemId = arg0.interactableObject.transform.GetComponent<PedestalItem>().itemId;

        if (itemIDNeeded == itemId)
        {
            placedright += 1;

            if (placedright == 3)
            {
                OnAllItemPlaced();
            }
        }
    }

    void OnAllItemPlaced()
    {
        
    }
    
}
