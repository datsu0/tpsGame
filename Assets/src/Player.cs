using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var playerCamera = gameObject.AddComponent<Camera>();
        var Palyer = GameObject.Find("unitychan");
        Palyer.transform.Translate(100,0,100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
