using Godot;
using System;

public partial class Home : Node2D
{

    TextEdit input = null;
    RichTextLabel output = null;
    public override void _Ready()
    {
        input = (TextEdit)GetNode("Input");
        output = (RichTextLabel)GetNode("Output");
        DateTime dt = DateTime.Now.Date;
        GameData.LoadGame();
        output.Text = "Calories: " + GameData.GetCaloriesOn(dt.ToString("yyyy/MM/dd")).ToString();
    }

    public void _on_button_pressed()
    {
        // output.Text = "Calories: " + input.Text;
        int value;
        DateTime dt = DateTime.Now.Date;
        string d = dt.ToString("yyyy/MM/dd");
        if (!int.TryParse(input.Text, out value)) return;

        GameData.InsertData(d, value);
        output.Text = "Calories: " + GameData.GetCaloriesOn(d).ToString();
    }

}
