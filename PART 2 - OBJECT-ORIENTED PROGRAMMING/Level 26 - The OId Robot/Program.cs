﻿Robot robot = new Robot();
for (int i = 0; i < 3; i++)
{
    robot.Commands[i] = Console.ReadLine() switch
    {
        "on" => robot.Commands[i] = new OnCommand(),
        "off" => robot.Commands[i] = new OffCommand(),
        "north" => robot.Commands[i] = new NorthCommand(),
        "south" => robot.Commands[i] = new SouthCommand(),
        "west" => robot.Commands[i] = new WestCommand(),
        "east" => robot.Commands[i] = new EastCommand()
    };
}
Console.WriteLine();
robot.Run();
public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}
public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
            robot.Y++;
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
            robot.Y--;
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
            robot.X--;
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered == true)
            robot.X++;
    }
}
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}