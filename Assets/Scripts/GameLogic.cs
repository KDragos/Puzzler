using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public GameObject player; 
	public GameObject startUI, restartUI; 
	public GameObject startPoint, playPoint, restartPoint;
	public GameObject gameBoard;
		
	public bool playerWon = false;

	// Use this for initialization
	void Start () {
		player.transform.position = startPoint.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && player.transform.position==playPoint.transform.position) {
			puzzleSuccess ();
		}
	}

	public void startPuzzle() { //Begin the puzzle sequence
		toggleUI(2);
		iTween.MoveTo (player, 
			iTween.Hash (
				"position", playPoint.transform.position, 
				"time", 3, 
				"easetype", "linear"
			)
		);
	}

	public void resetPuzzle() { //Reset the puzzle sequence
		player.transform.position = startPoint.transform.position;
		toggleUI (1);
	}


	public void puzzleSuccess() { //Do this when the player gets it right
		toggleUI(3);
		iTween.MoveTo (player, 
			iTween.Hash (
				"position", restartPoint.transform.position, 
				"time", 3, 
				"easetype", "linear"
			)
		);
	}

	public void quitPuzzle() {
		Application.Quit ();
		Debug.Log ("Quitting the game");
	}

	public void toggleUI() {
		startUI.SetActive (!startUI.activeSelf);
		restartUI.SetActive (!restartUI.activeSelf);
	}

	public void toggleUI(int spot){
		if (spot == 1) {
			startUI.SetActive (true);
			gameBoard.SetActive (false);
			restartUI.SetActive (false);
		} else if (spot == 2) {
			startUI.SetActive (false);
			gameBoard.SetActive (true);
			restartUI.SetActive (false);
		} else {
			startUI.SetActive (false);
			gameBoard.SetActive (false);
			restartUI.SetActive (true);
		}

	}
}
