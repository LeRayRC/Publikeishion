using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float liveTime_;
    public GameObject particlesPrefab_;
    Vector3 particlesScale_;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate<GameObject>(particlesPrefab_, gameObject.transform.position, gameObject.transform.rotation);
        go.GetComponent<ParticleSystem>().Play();

        go.transform.SetParent(gameObject.transform);
        Destroy(gameObject,liveTime_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("target")){
            //Reload
            GameManager.instance.spawnTarget();
            Destroy(other.gameObject);
            Destroy(this);
        }
    }
}
