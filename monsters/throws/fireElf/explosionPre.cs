using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionPre : MonoBehaviour
{
    public GameObject explosionPost;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("explosionPostCreate", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2.03f);
    }

    void explosionPostCreate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(explosionPost, new Vector3(x, y+1f, 0f), Quaternion.identity);
    }
}
