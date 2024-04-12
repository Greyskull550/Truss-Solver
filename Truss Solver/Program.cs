// welcome to the truss solver 

using Spectre.Console;
using Truss_Solver;

var green = "[#11634F]";
var gold = "[#F9CF2F]";
var orange = "[#Ffa500]";

var running = true;
Console.WriteLine("*************************************************************************************");
Console.WriteLine("#######                                 #####                                     \r\n   #    #####  #    #  ####   ####     #     #  ####  #      #    # ###### #####  \r\n   #    #    # #    # #      #         #       #    # #      #    # #      #    # \r\n   #    #    # #    #  ####   ####      #####  #    # #      #    # #####  #    # \r\n   #    #####  #    #      #      #          # #    # #      #    # #      #####  \r\n   #    #   #  #    # #    # #    #    #     # #    # #       #  #  #      #   #  \r\n   #    #    #  ####   ####   ####      #####   ####  ######   ##   ###### #    # ");
Console.WriteLine("*************************************************************************************");
AnsiConsole.MarkupLine($"{gold}Arra Solver V.0.1 [/]");

while (running)
{
    var choice1 = AnsiConsole.Prompt(
     new SelectionPrompt<string>()
         .Title("[#11634F]Select a Function[/]?")
         .PageSize(10)
         .MoreChoicesText("[grey]()overflow[/]")
         .AddChoices(new[] {
            "5 Member", "9 Member", "Angle", "Credits","Exit",

         }));

    if (choice1 == "5 Member")
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"{orange} 5 member truss[/]");

        // get variables 
        // I am using a Spectre function that will prompt for input and valadate the responce. 

        var topPoint = AnsiConsole.Ask<double>($"{gold}Enter force on Top Point:[/]");

        var legnthAB = AnsiConsole.Ask<double>($"{gold}Enter Legnth AB: [/]");

        var legnthAC = AnsiConsole.Ask<double>($"{gold}Enter Legnth AC: [/]");

        var legnthBC = AnsiConsole.Ask<double>($"{gold}Enter Legnth BC:[/]");

        var legnthBD = AnsiConsole.Ask<double>($"{gold}Enter Legnth BD: [/]");

        var legnthCD = AnsiConsole.Ask<double>($"{gold}Enter Legnth CD: [/]");

        var angleA = AnsiConsole.Ask<double>($"{gold}Enter Angle a:  [/]");
        double angleARad = RadConvert.ConvertToRad(angleA);

        var angleB = AnsiConsole.Ask<double>($"{gold}Enter Angle b: [/] ");
        double angleBRad = RadConvert.ConvertToRad(angleB);

        var angleC = AnsiConsole.Ask<double>($"{gold}Enter Angle c:  [/]");

        var angleD = AnsiConsole.Ask<double>($"{gold}Enter Angle d:  [/]");

        AnsiConsole.MarkupLine($"{green}calculating please be patent ......... [/]");
        Thread.Sleep(5000);

        AnsiConsole.MarkupLine($"{green}Solving for External Forces[/]");
        AnsiConsole.MarkupLine($"{gold}FA,X = 0 Lb [/]");
        AnsiConsole.MarkupLine($"{green}FAy(0)+(-{topPoint})({legnthAC})+FDy({legnthAC + legnthCD})[/]");

        double fDY = (topPoint * legnthAC) / (legnthAC + legnthCD);
        fDY = Math.Round(fDY, 1);
        double fAY = topPoint - fDY;
        AnsiConsole.MarkupLine($"{gold} FD,Y = {fDY} Lb [/]");

        AnsiConsole.MarkupLine($"{green}FA,Y + FD,Y = {topPoint}[/]");

        AnsiConsole.MarkupLine($"{gold} FD,Y = b\n[/]");
        AnsiConsole.MarkupLine($"{green}Solving Internal Forces\n[/]");

        AnsiConsole.MarkupLine($"{green}Fbd pt.A[/]");
        AnsiConsole.MarkupLine($"[darkcyan]{fAY} + FA,B * Sin({angleA}) = 0[/]");
        double fAB = (fAY * -1) / Math.Sin(angleARad);
        fAB = Math.Round(fAB, 1);
        AnsiConsole.MarkupLine($"{gold}FAB = {fAB} Lb)\n[/]");

        // Calculate FAC
        double fAC = -fAB * Math.Cos(angleARad);
        //double fAC = fAY *  Math.Cos(angleA * Math.PI / 180);
        fAC = Math.Round(fAC, 1);

        AnsiConsole.MarkupLine($"{gold}FAC = {fAC} Lb)[/]\n");

        AnsiConsole.MarkupLine($"{green}FBD pt C[/]");
        double fCD = fAC;
        double fCB = 0;

        AnsiConsole.MarkupLine($"{gold}FCD = {fCD}[/]");
        AnsiConsole.MarkupLine($"{gold}FCB = {fCB}[/]");

        AnsiConsole.MarkupLine($"{green}FBD pt D[/]");

        double fDB = -fCD / Math.Cos(angleBRad);
        fDB = Math.Round(fDB, 1);

        AnsiConsole.MarkupLine($"{gold}FDB = {fDB} [/]");

        var choice2 = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("[#11634F]Select a Function[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey]()overflow[/]")
        .AddChoices(new[] {
            "Reprint","Save","Exit",

        }));

        if (choice2 == "Reprint")
        {
            var Reprint = true;
            while (Reprint)
            {
                AnsiConsole.MarkupLine($"{green}Reprinting results[/]");
                AnsiConsole.MarkupLine($"{gold} FD,Y = {fDY} Lb [/]");
                AnsiConsole.MarkupLine($"{gold}FD,Y = b[/]");
                AnsiConsole.MarkupLine($"{green} Internal Forces[/]");
                AnsiConsole.MarkupLine($"{gold}FAB = {fAB} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FAC = {fAC} Lb[/]");
                AnsiConsole.MarkupLine($"{gold}FCD = {fCD}[/]");
                AnsiConsole.MarkupLine($"{gold}FCB = {fCB}[/]");
                AnsiConsole.MarkupLine($"{gold}FDB = {fDB} [/]");

                var choice3 = AnsiConsole.Prompt(
   new SelectionPrompt<string>()
       .Title("[#11634F]Select a Function[/]?")
       .PageSize(10)
       .MoreChoicesText("[grey]()overflow[/]")
       .AddChoices(new[] {
            "Reprint","Save","Exit",

       }));
                if (choice3 == "Reprint")
                {
                    Reprint = true;
                }
                else if (choice3 == "Exit")
                {
                    Reprint = false;
                }

            }


        }
        else if (choice2 == "Save")
        {
         
            AnsiConsole.MarkupLine($"{orange} saved to file[/]");
        }
        else if (choice2 == "Exit")
        {
            Console.Clear();
        }

    }


    else if (choice1 == "9 Member")
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"{orange} 9 member truss[/]");
        // get variables  

        var FFY = AnsiConsole.Ask<double>($"{gold}Enter Force on FFY \t[/]");

        var FFE = AnsiConsole.Ask<double>($"{gold}Enter Force on FFE \t[/]");
        double topPoints = FFY + FFE;

        var legnthAB = AnsiConsole.Ask<double>($"{gold}Enter legnthAB \t[/]");

        var legnthAF = AnsiConsole.Ask<double>($"{gold} Enter legnthAF \t[/]");

        var legnthBC = AnsiConsole.Ask<double>($"{gold} Enter legnthBC \t[/]");

        var legnthFB = AnsiConsole.Ask<double>($"{gold} Enter legnthFB \t[/]");

        var legnthCD = AnsiConsole.Ask<double>($"{gold} Enter legnthCD \t[/]");

        var legnthBE = AnsiConsole.Ask<double>($"{gold} Enter legnthBE \t[/]");

        var legnthED = AnsiConsole.Ask<double>($"{gold} Enter legnthED \t[/]");

        var legnthFE = AnsiConsole.Ask<double>($"{gold} Enter legnthFE \t[/]");



        var angleA = AnsiConsole.Ask<double>($"{gold} Enter angleA \t[/]");
        double angleARad = RadConvert.ConvertToRad(angleA);

        var angleB = AnsiConsole.Ask<double>($"{gold} Enter angleB \t[/]");

        double angleBRad = RadConvert.ConvertToRad(angleB);
        double angleBCalc = (90 + angleB) * -1;
        double angleBCalcRad = RadConvert.ConvertToRad(angleBCalc);


        var angleC = AnsiConsole.Ask<double>($"{gold} Enter angleC \t[/]");
        double angleCRad = RadConvert.ConvertToRad(angleC);


        var angleD = AnsiConsole.Ask<double>($"{gold} Enter angleD \t[/]");

        var angleE = AnsiConsole.Ask<double>($"{gold} Enter angleE \t[/]");



        var angleF = AnsiConsole.Ask<double>($"{gold} Enter angleF \t[/]");
        double angleFRad = RadConvert.ConvertToRad(angleF);

        AnsiConsole.MarkupLine($"{green}calculating please be patent ......... [/]");
        Thread.Sleep(5000);


        AnsiConsole.MarkupLine($"{green}Solving for External Forces[/]");
        AnsiConsole.MarkupLine($"{gold}FA,X = 0 Lb [/]");
        AnsiConsole.MarkupLine($"{gold}FAy(0)+(-{FFY})({legnthAB})+({FFE})({legnthAB + legnthBC})+(FDY)({legnthAB + legnthBC + legnthCD})= 0[/]");
        double fDY = ((FFY * legnthAB) + (FFE * (legnthAB + legnthBC))) / (legnthAB + legnthBC + legnthCD);
        fDY = Math.Round(fDY, 1);
        double fAY = topPoints - fDY;


        AnsiConsole.MarkupLine($"{gold}FD,Y = {fDY} Lb[/]");//yellow

        AnsiConsole.MarkupLine($"{gold}FA,Y + FD,Y = {topPoints}[/]");

        AnsiConsole.MarkupLine($"{gold} FA,Y= {fAY} Lb\n[/]");

        AnsiConsole.MarkupLine($"{green}Solving Internal Forces\n[/]");

        //Console.WriteLine("Fbd pt.A");
        //Console.WriteLine($"{fAY} + FA,B * Sin({angleA}) = 0");
        double FAF = (fAY * -1) / Math.Sin(angleARad);
        FAF = Math.Round(FAF, 1);

        AnsiConsole.MarkupLine($"{gold}FAF = {FAF} Lb)\n[/]");


        // Calculate FAB
        double FAB = -FAF * Math.Cos(angleARad);

        FAB = Math.Round(FAB, 1);

        AnsiConsole.MarkupLine($"{gold}FAB = {FAB} Lb)\n[/]");


        //Console.WriteLine("fbd pt.F");
        double FFe = FAF * Math.Sin(angleARad);
        FFe = Math.Round(FFe, 1);

        AnsiConsole.MarkupLine($"{gold}FED = {FFe} Lb)\n[/]");


        double FFB = (-FFY) + (FAF * Math.Sin(angleBCalcRad));
        FFB = Math.Round(FFB, 1);


        AnsiConsole.MarkupLine($"{gold}FFB = {FFB} Lb)\n[/]");


        //calcuate fbe
        double FBE = -FFB / Math.Sin(angleCRad);
        FBE = Math.Round(FBE, 1);

        AnsiConsole.MarkupLine($"{gold}FBE = {FBE} Lb)\n[/]");


        double FED = (fDY * -1) / Math.Sin(angleFRad);
        FED = Math.Round(FED, 1);

        AnsiConsole.MarkupLine($"{gold}FED = {FED} Lb)\n[/]");


        // Calculate FCD
        double fCD = -FED * Math.Cos(angleFRad);
        fCD = Math.Round(fCD, 1);

        AnsiConsole.MarkupLine($"{gold}FCD = {fCD} Lb)[/]");


        //FBC 
        double FBC = fCD;

        AnsiConsole.MarkupLine($"{gold}FBC = {FBC} Lb)[/]");

        var choice2 = AnsiConsole.Prompt(
new SelectionPrompt<string>()
.Title("[#11634F]Select a Function[/]?")
.PageSize(10)
.MoreChoicesText("[grey]()overflow[/]")
.AddChoices(new[] {
            "Reprint", "Save","Exit",

}));

        if (choice2 == "Reprint")
        {
            var Reprint = true;
            while (Reprint)
            {
                AnsiConsole.MarkupLine($"{gold}FA,X = 0 Lb [/]");
                AnsiConsole.MarkupLine($"{gold}FD,Y = {fDY} Lb[/]");//yellow
                AnsiConsole.MarkupLine($"{gold}FA,Y + FD,Y = {topPoints}[/]");
                AnsiConsole.MarkupLine($"{gold}FA,Y= {fAY} Lb[/]");
                AnsiConsole.MarkupLine($"{gold}FAF = {FAF} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FAB = {FAB} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FED = {FFe} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FFB = {FFB} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FBE = {FBE} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FED = {FED} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FCD = {fCD} Lb)[/]");
                AnsiConsole.MarkupLine($"{gold}FBC = {FBC} Lb)[/]");


                var choice3 = AnsiConsole.Prompt(
   new SelectionPrompt<string>()
       .Title("[#11634F]Select a Function[/]?")
       .PageSize(10)
       .MoreChoicesText("[grey]()overflow[/]")
       .AddChoices(new[] {
            "Reprint", "Save","Exit",

       }));
                if (choice3 == "Reprint")
                {
                    Reprint = true;
                }
                else if (choice3 == "Exit")
                {
                    Reprint = false;
                }

            }


        }
        else if (choice2 == "Save")
        {
            AnsiConsole.MarkupLine($"{orange} saved to file[/]");
        }
        else if (choice2 == "Exit")
        {
            Console.Clear();
        }

    }

    else if (choice1 == "Angle")
    {
        Console.Clear();
      
        var opposite = AnsiConsole.Ask<double>($"{gold} Enter opposite \t[/]");
        var adjacent = AnsiConsole.Ask<double>($"{gold} enter the adjacent\t[/]");

        double Radians = Math.Atan(opposite / adjacent);
        double Degrees = Radians * (180.0 / Math.PI);

        var choice2 = AnsiConsole.Prompt(
new SelectionPrompt<string>()
.Title("[#11634F]Select a Function[/]?")
.PageSize(10)
.MoreChoicesText("[grey]()overflow[/]")
.AddChoices(new[] {
            "Reprint", " Save to File","Exit",

}));

        if (choice2 == "Reprint")
        {
            var Reprint = true;
            while (Reprint)
            {

                AnsiConsole.MarkupLine($"{gold}FBC = {Degrees} Lb)[/]");


                var choice3 = AnsiConsole.Prompt(
   new SelectionPrompt<string>()
       .Title("[#11634F]Select a Function[/]?")
       .PageSize(10)
       .MoreChoicesText("[grey]()overflow[/]")
       .AddChoices(new[] {
            "Reprint", " Save to File","Exit",

       }));
                if (choice3 == "Reprint")
                {
                    Reprint = true;
                }
                else if (choice3 == "Exit")
                {
                    Reprint = false;
                }
            }
        }
    }
    else if (choice1 == "Credits")
    {
        Console.WriteLine("You must 'truss' this app ");
        Console.WriteLine("TrussSolver v0.2 pre Beta release");


    }
    else if (choice1 == "Exit")
    {
        running = false;
    }
    else
    {
        Console.WriteLine("INVALID INPUT");
    }

}




