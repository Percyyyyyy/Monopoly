using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    public int numero_case = 1;
    public int prix;
    private int nbMaisonsAchetes = 0;
    private Camera_script script;
    private Scoreboard scriptScore;
    public GameObject card;
    public GameObject ControleurCarte;
    public bool choisie = false;
    bool buy = false;
    bool enAttente = true;
    void Start()
    {
        script = GameObject.Find("Gestionnaire").GetComponent<Camera_script>();
        scriptScore = GameObject.Find("ControleurScoreboard").GetComponent<Scoreboard>();

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(numero_case.ToString());

        DeplacerJoueur(targetObject);
    }



    void DeplacerJoueur(GameObject targetObject)
    {
        if (targetObject != null && numero_case != 1)
        {
            agent.SetDestination(targetObject.transform.position);

        }
        if (targetObject != null && Vector3.Distance(transform.position, targetObject.transform.position) < 0.5f && numero_case != 1 && enAttente && !choisie)
        {
            script.plateau();
            PlacerMaisonSurCase(targetObject);
            enAttente = false; 
        }
    }


    CarteAchat PlacerMaisonSurCase(GameObject targetObject)
    {
        card.transform.parent.gameObject.SetActive(true);
        card.gameObject.SetActive(true);

        CarteAchat controleurCarte = ControleurCarte.GetComponent<CarteAchat>();
        controleurCarte.textVille.text = targetObject.gameObject.name;
        controleurCarte.couleurCarte.color = targetObject.transform.GetChild(1).GetComponent<Renderer>().material.color;
        // initialisation des valeurs de la carte
        if (numero_case >= 1 && numero_case < 10)
        {
            controleurCarte.textPrix.text = "500$";
            prix = 500;
        }
        else if (numero_case >= 10 && numero_case < 19)
        {
            controleurCarte.textPrix.text = "300$";
            prix = 300;
        }
        else if (numero_case >= 19 && numero_case < 28)
        {
            controleurCarte.textPrix.text = "800$";
            prix = 800;
        }
        else
        {
            controleurCarte.textPrix.text = "600$";
            prix = 600;
        }
        return controleurCarte;
    }

    public void ReceiveDiceValue(int value)
    {
        Debug.Log("Le joueur a reçu la valeur du dé : " + value);
      
        numero_case += value;
        if (numero_case > 36)
        {
            int montantRestant = numero_case % 36;
            numero_case = 0 + montantRestant;
            TextMeshProUGUI textArgent = scriptScore.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
            // argent case départ
            string argentTexte = textArgent.text;
            int prixArgent = 0;
            prixArgent = Int32.Parse(argentTexte) + 1000;
            textArgent.text = prixArgent.ToString();
        }
        choisie = false;
    }

    public void PlacerMaison()
    {
        card.transform.parent.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag(numero_case.ToString()).transform.GetChild(0).gameObject.SetActive(true);
        enAttente = true;
        script.de();
        choisie = true;
        buy = true;
        nbMaisonsAchetes++;
        // Scoreboard actualisation
        TextMeshProUGUI textMaison = scriptScore.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();

        TextMeshProUGUI textArgent = scriptScore.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        textMaison.text = nbMaisonsAchetes.ToString();
        GameObject targetObject = GameObject.FindGameObjectWithTag(numero_case.ToString());
        string argentTexte = textArgent.text;
        int prixArgent = 0;
        prixArgent = Int32.Parse(argentTexte) - prix;
        textArgent.text = prixArgent.ToString();
    }

    public void PasPlacerMaison()
    {
        card.transform.parent.gameObject.SetActive(false);
        enAttente = true;
        script.de();
        choisie = true;
        buy = false;
    }
}
