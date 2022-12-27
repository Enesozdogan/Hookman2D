using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI playerHpText;
    public TextMeshProUGUI winStateText;
    public PlayerController playerController;
    [SerializeField] GameObject panel;
    public bool isGameOver;
    public bool winState=false;
    public Boss boss;
    public TextMeshProUGUI BossHpText; 
    // Start is called before the first frame update
    void Start()
    {
        playerHpText.text="HP: "+playerController.playerHp;
        BossHpText.text="HP: "+boss.bossHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            EndGameMenu();
        }
    }
    public void UpdatePlayerHpText(){
        playerController.playerHp-=1;
        playerHpText.text="HP: "+playerController.playerHp;
        if(playerController.playerHp<=0){
            isGameOver=true;
            winState=false;
        }
    }
    public void UpdateBossHpText(){
        boss.bossHp-=1;
        BossHpText.text="HP: "+boss.bossHp;
        if(boss.bossHp<=0){
            isGameOver=true;
            winState=true;
        }
    }
    void EndGameMenu(){
        panel.SetActive(true);
        if(winState){
            winStateText.text="YOU WON";
        }
        else{
            winStateText.text="YOU LOST";
        }
    }
    public void RestartButton(){
        panel.SetActive(false);
        SceneManager.LoadScene(1);
        
    }
    public void ExitButton(){
        Application.Quit();
    }
}
