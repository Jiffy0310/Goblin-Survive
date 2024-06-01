using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public bool[] fullCheck;
    public GameObject[] weapon;
    public GameObject[] armor;
    public GameObject[] helm;
    public GameObject[] boots;
    public GameObject[] etcs;
    public GameObject[] slots;
    public GameObject itemTooltip;
    public Text itemNameTxt;
    public Text itemTooltipTxt;
    public Text priceTxt;
    public Text shopNameTxt;
    public int type;
    public static shop I;
    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        type = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(type == 1)
        {
            shopNameTxt.text = "무기";
            for(int i = 0; i < slots.Length; i++)
            {
                if(fullCheck[i] == false)
                {
                    fullCheck[i] = true;
                    Instantiate(weapon[i], slots[i].transform, false);
                    type = 0;
                }
            }
        }
        else if(type == 2)
        {
            shopNameTxt.text = "갑옷";
            for(int i = 0; i < slots.Length; i++)
            {
                if(fullCheck[i] == false)
                {
                    fullCheck[i] = true;
                    Instantiate(armor[i], slots[i].transform, false);
                    type = 0;
                }
            }
        }
        else if(type == 3)
        {
            shopNameTxt.text = "헬멧";
            for(int i = 0; i < slots.Length; i++)
            {
                if(fullCheck[i] == false)
                {
                    fullCheck[i] = true;
                    Instantiate(helm[i], slots[i].transform, false);
                    type = 0;
                }
            }
        }
        else if(type == 4)
        {
            shopNameTxt.text = "신발";
            for(int i = 0; i < slots.Length; i++)
            {
                if(fullCheck[i] == false)
                {
                    fullCheck[i] = true;
                    Instantiate(boots[i], slots[i].transform, false);
                    type = 0;
                }
            }
        }
        else if(type == 5)
        {
            shopNameTxt.text = "기타";
            for(int i = 0; i < slots.Length; i++)
            {
                if(fullCheck[i] == false)
                {
                    fullCheck[i] = true;
                    Instantiate(etcs[i], slots[i].transform, false);
                    type = 0;
                }
            }
        }
    }

    public void nextPage()
    {
        if(shopNameTxt.text == "무기")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 2;
        }
        else if(shopNameTxt.text == "갑옷")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 3;
        }
        else if(shopNameTxt.text == "헬멧")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 4;
        }
        else if(shopNameTxt.text == "신발")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 5;
        }
        else if(shopNameTxt.text == "기타")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 1;
        }
    }

    public void prevPage()
    {
        if(shopNameTxt.text == "무기")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 5;
        }
        else if(shopNameTxt.text == "갑옷")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 1;
        }
        else if(shopNameTxt.text == "헬멧")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 2;
        }
        else if(shopNameTxt.text == "신발")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 3;
        }
        else if(shopNameTxt.text == "기타")
        {
            for(int idx = 0; idx < slots.Length; idx++)
            {
                fullCheck[idx] = false;
                Destroy(slots[idx].transform.GetChild(0).gameObject);
            }
            type = 4;
        }
    }

}
