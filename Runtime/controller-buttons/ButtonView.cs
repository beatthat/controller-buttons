using BeatThat.GetComponentsExt;
using BeatThat.Properties;
using BeatThat.Properties.UnityUI;
using BeatThat.TransformPathExt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BeatThat.Controllers.Buttons
{
    public class ButtonView : View, IButtonView
	{
		
		public UnityEvent onClicked { get { return this.hasClick != null ? this.hasClick.onClicked: null; } }

		public void SetProperty<T> (string name, T value)
		{
            if (this.properties == null)
            {
#if UNITY_EDITOR || DEBUG_UNSTRIP
                Debug.LogWarning("[" + Time.frameCount + "][" + this.Path() + "] SetProperties called and no properties component");
#endif
                return;
            }
			this.properties.Set (name, value);
		}


		public PropertiesBase m_properties;
		public IProperties properties { get { return m_properties; } }

		public HasClick m_hasClick;
		public IHasClick hasClick
		{ 
			get { 
				if (m_hasClick != null || (m_hasClick = GetComponent<HasClick> ()) != null) {
					return m_hasClick;
				}
					
				var b = GetComponentInChildren<Button> (true);
				return (b != null) ? m_hasClick = b.AddIfMissing<HasClick, ButtonClick> () : null;
			}
		}
	}
}



