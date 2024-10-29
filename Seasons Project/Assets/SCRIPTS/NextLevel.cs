using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    string leveltoload = "LevelName";
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //IF player touches Dorito, load scene win
        if (collision.gameObject.tag == "Player")
        {

          
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //IF player touches Dorito, load win scene
            SceneManager.LoadScene(leveltoload);

        }
    }

   /* private IEnumerator LoadNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(leveltoload);
        {
            while (asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }*/
}
