using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    internal static object main;
    [SerializeField]
    CinemachineVirtualCamera cam1;
    [SerializeField]
    CinemachineVirtualCamera cam2;
    [SerializeField]
    CinemachineVirtualCamera cam3;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    public void de()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    public void player()
    {
        cam1.enabled = false;
        cam2.enabled = true;
        cam3.enabled = false;
    }

    public void plateau()
    {
        cam1.enabled = false;
        cam2.enabled = false;
        cam3.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
