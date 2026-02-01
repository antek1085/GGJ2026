using UnityEngine;

public class StairsController : MonoBehaviour
{
    public GameObject stairPrefab;
    public bool isRendererEnabled;
    
    void Start()
    {
        MaskWorldEvent.instance.onMaskGrab += MaskWorldObjectChangeState;
    }

    private void MaskWorldObjectChangeState(bool obj)
    {
        stairPrefab.SetActive(!obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
