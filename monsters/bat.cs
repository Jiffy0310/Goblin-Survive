using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    // 몬스터 새로 생성해서 스크립트 복붙시 수정사항 o 로 표시
    // 드랍 아이템 수정 필수 - 기본공격 / 스킬공격에 맞았을 때 구문 둘 다 수정해줘야함
    // 투사체 발사하는 몬스터의 경우 투사체 함수 작성해줘야함.
    // 몬스터 추가시 애니메이션 파라미터 네임 맞춰주기
    float hp = 3f;   // o
    float fullHp = 3f;   // o
    float speed = 0.7f;   // o
    float damage = 5f;   // o
    float exp = 4f;   // o
    int dropGold;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        dropGold = Random.Range(1, 3);   // o
        anim = GetComponent<Animator>();
        List<float> y = new List<float>();
        List<float> x = new List<float>();
        y.Add(-10f);
        y.Add(10f);
        x.Add(-10f);
        x.Add(10f);
        float xRand = Random.Range(-10f, 10f);
        float yRand = Random.Range(-10f, 10f);
        int yInd = Random.Range(0,2);
        int xInd = Random.Range(0,2);

        if(-5f < xRand & xRand < 5f)
        {
            transform.position = new Vector3(xRand,y[yInd],0);
        }
        else if(-5f > xRand || xRand > 5f)
        {
            transform.position = new Vector3(x[xInd],yRand,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float X = transform.position.x - goblin.I.transform.position.x;
        float Y = transform.position.y - goblin.I.transform.position.y;
        float absX = Mathf.Abs(X);
        float absY = Mathf.Abs(Y);

        transform.position = Vector3.MoveTowards(gameObject.transform.position, goblin.I.transform.position, speed*Time.deltaTime);

        if(absX>absY)
        {
            if(X>0)
            {
                anim.SetFloat("monsterLR", -1);  
                anim.SetFloat("monsterFB", 0);   
            }
            else 
            {
                anim.SetFloat("monsterLR", 1);   
                anim.SetFloat("monsterFB", 0);   
            }
        }
        else
        {
            if(Y>0)
            {
                anim.SetFloat("monsterLR", 0);  
                anim.SetFloat("monsterFB", -1);  
            }
            else
            {
                anim.SetFloat("monsterLR", 0); 
                anim.SetFloat("monsterFB", 1); 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "slash")  // 기본 공격에 맞았을 때
        {
            if(hp > 0f & anim.GetBool("monsterHit") == false) 
            {
                anim.SetBool("monsterHit", true); 
                hp = hp - goblin.I.damage;
                gameObject.transform.Find("hp/front").transform.localScale = new Vector3(hp/fullHp, 1f, 1f);
                Invoke("returnNormal", 0.5f);
                if(hp <= 0f)  // 죽었을 때
                {
                    float drop = Random.Range(0f, 100f);  // 드랍률
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.transform.Find("hp/front").transform.localScale = new Vector3(0f, 1f, 1f);
                    speed = 0f;
                    goblin.I.expPoint += exp;  // 경험치
                    goblin.I.gold += dropGold;  // 골드
                    anim.SetBool("monsterDie", true);  
                    if(drop <= 40f)  // 아이템 드랍1
                    {
                        //Instantiate(itemManager.I.gloveTalisman, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 40f & drop <= 70f)
                    {
                        //Instantiate(itemManager.I.theOneRing, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 70f)  // 아이템 드랍2
                    {
                        //Instantiate(itemManager.I.magicRing, transform.position, Quaternion.identity);
                    }
                    Destroy(gameObject, 0.7f);
                }
            }
        }

        if(coll.gameObject.tag == goblin.I.skill[0])  // 스킬 공격에 맞았을 때
        {
            if(hp > 0f & anim.GetBool("monsterHit") == false) 
            {
                anim.SetBool("monsterHit", true);  
                hp = hp - goblin.I.skillDmg[0];
                gameObject.transform.Find("hp/front").transform.localScale = new Vector3(hp/fullHp, 1f, 1f);
                Invoke("returnNormal", 0.5f);
                if(hp <= 0f)  // 죽었을 때
                {
                    float drop = Random.Range(0f, 100f);  // 드랍률
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.transform.Find("hp/front").transform.localScale = new Vector3(0f, 1f, 1f);
                    speed = 0f;
                    goblin.I.expPoint += exp;  // 경험치
                    goblin.I.gold += dropGold;  // 골드
                    anim.SetBool("monsterDie", true);
                    if(drop <= 40f)  // 아이템 드랍1
                    {
                        //Instantiate(itemManager.I.gloveTalisman, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 40f & drop <= 70f)
                    {
                        //Instantiate(itemManager.I.theOneRing, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 70f)  // 아이템 드랍2
                    {
                        //Instantiate(itemManager.I.magicRing, transform.position, Quaternion.identity);
                    }
                    Destroy(gameObject, 0.7f);
                }
            }
        }

        if(coll.gameObject.tag == "goblin")  // 고블린과 접촉 했을 때
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

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == goblin.I.skill[1])  // 지속 도트 공격에 맞았을 때
        {
            if(hp > 0f & anim.GetBool("monsterHit") == false) 
            {
                anim.SetBool("monsterHit", true);  
                hp = hp - goblin.I.skillDmg[1];
                gameObject.transform.Find("hp/front").transform.localScale = new Vector3(hp/fullHp, 1f, 1f);
                Invoke("returnNormal", 0.5f);
                if(hp <= 0f)  // 죽었을 때
                {
                    float drop = Random.Range(0f, 100f);  // 드랍률
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.transform.Find("hp/front").transform.localScale = new Vector3(0f, 1f, 1f);
                    speed = 0f;
                    goblin.I.expPoint += exp;  // 경험치
                    goblin.I.gold += dropGold;  // 골드
                    anim.SetBool("monsterDie", true);
                    if(drop <= 40f)  // 아이템 드랍1
                    {
                        //Instantiate(itemManager.I.gloveTalisman, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 40f & drop <= 70f)
                    {
                        //Instantiate(itemManager.I.theOneRing, transform.position, Quaternion.identity);
                    }
                    else if(drop >= 70f)  // 아이템 드랍2
                    {
                        //Instantiate(itemManager.I.magicRing, transform.position, Quaternion.identity);
                    }
                    Destroy(gameObject, 0.7f);
                }
            }
        }
    }

    void returnNormal()
    {
        anim.SetBool("monsterHit", false);
    }

    void returnNormalPlayer()
    {
        goblin.I.GetComponent<Animator>().SetBool("playerHit", false);
    }
}
