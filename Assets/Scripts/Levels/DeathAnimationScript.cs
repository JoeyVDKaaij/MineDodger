using System;
using JoUnityAddOn.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathAnimationScript : MonoBehaviour
{
    public static DeathAnimationScript instance { get; private set; }

    private Animator _animator;

    private bool _deadAnimationPlaying = false;
    
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
    }

    public void PlayDeathAnimation(Vector3 pos)
    {
        transform.position = pos;
        
        _animator.SetTrigger("Death");
    }
}
