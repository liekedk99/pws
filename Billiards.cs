using System;
using BilliardFramework;
// Courtesy of Fons van der Plas, fonsvdplas@gmail.com
// Do not edit
namespace Billiards
{
	public partial class Billiards : GraphicsProgram
	{
		public override void Render()
		{
			foreach(Ball ball in balls)
			{
				DrawBall(ball.position, ball.n);
			}
		}

		public Billiards(string[] arguments) : base(arguments) { }

		[STAThread]
		static void Main(string[] args)
		{
			using(Billiards billiards = new Billiards(args))
			{
				billiards.Run();
			}
		}
	}
}