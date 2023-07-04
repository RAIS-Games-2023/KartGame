using UnityEngine;
using UnityEngine.InputSystem;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        /*       public string TurnInputName = "Horizontal";
               public string AccelerateButtonName = "Accelerate";
               public string BrakeButtonName = "Brake";*/

        public PlayerInput input;

        bool accelerate, brake;
        float turn_input;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
        }

        public override InputData GenerateInput() {

            accelerate = input.actions.FindAction("Accelerate").IsPressed();
            brake = input.actions.FindAction("Brake").IsPressed();
            turn_input = input.actions.FindAction ("TurnInput").ReadValue<Vector2>().x;

            return new InputData
            {
                Accelerate = accelerate,
                Brake = brake,
                TurnInput = turn_input
            };
        }
    }
}
