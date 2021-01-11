using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecteCase : MonoBehaviour
{

    public string caseActuel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        caseActuel = collision.collider.name;
        print(collision.collider.name);
    }
}
