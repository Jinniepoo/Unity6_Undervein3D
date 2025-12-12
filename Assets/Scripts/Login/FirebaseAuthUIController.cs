using Firebase;
using Firebase.Auth;
using System;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class FirebaseAuthUIController : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;

    public TMP_Text outputText;

    private void Start()
    {
        FirebaseAuthController.Instance.OnChangedLoginState += OnChangeLoginState;
        FirebaseAuthController.Instance.InitializeFirebase();
    }

    public void CreateUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        FirebaseAuthController.Instance.CreateUser(email, password);
    }

    public void Login()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        FirebaseAuthController.Instance.Login(email, password);
    }

    public void SignOut()
    {
        FirebaseAuthController.Instance.SignOut();
    }

    public void OnChangeLoginState(bool signedIn)
    {
        outputText.text = signedIn ? "Signed In: " : "Signed Out: ";
        outputText.text += FirebaseAuthController.Instance.UserId;
    }
}
