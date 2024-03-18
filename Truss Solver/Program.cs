// welcome to the truss solver 

using System.Threading.Channels;
using Truss_Solver;
using Spectre.Console;
using System.Diagnostics.Tracing;

var running = true;
Console.WriteLine("*************************************************************************************");
Console.WriteLine("#######                                 #####                                     \r\n   #    #####  #    #  ####   ####     #     #  ####  #      #    # ###### #####  \r\n   #    #    # #    # #      #         #       #    # #      #    # #      #    # \r\n   #    #    # #    #  ####   ####      #####  #    # #      #    # #####  #    # \r\n   #    #####  #    #      #      #          # #    # #      #    # #      #####  \r\n   #    #   #  #    # #    # #    #    #     # #    # #       #  #  #      #   #  \r\n   #    #    #  ####   ####   ####      #####   ####  ######   ##   ###### #    # ");
Console.WriteLine("*************************************************************************************");
Console.WriteLine("Arra Solver V.0.1" );

while (running)
{
    var choice = AnsiConsole.Prompt(
     new SelectionPrompt<string>()
         .Title("[green]Select a Function[/]?")
         .PageSize(10)
         .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
         .AddChoices(new[] {
            "5 Member", "9 Member", "Angle", "Credits","Exit",

         }));

    if (choice == "5 Member")
    {
        // get variables 
        AnsiConsole.Markup("[green]Enter force on Top Point: [/]");
        double topPoint = Convert.ToDouble(Console.ReadLine());

        AnsiConsole.Markup("[green]Enter Legnth AB: [/]");
        double legnthAB = Convert.ToDouble(Console.ReadLine());

        AnsiConsole.Markup("[green]Enter Legnth AC: [/]");
        double legnthAC = Convert.ToDouble(Console.ReadLine());

        AnsiConsole.Markup("[green]Enter Legnth BC:[/] ");
        double legnthBC = Convert.ToDouble(Console.ReadLine());

         AnsiConsole.Markup("[green]Enter Legnth BD: [/]");
        double legnthBD = Convert.ToDouble(Console.ReadLine());

        AnsiConsole.Markup("[green]Enter Legnth CD: [/]");
        double legnthCD = Convert.ToDouble(Console.ReadLine());


        AnsiConsole.Markup("[green]Enter Angle a:  [/]");
        double angleA = Convert.ToDouble(Console.ReadLine());
        double angleARad = RadConvert.ConvertToRad(angleA);
        AnsiConsole.Markup("[green]Enter Angle b: [/] ");
        double angleB = Convert.ToDouble(Console.ReadLine());
        double angleBRad = RadConvert.ConvertToRad(angleB);
        AnsiConsole.Markup("[green]Enter Angle c:  [/]");
        double angleC = Convert.ToDouble(Console.ReadLine());
        AnsiConsole.Markup("[green]Enter Angle d:  [/]");
        double angleD = Convert.ToDouble(Console.ReadLine());

        AnsiConsole.Markup("Solving for External Forces");
        AnsiConsole.Markup("FA,X = 0 Lb ");
        AnsiConsole.Markup($"FAy(0)+(-{topPoint})({legnthAC})+FDy({legnthAC + legnthCD})");
        double fDY = (topPoint * legnthAC) / (legnthAC + legnthCD);
        fDY = Math.Round(fDY, 1);
        double fAY = topPoint - fDY;
        
        AnsiConsole.Markup($"FD,Y = {fDY} Lb");//yellow
     
        Console.WriteLine($"FA,Y + FD,Y = {topPoint}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FA,Y= {fAY} Lb\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Solving Internal Forces\n");

        Console.WriteLine("Fbd pt.A");
        Console.WriteLine($"{fAY} + FA,B * Sin({angleA}) = 0");
        double fAB = (fAY * -1) / Math.Sin(angleARad);
        fAB = Math.Round(fAB, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FAB = {fAB} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        // Calculate FAC
        double fAC = -fAB * Math.Cos(angleARad);
        //double fAC = fAY *  Math.Cos(angleA * Math.PI / 180);
        fAC = Math.Round(fAC, 1);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FAC = {fAC} Lb)");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("FBD pt C");
        double fCD = fAC;
        double fCB = 0;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FCD = {fCD}");
        Console.WriteLine($"FCB = {fCB}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("FBD pt D");
        double fDB = -fCD / Math.Cos(angleBRad);
        fDB = Math.Round(fDB, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FDB = {fDB}");
        Console.ForegroundColor = ConsoleColor.White;

    }
    else if (choice == "9 Member")              
    {

        // get variables  
        //Console.Write("Enter force on Top Point: ");
        //  double topPoint = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter Force on FFY \t");
        double FFY = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Force on FFE \t");
        double FFE = Convert.ToDouble(Console.ReadLine());

        double topPoints = FFY + FFE;

        Console.Write("Enter legnthAB \t");
        double legnthAB = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthAF \t");
        double legnthAF = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthBC \t");
        double legnthBC = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthFB \t");
        double legnthFB = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthCD \t");
        double legnthCD = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthBE \t");
        double legnthBE = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthED \t");
        double legnthED = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter legnthFE \t");
        double legnthFE = Convert.ToDouble(Console.ReadLine());



        Console.Write("Enter angleA \t");
        double angleA = Convert.ToDouble(Console.ReadLine());
        double angleARad = RadConvert.ConvertToRad(angleA);

        Console.Write("Enter angleB \t");
        double angleB = Convert.ToDouble(Console.ReadLine());
        double angleBRad = RadConvert.ConvertToRad(angleB);

        double angleBCalc = (90 + angleB) * -1;
        Console.WriteLine(angleBCalc);
        double angleBCalcRad = RadConvert.ConvertToRad(angleBCalc);


        Console.Write("Enter angleC \t");
        double angleC = Convert.ToDouble(Console.ReadLine());
        double angleCRad = RadConvert.ConvertToRad(angleC);


        Console.Write("Enter angleD \t");
        double angleD = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter angleE \t");
        double angleE = Convert.ToDouble(Console.ReadLine());


        Console.Write("Enter angleF \t");
        double angleF = Convert.ToDouble(Console.ReadLine());
        double angleFRad = RadConvert.ConvertToRad(angleF);

        Console.WriteLine("calculating please be patent ......... ");
        Thread.Sleep(5000);


        Console.WriteLine("Solving for External Forces");
        Console.WriteLine("FA,X = 0 Lb ");
        Console.WriteLine($"FAy(0)+(-{FFY})({legnthAB})+({FFE})({legnthAB + legnthBC})+(FDY)({legnthAB + legnthBC + legnthCD})= 0");
        double fDY = ((FFY * legnthAB) + (FFE * (legnthAB + legnthBC))) / (legnthAB + legnthBC + legnthCD);
        fDY = Math.Round(fDY, 1);
        double fAY = topPoints - fDY;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FD,Y = {fDY} Lb");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"FA,Y + FD,Y = {topPoints}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FA,Y= {fAY} Lb\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Solving Internal Forces\n");

        //Console.WriteLine("Fbd pt.A");
        //Console.WriteLine($"{fAY} + FA,B * Sin({angleA}) = 0");
        double FAF = (fAY * -1) / Math.Sin(angleARad);
        FAF = Math.Round(FAF, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FAF = {FAF} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        // Calculate FAB
        double FAB = -FAF * Math.Cos(angleARad);

        FAB = Math.Round(FAB, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FAB = {FAB} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        //Console.WriteLine("fbd pt.F");
        double FFe = FAF * Math.Sin(angleARad);
        FFe = Math.Round(FFe, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FED = {FFe} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        double FFB = (-FFY) + (FAF * Math.Sin(angleBCalcRad));
        FFB = Math.Round(FFB, 1);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FFB = {FFB} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;


        //calcuate fbe
        double FBE = -FFB / Math.Sin(angleCRad);
        FBE = Math.Round(FBE, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FBE = {FBE} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        double FED = (fDY * -1) / Math.Sin(angleFRad);
        FED = Math.Round(FED, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FED = {FED} Lb)\n");
        Console.ForegroundColor = ConsoleColor.White;

        // Calculate FCD
        double fCD = -FED * Math.Cos(angleFRad);
        fCD = Math.Round(fCD, 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FCD = {fCD} Lb)");
        Console.ForegroundColor = ConsoleColor.White;

        //FBC 
        double FBC = fCD;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"FBC = {FBC} Lb)");
        Console.ForegroundColor = ConsoleColor.White;

    }

    else if (choice == "Angle")
    {
        //goofy bozo 
    }
    else if (choice == "Credits")
    {
        Console.WriteLine("You must 'truss' this app ");
        Console.WriteLine( "TrussSolver v0.2 pre Beta release");
       

    }
    else if (choice == "Exit")
    {
        running = false; 
    }
    else
    {
        Console.WriteLine("INVALID INPUT");
    }
   
    }
    
    


