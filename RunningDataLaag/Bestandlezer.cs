using RunningBL;
using System;
using System.Collections.Generic;
using System.IO;

namespace RunningDataLaag {
    public class Bestandlezer {
        public List<Runningsession> LeesData(string bestandsnaam, string logBestandsnaam) {

            Dictionary<int, Runningsession> data = new Dictionary<int, Runningsession>(); // key = sessienummer

            using (StreamReader sr = new StreamReader(bestandsnaam))
            using (StreamWriter sw = new StreamWriter(logBestandsnaam)) {
                string lijn;
                while ((lijn = sr.ReadLine()) != null) {
                    string lijnSubstring = lijn.Substring(lijn.IndexOf('(') + 1, lijn.IndexOf(')') - lijn.IndexOf('(') - 1);
                    string[] lijnArray = lijnSubstring.Split(',');

                    int sessienummer = int.Parse(lijnArray[0]);
                    DateTime datum = DateTime.Parse(lijnArray[1].Trim('\''));
                    int klantnummer = int.Parse(lijnArray[2]);
                    int trainingsduur = int.Parse(lijnArray[3]);
                    double gemiddeldeSnelheid = double.Parse(lijnArray[4], System.Globalization.CultureInfo.InvariantCulture);
                    int sequentieNr = int.Parse(lijnArray[5]);
                    int interval = int.Parse(lijnArray[6]);
                    double loopsnelheid = double.Parse(lijnArray[7], System.Globalization.CultureInfo.InvariantCulture);

                    try {
                        Interval loopinterval = new Interval(sequentieNr, interval, loopsnelheid);
                            
                        if (!data.ContainsKey(sessienummer)) {
                            data.Add(sessienummer, new Runningsession(sessienummer, datum, gemiddeldeSnelheid, klantnummer, trainingsduur));
                        }
                        data[sessienummer].VoegIntervalToe(loopinterval);
                    } catch (RunningException ex) {
                        sw.WriteLine(ex.Message);
                    }
                    
                }
            }
            return new List<Runningsession>(data.Values);
        }
    }
}
