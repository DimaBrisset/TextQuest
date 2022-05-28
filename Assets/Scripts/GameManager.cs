using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;

    [Header("Initial Elements")]
    [SerializeField] private Step _startStep;
    private Step _currentStep;

    private void Start()
    {
        SetCurrentStep(_startStep);
    }

    private void Update()
    {
        int choiceIndex = GetPressedButtonIndex();
        if (choiceIndex == -1)
            return;
        SetCurrentStep(choiceIndex);
    }

    private int GetPressedButtonIndex()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            return 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            return 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            return 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            return 3;
        }

        return -1;
    }

    private void SetCurrentStep(int choiceIndex)
    {
        if(_currentStep.Choices.Length<=choiceIndex)
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
}