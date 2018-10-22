using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kaffeemaschinen;

namespace KaffeeGame
{
    public partial class Form1 : Form
    {
        //Wenn kein Index angegeben wird, beginnt die Zählung bei 0
        public enum KaffeemaschinenArten { PadMaschine = 1, Vollautomat = 2, Filtermaschine = 3 }

        public event Kaffeemaschine.FehlerEventHandler FehlerFall;

        //Kaffeemaschinen-Variablen
        FilterMaschine _filtermaschine;
        PadMaschine _padmaschine;
        Vollautomat _vollautomat;

        //Welche Kaffeemaschine ist aktuell ausgewählt? (allgemeinsten Datentypen verwendnen)
        Kaffeemaschine _ausgewählteMaschine;

        int _bestellteMenge;
        Type _bestellteSorte;

        int _score;
        int _zeit = 100;

        Random _random = new Random();


        //Konstruktor
        public Form1()
        {
            InitializeComponent();
            //ListBox mit Werten befüllen
            #region Automatisiertes Hinzufügen der Enum_Werte
            //foreach (var item in Enum.GetValues(typeof(KaffeemaschinenArten)))
            //{
            //    listBoxKaffeemaschine.Items.Add(item);
            //}  
            #endregion Automatisierte Variante

            listBoxKaffeemaschine.Items.Add(KaffeemaschinenArten.Filtermaschine);
            listBoxKaffeemaschine.Items.Add(KaffeemaschinenArten.PadMaschine);
            listBoxKaffeemaschine.Items.Add(KaffeemaschinenArten.Vollautomat);

            //Kaffeemaschinen erzeugen
            _filtermaschine = new FilterMaschine("Filtermaschine", 1000, 1000);
            _padmaschine = new PadMaschine("Padmaschine", 1000);
            _vollautomat = new Vollautomat("Vollautomat", 1000, 1000, 1000);

            //EventHandler für Bedienungsfehler-Event registrieren
            _filtermaschine.Bedienungsfehler += Bedienungsfehler_Handler;
            _padmaschine.Bedienungsfehler += Bedienungsfehler_Handler;
            _vollautomat.Bedienungsfehler += Bedienungsfehler_Handler;

            //EventHandler für FehlerFall-Event registrieren
            FehlerFall += Bedienungsfehler_Handler;

            //1. Bestellung
            BestelleNeuenKaffee();
        }

        private void Bedienungsfehler_Handler(object sender, FehlerEventArgs e)
        {
            //Fehlermeldung aktualisieren
            labelFehlermeldung.Text = e.Fehlermeldung;
            _score -= 2;
            //Vorher Timer stoppen, damit die Sekunden zurückgesetzt sind
            timerFehlerAusblenden.Stop();
            //Fehler nach 2 Sekunden entfernen
            timerFehlerAusblenden.Start();
        }

        //Was soll passieren, wenn der Nutzer ein anderes Element in der ListBox auswählt
        private void listBoxKaffeemaschine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxKaffeemaschine.SelectedItem == null)
                return;

            //MessageBox.Show("Nichts ausgewählt");

            KaffeemaschinenArten art = (KaffeemaschinenArten)listBoxKaffeemaschine.SelectedItem;
            switch (art)
            {
                case KaffeemaschinenArten.PadMaschine:
                    _ausgewählteMaschine = _padmaschine;
                    break;
                case KaffeemaschinenArten.Vollautomat:
                    _ausgewählteMaschine = _vollautomat;
                    break;
                case KaffeemaschinenArten.Filtermaschine:
                    _ausgewählteMaschine = _filtermaschine;
                    break;
                default:
                    throw new Exception("Unbekannte Maschinenart!");
            }

            labelKaffeebeschreibung.Text = _ausgewählteMaschine.ToString();
        }

        private bool prüfeNumerischenWert(TextBox textbox, out int wert, string art)
        {
            wert = 0;
            try
            {
                wert = int.Parse(textbox.Text);
            }
            catch (FormatException exp)
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs($"Die {art} {textBoxWasser.Text} ist keine gültige ganze Zahl."));
                return false;
            }
            catch (OverflowException exp)
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs($"Die {art} ist zu groß!"));
                return false;
            }
            catch (Exception exp)
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs(exp.Message));
                return false;
            }
            return true;
        }

        private void wasserButton_Click(object sender, EventArgs e)
        {
            FülleIrgendwasEin(() =>
            {
                if (!prüfeNumerischenWert(textBoxWasser, out int wassermenge, "Wassermenge"))
                {
                    return false;
                }

                _ausgewählteMaschine.Wasserstand += wassermenge;
                return true;
            });
        }

        public delegate bool FlexiblerCode();

        public void FülleIrgendwasEin(FlexiblerCode flexiblerCode)
        {
            if (_ausgewählteMaschine == null)
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs($"Keine Maschine ausgewählt"));
                return;
            }


            //Flexiblen Code ausführen
            if (!flexiblerCode())
            {
                return;
            }

            labelKaffeebeschreibung.Text = _ausgewählteMaschine.ToString();
        }

        private void buttonKaffee_Click(object sender, EventArgs e)
        {
            FülleIrgendwasEin(() =>
            {
                if (!prüfeNumerischenWert(textBoxKaffee, out int kaffeemenge, "Kaffeemenge"))
                {
                    return false;
                }

                #region Umständliche und fehleranfälligere Variante die Kaffeemaschinenart zu prüfen
                //if(_ausgewählteMaschine.GetType() == typeof(FilterMaschine) || _ausgewählteMaschine.GetType() == typeof(Vollautomat))
                #endregion
                if (_ausgewählteMaschine is FilterMaschine)
                {
                    FilterMaschine filter = (FilterMaschine)_ausgewählteMaschine;
                    filter.Kaffeestand += kaffeemenge;
                }
                else
                {
                    FehlerFall?.Invoke(this, new FehlerEventArgs("Das ist keine Filtermaschine!"));
                    return false;
                }
                return true;
            });
        }

        private void buttonMilch_Click(object sender, EventArgs e)
        {
            

            FülleIrgendwasEin(() => {
                if (!prüfeNumerischenWert(textBoxMilch, out int milchmenge, "Milchmenge"))
                {
                    return false;
                }
               
                #region Umständliche und fehleranfälligere Variante die Kaffeemaschinenart zu prüfen
                //if(_ausgewählteMaschine.GetType() == typeof(FilterMaschine) || _ausgewählteMaschine.GetType() == typeof(Vollautomat))
                #endregion
                if(_ausgewählteMaschine is IMilchEinfüllbar)
                {
                    IMilchEinfüllbar einfüllbareMaschine = (IMilchEinfüllbar)_ausgewählteMaschine;
                    einfüllbareMaschine.Milchstand += milchmenge;
                }
                else
                {
                    FehlerFall?.Invoke(this, new FehlerEventArgs($"Das ist kein Vollautomat!"));
                    return false;
                }
                return true;
            });
           
        }

        private void buttonPad_Click(object sender, EventArgs e)
        {

            FülleIrgendwasEin(() =>
            {
                #region Umständliche und fehleranfälligere Variante die Kaffeemaschinenart zu prüfen
                //if(_ausgewählteMaschine.GetType() == typeof(FilterMaschine) || _ausgewählteMaschine.GetType() == typeof(Vollautomat))
                #endregion
                if (_ausgewählteMaschine is PadMaschine)
                {
                    PadMaschine padmaschine = (PadMaschine)_ausgewählteMaschine;
                    if (padmaschine.PadEingelegt)
                    {
                        return false;
                    }
                    padmaschine.PadEingelegt = true;
                }
                else
                {
                    FehlerFall?.Invoke(this, new FehlerEventArgs("Keine PadMaschine ausgewählt!"));
                    return false;
                }
                return true;
            });
        }

        private void buttonZubereitung_Click(object sender, EventArgs e)
        {
            if (_ausgewählteMaschine == null)
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs("Keine Maschine ausgewählt!"));
                return;
            }
            //Prüfen ob die richtige Maschine ausgewählt wurde passend zur Bestellung
            if (_bestellteSorte != _ausgewählteMaschine.GetType())
            {
                FehlerFall?.Invoke(this, new FehlerEventArgs("Falsche Maschine ausgewählt!"));
                return;
            }

            if (_ausgewählteMaschine.BereiteKaffeeZu(_bestellteMenge))
            {
                MessageBox.Show("Kaffee wurde zubereitet!");
                _score += 5;
                BestelleNeuenKaffee();
            }

            labelKaffeebeschreibung.Text = _ausgewählteMaschine.ToString();
        }

        private void timerFehlerAusblenden_Tick(object sender, EventArgs e)
        {
            //lösche letzte Fehlermeldung
            labelFehlermeldung.Text = string.Empty;
            timerFehlerAusblenden.Stop();
        }


        private void BestelleNeuenKaffee()
        {
            _bestellteMenge = _random.Next(1, 11) * 100;
            KaffeemaschinenArten kaffeeArt = (KaffeemaschinenArten)_random.Next(1, 4);
            switch (kaffeeArt)
            {
                case KaffeemaschinenArten.PadMaschine:
                    _bestellteSorte = typeof(PadMaschine);
                    //Alternativ über die Instanz
                    //_bestellteSorte = _padmaschine.GetType();
                    labelBestellung.Text = $"{_bestellteMenge} ml Espresso bitte!";
                    break;
                case KaffeemaschinenArten.Vollautomat:
                    _bestellteSorte = typeof(Vollautomat);
                    labelBestellung.Text = $"{_bestellteMenge} ml Cappuccino bitte!";

                    break;
                case KaffeemaschinenArten.Filtermaschine:
                    _bestellteSorte = typeof(FilterMaschine);
                    labelBestellung.Text = $"{_bestellteMenge} ml Kaffee bitte!";
                    break;
                default:
                    throw new Exception("Unbekannte Maschinenart");
            }
        }

        private void timerZeit_Tick(object sender, EventArgs e)
        {
            _zeit--;
            //this.Location = new Point(_random.Next(0, 300), _random.Next(0, 300));
            labelZeit.Text = $"Zeit: {_zeit}";
            if (_zeit <= 0)
            {
                timerZeit.Stop();
                MessageBox.Show($"Du hast {_score} Punkte erreicht!");
                //TODO: Namen vom Spieler erfragen
                NewHighscoreForm form = new NewHighscoreForm(_score);
                form.ShowDialog();
                this.Close();
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                this.Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                this.Close();
            }
        }
    }
}