using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_script : MonoBehaviour
{
    // Start is called before the first frame update

    cube_script script;


    void Awake()
    {
        script = GameObject.Find("dice").GetComponent<cube_script>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "piste")
        {
            script.face = int.Parse(gameObject.name);
        }
    }
}
