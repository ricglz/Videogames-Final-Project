using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{ 
    private int lifeLAD, lifeIMI, lifeITC, lifeLMC, lifeE;
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
        SetGameControllerReferenceOnButtons();
        turn = 1;
        lifeLAD = 50;
        lifeIMI = 50;
        lifeITC = 70;
        lifeLMC = 100;
        lifeE = 400;
        enemyT.text = lifeE.ToString();
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
        int damage = Random.Range(20, 30);
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
    void openQuestion(int i)
    {
        int damage = Random.Range(30, 40);
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
        int damage = Random.Range(40, 60);
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

    public void perfectDrawing()
    {
        int damage = Random.Range(20, 30);
        lifeE -= damage;
        ladPanel.SetActive(false);
        turn++;
    }
    public void fireMixTape()
    {
        int damage = Random.Range(25, 35);
        lifeE -= damage;
        imiPanel.SetActive(false);
        turn++;
    }
    public void efficientCode()
    {
        int damage = Random.Range(15, 25);
        lifeE -= damage;
        itcPanel.SetActive(false);
        turn++;
    }
    public void amazingPresentation()
    {
        int damage = Random.Range(10, 20);
        lifeE -= damage;
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
        enemyT.text = lifeE.ToString();
        ladT.text = lifeLAD.ToString();
        imiT.text = lifeIMI.ToString();
        itcT.text = lifeITC.ToString();
        lmcT.text = lifeLMC.ToString();
        if (lifeE < 0)
        {
            gameOver(1);
        }
        else if (lifeIMI <= 0 && lifeLAD <= 0 && lifeITC <= 0 && lifeLMC <= 0)
        {
            gameOver(0);
        }

        if (lifeLAD <= 0)
        {
            lad.SetActive(false);
            dead.Add(1);
        }
        if (lifeIMI <= 0)
        {
            imi.SetActive(false);
            dead.Add(2);
        }
        if (lifeITC <= 0)
        {
            itc.SetActive(false);
            dead.Add(3);
        }
        if (lifeLMC <= 0)
        {
            lmc.SetActive(false);
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
            enemyAttack();
            turn = 1;
        }
    }
}
