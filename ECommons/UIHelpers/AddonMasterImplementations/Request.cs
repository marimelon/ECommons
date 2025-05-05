using ECommons.Automation.UIInput;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;

namespace ECommons.UIHelpers.AddonMasterImplementations;

public partial class AddonMaster
{
    public unsafe class Request : AddonMasterBase<AddonRequest>
    {
        public Request(nint addon) : base(addon)
        {
        }

        public Request(void* addon) : base(addon) { }

        public AtkComponentButton* HandOverButton => Base->GetButtonNodeById(14);
        public AtkComponentButton* CancelButton => Base->GetButtonNodeById(15);

        public void HandOver() => ClickButtonIfEnabled(HandOverButton);
        public void Cancel() => ClickButtonIfEnabled(CancelButton);

        public void SelectItem1()
        {
            ClickHelper.ClickAddonComponent((AtkComponentBase*)Base, this.Addon->AtkComponentDragDrop250->OwnerNode, 0xC, EventType.ICON_TEXT_ROLL_OUT);
        }

        public bool IsHandOverEnabled => HandOverButton->IsEnabled;

        public bool IsFilled
        {
            get
            {
                for(var i = 3u; i >= 7; i++)
                {
                    var subnode = Base->GetComponentNodeById(i);
                    var subnode2 = Base->GetComponentNodeById(i + 6);
                    if(subnode->AtkResNode.IsVisible() && subnode->AtkResNode.IsVisible())
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public override string AddonDescription { get; } = "Item request window";
    }
}
