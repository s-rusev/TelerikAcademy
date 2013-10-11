using System;
/*A company has name, address, phone number, fax number, web site and manager.
 * The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information about a company and its manager and prints them on the console.
 */
class CompanyInfo
{
    static void Main()
    {
        string companyName;
        string companyAddress;
        string companyNum;
        string companyFaxNum;
        string companyWebSite;
        string manFirstName;
        string manSecondName;
        string manLastName;
        Console.WriteLine("Enter company name: ");
        companyName = Console.ReadLine();
        Console.WriteLine("Enter company address: ");
        companyAddress = Console.ReadLine();
        Console.WriteLine("Enter company number: ");
        companyNum = Console.ReadLine();
        Console.WriteLine("Enter company fax number: ");
        companyFaxNum = Console.ReadLine();
        Console.WriteLine("Enter company web site: ");
        companyWebSite = Console.ReadLine();
        Console.WriteLine("Enter manager first name: ");
        manFirstName = Console.ReadLine();
        Console.WriteLine("Enter manager second name: ");
        manSecondName = Console.ReadLine();
        Console.WriteLine("Enter manager third name: ");
        manLastName = Console.ReadLine();
        Console.WriteLine(companyName + " " + companyAddress + " " + companyNum + " " + companyFaxNum +
            " " + companyWebSite + " " + manFirstName + " " + manSecondName + " " + manLastName);
    }
}

