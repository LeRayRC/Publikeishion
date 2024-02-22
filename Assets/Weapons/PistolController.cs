using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
// using Uni

public class PistolController : MonoBehaviour
{
    public InputActionReference controllerActionActivate;
    public GameObject bulletPrefab_;
    public Transform shootTR_;
    public float shootForce_;
    private void Awake(){
        controllerActionActivate.action.performed += Shoot;

    }

    private void Shoot(InputAction.CallbackContext obj){
        GameObject go_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
        Rigidbody rb_ = go_.GetComponent<Rigidbody>();
        rb_.AddForce(shootTR_.forward * shootForce_,ForceMode.Impulse);
        Debug.Log("Shooting");
    }
}
