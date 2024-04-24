using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;

    private float spawnTimer;
    int random;
    private float randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        transform.position = new Vector3(Random.Range(-7.5f,7.5f), 9, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject newObject;
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 0.8f)
        {
            random = Random.Range(1, 11);
            randomRotation = Random.Range(1, 361);
            if(random > 0 && random <= 3)
            {
                random = Random.Range(1, 11);
                if(random <= 7) {
                    newObject = Instantiate(Object1, transform.position, Quaternion.Euler(0, 0, randomRotation));
                    newObject = Instantiate(Object1, transform.position +  new Vector3(0, 2, 0), Quaternion.Euler(0, 0, randomRotation + randomRotation));
                } else {
                    newObject = Instantiate(Object1, transform.position, Quaternion.Euler(0, 0, randomRotation));
                }
            } else if (random > 3 && random <= 6) {
                newObject = Instantiate(Object2, transform.position, Quaternion.Euler(0, 0, randomRotation));
            } else if (random > 6 && random <= 9) {
                newObject = Instantiate(Object3, transform.position, Quaternion.Euler(0, 0, randomRotation));
            } else {
                newObject = Instantiate(Object4, transform.position, Quaternion.Euler(0, 0, randomRotation));
            }

            spawnTimer = 0;
            transform.position = new Vector3(Random.Range(-1f,1f)*9,9,0);
        }
    }
}
