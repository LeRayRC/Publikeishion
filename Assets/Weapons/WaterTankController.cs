using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterTankController : MonoBehaviour
{
    public float capacityLeft_;
    public float maxCapacity_;
    public float reloadAmount_;
    public float loadPercentage_;

    public XRGrabInteractable grabInteractable_;
    public Transform parentGameobject_;
    public GameObject placeReference_;

    private Material bodyMat_;
    public Color fullLoadedColor_;
    public Color emptyColor_;
    public bool grabbed_;


    // public bool placeOnReference_;
    // Start is called before the first frame update
    void Start()
    {
        capacityLeft_ = maxCapacity_;
        loadPercentage_ = capacityLeft_ / maxCapacity_;
        bodyMat_ = gameObject.GetComponent<Renderer>().material;
        // placeOnReference_ = true;
        parentGameobject_ = gameObject.transform.parent;
        grabInteractable_ = GetComponent<XRGrabInteractable>();
        grabInteractable_.selectEntered.AddListener(OnGrabbed);
        grabInteractable_.selectExited.AddListener(OnRelease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTankColor(){
        Vector4 bodyColor_ = new Vector4();
        bodyColor_.x = Mathf.Lerp(emptyColor_.r, fullLoadedColor_.r, loadPercentage_);
        bodyColor_.y = Mathf.Lerp(emptyColor_.g, fullLoadedColor_.g, loadPercentage_);
        bodyColor_.z = Mathf.Lerp(emptyColor_.b, fullLoadedColor_.b, loadPercentage_);
        bodyColor_.w = Mathf.Lerp(emptyColor_.a, fullLoadedColor_.a, loadPercentage_);

        bodyMat_.color = new Color(bodyColor_.x, bodyColor_.y, bodyColor_.z, bodyColor_.w);
    }
    
    void OnGrabbed(SelectEnterEventArgs args){
        gameObject.transform.SetParent(null);

        if(parentGameobject_ != null){
            PistolController PC_ = parentGameobject_.gameObject.GetComponent<PistolController>();
            PC_.hasWaterTank_ = false;
        }
        grabbed_ = true;
    }

    void OnRelease(SelectExitEventArgs args){
        if(grabbed_ && placeReference_ != null){
            gameObject.transform.SetParent(parentGameobject_);
            gameObject.transform.position = placeReference_.transform.position;
            gameObject.transform.rotation = placeReference_.transform.rotation;

            PistolController PC_ = parentGameobject_.gameObject.GetComponent<PistolController>();
            PC_.hasWaterTank_ = true;
        }else{
            gameObject.transform.SetParent(null);
        }
        grabbed_ = false;
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("WaterTankCollider") && grabbed_){
            placeReference_ = other.gameObject;
            other.gameObject.GetComponent<Renderer>().enabled = true;
            // placeOnReference_ = true;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("fountain") && grabbed_){
            //Reload
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("fountain") && grabbed_){
            //Reload
            Reload(reloadAmount_);
            Debug.Log("Reloading");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("WaterTankCollider") && grabbed_){
            placeReference_ = null;
            other.gameObject.GetComponent<Renderer>().enabled = false;
            // placeOnReference_ = false;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("fountain") && grabbed_){
            gameObject.GetComponent<AudioSource>().Stop();
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
            SetTankColor();
        }
    }
}
