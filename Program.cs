
using System.Globalization;
using System.Text;

string pathTest = @"2_feladat\teszt_input_7forduló.txt";
string path_2_feladat = @"2_feladat\input_7forduló_2feladat.txt";
string path_3_feladat = @"3_feladat\input_7forduló_3feladat.txt";
//string path_4_feladat = @"4_feladat\input_7fordulo_4feladat.txt";

System.Console.WriteLine($"teszt input eredménye: {MaximumFreeSquare(pathTest)}");   
System.Console.WriteLine($"2. feladat eredménye: {MaximumFreeSquare(path_2_feladat)}");
System.Console.WriteLine($"3. feladat eredménye: {MaximumFreeSquare(path_3_feladat)}");
//System.Console.WriteLine($"4. feladat eredménye: {MaximumFreeSquare(path_4_feladat)}");

static int MaximumFreeSquare(string path)
{
    int maxFreeArea = 0;
    string contents = File.ReadAllText(path);
    string[] bylines = contents.Split("\r\n");
    string[] whk = bylines[0].Split(" ");
    int width = int.Parse(whk[0]);
    int hight = int.Parse(whk[1]);
    int chips = int.Parse(whk[2]);
   
    string[ , ] positions = new string[hight, width];

    for (int line=0; line < hight; line++)
    {
        for (int col=0; col<width; col++)
        {
            positions[line , col] = "e";
        }
    }

    for (int blocks = 0; blocks < chips; blocks++)
    {
        string[] actualLine = bylines[blocks + 1].Split(" ");
        int[] actualNums = new int[actualLine.Length];
        for (int i = 0; i < actualLine.Length; i++)
        {
            actualNums[i] = int.Parse(actualLine[i]);
        }
        for (int line=actualNums[1]; line<actualNums[1] + actualNums[3]; line++ )
        {
            for (int col=actualNums[0]; col < actualNums[0] + actualNums[2]; col++ )
            {
                positions[line , col] = "b";
            }
        }  
    }


    for (int leftCornerY=0; leftCornerY<hight; leftCornerY++)
    {
        for (int leftCornerX=0; leftCornerX<width; leftCornerX++)
        {
            if (positions[leftCornerY,leftCornerX]=="b")
            {
                break;
            }
            else
            {
                int maxHightIndex = hight-1;
                int maxWidthIndex = width-1;
                for (int m = leftCornerY; m < hight; m++ )
                {
                    if (positions[m,leftCornerX]=="b")
                    {
                        maxHightIndex = m-1;
                        break;
                    }
                }
            
                for (int actualLine=leftCornerY; actualLine <= maxHightIndex; actualLine++)
                {
                    int actualArea=0;
                    for (int actualCol=leftCornerX; actualCol<=maxWidthIndex; actualCol++)
                    {
                        if (positions[actualLine,actualCol]=="b")
                        {
                            if (actualCol < maxWidthIndex) maxWidthIndex=actualCol-1; 
                            break;
                        }
                    }    
                    actualArea = (maxWidthIndex-leftCornerX+1)*(actualLine-leftCornerY+1);
                    if (actualArea > maxFreeArea) maxFreeArea = actualArea;
                }
                
            }
        }
    }
    return maxFreeArea;
}






   

    









