///////////////////////////////////////////
/////////Character Controller MVP ©////////
///////////////////////////////////////////
///User: Guts
///Date: 2019.8.21
///File: MonoCharacterController.cs
///////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Assets.Scripts.CharacterController
{
    public class MonoCharacterController : MonoBehaviour, ICharacterControllerView
    {
        CharacterArgs args;

        Rigidbody2D rigidBody;

        [SerializeField]
        CharacterControllerPresenter presenter;

        public event System.EventHandler<CharacterArgs> Move;
        public event System.EventHandler<CharacterArgs> MoveDirection;
        public event System.EventHandler<CharacterArgs> Jump;
        public event System.EventHandler<CharacterArgs> JumpEnd;
        public event System.EventHandler<CharacterArgs> SprintStart;
        public event System.EventHandler<CharacterArgs> SprintEnd;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                JumpEnd(this, args);
            }
        }

        private void Awake()
        {
            args = new CharacterArgs();
            presenter = new CharacterControllerPresenter(this, 10f, 10f);
            Move += presenter.OnMove;
            MoveDirection += presenter.GetMoveDirection;
            Jump += presenter.OnJump;
            Jump += presenter.OnJumpStart;
            JumpEnd += presenter.OnJumpEnd;
            SprintStart += presenter.OnSprintStart;
            SprintEnd += presenter.OnSprintEnd;
        }

        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            MoveDirection(this, args);
        }

        private void FixedUpdate()
        {
            Move(this, args);

            if (Input.GetKey(KeyCode.Space))
            {
                Jump(this, args);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SprintStart(this, args);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                SprintEnd(this, args);
            }
        }

        public void MoveView(object sender, System.EventArgs e) { }

        public void JumpView(object sender, System.EventArgs e) { }

        public void SprintView(object sender, System.EventArgs e) { }

        public ref Rigidbody2D GetRigidBody()
        {
            return ref rigidBody;
        }
    }
}