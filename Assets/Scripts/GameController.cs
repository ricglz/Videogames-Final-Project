using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int lifeLAD, lifeIMI, lifeITC, lifeLMC, lifeE,pdu=2;
    private int[] armor = new int[5];
    private int[] debuff = new int[5];
    private int turn;
    public Button[] buttons;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public Text enemyT;
    public Text ladT;
    public Text imiT;
    public Text itcT;
    public Text lmcT;
    public GameObject enemy;
    public GameObject lad;
    public GameObject ladPanel;
    public GameObject imi;
    public GameObject imiPanel;
    public GameObject itc;
    public GameObject itcPanel;
    public GameObject lmc;
    public GameObject lmcPanel;
    private List<int> dead = new List<int>();
    // Use this for initialization
    void Awake()
    {
        for (int i=0; i<5; i++)
        {
            armor[i] = 0;
            debuff[i] = 0;
        }
        SetGameControllerReferenceOnButtons();
        turn = 1;
        lifeLAD = 50;
        lifeIMI = 50;
        lifeITC = 70;
        lifeLMC = 100;
        lifeE = 900;
        ladT.text = lifeLAD.ToString();
        imiT.text = lifeIMI.ToString();
        itcT.text = lifeITC.ToString();
        lmcT.text = lifeLMC.ToString();
    }
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<attackButton>().SetGameControllerReference(this);
        }
    }
    void enemyAttack()
    {
        int enemy = Random.Range(1, 5);
        while (dead.Contains(enemy))
        {
            enemy = Random.Range(1, 5);
        }
        int att = Random.Range(1, 3);
        if (att == 3)
        {
            extraWork(enemy);
        }
        else if (att == 2)
        {
            openQuestion(enemy);
        }
        else
        {
            wordEssay(enemy);
        }

    }
    void extraWork(int i)
    {
        int damage = Random.Range(20, 30) - debuff[4];
        if (i == 1)
        {
            lifeLAD -= damage-armor[0];
        }
        else if (i == 2)
        {
            lifeIMI -= damage - armor[1];
        }
        else if (i == 3)
        {
            lifeITC -= damage - armor[2];
        }
        else if (i == 4)
        {
            lifeLMC -= damage - armor[0];
        }
    }
    void openQuestion(int i)
    {
        int damage = Random.Range(20, 30) - debuff[4];
        if (i == 1)
        {
            lifeLAD -= damage;
        }
        else if (i == 2)
        {
            lifeIMI -= damage;
        }
        else if (i == 3)
        {
            lifeITC -= damage;
        }
        else if (i == 4)
        {
            lifeLMC -= damage;
        }
    }
    void wordEssay(int i)
    {
        int damage = Random.Range(20, 30) - debuff[4];
        if (i == 1)
        {
            lifeLAD -= damage - armor[0];
        }
        else if (i == 2)
        {
            lifeIMI -= damage - armor[0];
        }
        else if (i == 3)
        {
            lifeITC -= damage - armor[0];
        }
        else if (i == 4)
        {
            lifeLMC -= damage - armor[0];
        }
    }

    public void perfectDrawing()
    {
        int damage = Random.Range(20, 30) - debuff[0];
        lifeE -= damage;
        ladPanel.SetActive(false);
        pdu--;
        turn++;
        if(pdu == 0)
        {
            
        }
    }
    public void fireMixTape()
    {
        int damage = Random.Range(25, 35) - debuff[1];
        lifeE -= damage;
        imiPanel.SetActive(false);
        turn++;
    }
    public void rickRoll()
    {
        if (debuff[4] < 20)
        { 
            debuff[4] += 5;
        }
        imiPanel.SetActive(false);
        turn++;
    }
    public void efficientCode()
    {
        int damage = Random.Range(15, 25) - debuff[2];
        lifeE -= damage;
        itcPanel.SetActive(false);
        turn++;
    }
    public void amazingPresentation()
    {
        int damage = Random.Range(5, 15) - debuff[3];
        lifeE -= damage;
        lmcPanel.SetActive(false);
        turn++;
    }
    public void suitOn()
    {
        for(int i=0; i<4; i++)
        {
            armor[i] = 10;
        }
        lmcPanel.SetActive(false);
        turn++;
    }


    void gameOver(int i)
    {
        gameOverPanel.SetActive(true);
        if (i == 1)
        {

            gameOverText.text = "You Win";
            turn = 10;
        }
        else
        {
            gameOverText.text = "You Lose";
            turn = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeLAD > 0) ladT.text = lifeLAD.ToString();
        if (lifeIMI > 0) imiT.text = lifeIMI.ToString();
        if (lifeITC > 0) itcT.text = lifeITC.ToString();
        if(lifeLMC > 0) lmcT.text = lifeLMC.ToString();
        if (lifeE < 0)
        {
            gameOver(1);
        }
        else if (lifeIMI <= 0 && lifeLAD <= 0 && lifeITC <= 0 && lifeLMC <= 0)
        {
            enemy.SetActive(false);
            gameOver(0);
        }

        if (lifeLAD <= 0)
        {
            lad.SetActive(false);
            ladT.text = "";
            dead.Add(1);
        }
        if (lifeIMI <= 0)
        {
            imi.SetActive(false);
            imiT.text = "";
            dead.Add(2);
        }
        if (lifeITC <= 0)
        {
            itc.SetActive(false);
            itcT.text = "";
            dead.Add(3);
        }
        if (lifeLMC <= 0)
        {
            lmc.SetActive(false);
            lmcT.text = "";
            dead.Add(4);
        }
        if (turn == 1)
        {
            if (lad.activeSelf)
            {
                ladPanel.SetActive(true);
            }
            else
            {
                turn++;
            }

        }
        
        if (turn == 2)
        {
            if (imi.activeSelf)
            {
                imiPanel.SetActive(true);
            }
            else
            {
                turn++;
            }

        }
        if (turn == 3)
        {
            if (itc.activeSelf)
            {
                itcPanel.SetActive(true);
            }
            else
            {
                turn++;
            }

        }
        if (turn == 4)
        {
            if (lmc.activeSelf)
            {
                lmcPanel.SetActive(true);
            }
            else
            {
                turn++;
            }

        }
        if (lifeE > 0 && turn == 5)
        {
            StartCoroutine(Example());
            enemyAttack();
            turn = 1;
        }
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5f);
    }
}
