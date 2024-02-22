using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    Vector3 initPos_;
    Rigidbody rb_;
    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        initPos_ = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            gameObject.transform.position = initPos_;
            rb_.velocity = Vector3.zero;
        }
    }
}
