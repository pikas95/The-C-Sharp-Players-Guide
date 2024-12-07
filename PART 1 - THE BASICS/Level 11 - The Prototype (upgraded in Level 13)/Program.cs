Console.Title = "Pilot";
int user1;
user1 = AskForNumberInRange("User 1, enter a number between ", 0, 100);
int AskForNumberInRange(string text, int min, int max)
{
    int input;
    while (true)
    {
        Console.WriteLine(text + min + " and " + max);
        input = Convert.ToInt32(Console.ReadLine());
        if (input >= min && input <= max)
            break;
        Console.WriteLine("The number is not suitable.");
    }
    return input;
}
Console.Clear();
Console.Title = "Hunter";
Console.WriteLine("User 2, guess the number.");
int user2 = user1 + 1;
while(user2 != user1)
{
    Console.Write("What is your next guess? ");
    user2 = Convert.ToInt32(Console.ReadLine());
    if (user2 > user1)
        Console.WriteLine(user2 + " is too high.");
    else if (user2 < user1)
        Console.WriteLine(user2 + " is too low.");
}
Console.WriteLine("You guessed the number!");