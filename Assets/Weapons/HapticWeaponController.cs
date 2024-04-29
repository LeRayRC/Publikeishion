using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticWeaponController : MonoBehaviour
{
    public XRBaseController rightController;
    public XRBaseController leftController;

    public enum ControllerSelected{
        Left,
        Right,
        None,
    }
    // Start is called before the first frame update
    void Start()
    {
        //rightController = XRBaseController 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VibrateController(ControllerSelected selected, float intensity, float duration){
        switch(selected){
            case ControllerSelected.Left:
                leftController.SendHapticImpulse(intensity, duration);
                break;
            case ControllerSelected.Right:
                rightController.SendHapticImpulse(intensity, duration);
                break;
        }
    }
}
