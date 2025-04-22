using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube_script : MonoBehaviour
{
    public int face, force = 700;
    public Player player; // Référence au script Player
    public Text txt;
    Rigidbody rb;
    bool playdice = false;
    private Camera_script script;


    private void Start()
    {
        script = GameObject.Find("Gestionnaire").GetComponent<Camera_script>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && rb.velocity.magnitude == 0)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                rb.AddForce(hit.point * force);
                Debug.Log("hit : " + hit.point);
                playdice = true;
            }
            
        }
    }

    void Update()
    {
        if (playdice && rb.velocity.magnitude == 0)
        {
            playdice = false;
            StartCoroutine(ShowFace());
        }
    }

    IEnumerator ShowFace()
    {
        Debug.Log("face : " + face);
        txt.enabled = true;
        txt.GetComponent<Text>().text = face.ToString();

        script.player();

        yield return new WaitForSeconds(2f);

        txt.enabled = false;
        if (player != null)
        {
            player.ReceiveDiceValue(face);
        }
    }


}