﻿ArrowClass arrow = DescribeArrow();
Console.WriteLine("This will cost " + arrow.GetCost() + " gold.");
ArrowClass DescribeArrow()
{
    ArrowClass LocalArrow = new ArrowClass();

    Console.Write("Pick Arrow Head (Steel, Wood, Obsidian): ");
    string text = Console.ReadLine();
    ArrowHead arrowHead = text switch
    {
        "Steel" => ArrowHead.Steel,
        "Wood" => ArrowHead.Wood,
        "Obsidian" => ArrowHead.Obsidian
    };
    LocalArrow.SetArrowHead(arrowHead);

    Console.Write("Enter the length of the shaft (60 - 100 cm): ");
    float length = Convert.ToSingle(Console.ReadLine());
    LocalArrow.SetLength(length);

    Console.Write("Pick a Fletching (Plastic, Turkey Feathers, Goose Feathers): ");
    text = Console.ReadLine();
    Fletching flething = text switch
    {
        "Plastic" => Fletching.Plastic,
        "Turkey Feathers" => Fletching.TurkeyFeathers,
        "Goose Feathers" => Fletching.GooseFeathers
    };
    LocalArrow.SetFletching(flething);

    return LocalArrow;
}
class ArrowClass
{
    private ArrowHead _arrowHead;
    private float _length;
    private Fletching _flecthing;

    public ArrowClass(ArrowHead arrowHead, float length, Fletching flecthing)
    {
        _arrowHead = arrowHead;
        _length = length;
        _flecthing = flecthing;
    }

    public ArrowClass()
    {
    }

    public ArrowHead GetArrowHead() => _arrowHead;
    public float GetLength() => _length;
    public Fletching GetFletching() => _flecthing;

    public ArrowHead SetArrowHead(ArrowHead value) => _arrowHead = value;
    public float SetLength(float value) => _length = value;
    public Fletching SetFletching(Fletching value) => _flecthing = value;

    public float GetCost()
    {
        float gold = 0;
        if (_arrowHead == ArrowHead.Steel)
            gold += 10;
        else if (_arrowHead == ArrowHead.Wood)
            gold += 3;
        else
            gold += 5;
        if (_flecthing == Fletching.Plastic)
            gold += 10;
        else if (_flecthing == Fletching.TurkeyFeathers)
            gold += 5;
        else
            gold += 3;
        gold += 0.05f * _length;
        return gold;
    }
}
enum ArrowHead { Steel, Wood, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }

/* SECOND ATTEMPT
Arrow arrow = GetArrow();
Console.WriteLine($"Arrow Cost for {arrow.GetFletching()} {arrow.GetArrowhead()} arrow that is {arrow.GetShaft()} cm length: {arrow.GetCost()}");
Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletching();
    float length = GetLength();
    return new Arrow(arrowhead, fletching, length);
}
Arrowhead GetArrowhead()
{
    Console.Write("Select Arrowhead (Steel, Wood, Obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "Steel" => Arrowhead.Steel,
        "Wood" => Arrowhead.Wood,
        "Obsidian" => Arrowhead.Obsidian
    };
}
Fletching GetFletching()
{
    Console.Write("Select Fletching (Plastic, Turkey Feathers, Goose Feathers): ");
    string input = Console.ReadLine();
    return input switch
    {
        "Plastic" => Fletching.Plastic,
        "Turkey Feathers" => Fletching.TurkeyFeathers,
        "Goose Feathers" => Fletching.GooseFeathers
    };
}
float GetLength()
{
    Console.Write("Type in Length between 60 and 100 cm: ");
    return Convert.ToSingle(Console.ReadLine());
}
class Arrow
{
    private Arrowhead _arrowHead;
    private float _shaft;
    private Fletching _fletching;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float shaft)
    {
        _arrowHead = arrowhead;
        _shaft = shaft;
        _fletching = fletching;
    }

    public void SetArrowhead(Arrowhead value) => _arrowHead = value;
    public void SetFletching(Fletching value) => _fletching = value;
    public void SetShaft(float value) => _shaft = value;

    public Arrowhead GetArrowhead() => _arrowHead;
    public Fletching GetFletching() => _fletching;
    public float GetShaft() => _shaft;

    public float GetCost()
    {
        float cost = 0;
        cost += _arrowHead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Obsidian => 5,
            Arrowhead.Wood => 3
        };
        cost += _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };
        cost += _shaft * 0.05f;
        return cost;
    }
}
public enum Arrowhead { Wood, Steel, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }*/