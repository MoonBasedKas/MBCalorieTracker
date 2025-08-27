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
    }

    public void _on_button_pressed()
    {
        output.Text = "Calories: " + input.Text;
    }

}
