using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllersManager : MonoBehaviour
{
    // Start is called before the first frame update
    public XRRayInteractor interactor;
    public float vibrationIntensity = 0.5f;
    public float vibrationDuration = 0.5f;
    private bool isHovering = false;

    private void Start()
    {
        // Suscribirse al evento de inicio de interacción con el objeto
        interactor.hoverEntered.AddListener(OnHoverEntered);
        // Suscribirse al evento de finalización de interacción con el objeto
        interactor.hoverExited.AddListener(OnHoverExited);
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        IXRHoverInteractable interactable = args.interactableObject;
        if(interactable != null){
            GetComponent<XRBaseController>().SendHapticImpulse(vibrationIntensity, vibrationDuration);
        }
        PistolController pistolController = interactable.colliders[0].gameObject.GetComponent<PistolController>();
        if(null != pistolController){
            pistolController.isHovered_ = true;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        IXRHoverInteractable interactable = args.interactableObject;
        
        PistolController pistolController = interactable.colliders[0].gameObject.GetComponent<PistolController>();
        if(null != pistolController){
            pistolController.isHovered_ = false;
        }
    }
}
