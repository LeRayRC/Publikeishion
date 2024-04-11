using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMaterialController : MonoBehaviour
{
    MeshRenderer ms_;
    Material waterMaterial_;

    public float speed_;
    public float speed_limit_;

    bool backwards_movement;
    float movement_time_;
    public float movement_time_threshold_;
    // Start is called before the first frame update
    void Start()
    {
        ms_ = GetComponent<MeshRenderer>();
        waterMaterial_ = ms_.material;
        movement_time_ = 0.0f;
        backwards_movement = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement_time_ += Time.deltaTime;
        if(movement_time_ > movement_time_threshold_){
            backwards_movement = !backwards_movement;
            movement_time_ = 0.0f;
        }
        
        if(backwards_movement){
            speed_ -= (Time.deltaTime*0.01f);
            speed_ = Mathf.Clamp(speed_,-1.0f*speed_limit_, speed_limit_);
            waterMaterial_.mainTextureOffset = new Vector2(waterMaterial_.mainTextureOffset.x, waterMaterial_.mainTextureOffset.y + (speed_ * Time.deltaTime));
        }else{
            speed_ += (Time.deltaTime*0.01f);
            speed_ = Mathf.Clamp(speed_,-1.0f*speed_limit_, speed_limit_);
            waterMaterial_.mainTextureOffset = new Vector2(waterMaterial_.mainTextureOffset.x, waterMaterial_.mainTextureOffset.y + (speed_ * Time.deltaTime));
        }
    }
}
