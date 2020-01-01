using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMyFilling : MonoBehaviour
{
    public GameObject fillMe;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(counter);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "fluid") {
            counter++;
        }
    }
}
