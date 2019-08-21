///////////////////////////////////////////
/////////Character Controller MVP ©////////
///////////////////////////////////////////
///User: Guts
///Date: 2019.8.21
///File: CharacterControllerPresenter.cs
///////////////////////////////////////////


using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.CharacterController
{
    [System.Serializable]
    public class CharacterControllerPresenter
    {
        [SerializeField]
        private CharacterControllerModel model;
        private ICharacterControllerView view;
        private float speedMultiplier = 1;

        public CharacterControllerPresenter(ICharacterControllerView view)
        {
            this.view = view;
        }

        public CharacterControllerPresenter(ICharacterControllerView view, float moveSpeed, float jumpHeight)
        {
            this.view = view;
            model = new CharacterControllerModel(moveSpeed, jumpHeight);
        }

        public void OnMove(object sender, CharacterArgs e)
        {
            view.GetRigidBody().AddForce(e.moveDirection * model.MoveSpeed * speedMultiplier);
        }

        public void GetMoveDirection(object sender, CharacterArgs e)
        {
            e.moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }

        public void OnJump(object sender, CharacterArgs e)
        {
            if (e.jumpEnd)
            {
                view.GetRigidBody().AddForce(new Vector2(0f, model.JumpHeight), ForceMode2D.Impulse);
            }
        }

        public void OnJumpEnd(object sender, CharacterArgs e)
        {
            e.jumpEnd = true;
        }

        public void OnJumpStart(object sender, CharacterArgs e)
        {
            e.jumpEnd = false;
        }

        public void OnSprintStart(object sender, CharacterArgs e)
        {
            speedMultiplier = 4;

        }

        public void OnSprintEnd(object sender, CharacterArgs e)
        {
            speedMultiplier = 1;
        }
    }
}