using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeeGame
{
    public static class HighscoreVerwaltung
    {
        public static List<HighscoreEintrag> HighscoreListe { get; private set; }

        const string Dateiname = "Kaffee_Game_Highscore.txt";

        //Anleitung zur Erstellung einer lokalen Datenbank: https://docs.microsoft.com/en-us/visualstudio/data-tools/create-a-simple-data-application-by-using-adonet?view=vs-2017
        const string Connection_String = "Data Source = (localdb)\\mssqllocaldb; Initial Catalog = KaffeeGameHighscore; Integrated Security = True; Pooling = False";

        //Statischer Konstruktor: wird nur 1 Mal im Programm aufgerufen
        static HighscoreVerwaltung()
        {
            HighscoreListe = new List<HighscoreEintrag>();
            //Daten aus der Datei/Datenbank laden

            if (File.Exists(Dateiname))
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(Dateiname);
                    string jsonString = reader.ReadToEnd();
                    HighscoreListe = JsonConvert.DeserializeObject<List<HighscoreEintrag>>(jsonString);
                }
                catch (Exception exp)
                {
                    System.Windows.Forms.MessageBox.Show(exp.Message);
                    return;
                }
                //Finally-Block wird immer ausgeführt, auch dann wenn im catch-Block returned wurde
                finally
                {
                    //Schließe die Datei, falls reader ungleich null ist
                    reader?.Close();
                }
            }

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(Connection_String);
                using (SqlCommand command = new SqlCommand("Select * FROM [Table]", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    string ausgabeAusDb = string.Empty;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            int score = (int)reader["Score"];
                            DateTime datum = (DateTime)reader["Datum"];
                            ausgabeAusDb += $"{name} \t {score} \t {datum}\n";
                        }
                        System.Windows.Forms.MessageBox.Show($"Inhalt der DB:\n{ausgabeAusDb}");
                    }
                }
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show($"Es gibt ein Problem mit der DB-Verbindung, bitte lege eine passende Datenbank an!\nFehlermeldung: {exp.Message}");
                return;
            }
            finally
            {
                connection?.Close();
            }

        }


        //Überladene Methode: Gleicher Name aber andere Parametertypen
        public static void FügeNeuenHighscoreHinzu(HighscoreEintrag eintrag)
        {
            HighscoreListe.Add(eintrag);


            StreamWriter writer = null;
            try
            {
                //Speichere Liste in Datei
                writer = new StreamWriter(Dateiname, false);
                //Serialisierungen: Binäre Daten (.NET Objekte im RAM) in einen String umwandeln
                //JSON: Komprimiert und Speicherplatz sparend (string hat weniger zeichen)
                //XML: Ausführlicher, besser lesbar, von Menschen gut bearbeitbar
                string jsonString = JsonConvert.SerializeObject(HighscoreListe);
                writer.Write(jsonString);
                writer.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                return;
            }
            //Finally-Block wird immer ausgeführt, auch dann wenn im catch-Block returned wurde
            finally
            {

                //Schließe die Datei, falls writer ungleich null ist
                writer?.Close();
            }

            //Eintrag in Datenbank
            SqlConnection connection = null;
            try
            {
                //In Datenbank abspeichern mittels ADO.NET
                connection = new SqlConnection(Connection_String);
                connection.Open();
                //In DB speichern
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Table] (Name,Score,Datum) VALUES (@name,@score, @datum)";
                    command.Parameters.AddWithValue("@name", eintrag.Name);
                    command.Parameters.AddWithValue("@score", eintrag.Score);
                    command.Parameters.AddWithValue("@datum", eintrag.Datum);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        System.Windows.Forms.MessageBox.Show("Datenbank Problem");
                    }
                }
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show($"Es gibt ein Problem mit der DB-Verbindung, bitte lege eine passende Datenbank an!\nFehlermeldung: {exp.Message}");

            }
            finally
            {
                connection?.Close();
            }
        }

        public static void FügeNeuenHighscoreHinzu(string name, int score, DateTime datum)
        {
            HighscoreEintrag eintrag = new HighscoreEintrag(score, name, datum);
            FügeNeuenHighscoreHinzu(eintrag);
        }

        public static void ZeigeHighscoreAn()
        {
            string message = string.Empty;

            //sortiere die Liste nur temporär für die Ausgabe, nach Score und bei Einträgen mit gleichen Score nach Datum
            //die Originalliste soll unverändert bleiben
            foreach (var item in HighscoreListe.OrderByDescending(h => h.Score).ThenBy(h => h.Datum))
            {
                message += $"{item.Name} \t{item.Score}\t {item.Datum.ToShortDateString()}\n";
                //Alternative wenn HighscoreEintrag eine ToString-Methode definiert:
                //message += $"{item}\n";
            }

            System.Windows.Forms.MessageBox.Show(message);
        }


        public static void AnwendungVerschiedenerSortierUndFiltermethoden()
        {
            string message = string.Empty;

            HighscoreListe = HighscoreListe.OrderByDescending(SortierKriterium).ToList();

            //Übung: Filter-Methode mit selbstgewählten FilterKriterium aufrufen
            HighscoreListe = Filtern(HighscoreListe, FilterNachScore);

            //Lambda: anonyme Methode
            HighscoreListe = Filtern(HighscoreListe, (HighscoreEintrag item) =>
            {
                return item.Name[0] == 'A';
            });

            HighscoreListe = Filtern(HighscoreListe, h => h.Name[0] == 'A');

            HighscoreListe = HighscoreListe.OrderByDescending(eintrag => eintrag.Score).ToList();

            //Where ist die Linq-Implementierung der Filter-Methode
            HighscoreListe = HighscoreListe.Where(h => h.Name[0] == 'A').ToList();

            FilterMethode _meth = h => h.Name[0] == 'A';
            _meth(new HighscoreEintrag(2, "Test", DateTime.Today));


            foreach (var item in HighscoreListe)
            {
                message += $"{item.Name} \t{item.Score}\t {item.Datum.ToShortDateString()}\n";
                //Alternative wenn HighscoreEintrag eine ToString-Methode definiert:
                //message += $"{item}\n";
            }



            System.Windows.Forms.MessageBox.Show(message);
        }

        public delegate bool FilterMethode(HighscoreEintrag eintrag);

        public static List<HighscoreEintrag> Filtern(List<HighscoreEintrag> zufilterndeListe, FilterMethode filterKriterium)
        {
            List<HighscoreEintrag> gefilterteListe = new List<HighscoreEintrag>();
            foreach (var item in zufilterndeListe)
            {
                //Prüfe ob der Eintrag dem Filterkriterium genügt
                //Dynamischen Algorithmus aufrufen
                if (filterKriterium(item))
                {
                    gefilterteListe.Add(item);
                }
            }
            return gefilterteListe;
        }


        #region Selbe Methode wie Filtern(), allerdings mit einem generischen Delegatetypen als zweiten Parameter
        public static List<HighscoreEintrag> FilternGeneric(List<HighscoreEintrag> zufilterndeListe, Func<HighscoreEintrag, bool> filterKriterium)
        {
            List<HighscoreEintrag> gefilterteListe = new List<HighscoreEintrag>();
            foreach (var item in zufilterndeListe)
            {
                //Prüfe ob der Eintrag dem Filterkriterium genügt
                //Dynamischen Algorithmus aufrufen
                if (filterKriterium(item))
                {
                    gefilterteListe.Add(item);
                }
            }
            return gefilterteListe;
        }
        #endregion


        #region Hilfsmethoden für Sortieren und Filtern
        public static bool FilterNachScore(HighscoreEintrag eintrag)
        {
            return eintrag.Score > 15;
        }

        public static object SortierKriterium(HighscoreEintrag eintrag)
        {
            System.Windows.Forms.MessageBox.Show(eintrag.ToString());

            return eintrag.Score;
        }
        #endregion

    }
}
