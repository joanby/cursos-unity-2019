using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public int currentMoney;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Money")){
            //Ya tenemos dinero de una sesión previa
            currentMoney = PlayerPrefs.GetInt("Money");
        }else{
            currentMoney = 0;
            PlayerPrefs.SetInt("Money", 0);
        }
        moneyText.text = currentMoney.ToString();
    }

    public void AddMoney(int moneyCollected){
        currentMoney += moneyCollected;
        moneyText.text = currentMoney.ToString();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
}
