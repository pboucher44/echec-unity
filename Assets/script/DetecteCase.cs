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

    void OnTriggerEnter(Collider collision)
    {
        if(!collision.gameObject.name.Contains("Pion"))
        {
            caseActuel = collision.gameObject.name;
        }

        if (GestionTourDeJeu.tourDeJeu == "blanc")
        {
            if (collision.gameObject.name.Contains("PionBlanc"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (GestionTourDeJeu.tourDeJeu == "noir")
        {
            if (collision.gameObject.name.Contains("PionNoir"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
    }
    

