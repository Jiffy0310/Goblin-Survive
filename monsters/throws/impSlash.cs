using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impSlash : MonoBehaviour
{
    // 몬스터 투사체 스크립트
    float damage = 20f;
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

        myRigidBody.velocity = new Vector2(throwDir.x, throwDir.y)*2f;
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,Mathf.Atan2(throwDirMag.y, throwDirMag.x) * Mathf.Rad2Deg));//(0f, 0f, Mathf.Atan2(throwDirMag.y, throwDirMag.x) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
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
