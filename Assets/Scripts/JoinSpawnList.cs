using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinSpawnList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spawnTRs_.Add(gameObject.transform);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
