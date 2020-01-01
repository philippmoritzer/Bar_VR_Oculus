using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelMe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject me;
     
    void Start()
    {
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();
        t.text = "new text set";
        t.fontSize = 5;
        t.transform.position = new Vector3(me.transform.position.x, me.transform.position.y, me.transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {
       // t.transform.localEulerAngles += new Vector3(0, 0, 0);
      // t.transform.position = new Vector3(me.transform.position.x, me.transform.position.y, me.transform.position.z);
    }
}
