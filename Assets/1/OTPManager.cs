using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OTPManager : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> otpFields = new();
    private float backspaceHoldTime = 0f;
    private const float holdThreshold = 0.2f;
    private bool backspaceHeld = false;


    void Start()
    {
        foreach (TMP_InputField field in otpFields)
        {
            field.characterLimit = 1;
            field.onValueChanged.AddListener(delegate { OnValueChanged(field); });
        }

        if (otpFields.Count > 0)
            otpFields[0].Select();
    }

    //void OnValueChanged(TMP_InputField currentField)
    //{
    //    if (currentField.text.Length == 1)
    //    {
    //        int tmp = otpFields.IndexOf(currentField);
    //        if (tmp < otpFields.Count - 1)
    //        {
    //            otpFields[tmp + 1].Select();
    //        }
    //    }
    //}

    private float mobileBackspaceTimer = 0f;
    private int backspaceCount = 0;
    private const float mobileBackspaceHoldThreshold = 0.3f;

    void OnValueChanged(TMP_InputField currentField)
    {
        int index = otpFields.IndexOf(currentField);

        // Detect mobile backspace hold (when input is backspace char)
        if (currentField.text == "\b")
        {
            currentField.text = "";

            mobileBackspaceTimer += Time.deltaTime;
            backspaceCount++;

            if (backspaceCount >= 3) // ~3 rapid backspaces == long press
            {
                OnContinuePressed();
                backspaceCount = 0;
                mobileBackspaceTimer = 0f;
            }
            else if (index > 0)
            {
                otpFields[index - 1].Select();
            }

            return;
        }

        backspaceCount = 0;
        mobileBackspaceTimer = 0f;

        // Move to next input
        if (currentField.text.Length == 1 && index < otpFields.Count - 1)
        {
            otpFields[index + 1].Select();
        }
    }

    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            backspaceHoldTime = 0f;
            backspaceHeld = true;

            GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
            if (selectedObj != null)
            {
                TMP_InputField currentField = selectedObj.GetComponent<TMP_InputField>();
                if (currentField != null && string.IsNullOrEmpty(currentField.text))
                {
                    int i = otpFields.IndexOf(currentField);
                    if (i > 0) otpFields[i - 1].Select();
                }
            }
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            backspaceHoldTime += Time.deltaTime;

            if ((backspaceHoldTime >= holdThreshold) && backspaceHeld)
            {
                OnContinuePressed();
                backspaceHeld = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            backspaceHeld = false;
            backspaceHoldTime = 0f;
        }

#elif UNITY_ANDROID || UNITY_IOS
        Debug.Log("-------");
        if (mobileBackspaceTimer > 0f)
        {
            mobileBackspaceTimer += Time.deltaTime;
            if (mobileBackspaceTimer > 0.5f)
            {
                mobileBackspaceTimer = 0f;
                backspaceCount = 0;
            }
        }
#endif
    }

    public void OnContinuePressed()
    {
        StartCoroutine(ClearOtpFieldsSequentially());
    }

    private IEnumerator ClearOtpFieldsSequentially()
    {
        for (int i = otpFields.Count - 1; i >= 0; i--)
        {
            otpFields[i].Select();
            otpFields[i].text = "";
            yield return new WaitForSeconds(0.1f);
        }
    }
}
