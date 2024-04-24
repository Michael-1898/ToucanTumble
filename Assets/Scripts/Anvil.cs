using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    [SerializeField] GameObject warningArrow;
    [SerializeField] float arrowTime;
    [SerializeField] float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 5.5f, 0);
        GameObject arrow = Instantiate(warningArrow, pos, Quaternion.identity);
        StartCoroutine(ApplyGravity(arrowTime - 0.1f));
        Destroy(arrow, arrowTime);
    }

    IEnumerator ApplyGravity(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
    }
}
