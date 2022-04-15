using RunningDataLaag;
using System;

namespace FitnessApplicatie {
    class Program {
        static void Main(string[] args) {
            string brondata = "C:\\Users\\miked\\Documents\\school\\HOGENT\\semester 2\\insertRunning\\insertRunning.sql";
            string brondata2 = @"C:\Users\miked\Documents\school\HOGENT\semester 2\insertRunning\insertRunningTest.txt";
            string logdata = @"C:\Users\miked\Documents\school\HOGENT\semester 2\insertRunning\logging.txt";

            Bestandlezer bestandlezer = new Bestandlezer();
            var data = bestandlezer.LeesData(brondata, logdata);

            Console.WriteLine(data);

            Databeheerder beheerder = new Databeheerder(data);
            var trainingenKlant = beheerder.GeefTrainingenKlant(154);
            foreach (var item in trainingenKlant) {
                Console.WriteLine(item);
                foreach (var interval in item.GeefIntervals()) {
                    Console.WriteLine(interval);
                }
            }

            var trainingenDag = beheerder.GeefTrainingenDag(new DateTime(2021, 12, 1));
            foreach (var item in trainingenDag) {
                Console.WriteLine(item);
                foreach (var interval in item.GeefIntervals()) {
                    Console.WriteLine(interval);
                }
            }
        }
    }
}
