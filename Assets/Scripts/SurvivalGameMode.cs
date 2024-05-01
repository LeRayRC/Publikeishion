using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalGameMode : MonoBehaviour
{
    public float currentTime_;

    // Start is called before the first frame update
    void Start()
    {
        currentTime_ = 120.0f;
    }

    public void AddTime(int time)
    {
        currentTime_ += time;
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
