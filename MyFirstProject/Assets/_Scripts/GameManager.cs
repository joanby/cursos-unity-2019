using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public string labelText = "Recolecta los 4 ítems y gánate la libertad!";
    public const int MAX_ITEMS = 4;

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    /*private string _firstName;
    public string FirstName { 
        get{
            //Aquí poneis codigo cuando se consulta una variable
            return _firstName;
        } 
        set
        {
            //Aquí ponéis código cuando se modifica una variable
            _firstName = value;
        } 
    }*/

    private int _itemsCollected = 0;
    public int Items
    {
        get{
            return _itemsCollected;
        }
        set{
            _itemsCollected = value;

            if (_itemsCollected >= MAX_ITEMS){
                GameOver(true);
            }else{
                labelText = "Ítem encontrado, te faltan: " + 
                    (MAX_ITEMS - _itemsCollected);
            }
        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get{
            return _playerHP;
        }
        set{
            if (value >= 0 && value <= 3)
            {
                _playerHP = value;
            }

            if(_playerHP<=0){
                GameOver(false);
            }else{
                labelText = "Ouch, me han dado...";
            }
            Debug.LogFormat("Vidas: {0}", _playerHP);
        }
    }

    private void GameOver(bool gameWon){
        labelText = gameWon?"Has encontrado todos los ítems": "Has muerto... Prueba otra vez";
        showWinScreen = gameWon;
        showLossScreen = !gameWon;
        Time.timeScale = 0;
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(/*dist x izda*/25,
                         /*dist y arri*/25,
                         /*anchura*/180,
                         /*altura*/25), "Vida: " + _playerHP);

        GUI.Box(new Rect(25, 25+25+15, 180, 25), "Ítems recogidos: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 50, 400, 50),
                  labelText);

        if(showWinScreen)
        {
            ShowEndLevel("Enhorabuena, Has Ganado!");
        }

        if(showLossScreen){
            ShowEndLevel("GAME OVER");
        }
    }


    private void ShowEndLevel(string message){
        if (GUI.Button(new Rect(Screen.width / 2 - 200,
                                   Screen.height / 2 - 100,
                                   400, 200),
                          message))
        {
            Utilities.RestartLevel();
        }
    }

}
