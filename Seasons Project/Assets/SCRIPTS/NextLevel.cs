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
        if(collision.gameObject.tag == "Flag" )
        {
           
            
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //IF player touches Dorito, load win scene
                SceneManager.LoadScene(leveltoload);
            
        }
    }
}