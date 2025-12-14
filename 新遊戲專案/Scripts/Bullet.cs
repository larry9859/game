using Godot;
using System;

public partial class Bullet : Sprite2D
{
	public float speed = 1000;
	public float timer = 2;
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
		float movement = speed * (float)delta;
		this.Position += new Vector2(movement, 0);
		timer -= (float)delta;
		if (timer <= 0){
			this.QueueFree();
		}
	}
}
