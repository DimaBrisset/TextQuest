using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Veriables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;

    [Header("Initial Elements")]
    [SerializeField] private Step _startStep;

    private Step _currentStep;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        SetCurrentStep(_startStep);
    }

    private void Update()
    {
        int choiceIndex = GetPressedButtonIndex();
        if (!IsIndexValid(choiceIndex))
            return;
        SetCurrentStep(choiceIndex);
    }

    #endregion


    #region Private Methods

    private bool IsIndexValid(int choiceIndex)
    {
        return choiceIndex >= 0;
    }

    private int GetPressedButtonIndex()
    {
        int pressButtonIndex = NumButtonHelper.GetPressButtonIndex();
        return pressButtonIndex - 1;
    }

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Choices.Length <= choiceIndex)
            return;
        Step nextStep = _currentStep.Choices[choiceIndex];
        SetCurrentStep(nextStep);
    }

    private void SetCurrentStep(Step step)
    {
        if (step == null)
            return;

        _currentStep = step;

        _headerLabel.text = _currentStep.DebugHeaderText;
        _descriptionLabel.text = _currentStep.DescriptionText;
        _choicesLabel.text = _currentStep.ChoicesText;
    }

    #endregion
}