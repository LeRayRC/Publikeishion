using UnityEngine;
using System;

public class GameHelpers : MonoBehaviour{


[Serializable]
public enum GameMenu{
    GameMenu_PlayMenu,
    GameMenu_ControlsMenu,
    GameMenu_SettingsMenu,
    GameMenu_CreditsMenu,
    GameMenu_PauseMenu,
    GameMenu_None,
    }

public enum GameChallenge{
    GameChallenge_Aim,
    GameChallenge_Survive,
    GameChallenge_Tutorial,
    GameChallenge_None,
}

}

