using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Veriables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;
    [SerializeField] private Button _menuButton;

    [Header("Initial Elements")]
    [SerializeField] private Step _startStep;

    [Header("External Components")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private string _gameOverSceneName;

    private Step _currentStep;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        _menuButton.onClick.AddListener(MenuButtonClicked);
        SetCurrentStep(_startStep);
    }

    private void Update()
    {

        CheckGameOver();
        int choiceIndex = GetPressedButtonIndex();
        if (!IsIndexValid(choiceIndex))
            return;
        SetCurrentStep(choiceIndex);
    }

    private void CheckGameOver()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;
        if (_currentStep.Choices.Length==0)
            _sceneLoader.LoadScene(_gameOverSceneName);
        
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

    private void MenuButtonClicked()
    {
        _sceneLoader.LoadScene(_menuSceneName);
    }

    /*
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(_menuSceneName);
    }
*/
    #endregion
}