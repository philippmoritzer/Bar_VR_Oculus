using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeIceAppear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    private int counter = 1;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "IceCube")
        {
            if (!cube1.active || !cube2.active || !cube3.active) { 
                audioSource.PlayOneShot(audioSource.clip);
            }
            switch (counter) {
                case 1:
                    cube1.active = true;
                    break;
                case 2:
                    cube2.active = true;
                    break;
                case 3:
                    cube3.active = true;

                    break;            
            
        }
            if (cube1.active && cube2.active && cube3.active) {
                ReceiptManager.GetInstance().activeReceipt.iceAdded = true;
            }
            Destroy(other);
            counter++;

    }
        
    }
}
