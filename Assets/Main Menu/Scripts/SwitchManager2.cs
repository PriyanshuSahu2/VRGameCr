using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Zone
{
    public class SwitchManager2 : MonoBehaviour
    {
        [Header("SWITCH")]
        public bool isOn;
        public bool isAxisOn;
        private Animator switchAnimator;
        public Animator anim;

        [Header("EVENT")]
        public UnityEvent onEvent;
        public UnityEvent offEvent;

        string onTransition = "Switch On";
        string offTransition = "Switch Off";

        void Start()
        {
            switchAnimator = gameObject.GetComponent<Animator>();
            switchAnimator.Play(offTransition);

            if (isOn == true)
            {
                a
                switchAnimator.Play(onTransition);
                onEvent.Invoke();
            }

            else
            {
                anim.Play(onTransition);
                switchAnimator.Play(offTransition);
                offEvent.Invoke();
            }
        }


        public void AnimateSwitch()
        {

            if (isOn == true)
            {
                
                switchAnimator.Play(offTransition);
                offEvent.Invoke();
                isOn = false;

            }

            else
            {
                
                switchAnimator.Play(onTransition);
                onEvent.Invoke();
                isOn = true;
            }
        }
        
    }
}