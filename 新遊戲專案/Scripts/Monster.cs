using Godot;
using System;

public partial class Monster : Sprite2D
{
	public float hp = 10;
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area2D");
		area.AreaEntered += onCollisionEnter;
	}

	public void onCollisionEnter(Area2D area){
		GD.Print("Collision");
		var hitNode = area.GetParent();
		if (hitNode?.Name?.ToString().Contains("Bullet") == true){
			hitNode.QueueFree();
			hp -= 1;
			if (hp <= 0)
				QueueFree();
		}
	}
	public override void _Process(double delta)
	{
		
	}
}
