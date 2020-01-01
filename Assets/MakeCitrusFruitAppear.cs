using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCitrusFruitAppear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lemonOnGlass;
    public GameObject limeOnGlass;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lemon_Piece")
        {
            lemonOnGlass.active = true;
            Destroy(other);

        }
        else if (other.gameObject.tag == "Lime_Piece") {
            limeOnGlass.active = true;
            Destroy(other);

        }

    }
}
