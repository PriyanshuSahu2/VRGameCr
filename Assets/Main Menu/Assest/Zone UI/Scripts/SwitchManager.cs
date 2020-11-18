using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Zone
{
    public class SwitchManager : MonoBehaviour
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
            

            if (isOn == true)
            {
                switchAnimator.Play(onTransition);
                
                onEvent.Invoke();
            }

            else
            {
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
        private void Update()
        {
            
        }

    }
}