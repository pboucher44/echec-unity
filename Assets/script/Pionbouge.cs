using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // colorisation cases possible
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.Contains("Pion"))
            {
                colorcase(hit);
            }

            // déplacement du pion
            else if(Physics.Raycast(ray, out hit) && illuminatedCases.Contains(hit.transform.gameObject))
            {
                avancePion(hit);
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
        newCaseUnder.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);

        illuminatedCases.Add(newCaseUnder);

        // si le pion est sur sa premiere case alors il peux bouger de 2 cases
        if (newDetecteCase.caseActuel.Contains("2"))
        {
            num = int.Parse(newDetecteCase.caseActuel[0].ToString()) + 2;
            colorInFront = num.ToString() + newDetecteCase.caseActuel[1];
            frontCase = GameObject.Find(colorInFront);
            frontCase.GetComponent<Renderer>().enabled = true;
            frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);

            illuminatedCases.Add(frontCase);
        }

        num = int.Parse(newDetecteCase.caseActuel[0].ToString()) + 1;
        colorInFront = num.ToString() + newDetecteCase.caseActuel[1];
        frontCase = GameObject.Find(colorInFront);
        frontCase.GetComponent<Renderer>().enabled = true;
        frontCase.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
        illuminatedCases.Add(frontCase);

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
        while (newClicledGameObject.transform.position.z < hit.transform.gameObject.transform.position.z)
        {
            newClicledGameObject.transform.position = new Vector3(newClicledGameObject.transform.position.x, newClicledGameObject.transform.position.y, newClicledGameObject.transform.position.z + 5f);
            if (newClicledGameObject.transform.name.Contains("Noir"))
            {
                newClicledGameObject.GetComponent<Renderer>().material.color = Color.black;
            }
            else
            {
                newClicledGameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
