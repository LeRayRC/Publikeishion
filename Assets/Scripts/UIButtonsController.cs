using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsController : MonoBehaviour
{
    public void ResetScore(){
        GameManager.instance.ResetScore();
    }

    public void ShiftMainMenuPosition(){
        GameManager.instance.menuController_.ActivateShiftPosition(GameManager.instance.MainMenuShiftedPosition_);
    }
}


