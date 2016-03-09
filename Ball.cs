using OpenTK;

namespace Billiards
{
	public class Ball
	{
		public Vector2 position;
		public Vector2 velocity;
		public int n;
	    public float mass;

		public Ball(Vector2 position, Vector2 velocity, int n, float mass)
		{
			this.position = position;
			this.velocity = velocity;
			this.n = n;
			this.mass = mass; 
		}
		// Dit is de bal constructor. Hierin staan op dit moment vier parameters: de positie, de velocity,
		// de integer voor de kleur en de massa.

	}
}