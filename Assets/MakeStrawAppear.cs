﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStrawAppear : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject straw;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "straw")
        {
            ReceiptManager.GetInstance().activeReceipt.strawAdded = true;
            straw.active = true;
            Destroy(other);

        }
       

    }
}
