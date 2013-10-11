﻿using System;
using System.Text.RegularExpressions;

class ReplaceAnchorsWithUML
{
    static void Main()
    {
        Console.WriteLine("A program that replaces all anchors in html document (represented as a string) with corresponding URL.");
        Console.WriteLine("Enter the html:");
        string htmlString = Console.ReadLine();
//            @"<p>Please visit <a href=\""http://academy.telerik.com\"">our site</a> 
//        to choose a training course. Also visit <a href=\""www.devbg.org\"">our forum</a> to 
//        discuss the courses.</p>";

        Console.WriteLine(Regex.Replace(htmlString, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]"));
    }
}