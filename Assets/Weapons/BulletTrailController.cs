using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailController : MonoBehaviour
{
    public float liveTime_;
    void Start(){
        Destroy(gameObject,liveTime_);
    }
}
