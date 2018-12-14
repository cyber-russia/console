using System;


namespace Labirinth
{
	public class GameObject
	{

		protected char Symbol = ' ';
		protected ConsoleColor bColor = GameOptions.DefaultBackColor;
		protected ConsoleColor fColor = GameOptions.DefaultFrontColor;


		protected bool canStep = false;


		public virtual bool StepOn ()
		{
			return canStep;
		}


		public void Print(Vector2 pos)
		{
			//prepare colors
			Console.ForegroundColor = fColor;
			Console.BackgroundColor = bColor;

			//set cursor position
			Console.SetCursorPosition(pos.col, pos.row);

			//finally print symbol
			Console.Write(Symbol);
		}

	}


	public class Wall : GameObject
	{
		public Wall()
		{
			fColor = ConsoleColor.DarkRed;
			Symbol = '▓';
		}
	}


	public class Floor : GameObject
	{
		public Floor()
		{
			fColor = ConsoleColor.Gray;
			Symbol = '░';

			canStep = true;
		}
	}


	public class Finish : GameObject
	{
		public Finish()
		{
			fColor = ConsoleColor.Red;
			Symbol = '▒';
		}
	}


	public class Item : GameObject
	{
		public virtual void Consume(ref Player p) {}
	}


	public class HealthItem : Item
	{
		public override void Consume(ref Player p) 
		{
			p.Health = Player.MaxHealth;
		}
	}


	public class ArmorItem : Item
	{
		protected int ArmorLvl = 1;


		public override void Consume(ref Player p)
		{
			p.ArmorLvl = ArmorLvl;
		}
	}


	public class WeaponItem : Item
	{
		protected int WeaponLvl = 1;

		public override void Consume(ref Player p)
		{
			p.WeaponLvl = WeaponLvl;
		}
	}


	public class Player : GameObject 
	{
	    static Player _instance;

		public static Player Instance {
			get {
				if (_instance == null)
					_instance = new Player();

				return _instance;
			}
		}


		//health
		int _health = 100;

		public const int MaxHealth = 100;

		public int Health 
		{
			get {
				return _health;
			}

			set {
				_health = Math.Min(value, Player.MaxHealth);
			}
			
		}


		//armour
		int _armorLvl = 1;

		public int ArmorLvl {
			get {
				return _armorLvl;
			}

			set {
				_armorLvl = Math.Max(_armorLvl, value);
			}
		}


		//weapon
		int _weaponLvl = 1;

		public int WeaponLvl
		{
			get
			{
				return _weaponLvl;
			}

			set
			{
				_weaponLvl = Math.Max(_weaponLvl, value);
			}
		}
	}
}
