using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tooltip : MonoBehaviour
{
    // 아이템 추가시 수정해야 할 스크립트
    // equipSlot.cs - 장비 아이템 추가시에만
    // item.cs - 인벤토리에 표시할 프리팹 유니티에서 설정
    // itemManager.cs - 아이템 게임오브젝트 선언 후 몬스터 드랍아이템 설정
    //                - 아이템 사용 효과 스크립트 추가
    // 몬스터.cs - 해당 아이템 드랍할 몬스터 스크립트에서 아이템드랍 구문 수정
    // goblin.cs - 무기 아이템 추가시 스킬 추가
    // tooltip.cs - 아이템 툴팁 추가

    public int price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if(gameObject.tag == "batWing")  // 이 아래로 루팅 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "박쥐 날개";
            itemManager.I.itemTooltipTxt.text = "사용 시 체력 5 회복";    
        }

        if(gameObject.tag == "holySword")  // 이 아래로 무기 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "홀리 소드";
            itemManager.I.itemTooltipTxt.text = "데미지 +2" + "\n" + "홀리 볼트 스킬" + "\n" + "스킬 추가 데미지 +5" + "\n" + "스킬 쿨타임 5초";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "홀리 소드";
            shop.I.itemTooltipTxt.text = "데미지 +2" + "\n" + "홀리 볼트 스킬" + "\n" + "스킬 추가 데미지 +5" + "\n" + "스킬 쿨타임 5초";
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "broadSword")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "브로드 소드";
            itemManager.I.itemTooltipTxt.text = "데미지 +3" + "\n" + "발도 스킬" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 10초";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "브로드 소드";
            shop.I.itemTooltipTxt.text = "데미지 +3" + "\n" + "발도 스킬" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 10초";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "katana")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "카타나";
            itemManager.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "공기 가르기 스킬" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 10초";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "카타나";
            shop.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "공기 가르기 스킬" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 10초";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "lightningSword")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "번개 검";
            itemManager.I.itemTooltipTxt.text = "데미지 +4" + "\n" + "낙뢰 스킬" + "\n" +  "스킬 추가 데미지 +13" + "\n" + "스킬 쿨타임 5초";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "번개 검";
            shop.I.itemTooltipTxt.text = "데미지 +4" + "\n" + "낙뢰 스킬" + "\n" +  "스킬 추가 데미지 +13" + "\n" + "스킬 쿨타임 5초";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "claymore")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "클레이모어";
            itemManager.I.itemTooltipTxt.text = "데미지 +8" + "\n" + "지반 붕괴 스킬" + "\n" +  "스킬 추가 데미지 +15" + "\n" + "스킬 쿨타임 15초";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "클레이모어";
            shop.I.itemTooltipTxt.text = "데미지 +8" + "\n" + "지반 붕괴 스킬" + "\n" +  "스킬 추가 데미지 +15" + "\n" + "스킬 쿨타임 15초";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "salamanderSword")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "샐러맨더 소드";
            itemManager.I.itemTooltipTxt.text = "데미지 +7" + "\n" + "화염 폭발 검기 스킬" + "\n" +  "스킬 추가 데미지 +15" + "\n" + "스킬 쿨타임 15초" + "\n" + "화염의 힘이 응축되어 있는 검.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "샐러맨더 소드";
            shop.I.itemTooltipTxt.text = "데미지 +7" + "\n" + "화염 폭발 검기 스킬" + "\n" +  "스킬 추가 데미지 +15" + "\n" + "스킬 쿨타임 15초" + "\n" + "화염의 힘이 응축되어 있는 검.";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "guardianSword")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "가디언 소드";
            itemManager.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "신성의 오라 스킬" + "\n" +  "스킬 추가 데미지 +3" + "\n" + "스킬 쿨타임 20초" + "\n" + "이 검은 항상 당신을 지켜줄 것이다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "가디언 소드";
            shop.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "신성의 오라 스킬" + "\n" +  "스킬 추가 데미지 +3" + "\n" + "스킬 쿨타임 20초" + "\n" + "이 검은 항상 당신을 지켜줄 것이다.";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "heavenlySword")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "천공의 검";
            itemManager.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "천공의 검기 스킬" + "\n" +  "스킬 추가 데미지 10" + "\n" + "스킬 쿨타임 10초" + "\n" + "하늘까지 가를 수 있는 검.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "천공의 검";
            shop.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "천공의 검기" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 10초" + "\n" + "하늘까지 가를 수 있는 검.";   
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "scimitar")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "언월도";
            itemManager.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "폭풍의 칼날 스킬" + "\n" +  "스킬 추가 데미지 10" + "\n" + "스킬 쿨타임 15초" + "\n" + "매우 무거워 휘두르기만 해도 폭풍이 휘몰아친다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "언월도";
            shop.I.itemTooltipTxt.text = "데미지 +5" + "\n" + "폭풍의 칼날 스킬" + "\n" +  "스킬 추가 데미지 +10" + "\n" + "스킬 쿨타임 15초" + "\n" + "매우 무거워 휘두르기만 해도 폭풍이 휘몰아친다.";   
            shop.I.priceTxt.text = price.ToString();
        }

        if(gameObject.tag == "banditLightArmor")  // 이 아래로 갑옷 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "가죽 갑옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 이동속도 +0.1" + "\n" + "\n" + "가죽으로 된 흔한 갑옷.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "가죽 갑옷";
            shop.I.itemTooltipTxt.text = "방어력 +2, 이동속도 +0.1" + "\n" + "\n" + "가죽으로 된 흔한 갑옷.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "royalTunic")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "귀족의 외투";
            itemManager.I.itemTooltipTxt.text = "방어력 +4, 최대체력 +10" + "\n" + "\n" + "인간 귀족들이 입던 외투.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "귀족의 외투";
            shop.I.itemTooltipTxt.text = "방어력 +4, 최대체력 +10" + "\n" + "\n" + "인간 귀족들이 입던 외투.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "battleguardArmor")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "전투 갑옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +6, 데미지 +2, 이동속도 -0.2" + "\n" + "\n" + "인간 병사들이 입던 갑옷.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "전투 갑옷";
            shop.I.itemTooltipTxt.text = "방어력 +6, 데미지 +2, 이동속도 -0.2" + "\n" + "\n" + "인간 병사들이 입던 갑옷.";    
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "greyKnightArmor")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "회색의 기사 갑옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +8, 최대체력 +25, 이동속도 -0.3" + "\n" + "\n" + "그는 전장에서 후퇴하는 법이 없었고, 갑옷은 항상 회색빛이었다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "회색의 기사 갑옷";
            shop.I.itemTooltipTxt.text = "방어력 +8, 최대체력 +25, 이동속도 -0.3" + "\n" + "\n" + "그는 전장에서 후퇴하는 법이 없었고, 갑옷은 항상 회색빛이었다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "darkArmor")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "어둠 군주의 갑옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -30, 데미지 +10" + "\n" + "\n" + "자신의 강함에 흠뻑 취해있던 어둠 군주의 갑옷.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "어둠 군주의 갑옷";
            shop.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -30, 데미지 +10" + "\n" + "\n" + "자신의 강함에 흠뻑 취해있던 어둠 군주의 갑옷.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "manticoreArmor")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "만티코어의 갑옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +15, 이동속도 +0.4" + "\n" + "\n" + "그것의 가죽은 매우 단단하지만 가벼워 최고급 갑옷의 재료가 된다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "만티코어의 갑옷";
            shop.I.itemTooltipTxt.text = "방어력 +15, 이동속도 +0.4" + "\n" + "\n" + "그것의 가죽은 매우 단단하지만 가벼워 최고급 갑옷의 재료가 된다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "hunterArmor")
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "사냥꾼의 겉옷";
            itemManager.I.itemTooltipTxt.text = "방어력 +1, 데미지 +4, 이동속도 +0.3" + "\n" + "\n" + "안정성과 기동성을 모두 확보하기 위하여 제작된 겉옷.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "사냥꾼의 겉옷";
            shop.I.itemTooltipTxt.text = "방어력 +1, 데미지 +4, 이동속도 +0.3" + "\n" + "\n" + "안정성과 기동성을 모두 확보하기 위하여 제작된 겉옷.";  
            shop.I.priceTxt.text = price.ToString();
        }

        if(gameObject.tag == "banditLightBoots")  // 이 아래로 신발 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "가죽 신발";
            itemManager.I.itemTooltipTxt.text = "방어력 +1, 이동속도 +0.3" + "\n" + "\n" + "가죽으로 만든 흔한 신발. 언뜻 보면 장화 같다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "가죽 신발";
            shop.I.itemTooltipTxt.text = "방어력 +1, 이동속도 +0.3" + "\n" + "\n" + "가죽으로 만든 흔한 신발. 언뜻 보면 장화 같다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "battleguardBoots")  
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "전투 장화";
            itemManager.I.itemTooltipTxt.text = "방어력 +3, 데미지 +1" + "\n" + "\n" + "전투에 특화되어 있는 장화."; 
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "전투 장화";
            shop.I.itemTooltipTxt.text = "방어력 +3, 데미지 +1" + "\n" + "\n" + "전투에 특화되어 있는 장화."; 
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "darkBoots") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "어둠 군주의 신발";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -15, 데미지 +7" + "\n" + "\n" + "자신의 강함에 흠뻑 취해있던 어둠 군주의 신발.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "어둠 군주의 신발";
            shop.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -15, 데미지 +7" + "\n" + "\n" + "자신의 강함에 흠뻑 취해있던 어둠 군주의 신발.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "greyKnightBoots") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "회색 기사 각반";
            itemManager.I.itemTooltipTxt.text = "방어력 +7, 최대체력 +15, 이동속도 +0.3" + "\n" + "\n" + "그는 전장에서 후퇴하는 법이 없었고, 각반조차 붉게 물드는 법이 없었다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "회색 기사 각반";
            shop.I.itemTooltipTxt.text = "방어력 +7, 최대체력 +15, 이동속도 +0.3" + "\n" + "\n" + "그는 전장에서 후퇴하는 법이 없었고, 각반조차 붉게 물드는 법이 없었다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "manticoreBoots") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "만티코어 신발";
            itemManager.I.itemTooltipTxt.text = "방어력 +10, 이동속도 +0.5" + "\n" + "\n" + "그것의 가죽은 매우 단단하지만 가벼워 최고급 갑옷의 재료가 된다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "만티코어 신발";
            shop.I.itemTooltipTxt.text = "방어력 +10, 이동속도 +0.5" + "\n" + "\n" + "그것의 가죽은 매우 단단하지만 가벼워 최고급 갑옷의 재료가 된다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "hunterBoots") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "사냥꾼의 신발";
            itemManager.I.itemTooltipTxt.text = "방어력 +1, 데미지 +2, 이동속도 +0.5" + "\n" + "\n" + "안정성과 기동성을 모두 확보하기 위하여 제작된 신발.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "사냥꾼의 신발";
            shop.I.itemTooltipTxt.text = "방어력 +1, 데미지 +2, 이동속도 +0.5" + "\n" + "\n" + "안정성과 기동성을 모두 확보하기 위하여 제작된 신발.";  
            shop.I.priceTxt.text = price.ToString();
        }

        if(gameObject.tag == "woodenShield")  // 이 아래로 방패 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "나무 방패";
            itemManager.I.itemTooltipTxt.text = "방어력 +1" + "\n" + "\n" + "나무로 만든 간단한 방패. 약한 공격을 막아줄 정도는 된다.";
        }
        if(gameObject.tag == "buckler") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "버클러";
            itemManager.I.itemTooltipTxt.text = "방어력 +3, 이동속도 +0.1" + "\n" + "\n" + "기동성을 중시한 가벼운 방패.";
        }
        if(gameObject.tag == "battleShield") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "전투 방패";
            itemManager.I.itemTooltipTxt.text = "방어력 +4, 데미지 +1" + "\n" + "\n" + "좋은 방패는 공격에도 도움이 된다.";  
        }
        if(gameObject.tag == "towerShield") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "타워 실드";
            itemManager.I.itemTooltipTxt.text = "방어력 +10, 이동속도 -0.2" + "\n" + "\n" + "무겁지만 어떠한 공격도 막을 수 있을 것만 같다.";  
        }

        if(gameObject.tag == "leatherHelmet")  // 이 아래로 모자 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "가죽 모자";
            itemManager.I.itemTooltipTxt.text = "방어력 +1, 이동속도 +0.1" + "\n" + "\n" + "아무것도 쓰지 않는 것 보다야 낫다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "가죽 모자";
            shop.I.itemTooltipTxt.text = "방어력 +1, 이동속도 +0.1" + "\n" + "\n" + "아무것도 쓰지 않는 것 보다야 낫다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "hawkHelm") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "호크 헬름";
            itemManager.I.itemTooltipTxt.text = "이동속도 +0.3" + "\n" + "\n" + "방어에 도움은 되지 않지만 몸이 가벼워지는 느낌이다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "호크 헬름";
            shop.I.itemTooltipTxt.text = "이동속도 +0.3" + "\n" + "\n" + "방어에 도움은 되지 않지만 몸이 가벼워지는 느낌이다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "rogueHat") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "도적의 두건";
            itemManager.I.itemTooltipTxt.text = "데미지 +3, 이동속도 +0.2" + "\n" + "\n" + "적의 약점이 눈에 훤히 보이는 것만 같다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "도적의 두건";
            shop.I.itemTooltipTxt.text = "데미지 +3, 이동속도 +0.2" + "\n" + "\n" + "적의 약점이 눈에 훤히 보이는 것만 같다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "copperHelm") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "구리 투구";
            itemManager.I.itemTooltipTxt.text = "방어력 +5" + "\n" + "\n" + "구리로 만들어진 투구. 이제 머리 맞을 일이 두렵지 않다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "구리 투구";
            shop.I.itemTooltipTxt.text = "방어력 +5" + "\n" + "\n" + "구리로 만들어진 투구. 이제 머리 맞을 일이 두렵지 않다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "knightHelm") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "기사의 투구";
            itemManager.I.itemTooltipTxt.text = "방어력 +7, 데미지 +1" + "\n" + "\n" + "전장을 누비던 기사의 투구. 자신감이 솟는 것만 같다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "기사의 투구";
            shop.I.itemTooltipTxt.text = "방어력 +7, 데미지 +1" + "\n" + "\n" + "전장을 누비던 기사의 투구. 자신감이 솟는 것만 같다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "darkHelm") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "암흑 기사 단장 투구";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -15, 데미지 +7" + "\n" + "\n" + "자신의 피를 바쳐서라도 강해지고 싶던 암흑 기사 단장의 투구.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "암흑 기사 단장 투구";
            shop.I.itemTooltipTxt.text = "방어력 +2, 최대체력 -15, 데미지 +7" + "\n" + "\n" + "자신의 피를 바쳐서라도 강해지고 싶던 암흑 기사 단장의 투구.";  
            shop.I.priceTxt.text = price.ToString();
        }

        if(gameObject.tag == "bronzeRing")  // 이 아래로 반지 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "동 가락지";
            itemManager.I.itemTooltipTxt.text = "방어력 +1" + "\n" + "\n" + "청동으로 만든 가락지. 오래되지 않아 아직 단단하다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "동 가락지";
            shop.I.itemTooltipTxt.text = "방어력 +1" + "\n" + "\n" + "청동으로 만든 가락지. 오래되지 않아 아직 단단하다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "silverRing")  
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "은 반지";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 데미지 +1" + "\n" + "\n" + "은으로 된 반지. 반지를 낀 채로 때리면 더욱 아프다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "은 반지";
            shop.I.itemTooltipTxt.text = "방어력 +2, 데미지 +1" + "\n" + "\n" + "은으로 된 반지. 반지를 낀 채로 때리면 더욱 아프다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "goldRing") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "금 반지";
            itemManager.I.itemTooltipTxt.text = "데미지 +2, 최대체력 +20" + "\n" + "\n" + "금으로 만들어진 반지. 금이라 그런지 몸에 좋은 기운이 들어오는 것 같다.";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "금 반지";
            shop.I.itemTooltipTxt.text = "데미지 +2, 최대체력 +20" + "\n" + "\n" + "금으로 만들어진 반지. 금이라 그런지 몸에 좋은 기운이 들어오는 것 같다.";  
            shop.I.priceTxt.text = price.ToString();
        }
        if(gameObject.tag == "magicRing") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "마법 반지";
            itemManager.I.itemTooltipTxt.text = "5초마다 체력 +1" + "\n" + "\n" + "마법이 깃든 반지. 조금씩 건강해 지는 것 같다.";  
        }
        if(gameObject.tag == "theOneRing") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "절대 반지";
            itemManager.I.itemTooltipTxt.text = "5초마다 체력 +1, 데미지 +3, 방어력 +3, 이동속도 +0.3" + "\n" + "\n" + "절 대 반 지";  
        }
        
        if(gameObject.tag == "gloveTalisman")   // 이 아래로 부적 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "무쇠 장갑(부적)";
            itemManager.I.itemTooltipTxt.text = "방어력 +2, 데미지 +2, 이동속도 -0.2" + "\n" + "\n" + "인간계 최강 무투사가 착용하던 장갑. 지니고 다니기만 해도 강해지는 것 같다.";  
        }
        if(gameObject.tag == "arrowTalisman") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "엘프의 화살(부적)";
            itemManager.I.itemTooltipTxt.text = "이동속도 +0.3" + "\n" + "\n" + "엘프 종족이 사용하는 화살. 엘프의 가호가 아직 화살에 남아있는 것 같다.";  
        }
        if(gameObject.tag == "bowTalisman") 
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "사냥꾼의 활(부적)";
            itemManager.I.itemTooltipTxt.text = "데미지 +3" + "\n" + "\n" + "사냥꾼이 사용하던 활. 많은 사냥 탓에 낡아있지만 여전히 쓸만하다.";  
        }

        if(gameObject.tag == "apple")  // 사과 사용, 이 아래로 기타 아이템
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "사과";
            itemManager.I.itemTooltipTxt.text = "사용 시 체력 10 회복";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "사과";
            shop.I.itemTooltipTxt.text = "사용 시 체력 10 회복";
            shop.I.priceTxt.text = price.ToString();  
        }
        if(gameObject.tag == "cheese")  // 치즈 사용
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "치즈";
            itemManager.I.itemTooltipTxt.text = "사용 시 체력 20 회복";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "치즈";
            shop.I.itemTooltipTxt.text = "사용 시 체력 20 회복";
            shop.I.priceTxt.text = price.ToString();  
        }
        if(gameObject.tag == "chicken")  // 치킨 사용
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "닭다리";
            itemManager.I.itemTooltipTxt.text = "사용 시 체력 30 회복";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "닭다리";
            shop.I.itemTooltipTxt.text = "사용 시 체력 30 회복";
            shop.I.priceTxt.text = price.ToString();  
        }
        if(gameObject.tag == "beer")  // 맥주 사용
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "맥주";
            itemManager.I.itemTooltipTxt.text = "사용 시 1분간 방어력 +10";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "맥주";
            shop.I.itemTooltipTxt.text = "사용 시 1분간 방어력 +10";
            shop.I.priceTxt.text = price.ToString();  
        }
        if(gameObject.tag == "potion")  // 힘의 포션 사용
        {
            itemManager.I.itemTooltip.SetActive(true);
            itemManager.I.itemNameTxt.text = "힘의 포션";
            itemManager.I.itemTooltipTxt.text = "사용 시 1분간 데미지 +10";
            shop.I.itemTooltip.SetActive(true);
            shop.I.itemNameTxt.text = "힘의 포션";
            shop.I.itemTooltipTxt.text = "사용 시 1분간 데미지 +10";
            shop.I.priceTxt.text = price.ToString();  
        }
    }

    void OnMouseExit()
    {
        itemManager.I.itemTooltip.SetActive(false);
        shop.I.itemTooltip.SetActive(false);
    }
}
