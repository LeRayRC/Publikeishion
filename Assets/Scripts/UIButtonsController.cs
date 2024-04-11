using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonsController : MonoBehaviour
{
    public void ResetScore(){
        GameManager.instance.ResetScore();
    }

    public void ShiftMainMenuPosition(){
        GameManager.instance.menuController_.ActivateShiftPosition(GameManager.instance.MainMenuShiftedPosition_);
    }

    public void SetControlImage(int id){
        GameManager.instance.controlImage_.GetComponent<Image>().sprite = GameManager.instance.controlImagesList_[id];
    }
}


