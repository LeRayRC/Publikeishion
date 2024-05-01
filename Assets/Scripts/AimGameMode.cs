using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGameMode : MonoBehaviour
{
    public float currentTime_;
    public float maxTime_;

    // Start is called before the first frame update
    void Start()
    {
        maxTime_ = 120.0f;
        currentTime_ = maxTime_;
    }

    // Update is called once per frame
    public void CustomUpdate()
    {
        currentTime_ -= Time.deltaTime;
        if (0 >= currentTime_)
        {
            
        }
    }
}
