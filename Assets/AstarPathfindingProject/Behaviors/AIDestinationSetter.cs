using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;
		public LayerMask kuleler;
		void Start() 
		{
			Collider2D[] init = Physics2D.OverlapCircleAll(transform.position, 100000, kuleler);
			for(int i=0;i<init.Length;i++)
			{
				if (init[i].gameObject.tag=="MainTower")
				{
					target = init[i].gameObject.transform;
				}
			}
		}
		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () 
		{
			if (target != null && ai != null) ai.destination = target.position;
			
			
			Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, 2, kuleler);
			List<Collider2D> Quartz = new List<Collider2D>();
			List<Collider2D> Clock = new List<Collider2D>();
			List<Collider2D> Infinity = new List<Collider2D>();
			List<Collider2D> Bend = new List<Collider2D>();
			List<Collider2D> Main = new List<Collider2D>();
			List<Collider2D> Final = new List<Collider2D>();
			
			for(int i=0;i<targetsInRange.Length;i++)
			{
				switch(targetsInRange[i].gameObject.tag) 
				{
					case "QuartzTower":
						Quartz.Add(targetsInRange[i]);
						break;
					case "BendTower":
						Bend.Add(targetsInRange[i]);
						
						break;
					case "ClockTower":
						Clock.Add(targetsInRange[i]);
						break;
					case "InfinityTower":
						Infinity.Add(targetsInRange[i]);
						break;
					case "MainTower":
						Main.Add(targetsInRange[i]);
						break;
					default:
					
						break;
				}

			}
			if(Clock.Count>0)
				Final = Clock;
			else if(Infinity.Count>0)
				Final = Infinity;
			else if(Bend.Count>0)
				Final = Bend;
			else if(Main.Count>0)
				Final = Main;
			else
				Final = Quartz;
			if(Final.Count>0)
			{
				Transform closest = Final[0].transform;
				if(Final.Count>1)
				{
					for(int i=1;i<Final.Count;i++)
					{
						float distance1 = Vector3.Distance(closest.position,transform.position);
						float distance2 = Vector3.Distance(Final[i].transform.position,transform.position);
						if(Mathf.Abs(distance1)>Mathf.Abs(distance2))
						{
							closest = Final[i].transform;
							
						}
							

					}
				}
			target = closest;
			}
			
		}
	}
}
