using RunningBL;
using RunningDataLaag;
using System;
using System.Collections.Generic;

namespace FitnessApplicatie {
    class Program {
        static void Main(string[] args) {
            string brondata = "insertRunning.sql";
            string logdata = "logging.txt";

            Bestandlezer bestandlezer = new Bestandlezer();
            List<Runningsession> data = bestandlezer.LeesData(brondata, logdata);

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
