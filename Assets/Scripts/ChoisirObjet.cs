using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoisirObjet : MonoBehaviour
{
    public List<GameObject> Pions;
    List<GameObject> PionsUtilisés;
    public GameObject optionmenuGameobject;
    OptionMenu optionmenuScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangerCouleur()
    {
        Debug.Log("Game Object Clicked!");
    }   
    // Update is called once per frame
    void Update()
    {
      
    }
}
