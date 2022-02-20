using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    private Text scoreText;
    private GameObject dia;
    private Text diaText;
    private List<string> diaMessages;
    private int diaIndex;

    public static bool isInDiaState; 

    private void Start()
    {
        isInDiaState = false;
        scoreText = transform.Find("score").GetComponent<Text>();
        dia = transform.GetChild(1).gameObject;
        diaText = dia.GetComponentInChildren<Text>();
        dia.GetComponent<Button>().onClick.AddListener(ShowNextDiaMessage);
        dia.SetActive(false);
        ShowScore(0);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            ShowNextDiaMessage();
        }
    }

    public void ShowScore(int score)
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void ShowDialo(List<string> messages)
    {
        if (dia.activeSelf) return;
        isInDiaState = true;
        diaMessages = messages;
        diaIndex = 0;
        ShowNextDiaMessage();
    }
    private void ShowNextDiaMessage()
    {
        if (!isInDiaState) return;
        dia.SetActive(true);
        if (diaIndex >= diaMessages.Count)
        {
            diaText.text = "";
            isInDiaState = false;
            dia.SetActive(false);
        }
        else
        {
            diaText.text = diaMessages[diaIndex];
            diaIndex++;
        }

    }
}
