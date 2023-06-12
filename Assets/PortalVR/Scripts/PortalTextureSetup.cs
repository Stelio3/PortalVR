using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    [SerializeField] private Camera _cameraB;
    [SerializeField] private Camera _cameraA;

    [SerializeField] private Material _cameraMatB;
    [SerializeField] private Material _cameraMatA;
    // Start is called before the first frame update
    void Start()
    {
        if(_cameraB.targetTexture != null)
        {
            _cameraB.targetTexture.Release();
        }
        _cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatB.mainTexture = _cameraB.targetTexture;
    }

}
