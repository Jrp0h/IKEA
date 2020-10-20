using System;
using System.IO;
using System.Collections.Generic;

using ikea.Token;

// TODO: Add function begin and end
namespace ikea
{
   static class IKEA
   {
      static string[] lines;
      static int currentLine;
      static int nextLine;

      // Implement a callstack
      static int callFromLine;

      static bool isInFunction = false;

      static List<Token.Token> tokens = new List<Token.Token>();

      static ProgramSegment sections = new ProgramSegment("SEC", "Section");
      static ProgramSegment functions = new ProgramSegment("FUN", "Function");

      private static bool hasLoaded = false;

      public static void Load(string _filePath)
      {
         tokens = new List<Token.Token>();
         sections = new ProgramSegment("SEC", "Section");
         functions = new ProgramSegment("FUN", "Function");

         Register.Initialize();

          if(!File.Exists(_filePath))
              throw new Exception("File not found");
          
        lines = File.ReadAllLines(_filePath);

        InitTokens();
        Clean();
        FindSegments();

        hasLoaded = true;
        currentLine = 0;
        nextLine = 0;
        callFromLine = -1;
        isInFunction = false;
      }


      public static void Run()
      {
         if(!hasLoaded)
            throw new Exception("No file has been loaded, call IKEA.Load first");

         ReadNextLine();
      }

      private static void ReadNextLine()
      {
         currentLine = nextLine++;

         if(currentLine == lines.Length)
            return;

         if(lines[currentLine].StartsWith("FUN"))
         {
            isInFunction = true;
            ReadNextLine();
            return;
         }

         if(lines[currentLine].StartsWith("EFUN"))
         {
            if(!isInFunction)
               throw new Exception("Tried ending a function that has not been started");

            isInFunction = false;
            ReadNextLine();
            return;
         }


         // Skip empty lines and lines of function declaration
         if(lines[currentLine] == "" || isInFunction)
         {
            ReadNextLine();
            return;
         }

         foreach (Token.Token t in tokens)
         {
            // If it matches, skip the other
            if(t.Parse(lines[currentLine], currentLine))
            {
               ReadNextLine();
               return;
            }
         }

         if(!(lines[currentLine].StartsWith("FUN") || lines[currentLine].StartsWith("SEC")))
            System.Console.WriteLine($"Unparsable line {currentLine + 1}: {lines[currentLine]}");

         // Fix INVALID Instruction
         ReadNextLine();
      }

      public static void SetNextLine(int _nextLine)
      {
         nextLine = _nextLine;
      }

      public static void SetCallFromLine(int _callFromLine)
      {
         callFromLine = _callFromLine;
      }

      public static int GetCallFromLine()
      {
         return callFromLine;
      }

      public static int GetFunctionLocation(string _functionname)
      {
         return functions.GetLocation(_functionname);
      }

      public static int GetSectionLocation(string _sectionname)
      {
         return sections.GetLocation(_sectionname);
      }

      private static void InitTokens()
      {
         tokens.Add(new JMPToken());
         tokens.Add(new JMPBToken());
         tokens.Add(new CALLToken());
         tokens.Add(new PRNTToken());
      }

      // Cleans the IKEA code from all Comments
      // and Trim lines
      private static void Clean()
      {
        for(int i = 0; i < lines.Length; i++)
        {
            int commentStart = lines[i].IndexOf(';');
            if(commentStart >= 0)
                lines[i] = lines[i].Substring(0, commentStart);

            lines[i] = lines[i].Trim();
        }
      }

      private static void FindSegments(){

        for(int i = 0; i < lines.Length; i++)
        {
            if(lines[i] == "")
                continue;

            if(!sections.Parse(lines[i], i))
                functions.Parse(lines[i], i);
        }
      }

      public static void PrintSections()
      {
        sections.Print();
      }

      public static void PrintFunctions()
      {
        functions.Print();
      }
   } 
}
