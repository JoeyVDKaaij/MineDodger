using System;
using JoUnityAddOn.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathAnimationScript : MonoBehaviour
{
    public static DeathAnimationScript instance { get; private set; }

    private Animator _animator;

    private bool _deadAnimationPlaying = false;

    [Header("Debug Settings")]
    [SerializeField, Tooltip("Start the Death Gameplay type. Use this to check the death state of the game.")]
    private bool startDeathGameplayType = false;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_deadAnimationPlaying && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Death Animation"))
        {
            SceneManager.ReloadScene();
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Death Animation"))
        {
            _deadAnimationPlaying = true;
        }
        
        if (GameManager.instance != null)
        {
            if (startDeathGameplayType)
                GameManager.instance.gameplayType = GameplayTypes.Death;
            else
                GameManager.instance.gameplayType = GameplayTypes.Moving;
        }
    }

    public void PlayDeathAnimation(Vector3 pos)
    {
        transform.position = pos;
        
        _animator.SetTrigger("Death");
    }
}
