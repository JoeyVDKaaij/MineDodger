using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace JoUnityAddOn.SceneManagement
{
    public class SceneManager
    {
        public static void LoadScene(string sceneName)
        {
            UnitySceneManager.LoadScene(sceneName);
        }
        public static void LoadScene(int sceneBuildIndex)
        {
            UnitySceneManager.LoadScene(sceneBuildIndex);
        }
        
        public static void LoadNextScene()
        {
            int nextSceneBuildIndex = GetActiveScene().buildIndex + 1;
            
            if (nextSceneBuildIndex >= UnitySceneManager.sceneCountInBuildSettings) nextSceneBuildIndex = 0;
            
            UnitySceneManager.LoadScene(nextSceneBuildIndex);
        }
        
        public static void LoadPreviousScene()
        {
            int previousSceneBuildIndex = GetActiveScene().buildIndex - 1;
            
            if (previousSceneBuildIndex < 0) previousSceneBuildIndex = UnitySceneManager.sceneCountInBuildSettings-1;
            
            UnitySceneManager.LoadScene(previousSceneBuildIndex);
        }

        public static Scene GetActiveScene()
        {
            return UnitySceneManager.GetActiveScene();
        }

        public static int sceneCountInBuildSettings
        {
            get { return UnitySceneManager.sceneCountInBuildSettings; }
        }

        public static int sceneCount
        {
            get { return UnitySceneManager.sceneCount; }
        }
    }
}