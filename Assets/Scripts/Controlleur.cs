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
    public GameObject panelMenu;

    void Start()
    {
        Animator animator = panelMenu.GetComponent<Animator>();
        animator.SetBool("show", false);

        controleurMenu = GameObject.Find("ControleurMenu");
        scriptMenu = controleurMenu.GetComponent<OptionMenu>();
        Dictionary<string, Color> joueurCouleur = scriptMenu.joueurCouleur;
        List<string> listeJoueur = scriptMenu.listeJoueur;

        foreach (var kvp in joueurCouleur)
        {
            Debug.Log("Clé : " + kvp.Key + ", Valeur : " + kvp.Value);
        }

        foreach (var joueur in listeJoueur)
        {
            Debug.Log("Joueur : " + joueur);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}