﻿using System;
using System.Net;

class DownloadFile
{
    public static void DownloadFileMethod() 
    {
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Not enough memory!");
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid address");
            }
            catch (NotSupportedException exc)
            {
                Console.WriteLine("Unknown Protocol: " + exc.Message);
            }
            catch (ProtocolViolationException exc)
            {
                Console.WriteLine("Protocol Error: " + exc.Message);
            }
            catch (UriFormatException exc)
            {
                Console.WriteLine("URI Format Error: " + exc.Message);
            }
            finally
            {
                Console.WriteLine("Program executed.");
            }
        }
    }
    static void Main()
    {
        DownloadFileMethod();
    }
}