using System;

namespace Tutorial
{
	public abstract class State
	{
		public Event enterEvent;
		public Event exitEvent;

		public abstract void Enter();
		public abstract void Exit();
		public abstract void Tick(float dt);
	}

	public class SimpleState : State
	{
		private Action OnEnter;
		private Action OnExit;

		public SimpleState(Action OnEnter, Action OnExit, Event enterEvent, Event exitEvent) {
			this.OnEnter = OnEnter;
			this.OnExit = OnExit;
			this.enterEvent = enterEvent;
			this.exitEvent = exitEvent;
		}

		public override void Enter() {
			OnEnter?.Invoke();
		}

		public override void Exit() {
			OnExit?.Invoke();
		}

		public override void Tick(float dt) { }
	}

	public class DialogState : State
	{
		private Action OnEnter;
		private Action OnExit;
		private DialogContent content;
		private DialogBox dialogBox;
		//private arrowPos;
		//private arrow;

		//or
		//Save content and arrow pos only
		//when enter state use it to setup dialog from scenario script

		public DialogState(DialogContent content, DialogBox dialogBox, Action OnEnter, Action OnExit, Event enterEvent, Event exitEvent) {
			this.content = content;
			this.dialogBox = dialogBox;
			this.OnEnter = OnEnter;
			this.OnExit = OnExit;
			this.enterEvent = enterEvent;
			this.exitEvent = exitEvent;
		}

		public override void Enter() {
			dialogBox.Show(content.Value);
			//if (haveArrow) {
			//	arrow.ShowAtpos(some params);
			//}
			OnEnter?.Invoke();
		}

		public override void Exit() {
			OnExit?.Invoke();
		}

		public override void Tick(float dt) { }
	}
}
