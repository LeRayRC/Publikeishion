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
    public float capacityLeft_;
    public float maxCapacity_;
    public float shotCost_;
    public float reloadAmount_;

    public InputActionReference controllerActionActivate;
    public XRGrabInteractable grabInteractable_;
    public GameObject bulletPrefab_;
    public GameObject bulletTrailPrefab_;
    public Transform shootTR_;
    public float shootForce_;

    public GameObject pistolBody_;
    private Material bodyMat_;
    public Color fullLoadedColor_;
    public Color emptyColor_;
    public bool isGrabbed_;
    public AudioClip[] soundTracks_;
    private AudioSource audioSource_;


    //Init values
    public Transform initPos_;
    private Quaternion initRot_;


    [SerializeField]
    private float loadPercentage_;
    public void Start(){
        initRot_ = gameObject.transform.rotation;

        capacityLeft_ = maxCapacity_;
        bodyMat_ = pistolBody_.GetComponent<MeshRenderer>().material;
        bodyMat_.color = fullLoadedColor_;
        loadPercentage_ = capacityLeft_ / maxCapacity_;
        isGrabbed_ = false;
        grabInteractable_ = GetComponent<XRGrabInteractable>();
        grabInteractable_.selectEntered.AddListener(OnGrabbed);
        grabInteractable_.selectExited.AddListener(OnRelease);
        audioSource_ = GetComponent<AudioSource>();
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

    private IEnumerator ShootTrail(){

        for (int i = 0; i < 5; i++){
            GameObject go_ = Instantiate<GameObject>(bulletTrailPrefab_, shootTR_.position, shootTR_.rotation);
            Rigidbody rb_ = go_.GetComponent<Rigidbody>();
            rb_.AddForce(shootTR_.forward * shootForce_, ForceMode.Impulse);
            Debug.Log("Trail");
            yield return new WaitForSeconds(0.0001f);
        }
    }

    private void Shoot(InputAction.CallbackContext obj){
        if(isGrabbed_){
            if(capacityLeft_ >= shotCost_){
                GameObject go_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
                Rigidbody rb_ = go_.GetComponent<Rigidbody>();
                rb_.AddForce(shootTR_.forward * shootForce_,ForceMode.Impulse);
                capacityLeft_-= shotCost_;
                loadPercentage_ = capacityLeft_ / maxCapacity_;

                //Trigger Sound
                audioSource_.clip = soundTracks_[0];
                audioSource_.Play();


                // GameObject go2_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
                // Rigidbody rb2_ = go2_.GetComponent<Rigidbody>();
                // rb2_.AddForce(shootTR_.forward * shootForce_, ForceMode.Impulse);
                // Debug.Log("Trail");

                StartCoroutine(ShootTrail());
            }
        }
    }

    public void OnTriggerStay(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("fountain")){
            //Reload
            Reload(reloadAmount_);
            Debug.Log("Reloading");
        }
    }

    void OnGrabbed(SelectEnterEventArgs args){
        isGrabbed_ = true;
    }

    void OnRelease(SelectExitEventArgs args){
        isGrabbed_ = false;
        gameObject.transform.rotation = initRot_;
        gameObject.transform.position = initPos_.position;
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
            audioSource_.clip = soundTracks_[1];
            audioSource_.Play();
        }
    }
}
