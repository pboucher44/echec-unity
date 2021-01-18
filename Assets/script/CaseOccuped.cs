using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseOccuped : MonoBehaviour
{
    public bool caseOccuped;

    // Start is called before the first frame update
    void Start()
    {
        caseOccuped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("Pion"))
        {
            caseOccuped = true;
        }
    }
}
