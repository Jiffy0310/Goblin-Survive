using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSlot : MonoBehaviour
{
    public int i;
    private shop shop;
    private tooltip tooltip;
    private inventory inventory;
    public GameObject fullTxt;
    public GameObject impossibleTxt;
    private void Awake()
    {
        shop = GameObject.FindObjectOfType<shop>();
        tooltip = GameObject.FindObjectOfType<tooltip>();
        inventory = GameObject.FindObjectOfType<inventory>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.childCount <= 0)
        {
            shop.fullCheck[i] = false;
        }        
    }

    public void buyItem()
    {
        if(transform.GetChild(0).GetComponent<tooltip>() != null)
        {
            if(goblin.I.gold >= transform.GetChild(0).GetComponent<tooltip>().price)
            {
                for(int i = 0; i < inventory.slots.Length; i++)
                {
                    if(inventory.fullCheck[i] == false)
                    {
                        inventory.fullCheck[i] = true;
                        goblin.I.gold -= transform.GetChild(0).GetComponent<tooltip>().price;
                        Instantiate(transform.GetChild(0), inventory.slots[i].transform, false);
                        break;
                    }
                    else if(inventory.fullCheck[0] == true & inventory.fullCheck[1] == true & inventory.fullCheck[2] == true & inventory.fullCheck[3] == true & inventory.fullCheck[4] == true & inventory.fullCheck[5] == true & inventory.fullCheck[6] == true & inventory.fullCheck[7] == true & inventory.fullCheck[8] == true)
                    {
                        fullTxtOpen();
                        Invoke("fullTxtClose", 1.5f);
                    }
                }
            }
            else
            {
                impossibleTxtOpen();
                Invoke("impossibleTxtClose", 1.5f);
            }
        }
    }

    void fullTxtOpen()
    {
        fullTxt.SetActive(true);
    }

    void fullTxtClose()
    {
        fullTxt.SetActive(false);
    }

    void impossibleTxtOpen()
    {
        impossibleTxt.SetActive(true);
    }

    void impossibleTxtClose()
    {
        impossibleTxt.SetActive(false);
    }
}
