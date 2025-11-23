using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToLevel : MonoBehaviour
{
    public string Level;
    [HideInInspector] public GameObject LoadUI;
    private Button LevelButton;

    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(Loadscene);
    }

    void OnDestroy()
    {
        LevelButton.onClick.RemoveListener(Loadscene);
    }

    void Loadscene()
    {
        Instantiate(LoadUI);
        SceneManager.LoadScene(Level);
    }
}
