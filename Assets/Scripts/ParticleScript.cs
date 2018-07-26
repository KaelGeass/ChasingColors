using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    [RequireComponent(typeof(Poderzinho))]
    public class  ParticleScript: MonoBehaviour  {

        public Poderzinho p;
        // Update is called once per frame
        //	private Platformer2DUserControl m_Character;

        public void liberaPoderzinho( PlatformerCharacter2D m_Character) { 
		    m_Character.setCan(p);
	    }
	}
}
