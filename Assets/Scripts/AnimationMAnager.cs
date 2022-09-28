using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMAnager : MonoBehaviour
{
    public Animator animaitorUI;
    public bool show = false;
    // Start is called before the first frame update
    public void On_Click_BTN()
    {
        if (show)
        {
            show = false;
            animaitorUI.SetBool("Show", show);
        }
        else
        {
            show = true;
            animaitorUI.SetBool("Show", show);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            On_Click_BTN();
        }
    }
}
