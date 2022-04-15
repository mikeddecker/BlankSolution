using RunningBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningDataLaag {
    public class Databeheerder {
        public Databeheerder(List<Runningsession> data) {
            // vul dictionary
            foreach (Runningsession sessie in data) {
                // Trainingen per klant
                if (!trainingVoorIedereKlant.ContainsKey(sessie.KlantNr)) {
                    trainingVoorIedereKlant.Add(sessie.KlantNr, new List<Runningsession> { sessie });
                } else {
                    trainingVoorIedereKlant[sessie.KlantNr].Add(sessie);
                }

                // Trainingen per dag
                if (!trainingPerDag.ContainsKey(sessie.Datum.Date)) {
                    trainingPerDag.Add(sessie.Datum.Date, new List<Runningsession> { sessie });
                } else {
                    trainingPerDag[sessie.Datum.Date].Add(sessie);
                }
            }
        }
        private Dictionary<int, List<Runningsession>> trainingVoorIedereKlant = new Dictionary<int, List<Runningsession>>(); // KeY = KlantID met zijn runningsessies
        private Dictionary<DateTime, List<Runningsession>> trainingPerDag = new Dictionary<DateTime, List<Runningsession>>(); //Key = Datum voor trainingen per dag.

        public List<Runningsession> GeefTrainingenKlant(int klantID) {
            if (trainingVoorIedereKlant.ContainsKey(klantID)) {
                return trainingVoorIedereKlant[klantID];
            } else {
                return null;
            }
        }

        public List<Runningsession> GeefTrainingenDag(DateTime datum) {
            if (trainingPerDag.ContainsKey(datum)) {
                return trainingPerDag[datum];
            } else {
                return null;
            }
        }
    }
}
