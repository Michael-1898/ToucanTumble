using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchBtn : MonoBehaviour
{
    [SerializeField] int sceneID;
    [SerializeField] KeyCode key;
    [SerializeField] GameObject fade; //use the fade img obj, not the canvas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)) {
            StartCoroutine(SceneSwitch(sceneID));
        }
    }

    void OnMouseDown()
    {
        StartCoroutine(SceneSwitch(sceneID));
    }

    IEnumerator SceneSwitch(int buildIndex)
    {
        if(fade != null) {
            fade.GetComponent<Animator>().SetTrigger("FadeOut");
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene(buildIndex);
    }
}
