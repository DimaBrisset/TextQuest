using UnityEngine;
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
    public Sprite States;

    #endregion


    #region Public Methods

    public void Change(int stateIndex)
    {
        GetComponent<Image>().sprite = States;
    }

    #endregion
}