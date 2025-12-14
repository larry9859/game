using Godot;
using System;

public partial class Player : Sprite2D

{
	private float speed = 500;
	public PackedScene bulletPrefab;
	public override void _Ready()
	{
		bulletPrefab = GD.Load<PackedScene>("res://Prefabs/Bullet.tscn");
	}

	public override void _Process(double delta)
	{
		float movement = speed * (float)delta;
		if (Input.IsKeyPressed(Key.Left)){
			this.Position += new Vector2(-movement, 0);
		}
		if (Input.IsKeyPressed(Key.Right)){
			this.Position += new Vector2(movement, 0);
		}
		if (Input.IsKeyPressed(Key.Up)){
			this.Position += new Vector2(0, -movement);
		}
		if (Input.IsKeyPressed(Key.Down)){
			this.Position += new Vector2(0, movement);
		}

		if (Input.IsActionJustPressed("shoot",true)){
			GD.Print("Shoot!!!");
			var Bullet = this.bulletPrefab.Instantiate<Bullet>() as Node2D;
			Bullet.Position = this.Position;
			this.GetTree().Root.AddChild(Bullet);
		}
	}	
}
