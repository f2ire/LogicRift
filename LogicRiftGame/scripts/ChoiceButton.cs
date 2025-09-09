using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ChoiceButton : Control
{
	public event Action<string> OnChoiceClicked;


    public override void _Ready()
	{
		foreach (Button button in GetNode("%GridContainer").GetChildren())
		{
			button.Pressed += () => OnChoiceClicked?.Invoke(button.Text);
		}
    }

    public void SetText(HashSet<string> moleculesNames) 
	{
		if (moleculesNames.Count != 4)
		{
			throw new ArgumentException("Molecules number must be 4.");
		}
		int i = 0;
		foreach(var moleculeName in moleculesNames)
		{
			Button button = GetNode("%GridContainer").GetChild<Button>(i);
			button.Text = moleculeName;
			i++;
		}
	}



}
