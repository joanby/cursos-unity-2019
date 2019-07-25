using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{

    public int questID;
    private QuestManager questManager;
    private ItemsManager itemManager;
    public string itemName;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            questManager = FindObjectOfType<QuestManager>();
            itemManager = FindObjectOfType<ItemsManager>();

            Quest q = questManager.QuestWithID(questID);
            if(q == null){
                Debug.LogErrorFormat("La misión con id {0} no existe", questID);
            }
            if (q.gameObject.activeInHierarchy&&!q.questCompleted){
                questManager.itemCollected = this;
                itemManager.AddQuestItem(this.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
