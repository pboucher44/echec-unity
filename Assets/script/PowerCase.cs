using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCase : MonoBehaviour
{
    List<GameObject> games = new List<GameObject>();
    bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (used == false) {
            if (other.gameObject.name.Contains("Blanc"))
            {
                foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Noir"))
                {
                    games.Add(fooObj);
                }
                Destroy(games[0]);
                games = new List<GameObject>();
                this.GetComponent<Renderer>().enabled = false;
                this.GetComponent<Renderer>().material = null;

            }
            else if (other.gameObject.name.Contains("Noir"))
            {
                foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Blanc"))
                {
                    games.Add(fooObj);
                }
                Destroy(games[0]);
                games = new List<GameObject>();
                this.GetComponent<Renderer>().enabled = false;
                this.GetComponent<Renderer>().material = null;

            }
            used = true;
        }        
    }
}
