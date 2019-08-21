///////////////////////////////////////////
/////////Character Controller MVP ©////////
///////////////////////////////////////////
///User: Guts
///Date: 2019.8.21
///File: CharacterControllerModel.cs
///////////////////////////////////////////


using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.CharacterController
{
    [CreateAssetMenu(fileName = "New CharacterControllerData", menuName = "CharacterController Data", order = 51)]

    public class CharacterControllerModel : ScriptableObject
    {
        [SerializeField]
        private float moveSpeed;
        public float MoveSpeed => moveSpeed;
        [SerializeField]
        private float jumpHeight;
        public float JumpHeight => jumpHeight;

        public CharacterControllerModel(float moveSpeed, float jumpHeight)
        {

            this.moveSpeed = moveSpeed;
            this.jumpHeight = jumpHeight;

        }
    }
}