using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using StatTrak.Handlers;
using TMPro;

namespace StatTrak.UI
{
    public class StatTrakViewController : BSMLResourceViewController
    {
        public override string ResourceName => "StatTrak.UI.info.bsml";
        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            base.DidActivate(firstActivation, addedToHierarchy, screenSystemEnabling);
            sliceText.SetText("Blocks Sliced: " + MainHandler.GetFormattedNumber(UIHandler.SelectedStatTrak.BlocksSliced));
        }

        [UIComponent("sliceText")]
        public TextMeshProUGUI sliceText = null;

    }
}
