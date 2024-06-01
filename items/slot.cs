using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour
{
    public int i;
    private inventory inventory;

    private void Awake()
    {
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
            inventory.fullCheck[i] = false;
        }
    }

    public void removeItem()
    {
        for(int idx=0; idx<transform.childCount; idx++)
        {
            Destroy(transform.GetChild(idx).gameObject);
        }
    }
}
