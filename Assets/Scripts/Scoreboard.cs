using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public List<GameObject> listScoreboardJoueur = new List<GameObject>();
    GameObject controleurMenu;
    OptionMenu scriptMenu;
    List<string> listeJoueur;
    int nbJoueurs;
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        controleurMenu = GameObject.Find("ControleurMenu");
        scriptMenu = controleurMenu.GetComponent<OptionMenu>();
        Dictionary<string, Color> joueurCouleur = scriptMenu.joueurCouleur;
        listeJoueur = scriptMenu.listeJoueur;
        // mise en place des couleurs des joueurs dans le scoreboard
        for(i = 0; i < listScoreboardJoueur.Count; i++)
        {
            
            if(i < joueurCouleur.Count)
            {
                Image component = listScoreboardJoueur[i].GetComponentInChildren<Image>();
                component.color = joueurCouleur.ElementAt(i).Value;
                nbJoueurs++;
            }
            else
            {
                listScoreboardJoueur[i].SetActive(false);
            }

        }
       
    }

    public void changementDeJoueur()
    {
        GameObject component;
        if (j == nbJoueurs)
        {
            j = 0;
        }
        component = listScoreboardJoueur[j].transform.GetChild(1).gameObject;
        component.GetComponent<Image>().color = Color.green;
        foreach (GameObject go in listScoreboardJoueur)
        {
            Image image = go.transform.GetChild(1).gameObject.GetComponent<Image>();
            if (image != component.GetComponent<Image>())
            {
                image.color = Color.red;
            }
        }
        j++;

    }
    // Update is called once per frame
    void Update()
    {
    }
}
