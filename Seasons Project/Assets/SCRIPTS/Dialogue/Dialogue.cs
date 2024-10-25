using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int Index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startDialogue()
    {
        Index = 0;
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[Index].ToCharArray))
                {

        }
    }
}
