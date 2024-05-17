using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointsController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inUse_;
    
    public float liveTime_;
    float initLiveTime_;

    public Vector3 initScale_;
    public Vector3 endScale_;
    Vector3 currentScale_;
    void Start()
    {
        initLiveTime_ = liveTime_;
    }

    public void Init(){
        liveTime_ = initLiveTime_;
    }

    // Update is called once per frame
    void Update()
    {
        if(inUse_){
            currentScale_ = Vector3.Lerp(endScale_, initScale_, liveTime_ / initLiveTime_);
            liveTime_ -= Time.deltaTime;
            //Lerp
            transform.LookAt(GameManager.instance.player_.transform);
            transform.localScale = currentScale_;
            if(liveTime_ < 0.0f){
                inUse_ = false;
            }
        }
    }

    public void Activate(){
        inUse_ = true;
        Init();
    }

}
