using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region instance
    
    public static GameManager instance { get; private set; }

    private void InstantiateInstance()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        InstantiateInstance();
    }

    private void OnEnable()
    {
        InstantiateInstance();
    }

    // private void OnDisable()
    // {
    //     instance = null;
    // }
    //
    // private void OnDestroy()
    // {
    //     instance = null;
    // }
    
    #endregion
    
    public GameplayTypes gameplayType = GameplayTypes.Moving;
}
