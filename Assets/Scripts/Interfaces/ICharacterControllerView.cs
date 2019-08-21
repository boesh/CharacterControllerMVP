///////////////////////////////////////////
/////////Character Controller MVP ©////////
///////////////////////////////////////////
///User: Guts
///Date: 2019.8.21
///File: ICharacterControllerView.cs
///////////////////////////////////////////


using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.CharacterController
{
    public interface ICharacterControllerView
    {
        event System.EventHandler<CharacterArgs> Move;

        event System.EventHandler<CharacterArgs> MoveDirection;

        event System.EventHandler<CharacterArgs> Jump;

        event System.EventHandler<CharacterArgs> JumpEnd;

        event System.EventHandler<CharacterArgs> SprintStart;

        event System.EventHandler<CharacterArgs> SprintEnd;


        void MoveView(object sender, System.EventArgs e);
        void JumpView(object sender, System.EventArgs e);

        void SprintView(object sender, System.EventArgs e);

        ref Rigidbody2D GetRigidBody();

    }
}