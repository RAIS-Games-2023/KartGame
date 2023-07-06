using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace KartGame.KartSystems 
{
    public class KartPlayerAnimator : MonoBehaviour
    {
        public Animator PlayerAnimator;
        public List<Animator> anims;
        public ArcadeKart Kart;

        public string SteeringParam = "Steering";
        public string GroundedParam = "Grounded";

        int m_SteerHash, m_GroundHash;

        float steeringSmoother;

        void Awake()
        {
            Assert.IsNotNull(Kart, "No ArcadeKart found!");
            Assert.IsNotNull(PlayerAnimator, "No PlayerAnimator found!");
            m_SteerHash  = Animator.StringToHash(SteeringParam);
            m_GroundHash = Animator.StringToHash(GroundedParam);
        }

        void Update()
        {
            steeringSmoother = Mathf.Lerp(steeringSmoother, Kart.Input.TurnInput, Time.deltaTime * 5f);

            foreach(Animator anim in anims)
            {
                anim.SetFloat(m_SteerHash, steeringSmoother);
                anim.SetBool(m_GroundHash, Kart.GroundPercent >= 0.5f);
            }

            // If more than 2 wheels are above the ground then we consider that the kart is airbourne.
            
        }
    }
}
