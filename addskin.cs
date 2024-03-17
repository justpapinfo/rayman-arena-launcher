using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.IO.Compression;
using System.Security.Cryptography;

namespace luncher_rayman_aréna
{

    


    public partial class addskin : Form
    {
        public static acceuil pageprincpal;




            
        



        public addskin()
        {
            InitializeComponent();
            //affichageskin(1);
            choixlangue();


        }
        string choixperso = "";
        string nompersolocal = "";
        string cheminfichierLangue = @"fils\Langue.txt "; //chemin fichier txt
        string skinajout = "";
        string skinsupprimer1 = "";
        string skinsupprimer2 = "";


         void choixlangue()
        {

            if (!File.Exists(cheminfichierLangue))
            {
                File.WriteAllText(cheminfichierLangue, "EN");
            }
            else
            {
                string lecture = File.ReadAllText(cheminfichierLangue);







                if (lecture == "EN")
                {

                    VisuNom1.Text = "Name :";
                    VisuNom2.Text = "Name :";
                    VisuNom3.Text = "Name :";
                    VisuNom4.Text = "Name :";
                    VisuNom5.Text = "Name :";
                    VisuNom6.Text = "Name :";
                    VisuNom7.Text = "Name :";
                    VisuNom8.Text = "Name :";
                    VisuNom9.Text = "Name :";
                    VisuNom10.Text = "Name :";

                    VisuAuteur1.Text = "Author :";
                    VisuAuteur2.Text = "Author :";
                    VisuAuteur3.Text = "Author :";
                    VisuAuteur4.Text = "Author :";
                    VisuAuteur5.Text = "Author :";
                    VisuAuteur6.Text = "Author :";
                    VisuAuteur7.Text = "Author :";
                    VisuAuteur8.Text = "Author :";
                    VisuAuteur9.Text = "Author :";
                    VisuAuteur10.Text = "Author :";

                    Visuasenseurskin.Text = "Character :";
                    label1.Text = "Please select a character: ";

                    add1.Text = "Add";
                    add2.Text = "Add";
                    add3.Text = "Add";
                    add4.Text = "Add";
                    add5.Text = "Add";
                    add6.Text = "Add";
                    add7.Text = "Add";
                    add8.Text = "Add";
                    add9.Text = "Add";
                    add10.Text = "Add";

                    supp1.Text = "Delete";
                    supp2.Text = "Delete";
                    supp3.Text = "Delete";
                    supp4.Text = "Delete";
                    supp5.Text = "Delete";
                    supp6.Text = "Delete";
                    supp7.Text = "Delete";
                    supp8.Text = "Delete";
                    supp9.Text = "Delete";
                    supp10.Text = "Delete";



                    skinajout = "added";
                    skinsupprimer1 = "The skin";
                    skinsupprimer2 = "well was deleted";

                }
                else if (lecture == "FR")
                {

                    VisuNom1.Text = "Nom :";
                    VisuNom2.Text = "Nom :";
                    VisuNom3.Text = "Nom :";
                    VisuNom4.Text = "Nom :";
                    VisuNom5.Text = "Nom :";
                    VisuNom6.Text = "Nom :";
                    VisuNom7.Text = "Nom :";
                    VisuNom8.Text = "Nom :";
                    VisuNom9.Text = "Nom :";
                    VisuNom10.Text = "Nom :";

                    VisuAuteur1.Text = "Auteur :";
                    VisuAuteur2.Text = "Auteur :";
                    VisuAuteur3.Text = "Auteur :";
                    VisuAuteur4.Text = "Auteur :";
                    VisuAuteur5.Text = "Auteur :";
                    VisuAuteur6.Text = "Auteur :";
                    VisuAuteur7.Text = "Auteur :";
                    VisuAuteur8.Text = "Auteur :";
                    VisuAuteur9.Text = "Auteur :";
                    VisuAuteur10.Text = "Auteur :";

                    Visuasenseurskin.Text = "Personnage :";
                    label1.Text = "Veuillez selectionner un personnage : ";

                    add1.Text = "Ajouter";
                    add2.Text = "Ajouter";
                    add3.Text = "Ajouter";
                    add4.Text = "Ajouter";
                    add5.Text = "Ajouter";
                    add6.Text = "Ajouter";
                    add7.Text = "Ajouter";
                    add8.Text = "Ajouter";
                    add9.Text = "Ajouter";
                    add10.Text = "Ajouter";

                    supp1.Text = "Supprimer";
                    supp2.Text = "Supprimer";
                    supp3.Text = "Supprimer";
                    supp4.Text = "Supprimer";
                    supp5.Text = "Supprimer";
                    supp6.Text = "Supprimer";
                    supp7.Text = "Supprimer";
                    supp8.Text = "Supprimer";
                    supp9.Text = "Supprimer";
                    supp10.Text = "Supprimer";



                    skinajout = "ajouté";
                    skinsupprimer1 = "Le skin";
                    skinsupprimer2 = "a bien été supprimé";


                }
                else if (lecture == "ES")
                {

                    VisuNom1.Text = "Apellido :";
                    VisuNom2.Text = "Apellido :";
                    VisuNom3.Text = "Apellido :";
                    VisuNom4.Text = "Apellido :";
                    VisuNom5.Text = "Apellido :";
                    VisuNom6.Text = "Apellido :";
                    VisuNom7.Text = "Apellido :";
                    VisuNom8.Text = "Apellido :";
                    VisuNom9.Text = "Apellido :";
                    VisuNom10.Text = "Apellido :";

                    VisuAuteur1.Text = "Autor :";
                    VisuAuteur2.Text = "Autor :";
                    VisuAuteur3.Text = "Autor :";
                    VisuAuteur4.Text = "Autor :";
                    VisuAuteur5.Text = "Autor :";
                    VisuAuteur6.Text = "Autor :";
                    VisuAuteur7.Text = "Autor :";
                    VisuAuteur8.Text = "Autor :";
                    VisuAuteur9.Text = "Autor :";
                    VisuAuteur10.Text = "Autor :";

                    Visuasenseurskin.Text = "Personaje :";
                    label1.Text = "Selecciona un personaje:";

                    add1.Text = "Agregar";
                    add2.Text = "Agregar";
                    add3.Text = "Agregar";
                    add4.Text = "Agregar";
                    add5.Text = "Agregar";
                    add6.Text = "Agregar";
                    add7.Text = "Agregar";
                    add8.Text = "Agregar";
                    add9.Text = "Agregar";
                    add10.Text = "Agregar";

                    supp1.Text = "Borrar";
                    supp2.Text = "Borrar";
                    supp3.Text = "Borrar";
                    supp4.Text = "Borrar";
                    supp5.Text = "Borrar";
                    supp6.Text = "Borrar";
                    supp7.Text = "Borrar";
                    supp8.Text = "Borrar";
                    supp9.Text = "Borrar";
                    supp10.Text = "Borrar";



                    skinajout = "agregado";
                    skinsupprimer1 = "El skin";
                    skinsupprimer2 = "fue eliminado con éxito";

                }



                else if (lecture == "RU")
                {

                    VisuNom1.Text = "Имя :";
                    VisuNom2.Text = "Имя :";
                    VisuNom3.Text = "Имя :";
                    VisuNom4.Text = "Имя :";
                    VisuNom5.Text = "Имя :";
                    VisuNom6.Text = "Имя :";
                    VisuNom7.Text = "Имя :";
                    VisuNom8.Text = "Имя :";
                    VisuNom9.Text = "Имя :";
                    VisuNom10.Text = "Имя :";

                    VisuAuteur1.Text = "Автор :";
                    VisuAuteur2.Text = "Автор :";
                    VisuAuteur3.Text = "Автор :";
                    VisuAuteur4.Text = "Автор :";
                    VisuAuteur5.Text = "Автор :";
                    VisuAuteur6.Text = "Автор :";
                    VisuAuteur7.Text = "Автор :";
                    VisuAuteur8.Text = "Автор :";
                    VisuAuteur9.Text = "Автор :";
                    VisuAuteur10.Text = "Автор :";

                    Visuasenseurskin.Text = "Характер :";
                    label1.Text = "Пожалуйста, выберите персонажа: ";

                    add1.Text = "Добавлять";
                    add2.Text = "Добавлять";
                    add3.Text = "Добавлять";
                    add4.Text = "Добавлять";
                    add5.Text = "Добавлять";
                    add6.Text = "Добавлять";
                    add7.Text = "Добавлять";
                    add8.Text = "Добавлять";
                    add9.Text = "Добавлять";
                    add10.Text = "Добавлять";

                    supp1.Text = "УДАЛИТЬ";
                    supp2.Text = "УДАЛИТЬ";
                    supp3.Text = "УДАЛИТЬ";
                    supp4.Text = "УДАЛИТЬ";
                    supp5.Text = "УДАЛИТЬ";
                    supp6.Text = "УДАЛИТЬ";
                    supp7.Text = "УДАЛИТЬ";
                    supp8.Text = "УДАЛИТЬ";
                    supp9.Text = "УДАЛИТЬ";
                    supp10.Text = "УДАЛИТЬ";



                    skinajout = "добавлен";
                    skinsupprimer1 = "НАШИ skin";
                    skinsupprimer2 = "был успешно удален";



                }


            }



        }








        private void addskin_Load(object sender, EventArgs e)
        {
           // acceuil.pageprincpal.lecturexml();
        }




        void boutonaddaslin(int numero) {



            XmlDocument monfichier = new XmlDocument();
            monfichier.Load("https://raymanarenaonline.eundilmako.com/skin/voirxml.php");
            // MessageBox.Show("xml ok");
            XmlNodeList lst = monfichier.GetElementsByTagName(choixperso);
            int i = 0;
            foreach (XmlNode node in lst)
            {
                i++;
                if (i == numero)
                {

                    XmlNode nom = node.SelectSingleNode("nom");
                    string nomString = nom.InnerText.ToString();
                    //MessageBox.Show(nomString);

                    XmlNode lienskin = node.SelectSingleNode("lienskin");
                    string lienskinString = lienskin.InnerText.ToString();
                   // MessageBox.Show(lienskinString);


                    try
                    {
                        acceuil.Instance.skinazerotemp();
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(lienskinString, nomString+".zip");
                       Directory.CreateDirectory(@".\fils\texture\customskin\" + nompersolocal + @"\" + nomString + @"\");
                        ZipFile.ExtractToDirectory(nomString + ".zip", @".\fils\texture\customskin\" + nompersolocal + @"\" + nomString + @"\");
                        File.Delete(@".\" + nomString + ".zip");
                        MessageBox.Show("skin" + " "+ nomString +" "+skinajout);
                        affichageSkin(1);
                        acceuil.Instance.lecturexml();
                        acceuil.Instance.majselectjoueurencour();
                        Application.Restart();
                        Environment.Exit(0); // Termine le processus actuel de l'application

                    }
                    catch (WebException e)
                    {
                        // Traitement des erreurs
                        MessageBox.Show(e.ToString());
                    }

                    

                }







            }

        }


        void boutonSuppskin(int numero)
        {



            XmlDocument monfichier = new XmlDocument();
            monfichier.Load("https://raymanarenaonline.eundilmako.com/skin/voirxml.php");
            // MessageBox.Show("xml ok");
            XmlNodeList lst = monfichier.GetElementsByTagName(choixperso);
            int i = 0;
            foreach (XmlNode node in lst)
            {
                i++;
                if (i == numero)
                {
                    //acceuil.Instance.skinazerotemp();
                    XmlNode nom = node.SelectSingleNode("nom");
                    string nomString = nom.InnerText.ToString();
                    //MessageBox.Show(nomString);

                    XmlNode lienskin = node.SelectSingleNode("lienskin");
                    string lienskinString = lienskin.InnerText.ToString();
                    //MessageBox.Show(lienskinString);


                    string comboboxskin1 = acceuil.Instance.Recupvaleurskin1();
                    // MessageBox.Show(comboboxskin1);
                    string comboboxskin2 = acceuil.Instance.Recupvaleurskin2();
                    // MessageBox.Show(comboboxskin2);
                    string comboboxskin3 = acceuil.Instance.Recupvaleurskin3();
                    // MessageBox.Show(comboboxskin3);
                     string comboboxskin4 = acceuil.Instance.Recupvaleurskin4();
                    // MessageBox.Show(comboboxskin4);

                    int skinexsistant = 0;

                    if (comboboxskin1 == nomString){ skinexsistant = 1; }
                    if (comboboxskin2 == nomString) { skinexsistant = 1; }
                    if (comboboxskin3 == nomString) { skinexsistant = 1; }
                    if (comboboxskin4 == nomString) { skinexsistant = 1; }

                    if (skinexsistant == 0)

                    {
                        Directory.Delete(@".\fils\texture\customskin\" + nompersolocal + @"\" + nomString + @"\", true);
                        MessageBox.Show(skinsupprimer1 + " skin " + nomString + skinsupprimer2);
                        affichageSkin(1);
                        acceuil.Instance.lecturexml();
                        acceuil.Instance.majselectjoueurencour();
                        Application.Restart();
                        Environment.Exit(0); // Termine le processus actuel de l'application
                    }
                    else { MessageBox.Show("le skin " + nomString + "ne peux pas etre supprimer car il est actuellement selectionner"); }


                   

              
                }



            }

        }



        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }



        private void add2_Click(object sender, EventArgs e)
        {
            boutonaddaslin(2);
        }

        void desactivationskin() {
            choixperso = "";
    

            skin1.Visible = false;
            skin1.Enabled = false;

            skin2.Visible = false;
            skin2.Enabled = false;

            skin3.Visible = false;
            skin3.Enabled = false;

            skin4.Visible = false;
            skin4.Enabled = false;

            skin5.Visible = false;
            skin5.Enabled = false;

            skin6.Visible = false;
            skin6.Enabled = false;

            skin7.Visible = false;
            skin7.Enabled = false;

            skin8.Visible = false;
            skin8.Enabled = false;

            skin9.Visible = false;
            skin9.Enabled = false;

            skin10.Visible = false;
            skin10.Enabled = false;


            compt1.Enabled = false; compt1.Visible = false;
            compt2.Enabled = false; compt2.Visible = false;
            compt3.Enabled = false; compt3.Visible = false;
            compt4.Enabled = false; compt4.Visible = false;
            compt5.Enabled = false; compt5.Visible = false;
            compt6.Enabled = false; compt6.Visible = false;
            compt7.Enabled = false; compt7.Visible = false;
            compt8.Enabled = false; compt8.Visible = false;
            compt9.Enabled = false; compt9.Visible = false;
            compt10.Enabled = false; compt10.Visible = false;



        }

        void affichageskin(int cont, string nom, string auteur, string lienphoto)
        {

         


            if (cont == 1 || cont == 11|| cont == 21 || cont == 31 || cont == 41 || cont == 51 || cont == 61 || cont == 71 || cont == 81 || cont == 91)
            {
                skin1.Visible = true;
                skin1.Enabled = true;
                image1.ImageLocation = @lienphoto;
                nom1.Text = nom;
                auteur1.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add1.Enabled = false;
                    supp1.Enabled = true;
                }
                else {

                  //  MessageBox.Show("il exsiste pas");
                    add1.Enabled = true;
                    supp1.Enabled = false;

                }
            }

            if (cont == 2 || cont == 12 || cont == 22 || cont == 32 || cont == 42 || cont == 52 || cont == 62 || cont == 72 || cont == 82 || cont == 92 )
            {
                skin2.Visible = true;
                skin2.Enabled = true;
                image2.ImageLocation = @lienphoto;
                nom2.Text = nom;
                auteur2.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add2.Enabled = false;
                    supp2.Enabled = true;
                }
                else
                {

                   // MessageBox.Show("il exsiste pas");
                    add2.Enabled = true;
                    supp2.Enabled = false;

                }

            }

            if (cont == 3 || cont == 13 || cont == 23 || cont == 33 || cont == 43 || cont == 53 || cont == 63 || cont == 73 || cont == 83 || cont == 93 )
            {
                skin3.Visible = true;
                skin3.Enabled = true;
                image3.ImageLocation = @lienphoto;
                nom3.Text = nom;
                auteur3.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add3.Enabled = false;
                    supp3.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add3.Enabled = true;
                    supp3.Enabled = false;

                }

            }

            if (cont == 4 || cont == 14 || cont == 24 || cont == 34 || cont == 44 || cont == 54 || cont == 64 || cont == 74 || cont == 84 || cont == 94 )
            {
                skin4.Visible = true;
                skin4.Enabled = true;
                image4.ImageLocation = @lienphoto;
                nom4.Text = nom;
                auteur4.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add4.Enabled = false;
                    supp4.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add4.Enabled = true;
                    supp4.Enabled = false;

                }

            }

            if (cont == 5 || cont == 15 || cont == 25 || cont == 35 || cont == 45 || cont == 55 || cont == 65 || cont == 75 || cont == 85 || cont == 95)
            {
                skin5.Visible = true;
                skin5.Enabled = true;
                image5.ImageLocation = @lienphoto;
                nom5.Text = nom;
                auteur5.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add5.Enabled = false;
                    supp5.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add5.Enabled = true;
                    supp5.Enabled = false;

                }

            }

            if (cont == 6 || cont == 16 || cont == 26 || cont == 36 || cont == 46 || cont == 56 || cont == 66 || cont == 76 || cont == 86 || cont == 96)
            {
                skin6.Visible = true;
                skin6.Enabled = true;
                image6.ImageLocation = @lienphoto;
                nom6.Text = nom;
                auteur6.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add6.Enabled = false;
                    supp6.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add6.Enabled = true;
                    supp6.Enabled = false;

                }

            }

            if (cont == 7 || cont == 17 || cont == 27 || cont == 37 || cont == 47 || cont == 57 || cont == 67 || cont == 77 || cont == 87 || cont == 97)
            {
                skin7.Visible = true;
                skin7.Enabled = true;
                image7.ImageLocation = @lienphoto;
                nom7.Text = nom;
                auteur7.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add7.Enabled = false;
                    supp7.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add7.Enabled = true;
                    supp7.Enabled = false;

                }

            }

            if (cont == 8 || cont == 18 || cont == 28 || cont == 38 || cont == 48 || cont == 58 || cont == 68 || cont == 78 || cont == 88 ||  cont == 98)
            {
                skin8.Visible = true;
                skin8.Enabled = true;
                image8.ImageLocation = @lienphoto;
                nom8.Text = nom;
                auteur8.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add8.Enabled = false;
                    supp8.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add8.Enabled = true;
                    supp8.Enabled = false;

                }

            }

            if (cont == 9 || cont == 19 || cont == 29 || cont == 39 || cont == 49 || cont == 59 || cont == 69 || cont == 79 || cont == 89 || cont == 99)
            {
                skin9.Visible = true;
                skin9.Enabled = true;
                image9.ImageLocation = @lienphoto;
                nom9.Text = nom;
                auteur9.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add9.Enabled = false;
                    supp9.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add9.Enabled = true;
                    supp9.Enabled = false;

                }

            }
            if (cont == 10 || cont == 20 || cont == 30 || cont == 40 || cont == 50|| cont == 60 || cont == 70 || cont == 80 || cont == 90 || cont == 100)
            {
                skin10.Visible = true;
                skin10.Enabled = true;
                image10.ImageLocation = @lienphoto;
                nom10.Text = nom;
                auteur10.Text = auteur;

                //partie qui test si le skin exsiste deja chez le client


                if (Directory.Exists(@".\fils\texture\customskin\" + nompersolocal + @"\" + nom + @"\"))
                {
                    //MessageBox.Show("il exsiste");
                    add10.Enabled = false;
                    supp10.Enabled = true;
                }
                else
                {

                    //MessageBox.Show("il exsiste pas");
                    add10.Enabled = true;
                    supp10.Enabled = false;

                }

            }


        }


   

        public int contageskin()

        {

            if (Choixperso1.SelectedIndex == 0) { choixperso = "Rayman"; }
            if (Choixperso1.SelectedIndex == 1) { choixperso = "Razor"; }
            if (Choixperso1.SelectedIndex == 2) { choixperso = "Razorwife"; }
            if (Choixperso1.SelectedIndex == 3) { choixperso = "Globox"; }
            if (Choixperso1.SelectedIndex == 4) { choixperso = "Henchman800"; }
            if (Choixperso1.SelectedIndex == 5) { choixperso = "Teensy"; }
            if (Choixperso1.SelectedIndex == 6) { choixperso = "Tily"; }
            if (Choixperso1.SelectedIndex == 7) { choixperso = "Henchman1000"; }

            if (Choixperso1.SelectedIndex == 0) { nompersolocal = "RaymanT"; }
            if (Choixperso1.SelectedIndex == 1) { nompersolocal = "Razor"; }
            if (Choixperso1.SelectedIndex == 2) { nompersolocal = "Razorwife"; }
            if (Choixperso1.SelectedIndex == 3) { nompersolocal = "globox"; }
            if (Choixperso1.SelectedIndex == 4) { nompersolocal = "Henchman"; }
            if (Choixperso1.SelectedIndex == 5) { nompersolocal = "Teensies"; }
            if (Choixperso1.SelectedIndex == 6) { nompersolocal = "Tily"; }
            if (Choixperso1.SelectedIndex == 7) { nompersolocal = "Henchman1000"; }


            XmlDocument monfichier = new XmlDocument();
            monfichier.Load("https://raymanarenaonline.eundilmako.com/skin/voirxml.php");
            // MessageBox.Show("xml ok");
            XmlNodeList lst = monfichier.GetElementsByTagName(choixperso);
            int i = 0;
            foreach (XmlNode node in lst)
            {
                i++;


            }
            string myString = i.ToString();

            if (i >= 1 && i <= 10) { compt1.Enabled = true; compt1.Visible = true; }
            if (i >= 11 && i <= 20) { compt1.Enabled = true; compt1.Visible = true;  compt2.Enabled = true; compt2.Visible = true; }
            if (i >= 21 && i <= 30) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true;  compt3.Enabled = true; compt3.Visible = true; }
            if (i >= 31 && i <= 40) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; }
            if (i >= 41 && i <= 50) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true;  compt5.Enabled = true; compt5.Visible = true; }
            if (i >= 51 && i <= 60) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; compt5.Enabled = true; compt5.Visible = true;  compt6.Enabled = true; compt6.Visible = true; }
            if (i >= 61 && i <= 70) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; compt5.Enabled = true; compt5.Visible = true; compt6.Enabled = true; compt6.Visible = true; compt7.Enabled = true; compt7.Visible = true; }
            if (i >= 71 && i <= 80) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; compt5.Enabled = true; compt5.Visible = true; compt6.Enabled = true; compt6.Visible = true; compt7.Enabled = true; compt7.Visible = true; compt8.Enabled = true; compt8.Visible = true; }
            if (i >= 81 && i <= 90) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; compt5.Enabled = true; compt5.Visible = true; compt6.Enabled = true; compt6.Visible = true;  compt7.Enabled = true; compt7.Visible = true; compt8.Enabled = true; compt8.Visible = true; compt9.Enabled = true; compt9.Visible = true;  }
            if (i >= 91 && i <= 100) { compt1.Enabled = true; compt1.Visible = true; compt2.Enabled = true; compt2.Visible = true; compt3.Enabled = true; compt3.Visible = true; compt4.Enabled = true; compt4.Visible = true; compt5.Enabled = true; compt5.Visible = true; compt6.Enabled = true; compt6.Visible = true;  compt7.Enabled = true; compt7.Visible = true; compt8.Enabled = true; compt8.Visible = true; compt9.Enabled = true; compt9.Visible = true; compt10.Enabled = true; compt10.Visible = true;}
            //MessageBox.Show(myString);
            return i;
        }











        void  affichageSkin (int numero)

        {
            
            desactivationskin();
            contageskin();


            if (Choixperso1.SelectedIndex == 0) { choixperso = "Rayman"; }
            if (Choixperso1.SelectedIndex == 1) { choixperso = "Razor"; }
            if (Choixperso1.SelectedIndex == 2) { choixperso = "Razorwife"; }
            if (Choixperso1.SelectedIndex == 3) { choixperso = "Globox"; }
            if (Choixperso1.SelectedIndex == 4) { choixperso = "Henchman800"; }
            if (Choixperso1.SelectedIndex == 5) { choixperso = "Teensy"; }
            if (Choixperso1.SelectedIndex == 6) { choixperso = "Tily"; }
            if (Choixperso1.SelectedIndex == 7) { choixperso = "Henchman1000"; }

            if (Choixperso1.SelectedIndex == 0) { nompersolocal = "RaymanT"; }
            if (Choixperso1.SelectedIndex == 1) { nompersolocal = "Razor"; }
            if (Choixperso1.SelectedIndex == 2) { nompersolocal = "Razorwife"; }
            if (Choixperso1.SelectedIndex == 3) { nompersolocal = "globox"; }
            if (Choixperso1.SelectedIndex == 4) { nompersolocal = "Henchman"; }
            if (Choixperso1.SelectedIndex == 5) { nompersolocal = "Teensies"; }
            if (Choixperso1.SelectedIndex == 6) { nompersolocal = "Tily"; }
            if (Choixperso1.SelectedIndex == 7) { nompersolocal = "Henchman1000"; }


            XmlDocument monfichier = new XmlDocument();
            monfichier.Load("https://raymanarenaonline.eundilmako.com/skin/voirxml.php");
            // MessageBox.Show("xml ok");
            XmlNodeList lst = monfichier.GetElementsByTagName(choixperso);
            int i = 0;
            foreach (XmlNode node in lst)
            {
                i++;


                if (numero == 1)
                {
                    if (i >= 1 && i <= 10) {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }               
                }

                if (numero == 2)
                {
                    if (i >= 11 && i <= 20)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 3)
                {
                    if (i >= 21 && i <= 30)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 4)
                {
                    if (i >= 31 && i <= 40)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 5)
                {
                    if (i >= 41 && i <= 50)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 6)
                {
                    if (i >= 51 && i <= 60)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 7)
                {
                    if (i >= 61 && i <= 70)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 8)
                {
                    if (i >= 71 && i <= 80)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 9)
                {
                    if (i >= 81 && i <= 90)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }

                if (numero == 10)
                {
                    if (i >= 91 && i <= 100)
                    {

                        XmlNode auteur = node.SelectSingleNode("auteur");
                        string auteurString = auteur.InnerText.ToString();

                        XmlNode nom = node.SelectSingleNode("nom");
                        string nomString = nom.InnerText.ToString();

                        XmlNode lienphoto = node.SelectSingleNode("lienphoto");
                        string lienphotoString = lienphoto.InnerText.ToString();

                        XmlNode lienskin = node.SelectSingleNode("lienskin");
                        string lienskinString = lienskin.InnerText.ToString();

                        affichageskin(i, nomString, auteurString, lienphotoString);
                    }
                }






            }

        }


        private void Choixperso1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
            desactivationskin();
            affichageSkin(1);

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void compt1_Click(object sender, EventArgs e)
        {
            affichageSkin(1);
        }

        private void compt2_Click(object sender, EventArgs e)
        {
            affichageSkin(2);
        }

        private void compt3_Click(object sender, EventArgs e)
        {
            affichageSkin(3);
        }

        private void compt4_Click(object sender, EventArgs e)
        {
            affichageSkin(4);
        }

        private void compt5_Click(object sender, EventArgs e)
        {
            affichageSkin(5);
        }

        private void compt6_Click(object sender, EventArgs e)
        {
            //7
            affichageSkin(7);
        }

        private void compt7_Click(object sender, EventArgs e)
        {
            //8
            affichageSkin(8);
        }

        private void compt8_Click(object sender, EventArgs e)
        {
            //9
            affichageSkin(9);
        }

        private void compt9_Click(object sender, EventArgs e)
        {
            //10
            affichageSkin(10);
        }

        private void compt6_Click_1(object sender, EventArgs e)
        {
            //6
            affichageSkin(6);
        }

        private void VisuNom7_Click(object sender, EventArgs e)
        {

        }





        private void add1_Click_1(object sender, EventArgs e)
        {

            boutonaddaslin(1);
        }

        private void add2_Click_1(object sender, EventArgs e)
        {
 
            boutonaddaslin(2);
        }

        private void add3_Click_1(object sender, EventArgs e)
        {
            boutonaddaslin(3);
        }

        private void add4_Click_1(object sender, EventArgs e)
        {
            boutonaddaslin(4);
        }

        private void add5_Click(object sender, EventArgs e)
        {
            boutonaddaslin(5);
        }

        private void add6_Click(object sender, EventArgs e)
        {
            boutonaddaslin(6);
        }

        private void add7_Click(object sender, EventArgs e)
        {
            boutonaddaslin(7);
        }

        private void add8_Click(object sender, EventArgs e)
        {
            boutonaddaslin(8);
        }

        private void add9_Click(object sender, EventArgs e)
        {
            boutonaddaslin(9);
        }

        private void add10_Click(object sender, EventArgs e)
        {
            boutonaddaslin(10);
        }

        private void supp1_Click_1(object sender, EventArgs e)
        {
            boutonSuppskin(1);
        }

        private void supp2_Click_1(object sender, EventArgs e)
        {
            boutonSuppskin(2);
        }

        private void supp3_Click_1(object sender, EventArgs e)
        {
            boutonSuppskin(3);
        }

        private void supp4_Click_1(object sender, EventArgs e)
        {
            boutonSuppskin(4);
        }

        private void supp5_Click(object sender, EventArgs e)
        {
            boutonSuppskin(5);
        }

        private void supp6_Click(object sender, EventArgs e)
        {
            boutonSuppskin(6);
        }

        private void supp7_Click(object sender, EventArgs e)
        {
            boutonSuppskin(7);
        }

        private void supp8_Click(object sender, EventArgs e)
        {
            boutonSuppskin(8);
        }

        private void supp9_Click(object sender, EventArgs e)
        {
            boutonSuppskin(9);
        }

        private void supp10_Click(object sender, EventArgs e)
        {
            boutonSuppskin(10);
        }
    }
}
