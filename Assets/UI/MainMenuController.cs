using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private RectTransform rectTransform_;
    private RectTransform initRectTransform_;
    private bool shifted;
    // Start is called before the first frame update
    void Start()
    {
        shifted = false;
        rectTransform_ = GetComponent<RectTransform>();
        initRectTransform_ = rectTransform_;
    }

    // Update is called once per frame
    public void InteractMainMenu(RectTransform finalRectTransform, GameHelpers.GameMenu menu){
        if(!shifted){
            StartCoroutine(ShiftPosition(finalRectTransform));
        }
        GameManager.instance.SetActiveMenu(menu);
    }

    public IEnumerator ShiftPosition(RectTransform finalRectTransform){
        while(Vector3.Distance(rectTransform_.position, finalRectTransform.position) > 0.01f){
            rectTransform_.position = Vector3.Lerp(rectTransform_.position,finalRectTransform.position,0.05f);
            yield return null;
        }
    }
}
