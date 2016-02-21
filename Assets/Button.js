#pragma strict

function Start_Game_Button () {
	Application.LoadLevel("NateScene");
}

function Main_Menu_Button () {
	Application.LoadLevel("Menu");
}

public function Exit_Game () {
	Application.Quit();
}