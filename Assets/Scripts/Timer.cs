using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    GameObject txtTimer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Tutorial").SetActive(false);
        timer = 0;
        txtTimer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        txtTimer.GetComponent<Text>().text = "Time: " + (Mathf.Round(timer * 100) / 100);

        if(timer >= 4 && GameObject.Find("Player").GetComponent<Rigidbody2D>().gravityScale == 0) {
            GameObject.Find("Player").GetComponent<Rigidbody2D>().gravityScale = 5;
        }

        if(timer >= 7 && GameObject.Find("Spawner2").GetComponent<Spawner>().enabled == false) {
            GameObject.Find("Spawner2").GetComponent<Spawner>().enabled = true;
        }
        if(timer >= 14 && GameObject.Find("Spawner3").GetComponent<Spawner>().enabled == false) {
            GameObject.Find("Spawner3").GetComponent<Spawner>().enabled = true;
        }
        if(timer >= 20 && GameObject.Find("Spawner4").GetComponent<Spawner>().enabled == false) {
            GameObject.Find("Spawner4").GetComponent<Spawner>().enabled = true;
        }
        if(timer >= 25 && GameObject.Find("Spawner5").GetComponent<Spawner>().enabled == false) {
            GameObject.Find("Spawner5").GetComponent<Spawner>().enabled = true;
        }
    }
}
