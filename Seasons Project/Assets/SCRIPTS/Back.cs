using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    
    // Start is called before the first frame update

    public void LoadNextInBuild()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 14);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
