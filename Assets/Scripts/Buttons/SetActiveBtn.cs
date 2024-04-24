using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveBtn : MonoBehaviour
{
    [SerializeField] GameObject[] D_objects;
    [SerializeField] GameObject[] A_objects;
    [SerializeField] KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)) {
            Activate();
        }
    }
    
    void OnMouseDown()
    {
        Activate();
    }

    public void Activate()
    {
        for(int i = 0; i < A_objects.Length; i++) {
            A_objects[i].SetActive(true);
        }

        for(int i = 0; i < D_objects.Length; i++) {
            D_objects[i].SetActive(false);
        }
    }
}
