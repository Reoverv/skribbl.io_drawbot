using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Net.Mime;
using System.Reflection;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Skribble;

public class GetColor{
    ImageProc imgProc = new();
    private Image<Bgr, Byte> img;

    private Color white = Color.White;
    private Color LightGray = Color.LightGray;
    private Color Red = Color.Red;
    private Color Orange = Color.Orange;
    private Color Yellow = Color.Yellow;
    private Color Green = Color.Green;
    private Color LightBlue = Color.Aqua;
    private Color Blue = Color.Blue;
    private Color Purple = Color.MediumPurple;
    private Color Pink = Color.Pink;
    private Color Brown = Color.SandyBrown;
    private Color Black = Color.Black;
    private Color Grey = Color.Gray;
    private Color DarkRed = Color.DarkRed;
    private Color DarkOrange = Color.DarkOrange;
    private Color DarkYellow = Color.Gold;
    private Color DarkGreen = Color.DarkGreen;
    private Color DarkAqua = Color.SteelBlue;
    private Color DarkBlue = Color.DarkBlue;
    private Color DarkPurple = Color.Purple;
    private Color DarkPink = Color.HotPink;
    private Color DarkBrown = Color.SaddleBrown;


    public GetColor(){
        img = imgProc.ImageToArray();
    }

    public String getColorName(int c1, int c2){



        var image = img[c1, c2];
        string colorName;
        Color c = Color.LightBlue;
        ;
        Color limitedColors = Color.FromArgb((int)image.Red, (int)image.Green,
            (int)image.Blue);

        FindColour(limitedColors, out colorName);
        return colorName;
    }


    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Drawing.Color; size: 223MB")]
    public string GetSkribbleColor(int c1, int c2){

        var colorName = getColorName(c1, c2);
        //  if (colorname == "White") return null;
        //Console.Write(colorname + " | ");

        return ((colorName) switch{
            "AliceBlue" => "Aqua",
            "AntiqueWhite" => "LightGray",
            "Aqua" => "Aqua",
            "Aquamarine" => "Aqua",
            "Azure" => "Blue",
            "Beige" => "Pink",
            "Bisque" => "Gray",
            "Black" => "Black",
            "BlanchedAlmond" => "LightGray",
            "Blue" => "Blue",
            "BlueViolet" => "Purple",
            "Brown" => "Brown",
            "BurlyWood" => "Brown",
            "CadetBlue" => "DarkAqua",
            "Chartreuse" => "Green",
            "Chocolate" => "Orange",
            "Coral" => "Orange",
            "CornflowerBlue" => "Aqua",
            "Cornsilk" => "LightGray",
            "Crimson" => "Red",
            "Cyan" => "Aqua",
            "DarkBlue" => "DarkBlue",
            "DarkCyan" => "DarkAqua",
            "DarkGoldenrod" => "DarkOrange",
            "DarkGray" => "LightGray",
            "DarkGreen" => "DarkGreen",
            "DarkKhaki" => "DarkYellow",
            "DarkMagenta" => "DarkPurple",
            "DarkOliveGreen" => "DarkBrown",
            "DarkOrange" => "DarkOrange",
            "DarkOrchid" => "DarkOrange",
            "DarkRed" => "DarkRed",
            "DarkSalmon" => "Pink",
            "DarkSeaGreen" => "Green",
            "DarkSlateBlue" => "DarkBlue",
            "DarkSlateGray" => "DarkGray",
            "DarkTurquoise" => "DarkAqua",
            "DarkViolet" => "DarkPurple",
            "DeepPink" => "DarkPink",
            "DeepSkyBlue" => "Aqua",
            "DimGray" => "DarkGray",
            "DodgerBlue" => "DarkAqua",
            "Firebrick" => "DarkRed",
            "FloralWhite" => "LightGray",
            "ForestGreen" => "DarkGreen",
            "Fuchsia" => "Purple",
            "RebeccaPurple" => "Purple",
            "Gainsboro" => "LightGray",
            "Gold" => "DarkYellow",
            "Goldenrod" => "DarkYellow",
            "Gray" => "Gray",
            "Green" => "DarkGreen",
            "GreenYellow" => "Green",
            "Honeydew" => "LightGray",
            "HotPink" => "Pink",
            "IndianRed" => "DarkPink",
            "Indigo" => "DarkPurple",
            "Khaki" => "DarkYellow",
            "Lavender" => "LightGray",
            "LavenderBlush" => "Pink",
            "LawnGreen" => "Green",
            "LemonChiffon" => "Yellow",
            "LightBlue" => "LightBlue",
            "LightCoral" => "Pink",
            "LightCyan" => "Aqua",
            "LightGoldenrodYellow" => "LightGray",
            "LightGray" => "LightGray",
            "LightGreen" => "Green",
            "LightPink" => "Pink",
            "LightSalmon" => "Pink",
            "LightSeaGreen" => "DarkAqua",
            "LightSkyBlue" => "Aqua",
            "LightSlateGray" => "DarkGray",
            "LightSteelBlue" => "Gray",
            "LightYellow" => "Yellow",
            "Lime" => "Green",
            "LimeGreen" => "DarkGreen",
            "Linen" => "Gray",
            "Magenta" => "Purple",
            "Maroon" => "DarkRed",
            "MediumAquamarine" => "Green",
            "MediumBlue" => "DarkBlue",
            "MediumOrchid" => "Pink",
            "MediumPurple" => "Purple",
            "MediumSeaGreen" => "Green",
            "MediumSlateBlue" => "Purple",
            "MediumSpringGreen" => "Green",
            "MediumTurquoise" => "DarkAqua",
            "MediumVioletRed" => "DarkPink",
            "MidnightBlue" => "DarkBlue",
            "MintCream" => "LightGray",
            "MistyRose" => "Pink",
            "Moccasin" => "DarkYellow",
            "NavajoWhite" => "DarkYellow",
            "Navy" => "DarkBlue",
            "OldLace" => "LightGray",
            "Olive" => "Brown",
            "OliveDrab" => "Green",
            "Orange" => "Orange",
            "OrangeRed" => "Red",
            "Orchid" => "Pink",
            "PaleGoldenrod" => "LightGray",
            "PaleGreen" => "Green",
            "PaleTurquoise" => "Aqua",
            "PaleVioletRed" => "DarkPink",
            "PapayaWhip" => "Orange",
            "PeachPuff" => "DarkYellow",
            "Peru" => "Brown",
            "Pink" => "Pink",
            "Plum" => "Pink",
            "PowderBlue" => "Aqua",
            "Purple" => "Purple",
            "Red" => "Red",
            "RosyBrown" => "Brown",
            "RoyalBlue" => "DarkAqua",
            "SaddleBrown" => "DarkBrown",
            "Salmon" => "Pink",
            "SandyBrown" => "Brown",
            "SeaGreen" => "DarkGreen",
            "SeaShell" => "LightGray",
            "Sienna" => "DarkBrown",
            "Silver" => "LightGray",
            "SkyBlue" => "Aqua",
            "SlateBlue" => "Blue",
            "SlateGray" => "DarkGray",
            "SpringGreen" => "Green",
            "SteelBlue" => "DarkAqua",
            "Tan" => "Orange",
            "Teal" => "DarkAqua",
            "Thistle" => "Pink",
            "Tomato" => "Pink",
            "Turquoise" => "Aqua",
            "Violet" => "Pink",
            "Wheat" => "Orange",
            "Yellow" => "Yellow",
            "YellowGreen" => "Green",
            _ => null
        })!;

    }


    enum MatchType{
        NoMatch,
        ExactMatch,
        ClosestMatch
    };

    MatchType FindColour(Color colour, out string name){
        MatchType
            result = MatchType.NoMatch;

        int
            least_difference = 0;

        name = "";

        foreach (PropertyInfo system_colour in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public |
                                                                           BindingFlags.FlattenHierarchy)){
            Color
                system_colour_value = (Color)system_colour.GetValue(null, null);

            if (system_colour_value == colour){
                name = system_colour.Name;
                result = MatchType.ExactMatch;
                break;
            }

            int
                a = colour.A - system_colour_value.A,
                r = colour.R - system_colour_value.R,
                g = colour.G - system_colour_value.G,
                b = colour.B - system_colour_value.B,
                difference = a * a + r * r + g * g + b * b;

            if (result == MatchType.NoMatch || difference < least_difference){
                result = MatchType.ClosestMatch;
                name = system_colour.Name;
                least_difference = difference;
            }
        }

        return result;
    }

}