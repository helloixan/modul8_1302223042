using System;
using System.Text.Json;
using modul8_1302223042;

public class Program
{
    public static void Main(string[] args)
    {
        AppConfig configApp = new AppConfig();

        if (configApp.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int nominal = int.Parse(Console.ReadLine());
        int biaya_tf;
        if (nominal <= configApp.config.transfer.threshold)
        {
            biaya_tf = configApp.config.transfer.low_fee;
        }
        else
        {
            biaya_tf = configApp.config.transfer.high_fee;
        }

        int total_biaya = nominal + biaya_tf;

        if (configApp.config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biaya_tf} \nTotal amount = {nominal + biaya_tf}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {biaya_tf}");
            Console.WriteLine($"Total biaya = {nominal + biaya_tf}");
        }

        configApp.PrintMetodeTransfer();
        string metode = Console.ReadLine();
        configApp.ConfirmationPhase();
    }
}