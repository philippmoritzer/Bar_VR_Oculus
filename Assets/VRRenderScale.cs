using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class VRRenderScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XRSettings.eyeTextureResolutionScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
