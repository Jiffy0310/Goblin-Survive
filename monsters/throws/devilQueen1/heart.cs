using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    float damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
        if(x < -15f || x > 15f || y < -15f || y > 15f)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D coll)  
    {
        if(coll.gameObject.tag == "goblin")
        {
            if(goblin.I.GetComponent<Animator>().GetBool("playerHit") == false)
            {
                goblin.I.GetComponent<Animator>().SetBool("playerHit", true);
                if(damage - goblin.I.armor > 1)
                {
                    goblin.I.healPoint = goblin.I.healPoint - (damage - goblin.I.armor);
                }
                else if(damage - goblin.I.armor <= 1)
                {
                    goblin.I.healPoint = goblin.I.healPoint - 1;
                }
                Invoke("returnNormalPlayer", 0.6f);
            }
        }     
    }

    void returnNormalPlayer()
    {
        goblin.I.GetComponent<Animator>().SetBool("playerHit", false);
    }
}
