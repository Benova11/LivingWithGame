using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialogue")]
public class dialogueSO : ScriptableObject
{
    public string OwnerDialogue;
   [TextArea(5,12)] public string dialogueText;
    
    public bool IsThisTheFinlelLine;
    public bool IsThisTheFirstLine;
    public dialogueSO nextLine;
    public dialogueSO preLine;

    public bool DidHeShowUp;

}
