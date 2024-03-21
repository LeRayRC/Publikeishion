using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsController : MonoBehaviour
{
    public void ResetScore(){
        GameManager.instance.ResetScore();
    }
}
