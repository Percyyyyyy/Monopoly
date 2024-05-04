using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Random = System.Random;



public class Controlleur : MonoBehaviour
{

    GameObject controleurMenu;
    OptionMenu scriptMenu;
    void Start()
    {
       
        controleurMenu = GameObject.Find("ControleurMenu");
        scriptMenu = controleurMenu.GetComponent<OptionMenu>();
        Dictionary<string, Color> joueurCouleur = scriptMenu.joueurCouleur;
        foreach (var kvp in joueurCouleur)
        {
            Debug.Log("Clé : " + kvp.Key + ", Valeur : " + kvp.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}