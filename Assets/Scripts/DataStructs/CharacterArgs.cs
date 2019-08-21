///////////////////////////////////////////
/////////Character Controller MVP ©////////
///////////////////////////////////////////
///User: Guts
///Date: 2019.8.21
///File: CharacterArgs.cs
///////////////////////////////////////////


using UnityEngine;
using UnityEditor;


namespace Assets.Scripts.CharacterController
{
    public class CharacterArgs : System.EventArgs
    {
        public Vector2 moveDirection;
        public bool jumpEnd;
        public bool isSprints;
    }
}