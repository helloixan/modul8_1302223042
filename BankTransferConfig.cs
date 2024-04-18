using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302223042
{
    public class BankTransferConfig
    {
        public String lang { get; set; }
        public class Transfer {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set;}
        }

        public Transfer transfer { get; set; }

        public string[] methods { get; set; }
        public class Confirmation
        {
            public String en {  get; set; }
            public String id { get; set; }
        }
        public Confirmation confirmation { get; set; }
    }

    public class AppConfig
    {
        public BankTransferConfig config { get; set; }
        private const string file_path = "../../../bank_transfer_config.json";

        public AppConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(file_path);
            this.config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
        }

        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String text = JsonSerializer.Serialize(config);
            File.WriteAllText(file_path, text);
        }

        public void SetDefault()
        {
            config = new BankTransferConfig();
            
            config.lang = "en";
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.methods = new string[] {"RTO (real time)", "SKN", "RTGS", "BI FAST"};
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";
        }

       public void PrintMetodeTransfer()
        {
            if (config.lang == "en")
            {
                Console.WriteLine("Select transfer method");
            }
            else
            {
                Console.WriteLine("Pilih metode transfer");
            }

            for (int i = 0; i < config.methods.Length; i++)
            {
                Console.WriteLine($"{i+1}. config.methods[i]");
            }
        }

        public void ConfirmationPhase()
        {
            if (config.lang == "en")
            {
                Console.WriteLine($"Please type {config.confirmation.en} to confirm the transaction:");
            }
            else
            {
                Console.WriteLine($"Ketik {config.confirmation.id} untuk mengkonfirmasi transaksi: ");
            }
            string konfirmasi = Console.ReadLine();

            if (konfirmasi == config.confirmation.en || konfirmasi == config.confirmation.id)
            {

                if (config.lang == "en")
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
            }
            else
            {
                if (config.lang == "en")
                {
                    Console.WriteLine("Transfer is cancelled");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}
