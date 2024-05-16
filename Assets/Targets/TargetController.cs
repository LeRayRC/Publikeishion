using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class TargetController : MonoBehaviour
{

    public uint smallTargetScore_;
    public uint mediumTargetScore_;
    public uint bigTargetScore_;

    public Color smallTargetColor_;
    public Color mediumTargetColor_;
    public Color bigTargetColor_;
    
    public float score_;
    public bool movableTarget_;
    private TargetSize size_;

    public GameObject cylinder1_;
    public GameObject cylinder2_;

    public Vector2 sizeThresholds = new Vector2();
    
    public Vector3 sizes_ = new Vector3();
    public int movement_probability;
    public float movableTargetScoreMultiplier_;

    public bool isTemporal_;
    public float fallTimer_;
    
    enum TargetSize{
        none,
        small,
        medium,
        big,
    }

    public void init(){
        Vector3 localScale_;
        Transform tr_ = GetComponent<Transform>();
        int size_probability = Random.Range(0,10);
        if(size_probability < sizeThresholds.x){
            localScale_ = new Vector3(sizes_.x,sizes_.x,sizes_.x);
            score_ = smallTargetScore_;
            cylinder1_.GetComponent<MeshRenderer>().material.color = smallTargetColor_;
            cylinder2_.GetComponent<MeshRenderer>().material.color = smallTargetColor_;
        }else if(size_probability < sizeThresholds.y){
            localScale_ = new Vector3(sizes_.y, sizes_.y, sizes_.y);
            score_ = mediumTargetScore_;
            cylinder1_.GetComponent<MeshRenderer>().material.color = mediumTargetColor_;
            cylinder2_.GetComponent<MeshRenderer>().material.color = mediumTargetColor_;
        }else{
            localScale_ = new Vector3(sizes_.z,sizes_.z,sizes_.z);
            score_ = bigTargetScore_;
            cylinder1_.GetComponent<MeshRenderer>().material.color = bigTargetColor_;
            cylinder2_.GetComponent<MeshRenderer>().material.color = bigTargetColor_;
        }
        
        tr_.localScale = localScale_;

        int movement_probability_calculated = Random.Range(0,10);
        if(movement_probability_calculated < movement_probability){
            movableTarget_ = true;
            score_ *= movableTargetScoreMultiplier_;
            GetComponent<SplineAnimate>().enabled = true;
            SelectSpline();
        }else{
            movableTarget_ = false;
        }
    }

    public void Update(){
        transform.LookAt(GameManager.instance.player_.transform);

        if(isTemporal_){
            fallTimer_ -= Time.deltaTime;
            if(fallTimer_ <= 0.0f){
                Rigidbody rb_ = GetComponent<Rigidbody>();
                if(rb_){
                    rb_.useGravity = true;
                    GetComponent<SplineAnimate>().enabled = false;
                }
            }

            if(transform.position.y < GameManager.instance.player_.transform.position.y){
                //GameManager.instance.spawnTempTarget();
                GameManager.instance.targetCount_--;
                Destroy(gameObject,0.0f);
            }
        }

    }

    void SelectSpline(){
        SplineAnimate splineAnimate_ = GetComponent<SplineAnimate>();
        int splineSelected = Random.Range(0,GameManager.instance.targetsSplines_.Count);
        splineAnimate_.Container = GameManager.instance.targetsSplines_[splineSelected];    //Random select from spline lists
        splineAnimate_.Duration = Random.Range(25,40);
        splineAnimate_.StartOffset = Random.Range(0.0f,1.0f);
    }
}