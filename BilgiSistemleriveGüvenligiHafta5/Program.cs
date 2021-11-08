using System;
using System.Net;
using System.Net.Mail;
using Helpers;

namespace BilgiSistemleriveGüvenligiHafta5
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.GenerateOneTimePassword();

        }
    }
}
