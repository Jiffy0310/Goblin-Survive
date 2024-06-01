using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salamanderSwordSkill : MonoBehaviour
{
    public Animator anime;
    public GameObject flame;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        Invoke("makeFlame", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }

    void makeFlame()
    {
        Instantiate(flame, new Vector3(transform.position.x, transform.position.y + 0.5f, 0f), Quaternion.identity);
    }
}
