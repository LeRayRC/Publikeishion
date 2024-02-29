using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
// using Uni

public class PistolController : MonoBehaviour
{
    public float capacityLeft_;
    public float maxCapacity_;
    public float shotCost_;
    public float reloadAmount_;

    public InputActionReference controllerActionActivate;
    public GameObject bulletPrefab_;
    public Transform shootTR_;
    public float shootForce_;

    public GameObject pistolBody_;
    private Material bodyMat_;
    public Color fullLoadedColor_;
    public Color emptyColor_;

    [SerializeField]
    private float loadPercentage_;
    public void Start(){
        capacityLeft_ = maxCapacity_;
        bodyMat_ = pistolBody_.GetComponent<MeshRenderer>().material;
        bodyMat_.color = fullLoadedColor_;
        loadPercentage_ = capacityLeft_ / maxCapacity_;
    }
    private void Awake(){
        controllerActionActivate.action.performed += Shoot;

    }

    public void Update(){
        //Update body color 
        Vector3 bodyColor_ = new Vector3();
        bodyColor_.x = Mathf.Lerp(emptyColor_.r, fullLoadedColor_.r, loadPercentage_);
        bodyColor_.y = Mathf.Lerp(emptyColor_.g, fullLoadedColor_.g, loadPercentage_);
        bodyColor_.z = Mathf.Lerp(emptyColor_.b, fullLoadedColor_.b, loadPercentage_);

        bodyMat_.color = new Color(bodyColor_.x, bodyColor_.y, bodyColor_.z, 1.0f);
    }

    private void Shoot(InputAction.CallbackContext obj){
        if(capacityLeft_ >= shotCost_){
            GameObject go_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
            Rigidbody rb_ = go_.GetComponent<Rigidbody>();
            rb_.AddForce(shootTR_.forward * shootForce_,ForceMode.Impulse);
            capacityLeft_-= shotCost_;
            loadPercentage_ = capacityLeft_ / maxCapacity_;
        }
    }

    public void OnTriggerStay(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("fountain")){
            //Reload
            Reload(reloadAmount_);
            Debug.Log("Reloading");
        }
    }

    public void Reload(float reloadAmount){
        if (capacityLeft_ > maxCapacity_)
        {
            capacityLeft_ = maxCapacity_;
        }
        else
        {
            capacityLeft_ += reloadAmount * Time.deltaTime;
            loadPercentage_ = capacityLeft_ / maxCapacity_;
        }
    }
}
