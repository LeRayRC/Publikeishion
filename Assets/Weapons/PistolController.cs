using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
// using Uni

public class PistolController : MonoBehaviour
{
    
    public float shotCost_;

    public InputActionReference controllerActionActivate;
    public XRGrabInteractable grabInteractable_;
    public GameObject bulletPrefab_;
    public Transform shootTR_;
    public float shootForce_;

    public GameObject pistolBody_;
    private Material bodyMat_;
    public Color fullLoadedColor_;
    public Color emptyColor_;
    public bool isGrabbed_;

    public bool hasWaterTank_;
    //Init values
    public Transform initPos_;
    private Quaternion initRot_;

    public WaterTankController WaterTank_;

    
    public void Start(){
        initRot_ = gameObject.transform.rotation;

        hasWaterTank_ = true;
        
        bodyMat_ = pistolBody_.GetComponent<MeshRenderer>().material;
        bodyMat_.color = fullLoadedColor_;
        
        isGrabbed_ = false;
        grabInteractable_ = GetComponent<XRGrabInteractable>();
        grabInteractable_.selectEntered.AddListener(OnGrabbed);
        grabInteractable_.selectExited.AddListener(OnRelease);
    }
    private void Awake(){
        controllerActionActivate.action.performed += Shoot;

    }

    public void Update(){
    }

    

    private void Shoot(InputAction.CallbackContext obj){
        if(isGrabbed_ && hasWaterTank_){
            if(WaterTank_.capacityLeft_ >= shotCost_){
                GameObject go_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
                Rigidbody rb_ = go_.GetComponent<Rigidbody>();
                rb_.AddForce(shootTR_.forward * shootForce_,ForceMode.Impulse);
                WaterTank_.capacityLeft_-= shotCost_;
                WaterTank_.loadPercentage_ = WaterTank_.capacityLeft_ / WaterTank_.maxCapacity_;

                WaterTank_.SetTankColor();
                //Trigger Sound
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void OnTriggerStay(Collider other){
        
    }

    void OnGrabbed(SelectEnterEventArgs args){
        isGrabbed_ = true;
    }

    void OnRelease(SelectExitEventArgs args){
        isGrabbed_ = false;
        gameObject.transform.rotation = initRot_;
        gameObject.transform.position = initPos_.position;
    }

    
}
