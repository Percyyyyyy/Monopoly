using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSlide : MonoBehaviour
{
    public GameObject panelMenu;

    public void ShowhideMenu()
    {
        if(panelMenu != null)
        {
            Animator animator = panelMenu.GetComponent<Animator>();
            if(animator != null )
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }
}
