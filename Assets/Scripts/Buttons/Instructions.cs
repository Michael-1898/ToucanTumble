﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("enter")) {
            GameObject.Find("PlayBtn").SetActive(false);
            GameObject.Find("InstrBtn").SetActive(false);
        }
    }
}
