using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    // 아이템 추가시 수정해야 할 스크립트
    // equipSlot.cs - 장비 아이템 추가시에만
    // item.cs - 인벤토리에 표시할 프리팹 유니티에서 설정
    // itemManager.cs - 아이템 게임오브젝트 선언 후 몬스터 드랍아이템 설정
    //                - 아이템 사용 효과 스크립트 추가
    // 몬스터.cs - 해당 아이템 드랍할 몬스터 스크립트에서 아이템드랍 구문 수정
    // goblin.cs - 무기 아이템 추가시 스킬 추가
    // tooltip.cs - 아이템 툴팁 추가
    Vector3 mousePos;
    public static itemManager I;
    private inventory inventory;
    private equipment equipment;
    public GameObject buffTxt;
    public GameObject itemTooltip;
    public Text itemNameTxt;
    public Text itemTooltipTxt;
    public GameObject batWing; // 루팅 아이템
    public GameObject holySword;  // 무기
    public GameObject broadSword;
    public GameObject katana;
    public GameObject lightningSword;
    public GameObject claymore;
    public GameObject salamanderSword;
    public GameObject guardianSword;
    public GameObject heavenlySword;
    public GameObject scimitar;
    public GameObject banditLightArmor;  // 갑옷
    public GameObject royalTunic;
    public GameObject battleguardArmor;
    public GameObject greyKnightArmor;
    public GameObject darkArmor;
    public GameObject manticoreArmor;
    public GameObject hunterArmor;
    public GameObject banditLightBoots;  // 신발
    public GameObject battleguardBoots;
    public GameObject darkBoots;
    public GameObject greyKnightBoots;
    public GameObject manticoreBoots;
    public GameObject hunterBoots;
    public GameObject woodenShield;  // 방패
    public GameObject buckler;
    public GameObject battleShield;
    public GameObject towerShield;
    public GameObject leatherHelmet;  // 모자
    public GameObject hawkHelm;
    public GameObject rogueHat;
    public GameObject copperHelm;
    public GameObject knightHelm;
    public GameObject darkHelm;
    public GameObject bronzeRing;  // 반지
    public GameObject silverRing;
    public GameObject goldRing;
    public GameObject magicRing;
    public GameObject theOneRing;
    public GameObject gloveTalisman;  // 탈리스만
    public GameObject arrowTalisman;
    public GameObject bowTalisman;
    public GameObject apple;  // 기타 아이템
    public GameObject cheese;
    public GameObject chicken;
    public GameObject beer;
    public GameObject potion;
    float beerTime;
    float potionTime;
    int armorBuffOn = 0;
    int damageBuffOn = 0;


    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindObjectOfType<inventory>();
        equipment = GameObject.FindObjectOfType<equipment>();
    }

    // Update is called once per frame
    void Update()
    {
        beerTime -= Time.deltaTime;
        potionTime -= Time.deltaTime;
        if(beerTime < 0)   // 맥주 버프시간 초기화
        {
            beerTime = 0;
        }
        if(potionTime < 0)   // 포션 버프시간 초기화
        {
            potionTime = 0;
        }

        if(armorBuffOn == 1)   // armorBuffOn = 1 : 맥주 버프 발동
        {
            goblin.I.armor += 10;
            armorBuffOn = 2;
        }
        else if(armorBuffOn == 2 & beerTime <= 0)   // armorBuffOn = 2 : 맥주 버프 지속중
        {
            goblin.I.armor -= 10;
            armorBuffOn = 0;
        }
        
        if(damageBuffOn == 1)   // damageBuffOn = 1 : 포션 버프 발동
        {
            goblin.I.damage += 10;
            goblin.I.skillDmg[0] += 10;
            damageBuffOn = 2;
        }
        else if(damageBuffOn == 2 & potionTime <= 0)   // damageBuffOn = 2 : 포션 버프 지속중
        {
            goblin.I.damage -= 10;
            goblin.I.skillDmg[0] -= 10;
            damageBuffOn = 0;            
        }

        if(goblin.I.myInventory == true)
        {
        // 0:amulet, 1:helmet, 2:talisman, 3:weapon, 4:armor, 5:shield, 6:ring1, 7:boots, 8:ring2
            if(Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                Vector2 pos = Camera.main.ScreenToWorldPoint(mousePos);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if(hit.collider != null)
                {
                    if(hit.collider.tag == "batWing")   // 이 아래로 루팅 아이템
                    {
                        if(goblin.I.healPoint >= goblin.I.maxHealPoint - 5f)
                        {
                            itemTooltip.SetActive(false);
                            goblin.I.healPoint = goblin.I.maxHealPoint;
                            Destroy(hit.collider.gameObject);
                        }
                        else if(goblin.I.healPoint < goblin.I.maxHealPoint - 5f)
                        {
                            itemTooltip.SetActive(false);
                            goblin.I.healPoint += 5f;
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "broadSword")   // 브로드소드 장착, 이 아래로 무기 아이템
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 3f;
                            goblin.I.skill.Insert(0, "broadSwordSkill");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 10f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "holySword")   // 홀리소드 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 2f;
                            goblin.I.skill.Insert(0, "holySwordSkill"); 
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 5f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "katana")   // 카타나 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 5f;
                            goblin.I.skill.Insert(0, "katanaSkill");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 10f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "lightningSword")   // 번개 검 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 4f;
                            goblin.I.skill.Insert(0, "lightningSwordSkill"); 
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 13f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "claymore")   // 클레이모어 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 8f;
                            goblin.I.skill.Insert(0, "claymoreSkill"); 
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 15f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "salamanderSword")   // 샐러맨더 소드 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 7f;
                            goblin.I.skill.Insert(0, "salamanderSwordSkill"); 
                            goblin.I.skill.Insert(1, "flame");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 15f);
                            goblin.I.skillDmg.Insert(1, goblin.I.damage + 3f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "guardianSword")   // 가디언 소드 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 5f;
                            goblin.I.skill.Insert(0, "guardianSwordSkill");
                            goblin.I.skill.Insert(1, "guardianSwordSkill");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 3f);
                            goblin.I.skillDmg.Insert(1, goblin.I.damage + 3f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "heavenlySword")   // 천공의 검 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 5f;
                            goblin.I.skill.Insert(0, "heavenlySwordSkill");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 10f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "scimitar")   // 언월도 장착
                    {
                        if(equipment.fullCheck[3] == false)
                        {                        
                            equipment.fullCheck[3] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 5f;
                            goblin.I.skill.Insert(0, "scimitarSkill");
                            goblin.I.skillDmg.Insert(0, goblin.I.damage + 10f);
                            Instantiate(hit.collider.gameObject, equipment.slots[3].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "banditLightArmor")  // 가죽 갑옷 장착, 이 아래로 갑옷 아이템
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 2f;
                            goblin.I.moveSpeed += 0.1f;
                            goblin.I.goblinStat[2] += 0.1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "royalTunic")  // 귀족의 외투 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 4f;
                            goblin.I.maxHealPoint += 10f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "battleguardArmor")  // 전투 갑옷 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 6f;
                            goblin.I.damage += 2f;
                            goblin.I.skillDmg[0] += 2f;
                            goblin.I.moveSpeed -= 0.2f;
                            goblin.I.goblinStat[2] -= 0.2f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "greyKnightArmor")  // 회색의 기사 갑옷 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 8f;
                            goblin.I.maxHealPoint += 25f;
                            goblin.I.moveSpeed -= 0.3f;
                            goblin.I.goblinStat[2] -= 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "darkArmor")  // 어둠 군주의 갑옷 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 2f;
                            if(goblin.I.maxHealPoint - goblin.I.healPoint < 30f)
                            {
                                goblin.I.healPoint = goblin.I.maxHealPoint - 30f;
                            }
                            goblin.I.maxHealPoint -= 30f;
                            goblin.I.damage += 10f;
                            goblin.I.skillDmg[0] += 10f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "manticoreArmor")  // 만티코어의 갑옷 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 15f;
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "hunterArmor")  // 사냥꾼의 갑옷 장착
                    {
                        if(equipment.fullCheck[4] == false)
                        {                        
                            equipment.fullCheck[4] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            goblin.I.damage += 4f;
                            goblin.I.skillDmg[0] += 4f;
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[4].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    } 

                    else if(hit.collider.tag == "banditLightBoots")  // 가죽 신발 장착, 이 아래로 신발 아이템
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "battleguardBoots")  // 전투 장화 장착
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 3f;
                            goblin.I.damage += 1f;
                            goblin.I.skillDmg[0] += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "darkBoots")  // 어둠 군주의 신발 장착
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 2f;
                            if(goblin.I.maxHealPoint - goblin.I.healPoint < 15f)
                            {
                                goblin.I.healPoint = goblin.I.maxHealPoint - 15f;
                            }
                            goblin.I.maxHealPoint -= 15f;
                            goblin.I.damage += 7f;
                            goblin.I.skillDmg[0] += 7f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }   
                    else if(hit.collider.tag == "greyKnightBoots")  // 회색 기사 각반 장착
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 7f;
                            goblin.I.maxHealPoint += 15f;
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "manticoreBoots")  // 만티코어 신발 장착
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 10f;
                            goblin.I.moveSpeed += 0.5f;
                            goblin.I.goblinStat[2] += 0.5f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "hunterBoots")  // 사냥꾼의 신발 장착
                    {
                        if(equipment.fullCheck[7] == false)
                        {                        
                            equipment.fullCheck[7] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            goblin.I.damage += 2f;
                            goblin.I.skillDmg[0] += 2f;
                            goblin.I.moveSpeed += 0.5f;
                            goblin.I.goblinStat[2] += 0.5f;
                            Instantiate(hit.collider.gameObject, equipment.slots[7].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "woodenShield")  // 나무 방패 장착, 이 아래로 방패 아이템
                    {
                        if(equipment.fullCheck[5] == false)
                        {                        
                            equipment.fullCheck[5] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[5].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "buckler")  // 버클러 장착
                    {
                        if(equipment.fullCheck[5] == false)
                        {                        
                            equipment.fullCheck[5] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 3f;
                            goblin.I.moveSpeed += 0.1f;
                            goblin.I.goblinStat[2] += 0.1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[5].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "battleShield")  // 전투 방패 장착
                    {
                        if(equipment.fullCheck[5] == false)
                        {                        
                            equipment.fullCheck[5] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.armor += 4f;
                            goblin.I.damage += 1f;
                            goblin.I.skillDmg[0] += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[5].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "towerShield")  // 타워 실드 장착
                    {
                        if(equipment.fullCheck[5] == false)
                        {                        
                            equipment.fullCheck[5] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.armor += 10f;
                            goblin.I.moveSpeed -= 0.2f;
                            goblin.I.goblinStat[2] -= 0.2f;
                            Instantiate(hit.collider.gameObject, equipment.slots[5].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    } 

                    else if(hit.collider.tag == "leatherHelmet")  // 가죽 모자 장착, 이 아래로 모자 아이템
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            goblin.I.moveSpeed += 0.1f;
                            goblin.I.goblinStat[2] += 0.1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "hawkHelm")  // 호크 헬름 장착
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "rogueHat")  // 도적의 두건 장착
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.moveSpeed += 0.2f;
                            goblin.I.goblinStat[2] += 0.2f;
                            goblin.I.damage += 3f;
                            goblin.I.skillDmg[0] += 3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "copperHelm")  // 구리 투구 장착
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 5f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "knightHelm")  // 기사의 투구 장착
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 7f;
                            goblin.I.damage += 1f;
                            goblin.I.skillDmg[0] += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "darkHelm")  // 암흑 기사 단장 투구 장착
                    {
                        if(equipment.fullCheck[1] == false)
                        {                        
                            equipment.fullCheck[1] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 2f;
                            if(goblin.I.maxHealPoint - goblin.I.healPoint < 15f)
                            {
                                goblin.I.healPoint = goblin.I.maxHealPoint - 15f;
                            }
                            goblin.I.maxHealPoint -= 15f;
                            goblin.I.damage += 7f;
                            goblin.I.skillDmg[0] += 7f;
                            Instantiate(hit.collider.gameObject, equipment.slots[1].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "bronzeRing")  // 동 가락지 장착, 이 아래로 반지 아이템 
                    {
                        if(equipment.fullCheck[6] == false)
                        {                        
                            equipment.fullCheck[6] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[6].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "silverRing")  // 은 반지 장착 
                    {
                        if(equipment.fullCheck[6] == false)
                        {                        
                            equipment.fullCheck[6] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.armor += 2f;
                            goblin.I.damage += 1f;
                            goblin.I.skillDmg[0] += 1f;
                            Instantiate(hit.collider.gameObject, equipment.slots[6].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "goldRing")  // 금 반지 장착 
                    {
                        if(equipment.fullCheck[6] == false)
                        {                        
                            equipment.fullCheck[6] = true;
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.damage += 2f;
                            goblin.I.skillDmg[0] += 2f;
                            goblin.I.maxHealPoint += 20f;
                            Instantiate(hit.collider.gameObject, equipment.slots[6].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }   
                    else if(hit.collider.tag == "magicRing")  // 마법 반지 장착 
                    {
                        if(equipment.fullCheck[6] == false)
                        {                        
                            equipment.fullCheck[6] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.magicRing = true;
                            Instantiate(hit.collider.gameObject, equipment.slots[6].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }   
                    else if(hit.collider.tag == "theOneRing")  // 절대 반지 장착 
                    {
                        if(equipment.fullCheck[6] == false)
                        {                        
                            equipment.fullCheck[6] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.damage += 3f;
                            goblin.I.skillDmg[0] += 3f;
                            goblin.I.armor += 3f;
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            goblin.I.magicRing = true;
                            Instantiate(hit.collider.gameObject, equipment.slots[6].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "gloveTalisman")  // 무쇠 장갑 장착, 이 아래로 탈리스만 아이템 
                    {
                        if(equipment.fullCheck[2] == false)
                        {                        
                            equipment.fullCheck[2] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.damage += 2f;
                            goblin.I.skillDmg[0] += 2f;
                            goblin.I.armor += 2f;
                            goblin.I.moveSpeed -= 0.2f;
                            goblin.I.goblinStat[2] -= 0.2f;
                            Instantiate(hit.collider.gameObject, equipment.slots[2].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "arrowTalisman")  // 엘프의 화살 장착
                    {
                        if(equipment.fullCheck[2] == false)
                        {                        
                            equipment.fullCheck[2] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.moveSpeed += 0.3f;
                            goblin.I.goblinStat[2] += 0.3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[2].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "bowTalisman")  // 사냥꾼의 활 장착
                    {
                        if(equipment.fullCheck[2] == false)
                        {                        
                            equipment.fullCheck[2] = true;
                            itemTooltip.SetActive(false);
                            goblin.I.damage += 3f;
                            goblin.I.skillDmg[0] += 3f;
                            Instantiate(hit.collider.gameObject, equipment.slots[2].transform, false);
                            Destroy(hit.collider.gameObject);
                        }
                    }

                    else if(hit.collider.tag == "apple")  // 사과 사용, 이 아래로 기타 아이템
                    {
                        if(goblin.I.healPoint >= goblin.I.maxHealPoint - 10f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint = goblin.I.maxHealPoint;
                            Destroy(hit.collider.gameObject);
                        }
                        else if(goblin.I.healPoint < goblin.I.maxHealPoint - 10f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint += 10f;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "cheese")  // 치즈 사용
                    {
                        if(goblin.I.healPoint >= goblin.I.maxHealPoint - 20f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint = goblin.I.maxHealPoint;
                            Destroy(hit.collider.gameObject);
                        }
                        else if(goblin.I.healPoint < goblin.I.maxHealPoint - 20f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint += 20f;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "chicken")  // 치킨 사용
                    {
                        if(goblin.I.healPoint >= goblin.I.maxHealPoint - 30f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint = goblin.I.maxHealPoint;
                            Destroy(hit.collider.gameObject);
                        }
                        else if(goblin.I.healPoint < goblin.I.maxHealPoint - 30f)
                        {
                            itemTooltip.SetActive(false);
                            shop.I.itemTooltip.SetActive(false);
                            goblin.I.healPoint += 30f;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if(hit.collider.tag == "beer")  // 맥주 사용
                    {
                        itemTooltip.SetActive(false);
                        shop.I.itemTooltip.SetActive(false);
                        if(beerTime <= 0)
                        {
                            beerTime = 10f;
                            armorBuffOn = 1;
                            Destroy(hit.collider.gameObject);
                        }
                        else
                        {
                            buffTxtOn();
                            Invoke("buffTxtClose", 1.5f);
                        }
                    }
                    else if(hit.collider.tag == "potion")  // 포션 사용
                    {
                        itemTooltip.SetActive(false);
                        shop.I.itemTooltip.SetActive(false);
                        if(potionTime <= 0)
                        {
                            potionTime = 10f;
                            damageBuffOn = 1;
                            Destroy(hit.collider.gameObject);
                        }
                        else
                        {
                            buffTxtOn();
                            Invoke("buffTxtClose", 1.5f);
                        }
                    }                                                 
                }
            }
        }
    }

    void buffTxtOn()
    {
        buffTxt.SetActive(true);
    }

    void buffTxtClose()
    {
        buffTxt.SetActive(false);
    }
}
