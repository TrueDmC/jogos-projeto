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


    void Start()
    {

        Time.timeScale = 1;
        if (mustreturn && ID == returnID)
        {

            GameObject playerGB = GameObject.FindWithTag("Player");
            CharacterController playerCCtrl = playerGB.GetComponent<CharacterController>();

            playerCCtrl.enabled = false;
            playerCCtrl.transform.position = BackPoint.position;
            playerCCtrl.transform.rotation = BackPoint.rotation;
            playerCCtrl.enabled = true;

        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Time.timeScale = 0;
            if (mustactivatereturn)
            {
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