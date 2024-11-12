// See https://aka.ms/new-console-template for more information

// Savanna Dickie
// 11/09/2024
// Lab 9: Maze #2
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

Console.Clear();
Stopwatch stopwatch = new Stopwatch();
Console.WriteLine("================================= MAZE #2 ================================");
Console.WriteLine("\nObjective: Collect all 10 coins ( ^ ) to open the gate to gather gems ( $ ).");
Console.WriteLine("\nChallenge: Avoid the bad guys ( % ) to survive");
Console.WriteLine("\n===============================GOOD LUCK ================================");
Console.ReadLine();

string[] mapRows = File.ReadAllLines("maze.txt");
Console.Clear();
stopwatch.Start();

foreach (string row in mapRows)
{
    Console.WriteLine($"{row}");
}

int score = 0;
Console.SetCursorPosition(0, mapRows.Length + 1);
Console.WriteLine($"Score: {score}  ");

Console.SetCursorPosition(0,0);

bool won = false;
Console.CursorVisible = false;
int newTop = 0;
int newLeft = 0;
Console.SetCursorPosition(newLeft,newTop);
Console.Write('@');
do
{
    Random rand = new Random();
    ConsoleKey Key = Console.ReadKey(true).Key;
    if (Key == ConsoleKey.Escape) {return;}
   

    //int cursorTop = Console.CursorTop;
    //int cursorLeft = Console.CursorLeft;
    //Console.SetCursorPosition(newLeft, newTop);
    //Console.Write(' ');
    int prevTop = newTop;
    int prevLeft = newLeft;

    if (Key == ConsoleKey.UpArrow) {newTop--;}
    else if (Key == ConsoleKey.DownArrow) {newTop ++;} 
    else if (Key == ConsoleKey.LeftArrow) {newLeft--;}
    else if (Key == ConsoleKey.RightArrow) {newLeft++;}
    
    bool gameContinues = TryMove(newTop, newLeft, mapRows,ref score);
    
    if (!gameContinues)
    {
        newTop = prevTop;
        newLeft = prevLeft;
    }
     if(mapRows[newTop][newLeft] == '%')
    {
        won = false;
        break;
    }
    
    else if (mapRows[newTop][newLeft] == '#')
    {
        won = true;
        break;
    }
    
    if (gameContinues)
    {
    int savedCursorLeft = Console.CursorLeft;
    int savedCursorTop = Console.CursorTop;
 
    BadGuys(mapRows);
    Console.SetCursorPosition(savedCursorLeft, savedCursorTop);
    }
    Console.SetCursorPosition(prevLeft, prevTop);
    Console.Write(' ');
    
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.SetCursorPosition(newLeft, newTop);
    Console.Write('@');
      
} while(true); 

stopwatch.Stop();
Console.Clear();
Console.ResetColor();

if(won)
{
Console.WriteLine("\n\nYOU WON THE MAZE");
}

else
{
    Console.WriteLine("\nThe bad guy killed you. YOU LOSE");
}
    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds/1000} seconds | Score: {score}");


//METHODS
static bool TryMove(int newTop,int newLeft, string[] mapRows, ref int score)
{
    Console.ResetColor();
    
    if (newTop >= 0 && newTop < mapRows.Length && newLeft >= 0
    && newLeft < mapRows[newTop].Length && mapRows[newTop][newLeft] 
    != '*' && newTop < Console.BufferHeight && newLeft < Console.BufferWidth)
    {
    
       
        if (mapRows[newTop][newLeft] == '^')
        {
            score += 100;
        
            char[] row = mapRows[newTop].ToCharArray();
            row[newLeft] = ' ';
            mapRows[newTop] = new string(row);
            Console.SetCursorPosition(0, mapRows.Length + 1);
            Console.ResetColor();
            Console.WriteLine($"score: {score}   ");
        }

        if (mapRows[newTop][newLeft] == '$')
        {
            score += 200;
       
            char[] row = mapRows[newTop].ToCharArray();
            row[newLeft] = ' ';
            mapRows[newTop] = new string(row);
            Console.SetCursorPosition(0, mapRows.Length + 1);
            Console.ResetColor();
            Console.WriteLine($"score: {score}   ");
        }

        if(score >= 1000)
        {
             for( int i = 0; i < mapRows.Length; i++)
            {
            mapRows[i] = mapRows[i].Replace('|', ' ');
            }
        }
       
        Console.SetCursorPosition(newLeft, newTop);
        return true;
       
    }
    
    return false;
    
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
            int[] colors = {4,15,9};
            Console.ForegroundColor = (ConsoleColor)colors[rand.Next(colors.Length)];
            //ConsoleColor.
            //Console.ForegroundColor = (ConsoleColor)rand.Next(16);
            Console.Write('%');
        } 
    
}







/*
Console.Clear();
Stopwatch stopwatch = new Stopwatch();
Console.WriteLine("================================= MAZE #2 ================================");
Console.WriteLine("\nObjective: Collect all 10 coins ( ^ ) to open the gate to gather gems ( $ ).");
Console.WriteLine("\nChallange: Avoid the bad guys ( % ) to survive");
Console.WriteLine("\n===============================GOOD LUCK ================================");
Console.ReadLine();


string[] mapRows = File.ReadAllLines("maze.txt");
Console.Clear();
stopwatch.Start();
//int score = 0;
//Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nScore: {score}");
//Console.WriteLine("================================= MAZE #2 ================================");
foreach (string row in mapRows)
{
    Console.WriteLine($"{row}");
}
//foreach(var row in mapRows)
//{
//foreach (char c in row)
//{
    //if(c == '$')
    //Console.ForegroundColor = ConsoleColor.Yellow;
    //Console.Write(c);
    //Console.ResetColor();
//}
//}
//char gems = '$';
//foreach (char c in "$")
//{
    //if (c == gems)
    //{
    //    Console.ForegroundColor = ConsoleColor.Green;
    //}
    //Console.Write(c);
//}
//mapRows['$'] = Console.BackgroundColor{$; 10;};



//Stopwatch stopwatch = new Stopwatch();
int score = 0;
Console.SetCursorPosition(0, mapRows.Length + 1);
Console.WriteLine($"Score: {score}  ");
//int score = 0;
//Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nScore: {score}");
Console.SetCursorPosition(0,0);
////int score = 0;
//Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nScore: {score}");
bool won = false;
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
    
    bool gameContinues = TryMove(cursorTop, cursorLeft, mapRows,ref score);
    
    //if (!gameContinues)
    //{
        
       // Console.Clear();
        //stopwatch.Stop();

        //Console.WriteLine("\nThe bad guy killed you. GAME OVER");
       // Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds/1000} seconds Score: {score}");
       // break;
    //}
     if(mapRows[cursorTop][cursorLeft] == '%')
        {
            won = false;
            break;
        }
    
    else if (mapRows[cursorTop][cursorLeft] == '#')
    {
        won = true;
        break;
    }
    //if (score == 1000)
    //{
     //   mapRows[y] = mapRows[y].Replace('%', ' ');
    //}
    
    
    if (gameContinues)
    {
    int savedCursorLeft = Console.CursorLeft;
    int savedCursorTop = Console.CursorTop;
 
    BadGuys(mapRows);
    Console.SetCursorPosition(savedCursorLeft, savedCursorTop);
    }
    
    
    
} while(true); 


stopwatch.Stop();
Console.Clear();
Console.ResetColor();

if(won)
{
Console.WriteLine("\n\nYOU WON THE MAZE");
//Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds/1000} seconds Score: {score}");
}
else
{
    Console.WriteLine("\nThe bad guy killed you. GAME OVER");
}
        Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds/1000} seconds Score: {score}");

static bool TryMove(int cursorTop,int cursorLeft, string[] mapRows, ref int score)
{
    Console.ResetColor();
    if (cursorTop >= 0 && cursorTop < mapRows.Length && cursorLeft >= 0
    && cursorLeft < mapRows[cursorTop].Length && mapRows[cursorTop][cursorLeft] 
    != '*' && cursorTop < Console.BufferHeight && cursorLeft < Console.BufferWidth)
    {
        //if(mapRows[cursorTop][cursorLeft] == '*')
        //{
         //   return false;
        //}
        

        if(mapRows[cursorTop][cursorLeft] == '%')
        {
            
            return false;
        }
       
        //int score = 0;
        if (mapRows[cursorTop][cursorLeft] == '^')
        {
            score += 100;
        //Console.SetCursorPosition(0, mapRows.Length + 1);
        //Console.WriteLine($"score: {score}");
        char[] row = mapRows[cursorTop].ToCharArray();
        row[cursorLeft] = ' ';
        mapRows[cursorTop] = new string(row);
        Console.SetCursorPosition(0, mapRows.Length + 1);
        Console.ResetColor();
        Console.WriteLine($"score: {score}   ");
        }
        if (mapRows[cursorTop][cursorLeft] == '$')
        {
            score += 200;
        //Console.SetCursorPosition(0, mapRows.Length + 1);
        //Console.WriteLine($"score: {score}");
        char[] row = mapRows[cursorTop].ToCharArray();
        row[cursorLeft] = ' ';
        mapRows[cursorTop] = new string(row);
        Console.SetCursorPosition(0, mapRows.Length + 1);
        Console.ResetColor();
        Console.WriteLine($"score: {score}   ");
        }
        if(score >= 1000)
        //for( int i = 0; i < mapRows.Length; i++)
        {
             for( int i = 0; i < mapRows.Length; i++)
            {
            mapRows[i] = mapRows[i].Replace('|', ' ');
            //Console.SetCursorPosition(0, i);
            //Console.Write(mapRows[i]);
            }
        }
        
        
        Console.SetCursorPosition(cursorLeft, cursorTop);
        return true;
        //Console.Write('@');
        
        
    }
    
    return true;
    
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
            Console.ForegroundColor = (ConsoleColor)rand.Next(16);
            Console.Write('%');
        } 
    
} */

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