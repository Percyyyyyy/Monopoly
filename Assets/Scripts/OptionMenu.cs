using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;

public class OptionMenu : MonoBehaviour
{
    int nbJoueurMax = 5;
    public static int nbTours = 5;
    public static int nbJoueurs = 2;
    public TMP_InputField inputTour;
    public TMP_InputField inputJoueur;
    public TextMeshProUGUI joueurActuelText;
    public UnityEngine.UI.Button btnValider;
    public Canvas optionMenu;
    public Canvas choisirObjet;
    bool afficherPopup;
    string nom = "Joueur";
    int num�roJoueur = 0;
    public List<string> listeJoueur = new List<string>();
    public List<GameObject> listePions = new List<GameObject>();
    public List<Color> listeCouleur = new List<Color> { Color.green, Color.red, Color.blue, Color.yellow, Color.magenta };
    public Dictionary<string, Color> joueurCouleur = new Dictionary<string, Color>();
    public Dictionary<string, GameObject> joueurPion = new Dictionary<string, GameObject>();
    int indexJoueur = 0;
    string joueurActuel = "";
    // Start is called before the first frame update
    void Start()
    {


    }
    void OnGUI()
    {
        if (afficherPopup)
        {
            // Affiche le pop-up avec un message
            GUI.Window(0, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), AfficherPopup, "Erreur : Trop de joueurs !");
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void AfficherPopup(int windowID)
    {
        GUI.Label(new Rect(65, 40, 200, 30), "Le nombre de joueurs est trop �lev� !");
        if (GUI.Button(new Rect(100, 100, 100, 30), "Fermer"))
        {
            // Ferme le pop-up en d�finissant afficherPopup � false
            afficherPopup = false;
        }
    }
    public void AttribuerCouleursAuxJoueurs(string joueur)
    {
        Random random = new Random();
        int indexCouleurAleatoire = random.Next(listeCouleur.Count);
        Color couleurChoisie = listeCouleur[indexCouleurAleatoire];
        joueurCouleur.Add(joueur, couleurChoisie);
        Debug.Log("La couleur " + couleurChoisie + " est assign� � " + joueur);
        listeCouleur.RemoveAt(indexCouleurAleatoire);
    }
    public void AssignerPionsAuxJoueurs(GameObject pion)
    {
        AjouterNombresJoueursDefini();
        joueurActuel = changementJoueur();
        GameObject ancienPion;
        if (joueurPion.ContainsKey(joueurActuel))
        {
            ancienPion = joueurPion[joueurActuel];
            joueurPion[joueurActuel] = pion;
            Debug.Log("Le pion " + pion + " est assign� � " + joueurActuel);
            AssignerCouleurAuxPions(ancienPion, pion, joueurActuel);

        }
        else
        {
            joueurPion.Add(joueurActuel, pion);
            AssignerCouleurAuxPions(pion, joueurActuel);

        }

    }
    public void AssignerCouleurAuxPions(GameObject ancienPion,GameObject pion, string joueur)
    {
        RawImage raw = pion.GetComponentInChildren<RawImage>();
        RawImage oldRaw = ancienPion.GetComponentInChildren<RawImage>();

        if (joueurCouleur.ContainsKey(joueur))
        {
            oldRaw.color = Color.white;
            raw.color = joueurCouleur[joueur];
            Debug.Log("La couleur du joueur assign� � " + pion + " est " + joueurCouleur[joueur]);
        }
        else
        {
            Debug.LogError("La couleur du joueur " + joueur + " n'est pas d�finie.");
        }
    }
    public void AssignerCouleurAuxPions(GameObject pion, string joueur)
    {
        RawImage raw = pion.GetComponentInChildren<RawImage>();

        if (joueurCouleur.ContainsKey(joueur))
        {
            raw.color = joueurCouleur[joueur];
            Debug.Log("La couleur du joueur assign� � " + pion + " est " + joueurCouleur[joueur]);
        }
        else
        {
            Debug.LogError("La couleur du joueur " + joueur + " n'est pas d�finie.");
        }
    }
    public void AjouterNombresJoueursDefini()
    {
        while (listeJoueur.Count < nbJoueurs)
        {
            num�roJoueur++;
            string nomJoueur = nom + " " + num�roJoueur.ToString();
            listeJoueur.Add(nomJoueur);
            AttribuerCouleursAuxJoueurs(nomJoueur);
            Debug.Log(nomJoueur + " a �t� ajout�.");
        }
    }
    public void validerOption()
    {
        nbTours = Int32.Parse(inputTour.text);
        nbJoueurs = Int32.Parse(inputJoueur.text);
        Debug.Log("nbTours = "+ nbTours);
        Debug.Log("nbJoueurs = " + nbJoueurs);

        if (nbJoueurs > nbJoueurMax)
        {
            afficherPopup = true;

        }
        else
        {
            afficherPopup = false;
            optionMenu.gameObject.SetActive(false);
            choisirObjet.gameObject.SetActive(true);
        }

    }
    public string changementJoueur()
    {
        joueurActuel = listeJoueur[indexJoueur];
        Debug.Log("Tour de " + joueurActuel);
        joueurActuelText.text = "Joueur actuel : " + joueurActuel.ToString();
        if(indexJoueur == listeJoueur.Count-1)
        {
            indexJoueur = 0;
        }
        else
        {
            indexJoueur++;
        }
        return joueurActuel;        
    }
    public void changementScene()
    {
        GameObject controleurMenu = GameObject.Find("ControleurMenu");

        if (controleurMenu.activeSelf)
        {
            Debug.Log("Le GameObject 'ControleurMenu' est actif.");
        }
        else
        {
            Debug.Log("Le GameObject 'ControleurMenu' est d�sactiv�.");
        }
        SceneManager.LoadScene("MonopolyScene");
    }
    // Update is called once per frame
    void Update()
    {
       

    }
}
