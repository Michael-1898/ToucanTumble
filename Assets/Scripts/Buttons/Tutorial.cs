using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            //start game
            GameObject.Find("Spawner").GetComponent<Spawner>().enabled = true;
            GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
            player.SetActive(true);
        }
    }
}
