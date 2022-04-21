using System;
using System.Collections.Generic;

namespace RunningBL {
    public class Runningsession {
        public Runningsession(int sessieNr, DateTime datum, double gemiddeldeSnelheid, int klantNr, int totaleTrainingsduur) {
            ZetSessienummer(sessieNr);
            Datum = datum;
            ZetGemiddeldeSnelheid(gemiddeldeSnelheid);
            ZetKlantNummer(klantNr);
            ZetTotaleTrainingsduur(totaleTrainingsduur);
        }

        public int SessieNr { get; private set; }
        public DateTime Datum { get; private set; }
        public double GemiddeldeSnelheid { get; private set; }
        public int KlantNr { get; private set; }
        public int TotaleTrainingsduur { get; private set; } //In minuten
        private SortedList<int, Interval> Intervallen = new SortedList<int, Interval>();

        public IReadOnlyList<Interval> GeefIntervals() {
            return new List<Interval>(Intervallen.Values).AsReadOnly();
        }

        public void ZetSessienummer(int sessienummer) {
            if (sessienummer <= 0) {
                throw new RunningException("Runningsession-ZetSessieNummerd | Sessienummer: " + sessienummer);
            }
            SessieNr = sessienummer;
        }
        public void ZetKlantNummer(int klantnummer) {
            if (klantnummer <= 0) {
                throw new RunningException("Runningsession-ZetKlantNummer | Klantnummer: " + klantnummer);
            }
            KlantNr = klantnummer;
        }
        public void ZetTotaleTrainingsduur(int totaleTrainingsduur) {
            if (totaleTrainingsduur < 5 || totaleTrainingsduur > 3 * 60) {
                throw new RunningException("Runningsession-ZetTotaleTrainingsduur | Een sessie duurt minstens 5 minuten en mag niet langer duren dan 3 uur " + totaleTrainingsduur + " minuten duurt jouw training");
            }
            TotaleTrainingsduur = totaleTrainingsduur;
        }
        public void ZetGemiddeldeSnelheid(double gemiddeldeSnelheid) {
            if (gemiddeldeSnelheid < 5 || gemiddeldeSnelheid > 22) {
                throw new RunningException("Runningsession-ZetGemiddeldeSnelheid | De snelheid mag niet lager zijn dan 5 en niet hoger dan 22 km / h.: De ingevoerde snelheid was: " + gemiddeldeSnelheid);
            }
            GemiddeldeSnelheid = gemiddeldeSnelheid;
        }
        public void VoegIntervalToe(Interval interval) {
            if (Intervallen.ContainsKey(interval.Sequentienummer)) {
                throw new RunningException("Runningsession-VoegIntervalToe");
            }
            Intervallen.Add(interval.Sequentienummer, interval);
        }
        public override string ToString() {
            return $"{SessieNr}, {KlantNr}, {Datum}, {TotaleTrainingsduur}";
        }
    }
}
