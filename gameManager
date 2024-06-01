using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject bat;  // 이 아래부터 endTxt 까지 몬스터 종류
    public GameObject zombie;
    public GameObject skeleton;
    public GameObject slime;
    public GameObject ghost;
    public GameObject arachne;
    public GameObject imp;
    public GameObject fireElf;
    public GameObject devilQueen1;
    public GameObject worm;
    public GameObject endTxt;
    public GameObject victoryTxt;
    public GameObject dmgUpBtn;
    public GameObject armUpbtn;
    public GameObject spdUpbtn;
    public Canvas canvas;
    public Canvas shopCanvas;
    public Text timeTxt;
    public float surviveTime;
    public static gameManager I;
    

    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeMonster", 0.0f, 2.0f);    
        canvas.GetComponent<RectTransform>().transform.position = new Vector3(1000f, 1000f, 0f);
        shopCanvas.GetComponent<RectTransform>().transform.position = new Vector3(1000f, 995f, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        if(goblin.I.statPoint >= 1f)
        {
            dmgUpBtn.SetActive(true);
            armUpbtn.SetActive(true);
            spdUpbtn.SetActive(true);
        }
        else
        {
            dmgUpBtn.SetActive(false);
            armUpbtn.SetActive(false);
            spdUpbtn.SetActive(false);
        }

        surviveTime += Time.deltaTime;
        timeTxt.text = surviveTime.ToString("N2");

        if(goblin.I.statPoint >= 1f & Input.GetKeyDown(KeyCode.Alpha1))
        {
            dmgUp();
        }

        if(goblin.I.statPoint >= 1f & Input.GetKeyDown(KeyCode.Alpha2))
        {
            armUp();
        }

        if(goblin.I.statPoint >= 1f & Input.GetKeyDown(KeyCode.Alpha3))
        {
            spdUp();
        }

        if(goblin.I.bossScore == 1)
        {
            Invoke("goblinVictory", 0f);
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
    }

    public void bossKill()
    {
        Time.timeScale = 0.0f;
        victoryTxt.SetActive(true);
    }
    
    public void goblinDie()
    {
        Invoke("gameOver", 2.0f);
    }

    public void goblinVictory()
    {
        Invoke("bossKill", 0.8f);
    }

    public void dmgUp()
    {
        goblin.I.statPoint -= 1f;
        goblin.I.damage += 1f;
        goblin.I.skillDmg[0] += 1f;
    }

    public void armUp()
    {
        goblin.I.statPoint -= 1f;
        goblin.I.armor += 1f;
    }

    public void spdUp()
    {
        goblin.I.statPoint -= 1f;
        goblin.I.moveSpeed += 0.1f;
        goblin.I.goblinStat[2] += 0.1f;
    }

    public void inventoryOpen()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }

    public void inventoryClose()
    {
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.GetComponent<RectTransform>().transform.position = new Vector3(1000f, 1000f, 0f);
    }

    public void shopOpen()
    {
        shopCanvas.renderMode = RenderMode.ScreenSpaceCamera;
    }

    public void shopClose()
    {
        shopCanvas.renderMode = RenderMode.WorldSpace;
        shopCanvas.GetComponent<RectTransform>().transform.position = new Vector3(1000f, 995f, 0f);
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        endTxt.SetActive(false);
    }

    public void makeMonster()   // 몬스터 생성, 난이도 조절
    {
        if(surviveTime >= 0f & surviveTime <= 10f)
        {
            Instantiate(bat);
            //Instantiate(zombie);
            //Instantiate(skeleton);
            //Instantiate(slime);
            //Instantiate(ghost);
            //Instantiate(imp);
            //Instantiate(arachne);
            //Instantiate(devilQueen1);
            //Instantiate(fireElf);
            //Instantiate(worm);
        }
        
        else if(surviveTime >= 10f & surviveTime <= 20f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 7) Instantiate(bat);
            Instantiate(zombie);
        }
        else if(surviveTime >= 20f & surviveTime <= 30f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 3) Instantiate(bat);
            if(p < 6) Instantiate(zombie);
            Instantiate(skeleton);
        }
        else if(surviveTime >= 30f & surviveTime <= 40f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 2) Instantiate(bat);
            if(p < 3) Instantiate(zombie);
            if(p < 6) Instantiate(skeleton);
            Instantiate(slime);
        }
        else if(surviveTime >= 40f & surviveTime <= 50f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 1) Instantiate(bat);
            if(p < 2) Instantiate(zombie);
            if(p < 4) Instantiate(skeleton);
            if(p < 6) Instantiate(slime);
            Instantiate(ghost);
        }
        else if(surviveTime >= 50f & surviveTime <= 60f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 1) Instantiate(bat);
            if(p < 2) Instantiate(zombie);
            if(p < 3) Instantiate(skeleton);
            if(p < 5) Instantiate(slime);
            if(p < 7) Instantiate(ghost);
            Instantiate(imp);
        }
        else if(surviveTime >= 60f & surviveTime <= 70f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 1) Instantiate(bat);
            if(p < 2) Instantiate(zombie);
            if(p < 2) Instantiate(skeleton);
            if(p < 3) Instantiate(slime);
            if(p < 5) Instantiate(ghost);
            if(p < 7) Instantiate(imp);
            Instantiate(arachne);
        }
        else if(surviveTime >= 70f & surviveTime <= 80f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 1) Instantiate(bat);
            if(p < 1) Instantiate(zombie);
            if(p < 1) Instantiate(skeleton);
            if(p < 2) Instantiate(slime);
            if(p < 4) Instantiate(ghost);
            if(p < 6) Instantiate(imp);
            if(p < 7) Instantiate(arachne);
            Instantiate(fireElf);
        }
        else if(surviveTime >= 80f & surviveTime <= 81f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 1) Instantiate(bat);
            if(p < 1) Instantiate(zombie);
            if(p < 1) Instantiate(skeleton);
            if(p < 2) Instantiate(slime);
            if(p < 3) Instantiate(ghost);
            if(p < 4) Instantiate(imp);
            if(p < 5) Instantiate(arachne);
            if(p < 7) Instantiate(fireElf);
            Instantiate(devilQueen1);
        }
        else if(surviveTime >= 90f)
        {
            float p = Random.Range(0f, 10f);
            if(p < 2) Instantiate(bat);
            if(p < 3) Instantiate(zombie);
            if(p < 4) Instantiate(skeleton);
            if(p < 5) Instantiate(slime);
            if(p < 6) Instantiate(ghost);
            if(p < 7) Instantiate(imp);
            if(p < 8) Instantiate(arachne);
            if(p < 9) Instantiate(fireElf);
        }                  
    }

}
