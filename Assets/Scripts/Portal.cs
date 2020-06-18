using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string ScenePoint;
    public Transform BackPoint;

    public bool mustactivatereturn;
   
    public int ID;

    static bool mustreturn;
    static int returnID;

    Color transparent = new Color(0, 0, 0, 0);


    void Start() {

        Time.timeScale = 1;
        if (mustreturn && ID == returnID) {

         GameObject playerGB = GameObject.FindWithTag("Player");
         Transform playerTR = playerGB.GetComponent<Transform>();
         playerTR.position = BackPoint.position;
         playerTR.rotation = BackPoint.rotation;
            Debug.Log("P: " + playerGB.name + " -> " + BackPoint.position.ToString(), BackPoint.gameObject);
        }
        
    }


    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player") {
            Time.timeScale = 0;
            if (mustactivatereturn) { 
                mustreturn = true;
                }
            
            returnID = ID;
            StartCoroutine(LoadingScene());
           
        }
    }

            IEnumerator LoadingScene()
    {
        Transicao transicao = FindObjectOfType<Transicao>();
        transicao.StartTransicao(transparent, Color.black);
        yield return new WaitUntil(() => transicao.finished);
        SceneManager.LoadScene(ScenePoint);
    }
}