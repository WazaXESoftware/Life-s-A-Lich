using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipEND : MonoBehaviour
{

    public Image skipBuffer;
    public Button skipButton;
    [Range(0f, 8f)] public float holdSkipTime = 3f;
    private float holdTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        holdTimer = 0f;
    }

    public void HoldSkip()
    {
        if (holdTimer > holdSkipTime)
        {
            //byt scen här
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            skipBuffer.fillAmount = holdTimer / holdSkipTime;
            holdTimer += Time.deltaTime;
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            FadeButtonColor(skipButton, skipButton.colors.pressedColor);
            skipButton.onClick.Invoke();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            FadeButtonColor(skipButton, skipButton.colors.normalColor);
            holdTimer = 0f;
            skipBuffer.fillAmount = 0f;
        }



    }

    void FadeButtonColor(Button button, Color color)
    {
        Graphic graphic = button.GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

}


