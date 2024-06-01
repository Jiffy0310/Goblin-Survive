using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipSlot : MonoBehaviour
{
    // 아이템 추가시 수정해야 할 스크립트
    // equipSlot.cs - 장비 아이템 추가시에만
    // item.cs - 인벤토리에 표시할 프리팹 유니티에서 설정
    // itemManager.cs - 아이템 게임오브젝트 선언 후 몬스터 드랍아이템 설정
    //                - 아이템 사용 효과 스크립트 추가
    // 몬스터.cs - 해당 아이템 드랍할 몬스터 스크립트에서 아이템드랍 구문 수정
    // goblin.cs - 장비 아이템 추가시 스킬 추가
    // tooltip.cs - 아이템 툴팁 추가
    public int i;   // 슬롯 번호
    private equipment equipment;
    private inventory inventory;
    public GameObject equipTxt;  // 인벤토리 풀 텍스트

    private void Awake()
    {
        equipment = GameObject.FindObjectOfType<equipment>();
        inventory = GameObject.FindObjectOfType<inventory>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()   // 하위 오브젝트가 없을 경우 fullCheck[i] 를 계속 false 로
    {
        if(transform.childCount <= 0)
        {
            equipment.fullCheck[i] = false;
        }        
    }

    public void unequipItem()
    {
        if(equipment.fullCheck[i] == true)
        {
            for(int idx = 0; idx < inventory.slots.Length; idx++)
            {
                if(inventory.fullCheck[idx] == false)
                {
                    inventory.fullCheck[idx] = true;
                    Instantiate(transform.GetChild(0), inventory.slots[idx].transform, false);  // 인벤토리 슬롯에 뺀 장비 생성
                    if(transform.GetChild(0).CompareTag("broadSword") == true)  // 장비 아이템 추가시 조건문 장비마다 추가
                    {
                        goblin.I.damage -= 3;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("holySword") == true)  
                    {
                        goblin.I.damage -= 2;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("katana") == true)  
                    {
                        goblin.I.damage -= 5;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("lightningSword") == true)  
                    {
                        goblin.I.damage -= 4;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("claymore") == true)  
                    {
                        goblin.I.damage -= 8;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("salamanderSword") == true)  
                    {
                        goblin.I.damage -= 7;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skill.Insert(1, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                        goblin.I.skillDmg.Insert(1, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("guardianSword") == true)  
                    {
                        goblin.I.damage -= 5;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("heavenlySword") == true)  
                    {
                        goblin.I.damage -= 5;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("scimitar") == true)  
                    {
                        goblin.I.damage -= 5;
                        goblin.I.skill.Insert(0, "0");
                        goblin.I.skillDmg.Insert(0, 0f);
                    }
                    else if(transform.GetChild(0).CompareTag("banditLightArmor") == true)  // 이 아래부터 갑옷
                    {
                        goblin.I.armor -= 2;
                        goblin.I.moveSpeed -= 0.1f;
                        goblin.I.goblinStat[2] -= 0.1f;
                    }
                    else if(transform.GetChild(0).CompareTag("royalTunic") == true)  
                    {
                        goblin.I.armor -= 4;
                        if(goblin.I.maxHealPoint - goblin.I.healPoint < 10f)
                        {
                            goblin.I.healPoint = goblin.I.maxHealPoint - 10f;
                        }
                        goblin.I.maxHealPoint -= 10f;
                    }
                    else if(transform.GetChild(0).CompareTag("battleguardArmor") == true)  
                    {
                        goblin.I.armor -= 6;
                        goblin.I.damage -= 2;
                        goblin.I.skillDmg[0] -= 2f;
                        goblin.I.moveSpeed += 0.2f;
                        goblin.I.goblinStat[2] += 0.2f;
                    }
                    else if(transform.GetChild(0).CompareTag("greyKnightArmor") == true)  
                    {
                        goblin.I.armor -= 8f;
                        if(goblin.I.maxHealPoint - goblin.I.healPoint < 25f)
                        {
                            goblin.I.healPoint = goblin.I.maxHealPoint - 25f;
                        }
                        goblin.I.maxHealPoint -= 25f;
                        goblin.I.moveSpeed += 0.3f;
                        goblin.I.goblinStat[2] += 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("darkArmor") == true)  
                    {
                        goblin.I.armor -= 2f;
                        goblin.I.maxHealPoint += 30f;
                        goblin.I.damage -= 10f;
                        goblin.I.skillDmg[0] -= 10f;
                    }
                    else if(transform.GetChild(0).CompareTag("manticoreArmor") == true)  
                    {
                        goblin.I.armor -= 15f;
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("hunterArmor") == true)  
                    {
                        goblin.I.armor -= 1f;
                        goblin.I.damage -= 4f;
                        goblin.I.skillDmg[0] -= 4f;
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }                    
                    else if(transform.GetChild(0).CompareTag("banditLightBoots") == true)  // 이 아래부터 신발
                    {
                        goblin.I.armor -= 1f;
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("battleguardBoots") == true) 
                    {
                        goblin.I.armor -= 3f;
                        goblin.I.damage -= 1f;
                        goblin.I.skillDmg[0] -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("darkBoots") == true) 
                    {
                        goblin.I.armor -= 2f;
                        goblin.I.maxHealPoint += 15f;
                        goblin.I.damage -= 7f;
                        goblin.I.skillDmg[0] -= 7f;
                    }
                    else if(transform.GetChild(0).CompareTag("greyKnightBoots") == true) 
                    {
                        goblin.I.armor -= 7f;
                        if(goblin.I.maxHealPoint - goblin.I.healPoint < 15f)
                        {
                            goblin.I.healPoint = goblin.I.maxHealPoint - 15f;
                        }
                        goblin.I.maxHealPoint -= 15f;
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("manticoreBoots") == true) 
                    {
                        goblin.I.armor -= 10f;
                        goblin.I.moveSpeed -= 0.5f;
                        goblin.I.goblinStat[2] -= 0.5f;
                    }
                    else if(transform.GetChild(0).CompareTag("hunterBoots") == true) 
                    {
                        goblin.I.armor -= 1f;
                        goblin.I.damage -= 2f;
                        goblin.I.skillDmg[0] -= 2f;
                        goblin.I.moveSpeed -= 0.5f;
                        goblin.I.goblinStat[2] -= 0.5f;
                    }
                    else if(transform.GetChild(0).CompareTag("woodenShield") == true)  // 이 아래부터 방패
                    {
                        goblin.I.armor -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("buckler") == true) 
                    {
                        goblin.I.armor -= 3f;
                        goblin.I.moveSpeed -= 0.1f;
                        goblin.I.goblinStat[2] -= 0.1f;
                    }
                    else if(transform.GetChild(0).CompareTag("battleShield") == true) 
                    {
                        goblin.I.armor -= 4f;
                        goblin.I.damage -= 1f;
                        goblin.I.skillDmg[0] -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("towerShield") == true) 
                    {
                        goblin.I.armor -= 10f;
                        goblin.I.moveSpeed += 0.2f;
                        goblin.I.goblinStat[2] += 0.2f;
                    }
                    else if(transform.GetChild(0).CompareTag("leatherHelmet") == true)   // 이 아래부터 모자
                    {
                        goblin.I.armor -= 1f;
                        goblin.I.moveSpeed -= 0.1f;
                        goblin.I.goblinStat[2] -= 0.1f;
                    }
                    else if(transform.GetChild(0).CompareTag("hawkHelm") == true) 
                    {
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("rogueHat") == true) 
                    {
                        goblin.I.moveSpeed -= 0.2f;
                        goblin.I.goblinStat[2] -= 0.2f;
                        goblin.I.damage -= 3f;
                        goblin.I.skillDmg[0] -= 3f;
                    }
                    else if(transform.GetChild(0).CompareTag("copperHelm") == true) 
                    {
                        goblin.I.armor -= 5f;
                    }
                    else if(transform.GetChild(0).CompareTag("knightHelm") == true) 
                    {
                        goblin.I.armor -= 7f;
                        goblin.I.damage -= 1f;
                        goblin.I.skillDmg[0] -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("darkHelm") == true) 
                    {
                        goblin.I.armor -= 2f;
                        goblin.I.maxHealPoint += 15f;
                        goblin.I.damage -= 7f;
                        goblin.I.skillDmg[0] -= 7f;
                    }
                    else if(transform.GetChild(0).CompareTag("bronzeRing") == true)   // 이 아래부터 반지
                    {
                        goblin.I.armor -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("silverRing") == true)  
                    {
                        goblin.I.armor -= 2f;
                        goblin.I.damage -= 1f;
                        goblin.I.skillDmg[0] -= 1f;
                    }
                    else if(transform.GetChild(0).CompareTag("goldRing") == true)  
                    {
                        if(goblin.I.maxHealPoint - goblin.I.healPoint < 20f)
                        {
                            goblin.I.healPoint = goblin.I.maxHealPoint - 20f;
                        }
                        goblin.I.maxHealPoint -= 20f;
                        goblin.I.damage -= 2f;
                        goblin.I.skillDmg[0] -= 2f;
                    }
                    else if(transform.GetChild(0).CompareTag("magicRing") == true)  
                    {
                        goblin.I.magicRing = false;
                    }
                    else if(transform.GetChild(0).CompareTag("theOneRing") == true)  
                    {
                        goblin.I.damage -= 3f;
                        goblin.I.skillDmg[0] -= 3f;
                        goblin.I.armor -= 3f;
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                        goblin.I.magicRing = false;
                    }
                    else if(transform.GetChild(0).CompareTag("gloveTalisman") == true)  // 이 아래부터 탈리스만
                    {
                        goblin.I.damage -= 2f;
                        goblin.I.skillDmg[0] -= 2f;
                        goblin.I.armor -= 2f;
                        goblin.I.moveSpeed += 0.2f;
                        goblin.I.goblinStat[2] += 0.2f;
                    }
                    else if(transform.GetChild(0).CompareTag("arrowTalisman") == true) 
                    {
                        goblin.I.moveSpeed -= 0.3f;
                        goblin.I.goblinStat[2] -= 0.3f;
                    }
                    else if(transform.GetChild(0).CompareTag("bowTalisman") == true) 
                    {
                        goblin.I.damage -= 3f;
                        goblin.I.skillDmg[0] -= 3f;
                    }
                    Destroy(transform.GetChild(0).gameObject);
                    break;
                }
                else if(inventory.fullCheck[0] == true & inventory.fullCheck[1] == true & inventory.fullCheck[2] == true & inventory.fullCheck[3] == true & inventory.fullCheck[4] == true & inventory.fullCheck[5] == true & inventory.fullCheck[6] == true & inventory.fullCheck[7] == true & inventory.fullCheck[8] == true)
                {
                    equipTxtOpen();
                    Invoke("equipTxtClose", 1.5f);
                }
            }
        }
    }

    void equipTxtOpen()
    {
        equipTxt.SetActive(true);
    }

    void equipTxtClose()
    {
        equipTxt.SetActive(false);
    }
}
