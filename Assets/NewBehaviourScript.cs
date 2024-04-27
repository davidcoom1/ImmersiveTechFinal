using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// Unity Script | 1 asset reference | 0 references
public class HMDInputManager : MonoBehaviour
{
    [SerializeField] GameObject VRRig;
    [SerializeField] GameObject FPSRig;

    // Start is called before the first frame update
    // Unity Message | 0 references
    void Start()
    {
        if (XRSettings.isDeviceActive || XRSettings.loadedDeviceName == "OpenXR Display")
        {
            Debug.Log("VR Rig Active Using device: " + XRSettings.loadedDeviceName);
            FPSRig.SetActive(false);
        }
        else
        {
            Debug.Log("Using FPS Rig");
            VRRig.SetActive(false);
        }
    }

    // Update is called once per frame
    // Unity Message | 0 references
    void Update()
    {

    }
}
