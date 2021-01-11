using System.Collections;
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

    string tour;

    int num;

    char[] alpha = "ABCDEFGH".ToCharArray();

    // Start is called before the first frame update
    void Start()
    {
        tour = "blanc";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.Contains("Pion"))
            {
                newClicledGameObject = hit.transform.gameObject;
                if(oldClicledGameObject != null)
                {
                    if(oldClicledGameObject.transform.name.Contains("Noir"))
                    {
                        oldClicledGameObject.GetComponent<Renderer>().material.color = Color.black;
                    } else
                    {
                        oldClicledGameObject.GetComponent<Renderer>().material.color = Color.white;
                    }

                    foreach (GameObject gameObject in illuminatedCases)
                    {
                        gameObject.GetComponent<Renderer>().enabled = false;
                    }
                }

                oldClicledGameObject = newClicledGameObject;
                PrintName(newClicledGameObject);
                newClicledGameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);

                newDetecteCase = newClicledGameObject.GetComponent<DetecteCase>();
                print(newDetecteCase.caseActuel);

                newCaseUnder = GameObject.Find(newDetecteCase.caseActuel);
                newCaseUnder.GetComponent<Renderer>().enabled = true;
                newCaseUnder.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);

                illuminatedCases.Add(newCaseUnder);

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
            else if(Physics.Raycast(ray, out hit) && illuminatedCases.Contains(hit.transform.gameObject))
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
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

}
