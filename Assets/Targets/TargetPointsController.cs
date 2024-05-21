using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text scoreText_;
    public ParticleSystem particles_;
    public AudioSource audioSource_;

    void Start()
    {
        inUse_ = false;
        initLiveTime_ = liveTime_;
    }

    public void Init(float score, Vector3 pos){
        liveTime_ = initLiveTime_;
        scoreText_.text = Mathf.FloorToInt(score).ToString();
        transform.position = pos;
        particles_.Play();
        audioSource_.Play();
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
                transform.position = transform.parent.gameObject.transform.position;
            }
        }
    }

    public void Activate(float score, Vector3 pos){

        inUse_ = true;
        Init(score, pos);
    }

}
