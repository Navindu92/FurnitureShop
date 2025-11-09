using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows
{
    public class MyCoolThemeSkin: RibbonProfesionalRendererColorTable
    {
        public MyCoolThemeSkin()
        {
            Color backColor = Color.FromArgb(120, 172, 12);
            Color captionColor = Color.FromArgb(186, 129, 187);
            Color textColor =Color.FromArgb(120, 172, 12);
            Color borderColor = Color.FromArgb(0, 90, 0);

            OrbDropDownDarkBorder = borderColor;
            OrbDropDownLightBorder = Color.FromKnownColor(KnownColor.WindowFrame);
            OrbDropDownBack = backColor;
            OrbDropDownNorthA = FromHex("#C2FF3D");
            OrbDropDownNorthB = Color.FromArgb(201, 100, 150);
            OrbDropDownNorthC = backColor;
            OrbDropDownNorthD = backColor;
            OrbDropDownSouthC = backColor;
            OrbDropDownSouthD = backColor;
            OrbDropDownContentbg = backColor;
            OrbDropDownContentbglight = backColor;
            OrbDropDownSeparatorlight = backColor;
            OrbDropDownSeparatordark = backColor;
            
            Caption1 = captionColor;
            Caption2 = captionColor;
            Caption3 = captionColor;
            Caption4 = captionColor;
            Caption5 = captionColor;
            Caption6 = captionColor;
            Caption7 = captionColor;

            QuickAccessBorderDark = borderColor;
            QuickAccessBorderLight = borderColor;
            QuickAccessUpper = backColor;
            QuickAccessLower = backColor;

            OrbOptionBorder = borderColor;
            OrbOptionBackground = backColor;
            OrbOptionShine = backColor;

            Arrow = backColor;
            ArrowLight = backColor;
            ArrowDisabled = backColor;
            Text = textColor;

            RibbonBackground = backColor;
            TabBorder = borderColor;
            TabNorth = backColor;
            TabSouth = backColor;
            TabGlow = backColor;
            TabText = textColor;
            TabActiveText = backColor;
            TabContentNorth = backColor;
            TabContentSouth = backColor;
            TabSelectedGlow = backColor;
            PanelDarkBorder = backColor;
            PanelLightBorder = backColor;
            PanelTextBackground = backColor;
            PanelTextBackgroundSelected = backColor;
            PanelText = backColor;
            PanelBackgroundSelected = backColor;
            PanelOverflowBackground = backColor;
            PanelOverflowBackgroundPressed = backColor;
            PanelOverflowBackgroundSelectedNorth = backColor;
            PanelOverflowBackgroundSelectedSouth = backColor;

            ButtonBgOut = backColor;
            ButtonBgCenter = backColor;
            ButtonBorderOut = backColor;
            ButtonBorderIn = backColor;
            ButtonGlossyNorth = backColor;
            ButtonGlossySouth = backColor;

            ButtonDisabledBgOut = backColor;
            ButtonDisabledBgCenter = backColor;
            ButtonDisabledBorderOut = backColor;
            ButtonDisabledBorderIn = backColor;
            ButtonDisabledGlossyNorth = backColor;
            ButtonDisabledGlossySouth = backColor;

            ButtonSelectedBgOut = backColor;
            ButtonSelectedBgCenter = backColor;
            ButtonSelectedBorderOut = backColor;
            ButtonSelectedBorderIn = backColor;
            ButtonSelectedGlossyNorth = backColor;
            ButtonSelectedGlossySouth = backColor;

            ButtonPressedBgOut = backColor;
            ButtonPressedBgCenter = backColor;
            ButtonPressedBorderOut = backColor;
            ButtonPressedBorderIn = backColor;
            ButtonPressedGlossyNorth = backColor;
            ButtonPressedGlossySouth = backColor;

            ButtonCheckedBgOut = backColor;
            ButtonCheckedBgCenter = backColor;
            ButtonCheckedBorderOut = backColor;
            ButtonCheckedBorderIn = backColor;
            ButtonCheckedGlossyNorth = backColor;
            ButtonCheckedGlossySouth = backColor;

            ItemGroupOuterBorder = backColor;
            ItemGroupInnerBorder = backColor;
            ItemGroupSeparatorLight = backColor;
            ItemGroupSeparatorDark = backColor;
            ItemGroupBgNorth = backColor;
            ItemGroupBgSouth = backColor;
            ItemGroupBgGlossy = backColor;

            ButtonListBorder = backColor;
            ButtonListBg = backColor;
            ButtonListBgSelected = backColor;

            DropDownBg = backColor;
            DropDownImageBg = backColor;
            DropDownImageSeparator = backColor;
            DropDownBorder = backColor;
            DropDownGripNorth = backColor;
            DropDownGripSouth = backColor;
            DropDownGripBorder = backColor;
            DropDownGripDark = backColor;
            DropDownGripLight = backColor;

            SeparatorLight = backColor;
            SeparatorDark = backColor;
            SeparatorBg = backColor;
            SeparatorLine = backColor;

            TextBoxUnselectedBg = backColor;
            TextBoxBorder = backColor;
            
        }
        public Color FromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");

            return Color.FromArgb(
                int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }
    }
}
