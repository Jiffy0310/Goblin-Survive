using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardianSwordSkill : MonoBehaviour
{
    public Animator anime;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, goblin.I.transform.position, speed*Time.deltaTime);
        Destroy(gameObject, 20f);
    }
}
