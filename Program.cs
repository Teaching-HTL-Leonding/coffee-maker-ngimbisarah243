// See https://aka.ms/new-console-template for more information

using System;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;

const char CAPPUCCINO = '1'; const decimal PRIZE_CAPPUCCINO = 3.50m;
const char TEA = '2'; const decimal PRIZE_TEA = 1.50m;
const char CACAO = '3'; const decimal PRIZE_CACAO = 2.50m;
const char NOTHING_ELSE = '4';

char product = '0';
decimal prize = 0;
decimal money = 0;
string smiley = "💕";

Console.WriteLine("Please enter the amount of money that you fed into the machine (multiple of 0.5€):  ");
money = Convert.ToDecimal(Console.ReadLine()!);
Console.WriteLine();

while (!(money % 0.5m == 0 && money >= PRIZE_TEA))
{
    Console.ForegroundColor = ConsoleColor.Red;

    if (money % 0.5m != 0)
    {
        Console.WriteLine("The entered amount of money is not a multiple of 0.5!!");
    }
    if (money < PRIZE_TEA)
    {
        Console.WriteLine("You don't have enough money sorry");
    }
    else
    {
        Console.WriteLine("Ivalid Iput!");
    }

    Console.ResetColor();

    Console.WriteLine("Please enter the amount of money that you fed into the machine (multiple of 0.5€):  ");
    money = Convert.ToDecimal(Console.ReadLine()!);
}

Console.WriteLine();

while (!(product == NOTHING_ELSE || money < PRIZE_TEA))
{
    Console.WriteLine("Wich product would you like to buy?");
    Console.WriteLine("1) Cappuccino (3.5€),    2) Tea (1.5€),    3) Cacao (2.5€),    4) Nothing else");
    product = Convert.ToChar(Console.ReadLine()!);

    switch (product)
    {
        case CAPPUCCINO: prize = PRIZE_CAPPUCCINO; break;
        case TEA: prize = PRIZE_TEA; break;
        case CACAO: prize = PRIZE_CACAO; break;
    }

    while (money < prize && product != NOTHING_ELSE)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Sorry, you do not have enough credit left");
        Console.WriteLine("Choose another thing or leave!");
        Console.ResetColor();

        Console.WriteLine("Wich product would you like to buy?");
        Console.WriteLine("1) Cappuccino (3.5€), 2) Tea (1.5€), 3) Cacao (2.5€), 4) Nothing else");
        product = Convert.ToChar(Console.ReadLine()!);

        switch (product)
        {
            case CAPPUCCINO: prize = PRIZE_CAPPUCCINO; break;
            case TEA: prize = PRIZE_TEA; break;
            case CACAO: prize = PRIZE_CACAO; break;

        }
    }

    if (money >= prize)
    {
        money -= prize;
    }
    if (money < PRIZE_TEA)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Sorry, you do not have enough credit left to buy something");
        Console.ResetColor();
    }
}

decimal twoEuroCoins = 0;
decimal oneEurosCoins = 0;
decimal zeroPointFiveCoins = 0;

if (product == NOTHING_ELSE || money < PRIZE_TEA)
{
    Console.WriteLine($"You get {money} back.");
    Console.WriteLine();
    twoEuroCoins = (int)money / 2;
    oneEurosCoins = (int)money % 2;
    zeroPointFiveCoins = (money - twoEuroCoins * 2 - oneEurosCoins * 1) / 0.5m;

    Console.WriteLine($"You get {twoEuroCoins} x2Euro pieces");
    Console.WriteLine($"You get {oneEurosCoins} x1Euro pieces");
    Console.WriteLine($"You get {zeroPointFiveCoins} x0.5Euro pieces");
}
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"HAVE A NICE DAY! {smiley} ");
Console.ReadKey();