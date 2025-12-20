using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button microsoftSignInButton;
    public TextMeshProUGUI errorMessage;

    [Header("Scene Management")]
    public string mainMenuScene = "MainMenu";

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginClick);
        microsoftSignInButton.onClick.AddListener(OnMicrosoftSignIn);
        
        if (errorMessage != null)
            errorMessage.gameObject.SetActive(false);
    }

    private void OnLoginClick()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowError("Please enter both username and password");
            return;
        }

        PlayerPrefs.SetString("CurrentUser", username);
        PlayerPrefs.SetInt("IsLoggedIn", 1);
        PlayerPrefs.SetString("LoginMethod", "Standard");
        PlayerPrefs.Save();

        Debug.Log($"User logged in: {username}");
        
        LoadMainMenu();
    }

    private void OnMicrosoftSignIn()
    {
        PlayerPrefs.SetString("CurrentUser", "Microsoft User");
        PlayerPrefs.SetInt("IsLoggedIn", 1);
        PlayerPrefs.SetString("LoginMethod", "Microsoft");
        PlayerPrefs.Save();

        Debug.Log("Microsoft Sign-In successful");
        
        LoadMainMenu();
    }

    private void ShowError(string message)
    {
        if (errorMessage != null)
        {
            errorMessage.text = message;
            errorMessage.gameObject.SetActive(true);
            Invoke("HideError", 3f);
        }
    }

    private void HideError()
    {
        if (errorMessage != null)
            errorMessage.gameObject.SetActive(false);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OnForgotPassword()
    {
        Debug.Log("Forgot Password clicked");
        ShowError("Password recovery coming soon");
    }
}