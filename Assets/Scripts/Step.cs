using UnityEngine;

public class Step : MonoBehaviour
{
 #region Veriables

 public string DebugHeaderText;
 [TextArea(4, 8)]
 public string DescriptionText;

 [TextArea]
 public string ChoicesText;

 public Step[] Choices;
 

 #endregion
   
}