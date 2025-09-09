using Godot;
using System;
using LogicRiftCore;
using System.Collections.Generic;
public partial class PracticeGame : Node
{
    public Database database;
    public GameData gameData;
    public PracticeGameController practiceGameController;

    public override void _Ready()
    {
        database = Database.Load("D:/Users/Yanis/source/repos/LogicRift/LogicRiftGame/database.json");
        gameData = new GameData(database);
        practiceGameController = new PracticeGameController(gameData);
        HashSet<string> answer = practiceGameController.GenerateAnswers(4);

        var newScene = (PackedScene)GD.Load("uid://hmjy4fwde8e");
        Node instance = newScene.Instantiate();
        AddChild(instance);
    }

    public override void _Process(double delta)
    {
    }
}
