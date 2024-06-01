using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goblin : MonoBehaviour
{
    // 장비 아이템 추가시 스킬 추가
    public List<string> skill = new List<string>();
    public List<float> skillDmg = new List<float>();
    public List<float> goblinStat = new List<float>();
    private Animator anim;
    private equipment equipment;
    public Text swordTxt;
    public Text armorTxt;
    public Text levelTxt;
    public Text bootsTxt;
    public Text coolTimeTxt;
    public Text goldTxt;
    public GameObject cooldownTxt;
    public GameObject needEquipTxt;
    public float moveSpeed;   // 이 아래로 스탯
    public float level = 1f;
    public float damage;
    public float armor;
    public float healPoint = 100f;
    public float maxHealPoint = 100f;
    public float expPoint = 0f;
    public float statPoint = 0f;
    public float nextLevelPoint = 30f;
    public int bossScore = 0;
    public int gold;
    float coolTime;  // 스킬 쿨타임
    public GameObject slashPrefab;   // 이 아래로 게임오브젝트 스킬 프리팹
    public GameObject holySwordSkillPrefab;
    public GameObject broadSwordSkillPrefab;
    public GameObject katanaSkillPrefab;
    public GameObject lightningSwordSkillPrefab;
    public GameObject claymoreSkillPrefab;
    public GameObject salamanderSwordSkillPrefab;
    public GameObject guardianSwordSkillPrefab;
    public GameObject heavenlySwordSkillPrefab;
    public GameObject scimitarSkillPrefab;
    bool playerMove;
    bool playerAttack;
    public Vector2 lastMove;
    public static goblin I;
    public bool myInventory = false;
    public bool shopping = false;
    public bool magicRing = false;
    public bool onWeb = false;
    float recoverTime;
    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        equipment = GameObject.FindObjectOfType<equipment>();
        skill.Insert(0, "0");
        skill.Insert(1, "0");
        skillDmg.Insert(0, 0f);
        skillDmg.Insert(1, 0f);
        goblinStat.Insert(0, 1f);  // 데미지
        goblinStat.Insert(1, 1f);  // 방어력
        goblinStat.Insert(2, 2f);  // 이동속도
    }

    // Update is called once per frame
    void Update()
    {
        swordTxt.text = damage.ToString();
        armorTxt.text = armor.ToString();
        bootsTxt.text = moveSpeed.ToString();
        playerMove = false;
        playerAttack = false;

        float x = transform.position.x;
        float y = transform.position.y;

        if(x <= -10f) transform.position = new Vector3(-10f, transform.position.y, 0f);
        if(x >= 10f) transform.position = new Vector3(10f, transform.position.y, 0f);
        if(y <= -10f) transform.position = new Vector3(transform.position.x, -10f, 0f);
        if(y >= 10f) transform.position = new Vector3(transform.position.x, 10f, 0f);    // 고블린 위치 제한

        if(Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)  // 수평 이동
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime, 0f, 0f));
            playerMove = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if(Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)  // 수직 이동
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime, 0f));
            playerMove = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("runLR", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("runFB", Input.GetAxisRaw("Vertical"));
        anim.SetBool("playerMove", playerMove);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);
        
        if(Input.GetKeyDown(KeyCode.Z))  // 일반 공격
        {
            playerAttack = true;
            if(lastMove.x == -1 & lastMove.y == 0)
            {
                Invoke("attack", 0f);
                Invoke("attackSlash", 0f);
            }
            if(lastMove.x == 1 & lastMove.y == 0)
            {
                Invoke("attack", 0f);
                Invoke("attackSlash", 0f);
            }
            if(lastMove.y == -1 & lastMove.x == 0)
            {
                Invoke("attack", 0f);
                Invoke("attackSlash", 0f);
            }
            if(lastMove.y == 1 & lastMove.x == 0)
            {
                Invoke("attack", 0f);
                Invoke("attackSlash", 0f);
            }
        }

        if(Input.GetKeyDown(KeyCode.X) & skill[0] != "0")  // 스킬 공격
        {
            if(coolTime <= 0)
            {
                playerAttack = true;
                if(lastMove.x == -1 & lastMove.y == 0)
                {
                    Invoke("attack", 0f);
                    Invoke(skill[0], 0f);
                }
                if(lastMove.x == 1 & lastMove.y == 0)
                {
                    Invoke("attack", 0f);
                    Invoke(skill[0], 0f);
                }
                if(lastMove.y == -1 & lastMove.x == 0)
                {
                    Invoke("attack", 0f);
                    Invoke(skill[0], 0f);
                }
                if(lastMove.y == 1 & lastMove.x == 0)
                {
                    Invoke("attack", 0f);
                    Invoke(skill[0], 0f);
                }
            }
            else if(coolTime > 0)  // 스킬 쿨타임
            {
                cooldownTxtOpen();
                Invoke("cooldownTxtClose", 1.5f);
            }
        }
        else if(Input.GetKeyDown(KeyCode.X) & skill[0] == "0")  // 장비 착용하지 않고 스킬 사용
        {
            needEquipTxtOpen();
            Invoke("needEquipTxtClose", 1.5f);
        }
        
        anim.SetBool("playerAttack", playerAttack);

        if(healPoint <= 0)  // 죽었을 때
        {
            moveSpeed = 0f;
            goblinStat.Insert(2, 0f);
            healPoint = 0f;
            transform.Find("hpBar/front").transform.localScale = new Vector3(0f, 1f, 1f);
            anim.SetBool("playerDie", true);
            gameManager.I.goblinDie();
        }

        if(expPoint >= nextLevelPoint)  // 경험치
        {
            level += 1;
            statPoint += 1;
            levelTxt.text = level.ToString();
            expPoint -= nextLevelPoint;
            nextLevelPoint += 20;
        }

        transform.Find("expBar/front").transform.localScale = new Vector3((expPoint/nextLevelPoint), 1f, 1f);
        transform.Find("hpBar/front").transform.localScale = new Vector3(healPoint/maxHealPoint, 1f, 1f);

        if(shopping == false & Input.GetKeyDown("i"))  // 인벤토리
        {
            if(myInventory == false) 
            {
                gameManager.I.inventoryOpen();
                myInventory = true;
            }
            else if(myInventory == true) 
            {
                gameManager.I.inventoryClose();
                myInventory = false;
            }
        }

        if(myInventory == false & Input.GetKeyDown("p"))  // 상점
        {
            if(shopping == false) 
            {
                gameManager.I.shopOpen();
                shopping = true;
            }
            else if(shopping == true) 
            {
                gameManager.I.shopClose();
                shopping = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))  // esc 로 상점, 인벤토리 끄기
        {
            if(myInventory == true)
            {
                gameManager.I.inventoryClose();
                myInventory = false;
            }
            if(shopping == true)
            {
                gameManager.I.shopClose();
                shopping = false;
            }
        }

        if(coolTime > 0) // 쿨타임 계산
        {
            coolTime -= Time.deltaTime;
            if(coolTime <= 0)
            {
                coolTime = 0;
            }
        }

        if(magicRing == true) // 셀프 리커버리
        {
            recoverTime += Time.deltaTime;
            if(recoverTime > 5f)
            {
                magicRingRecover();
                recoverTime = 0f;
            }
        }

        if(onWeb == true)
        {
            moveSpeed = 1f;
        }
        else
        {
            moveSpeed = goblinStat[2];
        }

        coolTimeTxt.text = coolTime.ToString("N1");
        goldTxt.text = gold.ToString();
    }

    void attack() // 기본 공격 모션
    {
        anim.SetFloat("attackLR", lastMove.x);
        anim.SetFloat("attackFB", lastMove.y);
    }

    void attackSlash()  // 기본 공격 발사
    {
        if(playerMove == false)
        {
            float x = transform.position.x + (lastMove.x*0.5f);
            float y = transform.position.y + (lastMove.y*0.5f);
            GameObject slash = Instantiate(slashPrefab, new Vector3(x, y, 0), Quaternion.identity);
            slash.GetComponent<Animator>().SetFloat("slashLR", lastMove.x);
            slash.GetComponent<Animator>().SetFloat("slashFB", lastMove.y);
        }
    }

    void holySwordSkill()  // 홀리소드 스킬
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x + (lastMove.x*1f);
            float y = transform.position.y + (lastMove.y*1f);
            GameObject holybolt = Instantiate(holySwordSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
            holybolt.GetComponent<Animator>().SetFloat("holyboltLR", lastMove.x);
            holybolt.GetComponent<Animator>().SetFloat("holyboltFB", lastMove.y);
            Vector2 dir = new Vector2(lastMove.x, lastMove.y);
            holybolt.GetComponent<Rigidbody2D>().AddForce(dir*Time.deltaTime*20000);
            coolTime = 5f;             
        }
    }

    void broadSwordSkill()  // 브로드소드 스킬
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x + (lastMove.x*1.0f);
            float y = transform.position.y + (lastMove.y*1.0f);
            GameObject broadSwordSkill = Instantiate(broadSwordSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
            coolTime = 10f;             
        }
    }

    void katanaSkill()  // 카타나 스킬
    {
        if(playerMove == false & coolTime <= 0)
        {
            StartCoroutine(katanaSkillCR());
            coolTime = 10f;
        }
    }
    IEnumerator katanaSkillCR()  // 카타나 스킬 코루틴
    {
        for(int i = 0; i < 16; i++) 
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float xRand = Random.Range(x-2f, x+2f);
            float yRand = Random.Range(y-2f, y+2f);
            Instantiate(katanaSkillPrefab, new Vector3(xRand, yRand, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);         
        }
    }

    void lightningSwordSkill()  // 라이트닝 소드 스킬
    {
        if(playerMove == false & coolTime <= 0)
        {
            StartCoroutine(lightningSwordSkillCR());
            coolTime = 5f;
        }
    }
    IEnumerator lightningSwordSkillCR()  // 라이트닝 소드 스킬 코루틴
    {
        float x = transform.position.x + (lastMove.x*1.0f);
        float y = transform.position.y + (lastMove.y*1.0f) + 1.5f;
        float xLast = lastMove.x;
        float yLast = lastMove.y;
        for(int i = 0; i < 7; i++)
        {
            Instantiate(lightningSwordSkillPrefab, new Vector3(x + i*xLast*1.2f, y + i*yLast*1.2f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void claymoreSkill()  // 클레이모어 스킬
    {
        if(playerMove == false & coolTime <= 0)
        {
            StartCoroutine(claymoreSkillCR());
            coolTime = 15f;
        }
    }
    IEnumerator claymoreSkillCR()  // 클레이모어 스킬 코루틴
    {
        float x = transform.position.x + (lastMove.x*1.0f);
        float y = transform.position.y + (lastMove.y*1.0f) + 0.7f;
        float xLast = lastMove.x;
        float yLast = lastMove.y;
        for(int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast, y + i*yLast, 0f), Quaternion.identity);
            }
            else if(i == 1)
            {
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast*1.1f + (yLast*0.9f), y + i*yLast*1.1f + (xLast*0.9f), 0f), Quaternion.identity);
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast*1.1f + (yLast*-0.9f), y + i*yLast*1.1f + (xLast*-0.9f), 0f), Quaternion.identity);
            }
            else if(i == 2)
            {
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast*1.1f + (yLast*1.7f), y + i*yLast*1.1f + (xLast*1.7f), 0f), Quaternion.identity);
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast*1.1f, y + i*yLast*1.1f, 0f), Quaternion.identity);
                Instantiate(claymoreSkillPrefab, new Vector3(x + i*xLast*1.1f + (yLast*-1.7f), y + i*yLast*1.1f + (xLast*-1.7f), 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void salamanderSwordSkill()
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x + (lastMove.x*1.5f);
            float y = transform.position.y + (lastMove.y*1.5f);
            Instantiate(salamanderSwordSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
            coolTime = 5f; 
        }
    }

    void guardianSwordSkill()
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            Instantiate(guardianSwordSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
            coolTime = 20f;
        }
    }

    void heavenlySwordSkill()
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x + (lastMove.x*1f);
            float y = transform.position.y + (lastMove.y*1f);
            GameObject heavenlySkill = Instantiate(heavenlySwordSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
            heavenlySkill.GetComponent<Animator>().SetFloat("heavenLR", lastMove.x);
            heavenlySkill.GetComponent<Animator>().SetFloat("heavenFB", lastMove.y);
            Vector2 dir = new Vector2(lastMove.x, lastMove.y);
            heavenlySkill.GetComponent<Rigidbody2D>().AddForce(dir*Time.deltaTime*9000);
            coolTime = 10f;             
        }
    }

    void scimitarSkill()
    {
        if(playerMove == false & coolTime <= 0)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            for(int i=0; i < 8; i++)
            {
                Vector3 dir = new Vector3(Mathf.Cos(Mathf.PI*2*i/8), Mathf.Sin(Mathf.PI*2*i/8), 0f);
                GameObject tornado = Instantiate(scimitarSkillPrefab, new Vector3(x, y, 0), Quaternion.identity);
                tornado.transform.Translate(dir*1f);
                tornado.GetComponent<Rigidbody2D>().AddForce(dir*Time.deltaTime*9000f);
            }
            coolTime = 5f;
        }
    }
    void cooldownTxtOpen()
    {
        cooldownTxt.SetActive(true);
    }

    void cooldownTxtClose()
    {
        cooldownTxt.SetActive(false);
    }

    void needEquipTxtOpen()
    {
        needEquipTxt.SetActive(true);
    }

    void needEquipTxtClose()
    {
        needEquipTxt.SetActive(false);
    }

    void magicRingRecover()
    {
        if(healPoint < maxHealPoint - 1f)
        {
            healPoint += 1;
        }
    }

    void cosmo()
    {
        //hi
    }

    
}
