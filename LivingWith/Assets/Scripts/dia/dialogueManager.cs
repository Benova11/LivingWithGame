using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueManager : MonoBehaviour
{
   [SerializeField] dialogueSO startDialogueFile;
    dialogueSO curDialogue;
   [SerializeField] TextMeshProUGUI DialogueTextObject;
   [SerializeField] TextMeshProUGUI DialogueOwnerTextObject;
    [SerializeField] GameObject textBox;


    bool isOn = true;
    private void Start()
    {
        curDialogue = startDialogueFile;

        textBox.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        goNextLine();
        goPreLine();
      
    }
    IEnumerator startDialog()
    {
        string tampText = null;
        DialogueOwnerTextObject.text = curDialogue.OwnerDialogue;
        foreach (var h in curDialogue.dialogueText)
        {
            tampText += h;  
            yield return new WaitForSeconds(0.01f);          
            DialogueTextObject.text = tampText;
        }
       
    }
    void goNextLine()
    {
        if (!curDialogue.IsThisTheFinlelLine && curDialogue.nextLine && isOn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                curDialogue = curDialogue.nextLine;
                StartCoroutine(startDialog());
            }
        }
    }   
    void goPreLine()
    {
        if (!curDialogue.IsThisTheFirstLine && curDialogue.preLine && isOn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                curDialogue = curDialogue.preLine;
                StartCoroutine(startDialog());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("its in");
        if (collision.GetComponent<Movement>())
        {
            Debug.Log("its in1");
            StartCoroutine(startDialog());
            textBox.SetActive(true);
            isOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
        {
            
            textBox.SetActive(false);
            isOn = false;
        }
    }
}
