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
                    try {

                        string lijnSubstring = lijn.Substring(lijn.IndexOf('(') + 1, lijn.IndexOf(')') - lijn.IndexOf('(') - 1);
                        string[] ingelezenGegevens = lijnSubstring.Split(',');

                        int sessienummer = int.Parse(ingelezenGegevens[0]);
                        DateTime datum = DateTime.Parse(ingelezenGegevens[1].Trim('\''));
                        int klantnummer = int.Parse(ingelezenGegevens[2]);
                        int trainingsduur = int.Parse(ingelezenGegevens[3]);
                        double gemiddeldeSnelheid = double.Parse(ingelezenGegevens[4], System.Globalization.CultureInfo.InvariantCulture);
                        int sequentieNr = int.Parse(ingelezenGegevens[5]);
                        int interval = int.Parse(ingelezenGegevens[6]);
                        double loopsnelheid = double.Parse(ingelezenGegevens[7], System.Globalization.CultureInfo.InvariantCulture);

                        if(sessienummer <= 0) {
                            throw new RunningException("LeesData | sessienummer is niet groter dan 0 : " + sessienummer);
                        }

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
