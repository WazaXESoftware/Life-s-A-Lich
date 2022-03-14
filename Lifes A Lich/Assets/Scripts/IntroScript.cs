using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public StudioEventEmitter intromusic;
    public Animator sceneAnimator;
    public Animator fadeAnimator;
    [SerializeField] public GameObject[] scenes;
    public int sceneIndex = 1;

    [Range(0f, 1f)] public float fadeOutTime = 0.3f;
    [Range(0f, 1f)] public float fadeInTime = 0.3f;

    public Button continueButton;
    private Image continueImage;
    public TextMeshProUGUI continueText;
    [Range(0f, 20f)]public float continueAppearInSeconds = 5f;
    [Range(0.1f, 5f)] public float continueFadeInTime = 1f;
    private float continueAppearTimer = 0f;
    public Image skipBuffer;
    public Button skipButton;
    [Range(0f, 8f)]public float holdSkipTime = 3f;
    private float holdTimer = 0f;

    private bool inTransition = false;

    void Start()
    {
        if (continueButton != null) continueImage = continueButton.GetComponent<Image>();
        Cursor.lockState = CursorLockMode.Locked;
        sceneIndex = 1;
        continueAppearTimer = 0f;
        holdTimer = 0f;

        DisplayScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && continueButton.gameObject.activeSelf)
        {
            FadeButtonColor(continueButton, continueButton.colors.pressedColor);
            continueButton.onClick.Invoke();
        }
        else if (Input.GetButtonUp("Jump") && continueButton.gameObject.activeSelf)
        {
            FadeButtonColor(continueButton, continueButton.colors.normalColor);
        }

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
        if (continueAppearTimer > continueAppearInSeconds)
        {
            if (!continueButton.gameObject.activeSelf) continueButton.gameObject.SetActive(true);
            float fadeRatio = Mathf.Clamp(continueAppearTimer - continueAppearInSeconds, 0f, continueFadeInTime) / continueFadeInTime;
            continueImage.color = new Color(1f, 1f, 1f, (fadeRatio));
            continueText.color = new Color(1f, 1f, 1f, (fadeRatio));
        }
        else if (continueButton.gameObject.activeSelf)
        {
            continueButton.gameObject.SetActive(false);
        }
        continueAppearTimer += Time.deltaTime;
    }

    void FadeButtonColor(Button button, Color color)
    {
        Graphic graphic = button.GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }

    public void NextScene()
    {
        if (!inTransition) StartCoroutine(Transition());
    }

    public void HoldSkip()
    {
        if (holdTimer > holdSkipTime)
        {
            sceneIndex = scenes.Length - 1;
            StartCoroutine(Transition());
        }
        else
        {
            skipBuffer.fillAmount = holdTimer / holdSkipTime;
            holdTimer += Time.deltaTime;
        }
    }

    public void DisplayScene(int index)
    {
        sceneIndex = index;
        scenes[index - 1].SetActive(true);
        sceneAnimator.SetTrigger("Scene" + index);
        intromusic.SetParameter("Next Slider", sceneIndex - 1);
        continueAppearTimer = 0f;
        //IntroSoundFXManager.Play(index);
    }

    public void HideScene(int index)
    {
        scenes[index - 1].SetActive(false);
    }

    void ExitIntro()
    {
        SceneManager.LoadScene("MainTutorial");
        intromusic.Stop();
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator Transition()
    {
        inTransition = true;
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeInTime);
        HideScene(sceneIndex);
        sceneIndex++;
        if (sceneIndex > scenes.Length)
        {
            ExitIntro();
        }
        else
        {
            DisplayScene(sceneIndex);
        }
        fadeAnimator.SetTrigger("FadeIn");
        inTransition = false;
    }
}
