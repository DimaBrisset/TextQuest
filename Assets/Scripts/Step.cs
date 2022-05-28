using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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


  
    public Sprite[] States; // Состояния персонажа

    // Этот метод вешаете на нужную вам кнопку и выставляете соответствующий индекс
    public void Change(int stateIndex)
    {
        GetComponent<Image>().sprite = States[stateIndex];
    }
}

  
