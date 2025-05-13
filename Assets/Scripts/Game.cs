using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Start()
    {
        _animator.SetTrigger("Dance");
    }
}
