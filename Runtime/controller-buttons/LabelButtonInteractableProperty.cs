using BeatThat.Properties;

namespace BeatThat.Controllers.Buttons
{
    public class LabelButtonInteractableProperty : BoolProp, IDrive<LabelButton>
    {
        public override bool sendsValueObjChanged { get { return false; } }

        public LabelButton m_driven;

        public LabelButton driven
        {
            get{
                return m_driven != null ?
                    m_driven : (m_driven = GetComponent<LabelButton>());
            }
        }

        public object GetDrivenObject()
        {
            return this.driven;
        }

        public bool ClearDriven()
        {
            m_driven = null;
            return true;
        }

        protected override void EnsureValue(bool s)
        {
            this.driven.interactable = s;
        }

        protected override bool GetValue()
        {
            return this.driven.interactable;
        }

        protected override void _SetValue(bool s)
        {
            this.driven.interactable = s;
        }
    }
}

