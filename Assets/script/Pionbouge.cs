using System.Collections.Generic;
using UnityEngine;
using System;


public class Pionbouge : MonoBehaviour
{
    GameObject oldClicledGameObject;
    GameObject newClicledGameObject;

    GameObject newCaseUnder;
    DetecteCase newDetecteCase;

    List<GameObject> illuminatedCases = new List<GameObject>();

    GameObject frontCase;
    string colorInFront;

    int num;
    string sentence;
    char[] letterCase;

    // Start is called before the first frame update
    void Start()
    {
        sentence = "ABCDEFGH";
        letterCase = sentence.ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // colorisation cases possible
            if(GestionTourDeJeu.tourDeJeu == "blanc" && Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.Contains("PionBlanc"))
            {
                colorcase(hit);
            } 
            else if (GestionTourDeJeu.tourDeJeu == "noir" && Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.Contains("PionNoir"))
            {
                colorcase(hit);
            }


            // déplacement du pion
            else if (Physics.Raycast(ray, out hit) && illuminatedCases.Contains(hit.transform.gameObject))
            {
                avancePion(hit);
                GestionTourDeJeu.changeTourJeu();
            }
        }
    }

    void colorcase(RaycastHit hit)
    {
        newClicledGameObject = hit.transform.gameObject;
        if (oldClicledGameObject != null)
        {
            foreach (GameObject gameObject in illuminatedCases)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        oldClicledGameObject = newClicledGameObject;

        newDetecteCase = newClicledGameObject.GetComponent<DetecteCase>();

        newCaseUnder = GameObject.Find(newDetecteCase.caseActuel);
        newCaseUnder.GetComponent<Renderer>().enabled = true;

        illuminatedCases.Add(newCaseUnder);

        if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 1)
        {
            num = int.Parse(newDetecteCase.caseActuel[0].ToString()) - 1;
            colorInFront = num.ToString() + newDetecteCase.caseActuel[1];
            print(newDetecteCase.caseActuel[1].ToString());
            frontCase = GameObject.Find(colorInFront);
            frontCase.GetComponent<Renderer>().enabled = true;
            frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
            illuminatedCases.Add(frontCase);
        }

        if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 8)
        {
            num = int.Parse(newDetecteCase.caseActuel[0].ToString()) + 1;
            colorInFront = num.ToString() + newDetecteCase.caseActuel[1];
            frontCase = GameObject.Find(colorInFront);
            frontCase.GetComponent<Renderer>().enabled = true;
            frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
            illuminatedCases.Add(frontCase);
        }


        // détection de la case a gauche
        if (newDetecteCase.caseActuel[1] != 'A')
        {
            num = int.Parse(newDetecteCase.caseActuel[0].ToString());
            int index = Array.IndexOf(letterCase, newDetecteCase.caseActuel[1]);
            colorInFront = num.ToString() + letterCase[index - 1];
            frontCase = GameObject.Find(colorInFront);
            frontCase.GetComponent<Renderer>().enabled = true;
            frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
            illuminatedCases.Add(frontCase);

            if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 8)
            {
                num = int.Parse(newDetecteCase.caseActuel[0].ToString()) + 1;
                colorInFront = num.ToString() + letterCase[index - 1];
                frontCase = GameObject.Find(colorInFront);
                frontCase.GetComponent<Renderer>().enabled = true;
                frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
                illuminatedCases.Add(frontCase);
            }

            if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 1)
            {
                num = int.Parse(newDetecteCase.caseActuel[0].ToString()) - 1;
                colorInFront = num.ToString() + letterCase[index - 1];
                frontCase = GameObject.Find(colorInFront);
                frontCase.GetComponent<Renderer>().enabled = true;
                frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
                illuminatedCases.Add(frontCase);
            }
        }

        // détection de la case a droite
        if (newDetecteCase.caseActuel[1] != 'H')
        {
            num = int.Parse(newDetecteCase.caseActuel[0].ToString());
            int index = Array.IndexOf(letterCase, newDetecteCase.caseActuel[1]);
            colorInFront = num.ToString() + letterCase[index + 1];
            frontCase = GameObject.Find(colorInFront);
            frontCase.GetComponent<Renderer>().enabled = true;
            frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
            illuminatedCases.Add(frontCase);

            if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 8)
            {
                num = int.Parse(newDetecteCase.caseActuel[0].ToString()) + 1;
                colorInFront = num.ToString() + letterCase[index + 1];
                frontCase = GameObject.Find(colorInFront);
                frontCase.GetComponent<Renderer>().enabled = true;
                frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
                illuminatedCases.Add(frontCase);
            }

            if (int.Parse(newDetecteCase.caseActuel[0].ToString()) != 1)
            {
                num = int.Parse(newDetecteCase.caseActuel[0].ToString()) - 1;
                colorInFront = num.ToString() + letterCase[index + 1];
                frontCase = GameObject.Find(colorInFront);
                frontCase.GetComponent<Renderer>().enabled = true;
                frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
                illuminatedCases.Add(frontCase);
            }
        }



        newCaseUnder = GameObject.Find(newDetecteCase.caseActuel);
        newCaseUnder.GetComponent<Renderer>().enabled = true;
        newCaseUnder.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);

    }

    void avancePion(RaycastHit hit)
    {
        foreach (GameObject gameObject in illuminatedCases)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        illuminatedCases = new List<GameObject>();

        newClicledGameObject.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

    }
}