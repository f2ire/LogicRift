using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button exitButton = GetNode<Button>("%Button_Exit");
		exitButton.Pressed += Quit;

		Button PracticeButton = GetNode<Button>("%Button_PracticeGame");
		PracticeButton.Pressed += LaunchPracticeGame;

		Button ChallengeGame = GetNode<Button>("%Button_ChallengeGame");
		ChallengeGame.Pressed += LaunchChallengeGame;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void LaunchPracticeGame()
	{
		GetTree().ChangeSceneToFile("uid://dmq8m6oem20f0");

    }


    public void LaunchChallengeGame()
    {
        GetTree().ChangeSceneToFile("uid://cbg8tmmjtjpyc");
    }

    public void Quit()
    {
	GetTree().Quit();
    }
}
