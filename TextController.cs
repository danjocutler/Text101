using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {beach_start, hand_up, speak, beach_children, street};
	private States myState;
	
	private string state_machete_death = "He strides up to you and takes you by the arm, " +
			"pulling you upright. Before you can utter any thanks, you see a glint as he pulls " +
			"something shiny out from the back of his trousers.\nThe machete is so sharp, it slices " +
			"your arm clean off! He utters something to you in a language you can't make out before " +
			"taking another swing with the massive blade. This time, the machete lodges deep in your neck. " +
			"You fall to your knees, your one remaining hand clutching at your neck. Blood flows from the " +
			"wound and over your fingers. Before you black out, your final thought is 'How the hell did I " +
			"end up here?'\n\nYou died!\n\nPress 'SPACE' to start again.";

	// Use this for initialization
	void Start () {
		myState = States.beach_start;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.beach_start) {
			state_beach();
		} else if (myState == States.hand_up) {
			state_hand_up();
		} else if (myState == States.speak) {
			state_speak();
		}
	}
	
	void state_beach () {
		text.text = "You wake up to the sea licking at your bare toes. You squint in " +
					"the bright, morning sunlight. How you got here is anyone's guess. " +
					"You hear children's laughter in the distance, further down the " +
					"shoreline. Behind you, the sound of traffic and a seaside town. " +
					"You sit up and rub your eyes as the world comes into focus. " +
					"A man approaches. It's difficult to make out his face in the bright light " +
					"of day, but as he gets closer, his body blocks the sun and you see him more " +
					"clearly. He does NOT look happy. He doesn't look familiar either.\n\n" +
					"Press 'H' to raise your Hand for him to help you up.\n" +
					"Press 'S' to Speak to the man.\n" +
					"Press 'C' to get up and run towards the sound of the Children.\n" +
					"Press 'T' to get up and run towards the sound of the Traffic.";
					
		if (Input.GetKeyDown(KeyCode.H)) {
			myState = States.hand_up;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.speak;
		}
	}
	
	void state_hand_up () {
		text.text = "Unaware of who the man is, or why he looks so angry, you raise your hand " +
					"in the hope that he'll help you up. " + state_machete_death; 
		restart();
	}
	
	void state_speak () {
		text.text = "\"Excuse me, my friend. Could you help me up. I have no ide....\".\n" + state_machete_death; 
		restart();
	}
		
	void restart () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.beach_start;
		}
	}
}
