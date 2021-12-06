using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Player Manager")]
    //[SerializeField] private Animator animator;
    private PlayerController controller;

    private void Awake()
    {
        controller = gameObject.GetComponent<PlayerController>();
    }
}
