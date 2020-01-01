using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheZitrusfrucht : MonoBehaviour
{
    public GameObject go;
    public GameObject slice;
    private bool beingHandled = false;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (beingHandled == false) {
            print("one");
            print(other.gameObject.tag);
            if (other.gameObject.tag.Contains("knive"))
            {
                print("two");
                Vector3 position = go.transform.position;
                
               // OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                Instantiate(slice, new Vector3(position.x, position.y, position.z), go.transform.rotation);
                beingHandled = true;

                StartCoroutine(WaitAndDie());


            }
        }
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(0.5f);
        beingHandled = false;


    }




}
