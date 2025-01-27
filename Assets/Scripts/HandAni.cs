using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAni : MonoBehaviour
{

    // Start is called before the first frame update
    //yes
    [SerializeField] private InputActionProperty pinch_animation;
    [SerializeField] private Animator hand_animator;
    [SerializeField] private InputActionProperty grab_animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handle_pinch_animation();
        handle_grab_animation();
    }
    private void handle_pinch_animation(){
        float trigger_value = pinch_animation.action.ReadValue<float>();
        hand_animator.SetFloat("Trigger", trigger_value);

    }
    private void handle_grab_animation(){
        float grab_value = grab_animation.action.ReadValue<float>();
        hand_animator.SetFloat("Grip", grab_value);
    }
}
