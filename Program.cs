// See https://aka.ms/new-console-template for more information

// Savanna Dickie
// 11/09/2024
// Lab 9: Maze #2
Console.Clear();
Console.WriteLine("================================= MAZE #2 ================================");
Console.WriteLine("\nObjective: Collect all 10 coins ( ^ ) to open the gate to gather gems ( $ ).");
Console.WriteLine("\nChallange: Avoid the bad guys ( % ) to survive");
Console.WriteLine("\n===============================GOOD LUCK ================================");
Console.ReadLine();


string[] mapRows = File.ReadAllLines("maze.txt");
Console.Clear();
//Console.WriteLine("================================= MAZE #2 ================================");
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}
Console.SetCursorPosition(0,0);
do
{
    ConsoleKey Key = Console.ReadKey(true).Key;
    if (Key == ConsoleKey.Escape) {return;}
    int cursorTop = Console.CursorTop;
    int cursorLeft = Console.CursorLeft;

    if (Key == ConsoleKey.UpArrow) {cursorTop--;}
    else if (Key == ConsoleKey.DownArrow) {cursorTop ++;}
    else if (Key == ConsoleKey.LeftArrow) {cursorLeft--;}
    else if (Key == ConsoleKey.RightArrow) {cursorLeft++;}
    //Console.SetCursorPosition(cursorLeft, cursorTop);
    TryMove(cursorTop, cursorLeft, mapRows);
    
} while(true);

static void TryMove(int cursorTop, int cursorLeft, string[] mapRows)
{
    if (cursorTop >= 0 && cursorTop < mapRows.Length && cursorLeft >= 0
    && cursorLeft < mapRows[cursorTop].Length && mapRows[cursorTop][cursorLeft] 
    != '*' && cursorTop < Console.BufferHeight && cursorLeft < Console.BufferWidth)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);
    }
}