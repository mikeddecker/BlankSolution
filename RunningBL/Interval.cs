using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningBL {
    public class Interval {
        public Interval(int sequentienummer, int tijdsduurInSeconden, double gemiddeldeSnelheid) {
            SetSequentieNummer(sequentienummer);
            SetTijdsduurInSeconden(tijdsduurInSeconden);
            SetGemiddeldeSnelheid(gemiddeldeSnelheid);
        }

        public int Sequentienummer { get; private set; }
        public int TijdsduurInSeconden { get; private set; }
        public double GemiddeldeSnelheid { get; private set; }

        public void SetSequentieNummer(int sequentienummer) {
            if (sequentienummer <= 0) {
                throw new RunningException("Interval-SetSequentieNummer");
            }
            Sequentienummer = sequentienummer;
        }

        public void SetTijdsduurInSeconden(int tijdsduurInSeconden) {
            if (tijdsduurInSeconden < 5 || tijdsduurInSeconden > 3 * 60 * 60) {
                throw new RunningException("Interval-SetTijdsduurInSeconden");
            }
            TijdsduurInSeconden = tijdsduurInSeconden;
        }

        public void SetGemiddeldeSnelheid(double gemiddeldeSnelheid) {
            if (gemiddeldeSnelheid < 5 || gemiddeldeSnelheid > 22) {
                throw new RunningException("Interval-SetGemiddeldeSnelheid");
            }
            GemiddeldeSnelheid = gemiddeldeSnelheid;
        }
        public override string ToString() {
            return $"Seq.Nr: {Sequentienummer}, Tijdsduur: {TijdsduurInSeconden}sec, GemiddeldeSnelheid: {GemiddeldeSnelheid}";
        }
    }
}
