using UnityEngine;

public class GestionSelectionPion : MonoBehaviour
{
    GameObject oldClicledGameObject;

    GameObject newClicledGameObject;

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

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name.Contains("Pion"))
            {
                newClicledGameObject = hit.transform.gameObject;
                if (oldClicledGameObject != null)
                {
                    if (oldClicledGameObject.transform.name.Contains("Noir"))
                    {
                        oldClicledGameObject.GetComponent<Renderer>().material.color = Color.black;
                    }
                    else
                    {
                        oldClicledGameObject.GetComponent<Renderer>().material.color = Color.white;
                    }
                }

                oldClicledGameObject = newClicledGameObject;

                newClicledGameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.64f, 0.0f);
            }
        }
    }
}
