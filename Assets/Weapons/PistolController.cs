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

    public int shotTrailsAmount_;


    public bool hasWaterTank_;
    //Init values
     Vector3 initPos_;
    private Quaternion initRot_;

    public WaterTankController WaterTank_;

    public bool canShoot;

    
    public void Start(){
        initRot_ = gameObject.transform.rotation;
        initPos_ = gameObject.transform.position;
        hasWaterTank_ = true;
        canShoot = true;
        
        bodyMat_ = pistolBody_.GetComponent<MeshRenderer>().material;
        bodyMat_.color = fullLoadedColor_;
        
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
        //GameManager.instance.UiGameobject_.SetActive(!isGrabbed_);
    }

    private IEnumerator ShootTrail(){
        float shotScale_ = 0.0f; 
        for (int i = 0; i < shotTrailsAmount_; i++){
            shotScale_ = Mathf.Clamp(1.0f - ((float)(i +1) / (float)shotTrailsAmount_), 0.1f, 1.0f);
            GameObject go_ = Instantiate<GameObject>(bulletTrailPrefab_, shootTR_.position, shootTR_.rotation);
            go_.transform.localScale = new Vector3(go_.transform.localScale.x * shotScale_,
                                                   go_.transform.localScale.y * shotScale_,
                                                   go_.transform.localScale.z * shotScale_) ;
            Rigidbody rb_ = go_.GetComponent<Rigidbody>();
            rb_.AddForce(shootTR_.forward * shootForce_, ForceMode.Impulse);
            yield return null;
        }
    }

    private void Shoot(InputAction.CallbackContext obj){
        if(canShoot){
            if(isGrabbed_ && hasWaterTank_){
                if(WaterTank_.capacityLeft_ >= shotCost_){
                    GameObject go_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
                    Rigidbody rb_ = go_.GetComponent<Rigidbody>();
                    rb_.AddForce(shootTR_.forward * shootForce_,ForceMode.Impulse);
                    WaterTank_.capacityLeft_-= shotCost_;
                    WaterTank_.loadPercentage_ = WaterTank_.capacityLeft_ / WaterTank_.maxCapacity_;

                    WaterTank_.SetTankColor();
                    //Trigger Sound
                    audioSource_.clip = soundTracks_[0];
                    audioSource_.Play();


                    // GameObject go2_ = Instantiate<GameObject>(bulletPrefab_, shootTR_.position, shootTR_.rotation);
                    // Rigidbody rb2_ = go2_.GetComponent<Rigidbody>();
                    // rb2_.AddForce(shootTR_.forward * shootForce_, ForceMode.Impulse);
                    // Debug.Log("Trail");

                    //StartCoroutine(ShootTrail());
                }else{
                    if(GameSceneLink.instance.challengeSelected == GameHelpers.GameChallenge.GameChallenge_Tutorial){
                        WeaponTutorialIntegration wti = GetComponent<WeaponTutorialIntegration>();
                        wti.EmptyTank();
                    }
                    audioSource_.clip = soundTracks_[1];
                    audioSource_.Play();
                }
            }
        }
    }

    void OnGrabbed(SelectEnterEventArgs args){
        isGrabbed_ = true;

        if(GameSceneLink.instance.challengeSelected == GameHelpers.GameChallenge.GameChallenge_Tutorial){
            WeaponTutorialIntegration wti = GetComponent<WeaponTutorialIntegration>();
            wti.WeaponGrabbed();
        }
    }

    void OnRelease(SelectExitEventArgs args){
        isGrabbed_ = false;
        gameObject.transform.rotation = initRot_;
        gameObject.transform.position = initPos_;
    }

    
}
