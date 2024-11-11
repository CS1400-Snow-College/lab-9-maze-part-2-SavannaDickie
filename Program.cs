// See https://aka.ms/new-console-template for more information

// Savanna Dickie
// 11/09/2024
// Lab 9: Maze #2
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

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
    
    TryMove(cursorTop, cursorLeft, mapRows);
    int savedCursorLeft = Console.CursorLeft;
    int savedCursorTop = Console.CursorTop;
 
    BadGuys(mapRows);
    Console.SetCursorPosition(savedCursorLeft, savedCursorTop);
    
    
} while(true); 

static void TryMove(int cursorTop,int cursorLeft, string[] mapRows)
{
    if (cursorTop >= 0 && cursorTop < mapRows.Length && cursorLeft >= 0
    && cursorLeft < mapRows[cursorTop].Length && mapRows[cursorTop][cursorLeft] 
    != '*' && cursorTop < Console.BufferHeight && cursorLeft < Console.BufferWidth)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);
        //Console.Write('@');
    }
}

static void BadGuys(string[] mapRows)
{
Random rand = new Random();

    for(int y = 0; y < mapRows.Length; y++)
    {
        mapRows[y] = mapRows[y].Replace('%', ' ');
        Console.SetCursorPosition(0, y);
        Console.Write(mapRows[y]);
    }
        //if (mapRows[y][x] == '%')
    for (int i = 0; i < 2; i++)
        {

            int badGuyOne;
            int badGuyTwo;
            do
            {
                badGuyOne = rand.Next(mapRows[0].Length);
                badGuyTwo = rand.Next(mapRows.Length);
            
            } while (mapRows[badGuyTwo][badGuyOne] != ' ');
           
            char[] row = mapRows[badGuyTwo].ToCharArray();
            row[badGuyOne] = '%';
            mapRows[badGuyTwo] = new string(row);
            Console.SetCursorPosition(badGuyOne, badGuyTwo);
            Console.Write('%');
        }
        
        
    
    
}


//List<(int x, int y)> badGuys = new List<(int, int)> { (13, 5)};
//foreach (var (x, y) in badGuys)
//{
  //  Console.SetCursorPosition(x,y);
//}
/* 
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
//int cursorLeft = 0;
//int cursorTop = 0;
Console.SetCursorPosition(0,0);
//Console.Write('@');
//Console.Write('@');
do
{
    ConsoleKey Key = Console.ReadKey(true).Key;
    if (Key == ConsoleKey.Escape) {return;}
    //int cursorTop = Console.CursorTop;
    //int cursorLeft = Console.CursorLeft;

    int cursorTop = Console.CursorTop;
    int cursorLeft = Console.CursorLeft;

    if (Key == ConsoleKey.UpArrow) {cursorTop--;}
    else if (Key == ConsoleKey.DownArrow) {cursorTop ++;} 
    else if (Key == ConsoleKey.LeftArrow) {cursorLeft--;}
    else if (Key == ConsoleKey.RightArrow) {cursorLeft++;}
    //Console.SetCursorPosition(cursorLeft, cursorTop);
    TryMove(cursorTop, cursorLeft, mapRows);
    //Console.SetCursorPosition(oldCursorLeft, oldCursorTop);
    //Console.Write(' ');
    //Console.SetCursorPosition(cursorLeft, cursorTop);
    //Console.Write('@');
    //TryMove(cursorTop, cursorLeft, mapRows);
    BadGuys(mapRows);
    
    
} while(true); 

static void TryMove(int cursorTop,int cursorLeft, string[] mapRows)
{
    if (cursorTop >= 0 && cursorTop < mapRows.Length && cursorLeft >= 0
    && cursorLeft < mapRows[cursorTop].Length && mapRows[cursorTop][cursorLeft] 
    != '*' && cursorTop < Console.BufferHeight && cursorLeft < Console.BufferWidth)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);
        //Console.Write('@');
    }
}

static void BadGuys(string[] mapRows)
{
Random rand = new Random();
//for (int x = 0; x < mapRows.Length; x++) 
//{
    //for (int x = 0; x < mapRows[y].Length; x++)
    for(int y = 0; y < mapRows.Length; y++)
    {
        mapRows[y] = mapRows[y].Replace('%', ' ');
        Console.SetCursorPosition(0, y);
        Console.Write(mapRows[y]);
    }
        //if (mapRows[y][x] == '%')
    for (int i = 0; i < 2; i++)
        {
            //Console.SetCursorPosition(x , y);
            //Console.Write(' ');

            int badGuyOne;
            int badGuyTwo;
            do
            {
                badGuyOne = rand.Next(mapRows[0].Length);
                badGuyTwo = rand.Next(mapRows.Length);
            
            } while (mapRows[badGuyTwo][badGuyOne] != ' ');
            //int badGuyOne = x + rand.Next(-1,5);
            //int badGuyTwo = y + rand.Next(-1,5);
        
        //if(badGuyTwo >= 0 && badGuyTwo < mapRows.Length && badGuyOne >= 0 && badGuyOne < mapRows[badGuyTwo].Length && mapRows[badGuyTwo][badGuyOne] == ' ')
        //{
            //Console.SetCursorPosition(x,y);
            //Console.Write(' ');
            //Console.SetCursorPosition(badGuyOne, badGuyTwo);
            //Console.Write('%');
            char[] row = mapRows[badGuyTwo].ToCharArray();
            row[badGuyOne] = '%';
            mapRows[badGuyTwo] = new string(row);
            Console.SetCursorPosition(badGuyOne, badGuyTwo);
            Console.Write('%');
        }
        
        
    
    
} */