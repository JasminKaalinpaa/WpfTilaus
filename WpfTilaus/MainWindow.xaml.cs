﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTilaus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime tänään = DateTime.Today;
        Decimal RiviSummaYht = 0;

        public MainWindow()
        {
            InitializeComponent();
            dpTilausPvm.SelectedDate = tänään;
            dpToimitusPvm.SelectedDate = tänään.AddDays(14);

            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Binding = new Binding("TilausNumero");
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Binding = new Binding("TuoteNumero");
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Binding = new Binding("TuoteNimi");
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Binding = new Binding("Maara");
            DataGridTextColumn textColumn5 = new DataGridTextColumn();
            textColumn5.Binding = new Binding("AHinta");
            DataGridTextColumn textColumn6 = new DataGridTextColumn();
            textColumn6.Binding = new Binding("Summa");

            textColumn1.Header = "Tilauksen numero";
            dgTilausRivit.Columns.Add(textColumn1);
            textColumn2.Header = "Tuotteen numero";
            dgTilausRivit.Columns.Add(textColumn2);
            textColumn3.Header = "Tuotteen nimi";
            dgTilausRivit.Columns.Add(textColumn3);
            textColumn4.Header = "Määrä";
            dgTilausRivit.Columns.Add(textColumn4);
            textColumn5.Header = "Hinta";
            dgTilausRivit.Columns.Add(textColumn5);
            textColumn6.Header = "Summa";
            dgTilausRivit.Columns.Add(textColumn6);



        }

        private void BtnTallenna_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TilausOtsikko Tilaus = new TilausOtsikko();
                Tilaus.TilausNumero = int.Parse(txtTilausNumero.Text);
                Tilaus.TilausPvm = dpTilausPvm.SelectedDate.Value;
                Tilaus.ToimitusPvm = dpToimitusPvm.SelectedDate.Value;
                Tilaus.AsiakasNumero = int.Parse(txtAsiakasNumero.Text);
                Tilaus.AsiakkaanNimi = txtAsiakkaanNimi.Text;
                Tilaus.ToimitusOsoite = txtToimitusOsoite.Text;

            MessageBox.Show("Tilaus tallennettu: " + "\r\n" + "Tilausnumero: " + Tilaus.TilausNumero.ToString() +
                "\r\n" + "Tilauspäivämäärä: " + Tilaus.TilausPvm.ToString() +
                "\r\n" + "Toimituspäivämäärä: " + Tilaus.ToimitusPvm.ToString() +
                "\r\n" + "Asiakasnumero: " + Tilaus.AsiakasNumero.ToString() +
                "\r\n" + "Asiakkaannimi: " + Tilaus.AsiakkaanNimi +
                "\r\n" + "Toimitusosoite: " + Tilaus.ToimitusOsoite
                );
                
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLisaaRivi_Click(object sender, RoutedEventArgs e)
        {
 
                try
                {
                    TilausRivi TilausR = new TilausRivi();
                    TilausR.TilausNumero = int.Parse(txtTilausNumero.Text);
                    TilausR.TuoteNumero = txtTuoteNumero.Text;
                    TilausR.TuoteNimi = txtTuoteNimi.Text;
                    TilausR.Maara = int.Parse(txtMaara.Text);
                    TilausR.AHinta = Convert.ToDecimal(txtAHinta.Text);
                    
     

                MessageBox.Show("Tilaus tallennettu: " + "\r\n" + "Tilausnumero: " + TilausR.TilausNumero.ToString() +
                        "\r\n" + "Tilausnumero: " + TilausR.TilausNumero +
                        "\r\n" + "Tuotteen nimi: " + TilausR.TuoteNimi +
                        "\r\n" + "Määrä: " + TilausR.Maara.ToString() +
                        "\r\n" + "A-hinta: " + TilausR.AHinta.ToString() +
                        "\r\n" + "RiviSumma: " + TilausR.RiviSumma().ToString() 
                        

                        );
                dgTilausRivit.Items.Add(TilausR);

                RiviSummaYht += TilausR.RiviSumma();
                txtSumma.Text = RiviSummaYht.ToString();
                dgTilausRivit.Items.Add(TilausR);
            }
                catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                {
                    txtTilausNumero.Clear();
                    txtTuoteNimi.Clear();
                    txtTuoteNimi.Clear();
                    txtMaara.Clear();
                    txtAHinta.Clear();

                }


                }
            }
        }
    }


