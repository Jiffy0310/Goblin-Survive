using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderWeb : MonoBehaviour
{
    // 몬스터 투사체 스크립트
    public int onWeb = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("vanishWeb", 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)  
    {
        if(coll.gameObject.tag == "goblin")
        {
            goblin.I.onWeb = true;
            Invoke("onWebNormal", 1.2f);
        }
    }

    void vanishWeb()
    {
        anim.SetBool("webVanish", true);
        Destroy(gameObject, 1.5f);
    }

    void onWebNormal()
    {
        goblin.I.onWeb = false;
    }
}
