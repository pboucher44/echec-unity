using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTourDeJeu : MonoBehaviour
{
    public static string tourDeJeu;

    // Start is called before the first frame update
    void Start()
    {
        tourDeJeu = "blanc";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void changeTourJeu()
    {
        tourDeJeu = tourDeJeu == "blanc" ? "noir" : "blanc";
    }
}
