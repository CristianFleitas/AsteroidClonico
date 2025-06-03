using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlMenu;
    public GameObject recordMenu;

    public Achievement achievement;

    public List<TextMeshProUGUI> textList;

    // Start is called before the first frame update
    private void Awake()
    {
        controlMenu.SetActive(false);
        recordMenu.SetActive(false);
    }
    void Start()
    {
        achievement = GameManager._instance.SaveData.GetComponent<SaveData>().achievement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startNewGame()
    {
        GameManager._instance.IniciarPartida();
    }
    public void exitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void openControlInterface()
    {
        mainMenu.SetActive(false);
        controlMenu.SetActive(true);
        recordMenu.SetActive(false);
    }
    public void openMainMenu()
    {
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
        recordMenu.SetActive(false);
    }
    public void openRecordMenu()
    {
        recordText();
        recordMenu.SetActive(true);
        controlMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    private string cronometro(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void recordText()
    {
        textList[0].text = achievement.record.ToString();
        textList[1].text = achievement.puntuation.ToString();
        textList[2].text = achievement.asteroidsDestroyed.ToString();
        textList[3].text = achievement.enemiesDefeated.ToString();
        textList[4].text = achievement.wavesCleared.ToString();
        textList[5].text = cronometro(achievement.timePlayed);
        textList[6].text = achievement.timesPlayed.ToString();

    }
}
