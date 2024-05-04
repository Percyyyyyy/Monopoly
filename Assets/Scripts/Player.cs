using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    public int numero_case = 1;
    private Camera_script script;


    void Start()
    {
        script = GameObject.Find("Gestionnaire").GetComponent<Camera_script>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(numero_case.ToString());

        if (targetObject != null)
        {
            // si le case n'est pas celle du départ
            if (numero_case != 1)
            {
                agent.SetDestination(targetObject.transform.position);
            }
            
            //si le player arrive sur la case
            if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.5f && numero_case !=1)
            {
                script.plateau();

                //place la maison sur la case
                GameObject.FindGameObjectWithTag(numero_case.ToString()).transform.GetChild(0).gameObject.SetActive(true);

            }
        }
        else
        {
            Debug.LogError("L'objet avec le tag " + numero_case.ToString() + " n'a pas été trouvé !");
        }

     
    }

    // Méthode pour recevoir la valeur du dé
    public void ReceiveDiceValue(int value)
    {
        Debug.Log("Le joueur a reçu la valeur du dé : " + value);
        numero_case += value;
    }
    
}