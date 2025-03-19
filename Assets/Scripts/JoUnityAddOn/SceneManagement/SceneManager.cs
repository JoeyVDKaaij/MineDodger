using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace JoUnityAddOn.SceneManagement
{
    public class SceneManager : UnitySceneManager
    {
        /// <summary>
        /// Loads the next scene in the build settings.
        /// </summary>
        public static void LoadNextScene()
        {
            int nextSceneBuildIndex = GetActiveScene().buildIndex + 1;
            
            if (nextSceneBuildIndex >= sceneCountInBuildSettings) nextSceneBuildIndex = 0;
            
            LoadScene(nextSceneBuildIndex);
        }
        
        /// <summary>
        /// Loads the previous scene in the build settings.
        /// </summary>
        public static void LoadPreviousScene()
        {
            int previousSceneBuildIndex = GetActiveScene().buildIndex - 1;
            
            if (previousSceneBuildIndex < 0) previousSceneBuildIndex = sceneCountInBuildSettings-1;
            
            LoadScene(previousSceneBuildIndex);
        }

        /// <summary>
        /// Reload the current active Scene.
        /// </summary>
        public static void ReloadScene()
        {
            LoadScene(GetActiveScene().buildIndex);
        }
    }
}