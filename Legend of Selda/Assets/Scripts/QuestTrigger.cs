using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    public int questID;
    public bool startPoint, endPoint;
    private bool playerInZone;
    public bool automaticCatch;
    
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            playerInZone = true;
            Debug.Log("El jugador ha entrado");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            playerInZone = false;
        }
    }

    private void Update()
    {
        if(playerInZone){
            Debug.Log("En la zona");

            if (automaticCatch || (!automaticCatch && Input.GetMouseButtonDown(1))){
                Quest q = questManager.QuestWithID(questID);
                if(q == null){
                    Debug.LogErrorFormat("La misión con ID {0} no existe", questID);
                    return;
                }
                Debug.Log("Tengo mision");

                //Si llego aquí, la misión existe
                if (!q.questCompleted){ //Si quitamos esta línea, la misión es repetible
                    //No he completado la misión actual
                    Debug.Log("No completada");

                    if (startPoint){
                        Debug.Log("Punto de inicio");

                        //Estoy en la zona que empieza la misión
                        if (!q.gameObject.activeInHierarchy){
                            Debug.Log("Procedemos a activar");

                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }
                    if(endPoint){
                        Debug.Log("Punto de fin");

                        //Estoy en la zona que acaba la misión
                        if (q.gameObject.activeInHierarchy){
                            Debug.Log("Completamos mision");

                            q.CompleteQuest();
                        }
                    }
                }
            }
        }
    }
}
