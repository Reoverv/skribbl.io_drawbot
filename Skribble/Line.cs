namespace Skribble;

public class Line{
    public Coords Start{ get; set; }
    public Coords End{ get; set; }

    public int Lenght{ get; set; }
    public String Color{ get; set; }
    public bool isSet{ get; set; }
    public int lineNumber{ get; set; }

    public Line(Coords start, bool isSet){
        Start = start;
        this.isSet = isSet;
    }

    public Line(Coords start, int lenght){
        Start = start;
        Lenght = lenght;
    }


}


public class Coords{
    public int X{ get; set; }
    public int Y{ get; set; }

    public Coords(int y, int x){
        X = x;
        Y = y;
    }

    public override string ToString(){
        return $"{nameof(Y)}: {Y}, {nameof(X)}: {X}";
    }
}