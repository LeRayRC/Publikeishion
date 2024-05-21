using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGameController : MonoBehaviour
{
    public InputActionReference controllerPauseActivate_;
    public bool gamePaused_;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused_ = false;
        controllerPauseActivate_.action.performed += TooglePauseMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TooglePauseMenu(){
        gamePaused_ = !gamePaused_;
        GameManager.instance.gamePaused_ = gamePaused_;
        if(gamePaused_){
            Time.timeScale = 0.0f;
        }else{
            Time.timeScale = 1.0f;
        }
    }

    void TooglePauseMenu(InputAction.CallbackContext obj){
        gamePaused_ = !gamePaused_;
        GameManager.instance.gamePaused_ = gamePaused_;
        if(gamePaused_){
            Time.timeScale = 0.0f;
        }else{
            Time.timeScale = 1.0f;
        }
    }


}
