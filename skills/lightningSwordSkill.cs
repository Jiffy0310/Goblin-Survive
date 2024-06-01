using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningSwordSkill : MonoBehaviour
{
    public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.7f);
    }
}
