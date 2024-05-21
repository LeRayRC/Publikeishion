using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float liveTime_;
    public GameObject particlesPrefab_;
    void Start()
    {
        GameObject go = Instantiate<GameObject>(particlesPrefab_, gameObject.transform.position, gameObject.transform.rotation);
        go.GetComponent<ParticleSystem>().Play();

        go.transform.SetParent(gameObject.transform);
        Destroy(gameObject,liveTime_);
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("target")){
            //Reload
            TargetController TC_ = other.gameObject.GetComponent<TargetController>();
            //if(TC_.isTemporal_){
            //    GameManager.instance.spawnTempTarget();
            //}else{
            //    GameManager.instance.spawnTarget();
            //}
            GameManager.instance.spawnTempTarget();
            if(GameSceneLink.instance.challengeSelected == GameHelpers.GameChallenge.GameChallenge_Tutorial){
                GameManager.instance.tutorialController.TargetDestroyed();
            }

            GameManager.instance.gameStats_.ShotAimed();
            GameManager.instance.gameStats_.AddScore(TC_.score_);
            GameManager.instance.ActivateTargetPoint(TC_.score_,TC_.gameObject.transform.position);
            //Spawn FX at target
            GameObject go = Instantiate<GameObject>(GameManager.instance.impactTargetFX_, other.gameObject.transform.position, other.gameObject.transform.rotation);
            go.GetComponent<ParticleSystem>().Play();
            go.GetComponent<AudioSource>().Play();
            Destroy(go, go.GetComponent<ParticleSystem>().main.duration);
            Destroy(other.gameObject);
            GameManager.instance.targetCount_--;
            Destroy(this);
        }
    }
}
