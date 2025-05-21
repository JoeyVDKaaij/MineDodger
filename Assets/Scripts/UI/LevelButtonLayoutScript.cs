using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class LevelButtonLayoutScript : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = transform.childCount - 1; i > 0; i--)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (OptionsManager.instance != null)
        {
            if (OptionsManager.instance.levelBeaten > 0)
            {
                for (int i = 1; i <= OptionsManager.instance.levelBeaten; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
