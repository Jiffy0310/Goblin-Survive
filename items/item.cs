using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    // 아이템 추가시 수정해야 할 스크립트
    // equipSlot.cs - 장비 아이템 추가시에만
    // item.cs - 인벤토리에 표시할 프리팹 유니티에서 설정
    // itemManager.cs - 아이템 게임오브젝트 선언 후 몬스터 드랍아이템 설정
    //                - 아이템 사용 효과 스크립트 추가
    // 몬스터.cs - 해당 아이템 드랍할 몬스터 스크립트에서 아이템드랍 구문 수정
    // goblin.cs - 장비 아이템 추가시 스킬 추가
    // tooltip.cs - 아이템 툴팁 추가
    private inventory inventory;
    public GameObject itemObject;  // 인벤토리에 생성할 아이콘(프리팹)
    public GameObject fullTxt;

    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<inventory>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "goblin")
        {
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.fullCheck[i] == false)
                {
                    inventory.fullCheck[i] = true;
                    Instantiate(itemObject, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
                else if(inventory.fullCheck[0] == true & inventory.fullCheck[1] == true & inventory.fullCheck[2] == true & inventory.fullCheck[3] == true & inventory.fullCheck[4] == true & inventory.fullCheck[5] == true & inventory.fullCheck[6] == true & inventory.fullCheck[7] == true & inventory.fullCheck[8] == true)
                {
                    fullTxtOpen();
                    Invoke("fullTxtClose", 1.5f);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void itemTxtOpen()
    {
        //float x = goblin.I.transform.position.x;
        //float y = goblin.I.transform.position.y;
        //itemTxt.transform.position = new Vector3(x, y, 0);
        //itemTxt.SetActive(true);
    }

    void itemTxtClose()
    {
        //itemTxt.SetActive(false);
    }

    void fullTxtOpen()
    {
        fullTxt.SetActive(true);
    }

    void fullTxtClose()
    {
        fullTxt.SetActive(false);
    }
}
