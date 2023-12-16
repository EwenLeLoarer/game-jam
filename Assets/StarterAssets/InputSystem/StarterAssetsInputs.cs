using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		[SerializeField] ThirdPersonController _player;
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool jumpHasBeenRelease;
		public bool sprint;
		public bool attack;
		public bool option;
		public int nbrJump;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			if(_player.Grounded)
			{
				nbrJump = 0;
			}
			JumpInput(value.isPressed);
			if(nbrJump ==  0 || nbrJump == 1)
			{
                _player.Jump();
				
				nbrJump++;
            }
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif
		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}

		public void OnOption(InputValue value)
		{
			OptionInput(value.isPressed);
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
		}

		public void OptionInput(bool newOptionState)
		{
			option = newOptionState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}