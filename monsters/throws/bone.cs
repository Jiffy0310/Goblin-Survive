using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone : MonoBehaviour
{   
    // 몬스터 투사체 스크립트
    float damage = 15f;
    public Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float goblx = goblin.I.transform.position.x;
        float gobly = goblin.I.transform.position.y;

        Vector2 boneDir = new Vector2(x, y);
        Vector2 goblDir = new Vector2(goblx, gobly);

        Vector2 throwDirMag = goblDir - boneDir;
        float magnitude = throwDirMag.magnitude;
        Vector2 throwDir = throwDirMag / magnitude;

        myRigidBody.velocity = new Vector2(throwDir.x, throwDir.y)*3f;
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
