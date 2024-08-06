using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplayGUI;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isViable;

    private void Start()
    {
        PlayerInput input = FindObjectOfType<PlayerInput>();
        input.actions["Menu"].started += OnMenuPerformed;
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
            gameplayGUI.SetActive(true);
            Time.timeScale = 1;
        }
        else if (!isDead && isViable)
        {
            pauseMenu.SetActive(true);
            foreach (Transform child in gameplayGUI.transform)
            {
                if (child.name != "Ammunition")
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    foreach (Transform grandchild in child.transform)
                    {
                        if (grandchild.name != "AmmoBarCounter")
                        {
                            grandchild.gameObject.SetActive(false);
                        }
                        else
                        {
                            Transform tmp = child.Find("AmmoBarCounter");
                            foreach (Transform greatgrandchild in tmp)
                            {
                                greatgrandchild.gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }

            //gameplayGUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void SetIsDead()
    {
        isDead = true;
    }

    public void SetIsViable()
    {
        isViable = true;
    }

    public void SetIsUnviable()
    {
        isViable = false;
    }
}