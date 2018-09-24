using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trabajo_PabloPerez {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        OpenFileDialog txt = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e) {

            txt.Filter = "Archivos de texto (*.txt)|*.txt";

            if (txt.ShowDialog() == DialogResult.OK) {


                /*Mostrar el contenido en el textfield*/
                txtNombreRuta.Text = txt.FileName;
                StreamReader leer = new StreamReader(txt.FileName);
                string text = leer.ReadToEnd();
                txtLectura.Text = text;
                /*Mostrar el contenido en el textfield*/

                

                /*Contar espacios en blanco*/
                int espaciosBlancos = 0;

                espaciosBlancos = text.Split(' ').Length;
                espaciosBlancos--;
                txtBlancos.Text = espaciosBlancos.ToString();
                /*Contar espacios en blanco*/

                /*Contar tabulaciones */
                int tabulaciones = 0;

                tabulaciones = text.Split('\t').Length;
                tabulaciones--;
                txtTabuladores.Text = tabulaciones.ToString();
                /*Contar tabulaciones */

                /*Contar lineas */
                int lineas = 0;

                lineas = text.Split('\n').Length;
                txtLineas.Text = lineas.ToString();
                /*Contar lineas */


                /*Contar letras*/
                int contarLetras = 0;
                contarLetras = text.Length;
                txtCaracteres.Text = contarLetras.ToString();
                /*Contar letras*/

                int vocales = 0;
                int consonantes = 0;
                int palabras = 0;

                for (int i = 0; i < text.Length - 1; i++) {

                    char c = text[i];

                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') { 
                        vocales++; //Guardar las vocales

                        if (i == 0) {

                            palabras++; //Donde haya una vocal guardará una palabra

                        }
                    } else if (c == 'b' || c == 'B' || c == 'c' || c == 'C' || c == 'd' || c == 'D' || c == 'f' || c == 'F' || c == 'g' || c == 'G' || c == 'h' || c == 'H' || c == 'j' || c == 'J' || c == 'k' || c == 'K' || c == 'l' || c == 'L' || c == 'm' || c == 'M' || c == 'n' || c == 'N' || c == 'ñ' || c == 'Ñ' || c == 'p' || c == 'P' || c == 'q' || c == 'Q' || c == 'r' || c == 'R' || c == 's' || c == 'S' || c == 't' || c == 'T' || c == 'v' || c == 'V' || c == 'w' || c == 'W' || c == 'x' || c == 'X' || c == 'y' || c == 'Y' || c == 'z' || c == 'Z') {

                        consonantes++; //Donde haya una consonantes sumará el contador

                        if (i == 0) {

                            palabras++; //Guardará una palabra más

                        }

                    } else if (c == ' ' || c == '\n' || c == '\t') {


                        if (text[i + 1] != ' ' && text[i + 1] != '\n' && text[i + 1] != '\t') { //Si no es un espacio, un salto de linea o un tab, se guardará como una palabra.
                            palabras++;
                        }
                       

                    }

                }

                txtVocales.Text = vocales.ToString();
                txtConsonantes.Text = consonantes.ToString();
                txtPalabras.Text = palabras.ToString();
                


            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void cboQuitar_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnGuardar_Click(object sender, EventArgs e) {

            //Guardar txt
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos de texto (*.txt)|*.txt";
            guardar.RestoreDirectory = true;

            if (guardar.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(guardar.FileName, txtLectura.Text);
            }

        }
    }
}
