using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprudel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bottle;
    public float coeff;
    public GameObject fluid;
    private Collider bottleColider;
    private bool soundIsPlaying = false;
    void Start()
    {
        bottleColider = bottle.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(bottle.transform.up, Vector3.down) > 0)
        {
    
            Vector3 position = bottle.transform.TransformPoint(Vector3.up * coeff);
    
            GameObject fluidClone = Instantiate(fluid, position, bottle.transform.rotation);
            GameObject.Destroy(fluidClone, 2.0f);

            if (!soundIsPlaying) { 
               // bottle.GetComponent<AudioSource>().Play();
                soundIsPlaying = true;
            }

            
        }
        else {
            
            if (soundIsPlaying) { 
                //bottle.GetComponent<AudioSource>().Stop();
                soundIsPlaying = false;
            }
        }

        
    }
}
