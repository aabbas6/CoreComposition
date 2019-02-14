using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI : MonoBehaviour
{

    private Sprite[] StaminaSprites;
    private Sprite[] HealthSprites;

    private Image StaminaImageRef;
    private Image HealthImageRef;

    public GameObject pauseMenu;
    private bool isPaused;

    //GameObject characterRef;
    TextMeshProUGUI coin;

    public int staminaPipCtr;
    public int healthPipCtr;
    private int coinCtr;

    //int i;

    void Start()
    {

        staminaPipCtr = 0;
        healthPipCtr = 5;

        coinCtr = 0;
        coin = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();

        StaminaSprites = Resources.LoadAll<Sprite>("StaminaDirectory");
        HealthSprites = Resources.LoadAll<Sprite>("HealthDirectory");

        Array.Reverse(HealthSprites);

        StaminaImageRef = GameObject.Find("StaminaHolder").GetComponent<Image>();
        HealthImageRef = GameObject.Find("HealthHolder").GetComponent<Image>();

        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        isPaused = false;

        // Character reference <--------- UNCOMMENT BELOW -------->
        // characterRef = GameObject.Find("__INSERT_NAME_OF_CHARACTER__");

        //i = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        //i++;

        //coin.GetComponent<TextMeshProUGUI>().text = i.ToString();

        /*
        if (healthPipCtr != characterRef.health)
        {
            healthPipCtr = characterRef.health;
            HealthImageRef.sprite = HealthSprites[healthPipCtr];
        }
        */

        /*
        if (staminaPipCtr != characterRef.stamina)
        {
            staminaPipCtr = characterRef.stamina;
            StaminaImageRef.sprite = StaminaSprites[staminaPipCtr];
        }
        */

        /*
        if (coinCtr != characterRef.coin)
        {
            coinCtr = characterRef.coin
            UpdateCoinText();
        }
        */

    }

    // Used to recolor all the health triangles
    void UpdateCoinText()
    {
        coin.GetComponent<TextMeshProUGUI>().text = coinCtr.ToString();
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
