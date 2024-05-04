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

public class OptionMenu : MonoBehaviour
{
    int nbJoueurMax = 5;
    public GameObject optionMenu;
    public static int nbTours = 5;
    public static int nbJoueurs = 2;
    public TMP_InputField inputTour;
    public TMP_InputField inputJoueur;
    public TextMeshProUGUI joueurActuelText;
    public UnityEngine.UI.Button btnValider;
    public Canvas choisirObjet;
    bool afficherPopup;
    string nom = "Joueur";
    int numéroJoueur = 0;
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

    void Awake()

    {

        DontDestroyOnLoad(this.gameObject);

    }

    void OnGUI()
    {
        if (afficherPopup)
        {
            // Affiche le pop-up avec un message
            GUI.Window(0, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), AfficherPopup, "Erreur : Trop de joueurs !");
        }
    }

    void AfficherPopup(int windowID)
    {
        GUI.Label(new Rect(65, 40, 200, 30), "Le nombre de joueurs est trop élevé !");
        if (GUI.Button(new Rect(100, 100, 100, 30), "Fermer"))
        {
            // Ferme le pop-up en définissant afficherPopup à false
            afficherPopup = false;
        }
    }
    public void AttribuerCouleursAuxJoueurs(string joueur)
    {
        Random random = new Random();
        int indexCouleurAleatoire = random.Next(listeCouleur.Count);
        Color couleurChoisie = listeCouleur[indexCouleurAleatoire];
        joueurCouleur.Add(joueur, couleurChoisie);
        Debug.Log("La couleur " + couleurChoisie + " est assigné à " + joueur);
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
            Debug.Log("Le pion " + pion + " est assigné à " + joueurActuel);
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
            Debug.Log("La couleur du joueur assigné à " + pion + " est " + joueurCouleur[joueur]);
        }
        else
        {
            Debug.LogError("La couleur du joueur " + joueur + " n'est pas définie.");
        }
    }
    public void AssignerCouleurAuxPions(GameObject pion, string joueur)
    {
        RawImage raw = pion.GetComponentInChildren<RawImage>();

        if (joueurCouleur.ContainsKey(joueur))
        {
            raw.color = joueurCouleur[joueur];
            Debug.Log("La couleur du joueur assigné à " + pion + " est " + joueurCouleur[joueur]);
        }
        else
        {
            Debug.LogError("La couleur du joueur " + joueur + " n'est pas définie.");
        }
    }
    public void AjouterNombresJoueursDefini()
    {
        while (listeJoueur.Count < nbJoueurs)
        {
            numéroJoueur++;
            string nomJoueur = nom + " " + numéroJoueur.ToString();
            listeJoueur.Add(nomJoueur);
            AttribuerCouleursAuxJoueurs(nomJoueur);
            Debug.Log(nomJoueur + " a été ajouté.");
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
       
            afficherPopup = false;
            optionMenu.gameObject.SetActive(false);
            choisirObjet.gameObject.SetActive(true);
            

    }

    public void ValiderChoixOption()
    {
        Debug.Log("Il y a " + nbTours + " tours et " + nbJoueurs + " nombre de joueur");

        // Parcourir chaque joueur et afficher ses informations
        foreach (var joueur in listeJoueur)
        {
            if (joueurPion.ContainsKey(joueur) && joueurCouleur.ContainsKey(joueur))
            {
                GameObject pion = joueurPion[joueur];
                Color couleur = joueurCouleur[joueur];
                /* Debug.Log(joueur + " a choisi le pion : " + pion.name + " et a la couleur : " + couleur.ToString());*/

                // Stocker les informations du joueur dans PlayerPrefs
                PlayerPrefs.SetString(joueur + "_Pion", pion.name);
                PlayerPrefs.SetString(joueur + "_Couleur", couleur.ToString());
                PlayerPrefs.SetString("ListeJoueurs", JsonUtility.ToJson(listeJoueur));
            }
            else
            {
                Debug.LogWarning("Le joueur " + joueur + " n'a pas encore choisi de pion ou de couleur.");
            }
        }

        // Charger la prochaine scène
        SceneManager.LoadScene("MonopolyScene");
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
    // Update is called once per frame
    void Update()
    {
       

    }
}
