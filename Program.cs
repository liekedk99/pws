using System;
using System.Collections.Generic;
using System.Drawing;
using BilliardFramework;
using OpenTK;

namespace Billiards
{
	public partial class Billiards : GraphicsProgram
	{
		public List<Ball> balls = new List<Ball>();

		public override void InitGame()
		{
			// Hier begint het programma: alle code in deze functie wordt 1 keer opgeroepen als het programma start.

			// Handige dingen:
			RenderWindow.Instance.ClientSize = new Size(508, 254); // Verandert de grootte van het spel
																   //RenderWindow.Instance.WindowBorder = WindowBorder.Fixed; // Zorgt ervoor dat het spel niet van grootte veranderd kan worden
			Console.Write("Hello "); // Stuurt tekst naar de Console
			Console.WriteLine("world!"); // " en begint een nieuwe regel
			Console.WriteLine(ballRadius); // ballRadius is de straal van een bal (deze kan je ook aanpassen)

			// Voorbeeld: een witte en een zwarte bal worden aangemaakt.
			// De volgorde is belangrijk: De witte bal is nu balls[0] en de zwarte bal is balls[1].
			/*
			balls.Add(new Ball(new Vector2(100f, 150f), new Vector2(100f, 200f), 0, 4));
			balls.Add(new Ball(new Vector2(200f, 130f), new Vector2(-100f, -200f), 8, 4));
			balls.Add(new Ball(new Vector2(300f, 249f), new Vector2(-100f, 200f), 2, 4));
			balls.Add(new Ball(new Vector2(400f, 160f), new Vector2(200f, -100f), 3, 4));
			balls.Add(new Ball(new Vector2(500f, 120f), new Vector2(200f, 100f), 4, 4));
			balls.Add(new Ball(new Vector2(250f, 90f), new Vector2(-200f, 100f), 5, 4));
			*/
			/*
			balls.Add(new Ball(new Vector2(100f, 150f), new Vector2(350f, 400f), 0, 20));
			balls.Add(new Ball(new Vector2(200f, 130f), new Vector2(-45f, -40f), 8, 6));
			balls.Add(new Ball(new Vector2(300f, 249f), new Vector2(-35f, 30f), 2, 6));
			balls.Add(new Ball(new Vector2(400f, 160f), new Vector2(25f, -45f), 3, 6));
			balls.Add(new Ball(new Vector2(500f, 120f), new Vector2(30f, 35f), 4, 6));
			balls.Add(new Ball(new Vector2(250f, 90f), new Vector2(45f, 40f), 5, 6));
			*/

			
			balls.Add(new Ball(new Vector2(100f, 150f), new Vector2(64f, 71f), 0, 20));
			balls.Add(new Ball(new Vector2(200f, 130f), new Vector2(-55f, -65f), 8, 4));
			balls.Add(new Ball(new Vector2(300f, 249f), new Vector2(-65f, 54f), 2, 6));
			balls.Add(new Ball(new Vector2(400f, 160f), new Vector2(55f, -65f), 3, 8));
			balls.Add(new Ball(new Vector2(500f, 120f), new Vector2(70f, 55f), 4, 10));
			balls.Add(new Ball(new Vector2(250f, 90f), new Vector2(55f, 60f), 5, 12));
			

			// Syntax: balls.Add(new Ball( *positievector*, *balnummer* ));
			// Syntax: *positievector* = new Vector2( *x-coord*, *y-coord* ); (x,y zijn kommagetallen)
			// Het balnummer is het getal dat op een biljartbal staat, 0 is de witte bal.
		}

		public override void Update(float timeSinceLastUpdate)
		{
			// Deze code wordt bij elke update opgeroepen. Op een snelle computer gebeurt dit elke 1/1000 seconde, op
			// een langzame computer elke 1/60 seconde. Deze tijd is opgenomen met timeSinceLastUpdate.

			// Voorbeeld 1: alle ballen bewegen met 10 px/s naar rechts.

			// Met de if statements hierboven wordt gekeken of een bal de zijkant raakt. Als dit het geval is, 
			// dan wordt de velocity naar deze zijkant omgedraait. De bal kaatst dan weg.

			foreach (var ball in balls)
			{
				//ball.position.X += 50f * timeSinceLastUpdate; // ds = v * dt
				ball.position += ball.velocity * timeSinceLastUpdate;

				if (ball.position.X <= ballRadius && ball.velocity.X < 0)
				{
					//Console.WriteLine("Out of left bound");
					ball.velocity.X *= -1;
				}

				if (ball.position.Y <= ballRadius && ball.velocity.Y < 0)
				{
					//Console.WriteLine("Out of upper bound");
					ball.velocity.Y *= -1;
				}

				if (ball.position.X >= RenderWindow.Instance.Width - ballRadius && ball.velocity.X > 0)
				{
					//Console.WriteLine("Out of right bound");
					ball.velocity.X *= -1;
				}

				if (ball.position.Y >= RenderWindow.Instance.Height - ballRadius && ball.velocity.Y > 0)
				{
					//Console.WriteLine("Out of bottom bound");
					ball.velocity.Y *= -1;
				}
			}

			// Deze for loops kijken of de ballen botsen en als dit zo is, dan gaat deze ze oplossen.

			for (int i = 0; i < balls.Count; i++)
			{
				for (int j = i + 1; j < balls.Count; j++)
				{
					if ((balls[i].position - balls[j].position).Length <= 2 * ballRadius)
					{
						solveCollision(i, j);
						/*
						// d is de richting van de botsing.
						Vector2 d = balls[i].position - balls[j].position;
						// met normalize wordt de lengte van d 1 gemaakt.
						d.Normalize(); 
						Vector2 ai = balls[i].velocity;
						// met de dot wordt de lengte van c berekend doordat het: lengte(d) * lengte(a) 
						// * cos(hoek a en d) doet.
						Vector2 ci = d * Vector2.Dot(ai,d);
						Vector2 bi = ai - ci;
						d *= -1f;
						Vector2 aj = balls[j].velocity;
						Vector2 cj = d * Vector2.Dot(aj,d);
						Vector2 bj = aj - cj;

						// ci en cj worden omgewisseld.
						Vector2 ck = cj;
						cj = ci;
						ci = ck;

						// Hiermee worden de a vectoren berekend.
						ai = bi + ci;
						aj = bj + cj;

						// Hier worden de vectoren weer gekoppeld aan de ballen.
						if (Vector2.Dot(balls[i].velocity - balls[j].velocity, d) >= 0)
						{
							balls[i].velocity = ai;
							balls[j].velocity = aj;
						*/
		}
	}
			}
		}
		public void solveCollision(int i, int j)
		{
			// Door n.Normalize te doen, wordt de n vector een unit vector net zoals op het uitgewerkte blad. 
			Vector2 n = balls[i].position - balls[j].position;
			n.Normalize();

			// Dit controleert of de botsing al heeft plaatsgevonden, zodat ze niet aan elkaar blijven hangen. Hierbij kijkt het naar 
			// de dot product van de vectoren balls[j].velocity - balls[i].velocity en n. Als de vectoren van de snelheden van de ballen
			// naar elkaar toe richten zullen ze botsen. Als ze gaan botsen dan is de hoek tussen deze vectoren kleiner dan
			// 90 graden, dan is de uitkomst van de cosinus van deze hoek positief. De uitkomst van de dot product is dan ook positief en 
			// de botsing wordt dan dus uitgevoerd. Als de vectoren van de snelheden van de ballen niet naar elkaar toe richten zal de 
			// uitkomst van de cosinus negatief zijn, omdat de hoek dan groter dan 90 graden is. De uitkomst van de dot product zal dan
			// ook negatief zijn. Als de uitkomst van de dot product negatief is, is het dus kleiner dan de 0f en zal er geen botsing 
			// uitgewerkt worden.
			if (Vector2.Dot(balls[j].velocity - balls[i].velocity, n) <= 0f)
			{
				return;
			}

			// Hiermee is de unit tangent gedefinieerd.
			Vector2 t = new Vector2(-n.Y, n.X);
			// Hiermee zijn de twee snelheden gedefinieerd.
			Vector2 velocity1 = balls[i].velocity;
			Vector2 velocity2 = balls[j].velocity;
			// Hiermee worden de normal snelheden uitgerekend net zoals op het uitgewerkte blad.
			float velocity1Normal = Vector2.Dot(velocity1, n);
			float velocity2Normal = Vector2.Dot(velocity2, n);
			// Hiermee worden de tangent snelheden uitgerekend net zoals op het uitgewerkte blad.
			float velocity1Tangent = Vector2.Dot(velocity1, t);
			float velocity2Tangent = Vector2.Dot(velocity2, t);
			// Omdat de snelheden ten opzichte van de tangent niet veranderen geldt dit voor die snelheden:
			float velocity1FinalTangent = velocity1Tangent;
			float velocity2FinalTangent = velocity2Tangent;
			// Hiermee wordt de v1 final van normal berekend met de formule gegeven op het blad.
			float v1f_n = (velocity1Normal * (balls[i].mass - balls[j].mass) + 2 * balls[j].mass * velocity2Normal) / (balls[i].mass + balls[j].mass);
			float v2f_n = (velocity2Normal * (balls[j].mass - balls[i].mass) + 2 * balls[i].mass * velocity1Normal) / (balls[i].mass + balls[j].mass);
			// Hiermee worden de v1 final normal/tangent en v2 final normal/tangent grootheden omgezet in vectoren.
			Vector2 v1_fn = new Vector2(v1f_n * n.X, v1f_n * n.Y);
			Vector2 v2_fn = new Vector2(v2f_n * n.X, v2f_n * n.Y);
			Vector2 v1_ft = new Vector2(velocity1FinalTangent * t.X, velocity1FinalTangent * t.Y);
			Vector2 v2_ft = new Vector2(velocity2FinalTangent * t.X, velocity2FinalTangent * t.Y);
			// Hiermee worden de uiteindelijke vectoren mee berekend.
			Vector2 v1f = v1_fn + v1_ft;
			Vector2 v2f = v2_fn + v2_ft;
			// Hiermee wordt de snelheid aan de juiste bal gekoppeld.
			balls[i].velocity = v1f;
			balls[j].velocity = v2f;
		}
	}
	
}
