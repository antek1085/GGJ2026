using UnityEngine;

public class MaskWorldObject : MonoBehaviour
{
    private Renderer _renderer;
    private Collider _collider;
    public bool isRendererEnabled;
    void Start()
    {
        MaskWorldEvent.instance.onMaskGrab += MaskWorldObjectChangeState;
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
        MaskWorldObjectChangeState(false);
    }

    // Update is called once per frame
    void MaskWorldObjectChangeState(bool didGrab)
    {
        if(isRendererEnabled)
            _renderer.enabled = didGrab;
        
        _collider.enabled = didGrab;
    }
}
