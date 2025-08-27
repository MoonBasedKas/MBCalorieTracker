using Godot;
using System;

public partial class Home : Node2D
{

	TextEdit input = null;
	RichTextLabel output = null;
	public override void _Ready()
	{
		this.input = (TextEdit)GetNode("Input");
		this.output = (RichTextLabel)GetNode("Output");
	}

	public void _on_button_pressed()
	{
		this.output.Text = this.input.Text;
	}

}
