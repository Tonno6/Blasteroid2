using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplayGUI;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isViable;
    [SerializeField] private List<Image> imageList;
    [SerializeField] private List<TMP_Text> textList;
    [SerializeField] private ImageTextActivator imageTextActivator;
    private PlayerInput input;

    private void Start()
    {
        input = FindObjectOfType<PlayerInput>();
        input.actions["Menu"].started += OnMenuPerformed;
        imageTextActivator.ImageList = imageList;
        imageTextActivator.TextList = textList;
        pauseMenu.SetActive(false);
    }

    private void OnMenuPerformed(InputAction.CallbackContext context)
    {
        ChangeStatePauseMenu();
    }

    public void ChangeStatePauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            imageTextActivator.ActivateList(true);
            Time.timeScale = 1;
        }
        else if (!isDead && isViable)
        {
            pauseMenu.SetActive(true);
            imageTextActivator.ActivateList(false);
            Time.timeScale = 0;
        }
    }

    public void SetIsDead()
    {
        isDead = true;
        input.actions["Menu"].started -= OnMenuPerformed;
    }

    public void SetIsViable(bool tmp)
    {
        isViable = tmp;
    }
}