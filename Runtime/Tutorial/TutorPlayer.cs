using System;
using System.Collections.Generic;

namespace Tutorial
{
	public class TutorPlayer
	{
		public void FeedEvent(int ev, int arg = 0) { // Process
			if (current == null)
				return;

			if (!insideState) {
				if (current.enterEvent.Succeed(ev, arg)) {
					insideState = true;
					current.Enter();
				}
			}
			else {
				if (current.exitEvent.Succeed(ev, arg)) {
					insideState = false;
					current.Exit();

					SetNextState();
					if (current != null && current.enterEvent.type == 0) {
						insideState = true;
						current.Enter();
					}
				}
			}
		}

		public void AddState(State state) {
			states.Add(state);
		}

		public void AddState(Action OnEnter, Action OnExit, int exitEvent) {
			var newState = new SimpleState(OnEnter, OnExit, new Event(0), new Event(exitEvent));
			states.Add(newState);
		}

		public void AddState(Action OnEnter, Action OnExit, Event enterEvent, Event exitEvent) {
			var newState = new SimpleState(OnEnter, OnExit, enterEvent, exitEvent);
			states.Add(newState);
		}

		public void AddState(Action OnEnter, Action OnExit, int enterEvent, int exitEvent) {
			var newState = new SimpleState(OnEnter, OnExit, new Event(enterEvent), new Event(exitEvent));
			states.Add(newState);
		}

		public void Play() {
			ip = 0;
			current = states[ip];
			current.Enter();
			insideState = true;
		}

		public void Tick(float dt) {
			if (insideState) {
				current.Tick(dt);
			}
		}

		private void SetNextState() {
			ip++;
			current = NoStatesLeft ? null : states[ip];
		}

		private bool NoStatesLeft => ip >= states.Count;

		private List<State> states = new List<State>();
		private State current;
		private int ip;
		private bool insideState;
	}
}
