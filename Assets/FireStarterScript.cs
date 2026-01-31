using System;
using System.Collections.Generic;
using UnityEngine;

public class FireStarterScript : MonoBehaviour
{
    private List <GameObject> fireStarterList;
    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount -1; i++)
        {
            fireStarterList.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
