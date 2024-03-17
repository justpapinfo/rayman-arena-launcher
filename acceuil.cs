using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using RayCarrot.Binary;
using RayCarrot.Rayman;
using RayCarrot.Rayman.OpenSpace;
using System.Threading;
using System.Net.Http;
using Memory;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Management;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace luncher_rayman_aréna
{






    public partial class acceuil : Form
    {



        string cheminfichier = @"game\HD\arenaPatch.cfg "; //chemain fichier txt carte reseau
        string cheminfichier2 = @"game\SD\arenaPatch.cfg "; //chemain fichier txt carte reseau
        string cheminfichierLangue = @"fils\Langue.txt "; //chemain fichier txt langue
        string cheminfichierversion = @"fils\version.txt "; //chemain fichier txt version

        int VerifHdok = 0;


        string curItem; //contenue de l'asenseur selectionner carte reseau



        public static acceuil Instance;


        public string Recupvaleurskin1()
        {
            return skin1.SelectedItem.ToString();
        }

        public string Recupvaleurskin2()
        {
            return skin2.SelectedItem.ToString();
        }

        public string Recupvaleurskin3()
        {
            return skin3.SelectedItem.ToString();
        }

        public string Recupvaleurskin4()
        {
            return skin4.SelectedItem.ToString();
        }


        public acceuil()
        {




        







            InitializeComponent();
            Instance = this;




            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionStr = version.ToString();
            label16.Text = versionStr;











            var CheminDgVoodo = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), @"dgVoodoo\dgVoodoo.conf");

            var CheminIniVirtuel = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"VirtualStore\Windows\Ubisoft\ubi.ini");

            //MessageBox.Show("ini dgvoddo");

            if (File.Exists(Path.Combine(CheminDgVoodo))) {  } else {
                //MessageBox.Show("creation");

                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\basefile\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf"); 
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\basefile\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
                string sourceFile2 = @"fils\basefile\dgVoodooSetupPaths.dat";
                string destPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\dgVoodoo\";
                string destFile2 = destPath2 + "dgVoodooSetupPaths.dat";

                // Vérifier si le répertoire de destination existe et le créer s'il n'existe pas
                if (!Directory.Exists(destPath2))
                {
                    Directory.CreateDirectory(destPath2);
                }

                // Copier le fichier source vers le fichier de destination
                File.Copy(sourceFile2, destFile2, true);

                string sourceFile = @"fils\basefile\dgVoodoo.conf";
                string destPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\dgVoodoo\";
                string destFile = destPath + "dgVoodoo.conf";

                // Vérifier si le répertoire de destination existe et le créer s'il n'existe pas
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }

                // Copier le fichier source vers le fichier de destination
                File.Copy(sourceFile, destFile, true);



            }
            //MessageBox.Show(" dgvoddo ok");

            //MessageBox.Show("ini ini");
            if (File.Exists(Path.Combine(@"C:\Windows\Ubisoft\ubi.ini"))) { } else {




                string sourceFile2 = @"fils\basefile\ubi.ini";
                string destPath2 = @"C:\Windows\Ubisoft\";
                string destFile2 = destPath2 + "ubi.ini";

                // Vérifier si le répertoire de destination existe et le créer s'il n'existe pas
                if (!Directory.Exists(destPath2))
                {
                    Directory.CreateDirectory(destPath2);
                }

                File.Copy(sourceFile2, destFile2, true);

                // File.Copy("fils\\basefile\\ubi.ini", @"C:\Windows\Ubisoft\ubi.ini", true);
                System.Threading.Thread.Sleep(1000);
            
            }
           // MessageBox.Show("ini ok");
            // if (File.Exists(Path.Combine(CheminIniVirtuel))) { } else { System.Diagnostics.Process.Start("cmd", @"/c copy fils\basefile\ubi.ini %LocalAppData%\VirtualStore\Windows\Ubisoft\ubi.ini"); System.Threading.Thread.Sleep(1000); }



            // UIGLIU

          //  MessageBox.Show("lecture xml init");
            lecturexml();
            //MessageBox.Show("lecture xml ok");
            //MessageBox.Show("maj xml init");
            majselectjoueur();
            //MessageBox.Show("maj xml ok");
            FillScreenResolutions();
            // verifie les résolution compatible

            MajRadminServeurName();

            //MessageBox.Show(" init reso ");
            if (ResoAuto == "1")// si le bouton reso et cocher alors on active la fonction qui calcul la resolution
            { ActivationResoAuto(); ButtonresoAuto.Checked = true; }
           

            if (ResoGame != "0")
            {
                int m = Int32.Parse(ResoGame);

                comboBox2.SelectedIndex = m;

            }
            else {

                comboBox2.SelectedIndex = 0;

            }

            if (Langueauto == "1") { langueautomatique.Checked = true; }        // si le bouton langueauto  et cocher alors on active 

            else { langueautomatique.Checked = false; }


            //MessageBox.Show("  reso ok ");


            //            MessageBox.Show("  verif position bouton int ");

            if (Manettevib == "2") { Manettevib = "3"; radioButton2.Checked = true; } // manette vibration on 

            if (Manettevib == "0") { Manettevib = "4"; radioButton1.Checked = true; } // manette vibration on 


            //          MessageBox.Show("  langue init ");
            langageautomatique();
            int LangueGameint = int.Parse(LangueGame);

            comboBox3.SelectedIndex = LangueGameint; // intiali langue jeu

    //        MessageBox.Show("  langue ok ");

      //      MessageBox.Show("  HD SD ININT");

            //initilise le bouton radio choix du jeu hd ou sd
            if (Gamehdsd == "1")
            {
                HDRADIO.Checked = true;
            }
            else
            {
                SDRADIO.Checked = true;

            }

            if (Videomode == "1" || Videomode == "3") {

                OnGameIntro.Checked = true;

            }


            if (Screenmode == "1" || Screenmode == "3")
            {
                Windowsscreen.Checked = true;
            }


            if (Screenmode == "0" || Screenmode == "2")
            {
                FullScreen.Checked = true;
            }



            if (Screenmode == "3")
            {
                Windowsscreen.Checked = true;
            }

            if (Videomode == "0" || Videomode == "4")
            {
                OffGameIntro.Checked = true;
            }


            //MessageBox.Show("  HD SD OK");


            // test si un modif skin viens d etre effectuer pour lancer le luncher direct sur le skin
            if (Ongletskin != "0") { tabControl1.SelectedIndex = 1; Ongletskin = "0"; MajXML();  checkBox1.Enabled = false; } //affiche l'onglet des skin} 

            if (Skinhdsd == "1") { checkBox1.Checked = true; checkBox1.Enabled = false; }  // la personne a modifier un skin, on lui empeche de touxher à la checkbox jusqu'a reinisialisation

            if (Skinhdsd == "2") { checkBox1.Checked = false; checkBox1.Enabled = false; }  // la personne a modifier un skin, on lui empeche de touxher à la checkbox jusqu'a reinisialisation

            if (Skinhdsd == "3") { checkBox1.Checked = false; checkBox1.Enabled = Enabled; Skinhdsd = "0"; MajXML(); }
           // reinisialisation des skin donc on rend le check box accessible
                                                                                                                        //test si le fichier txt est present (partie langue)
                                                                                                                        //MessageBox.Show("  verif position bouton ok ");

            //MessageBox.Show("  choix langue inint ");


            verifhd();



            if (!File.Exists(cheminfichierLangue))
            {
                File.WriteAllText(cheminfichierLangue, "EN");
                changelangue.SelectedIndex = 0;
                choixlangue();





            }
            else
            {
                string lecture = File.ReadAllText(cheminfichierLangue);

                if (lecture == "EN")
                {
                    changelangue.SelectedIndex = 0;
                    choixlangue();

                }
                else if (lecture == "FR")
                {
                    changelangue.SelectedIndex = 1;
                    choixlangue();

                }
                else if (lecture == "ES")
                {
                    changelangue.SelectedIndex = 2;
                    choixlangue();

                }
                else if (lecture == "RU")
                {
                    changelangue.SelectedIndex = 3;
                    choixlangue();

                }
            }

          //  MessageBox.Show("  choix langue ok ");

            //MessageBox.Show("  test reseau ok ");
            // affiche les interface reseau au demarrage
            Adapters obj = new Adapters();
            var value = obj.net_adapters();
            foreach (var name in value) { comboBox1.Items.Add(name); Console.WriteLine(name); }

            comboBox1.SelectedIndex = 0; // combo carte reseau





         
          //  MessageBox.Show("  test reseau ok ");


            //MessageBox.Show("  verification jeu en ligne inint ");
            
            //MessageBox.Show("  verification jeu en ligne ok ");

            //tester que le luncher et bein configurer pour jouer en ligne

            //MessageBox.Show("  verification maj init");
            verifmaj(0);
            //MessageBox.Show("  verification maj ok");
            // verifie les mise à jour
            onlinetest();

            //verif sd  present pour ouvrire fenetre

            string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
             string cheminRepertoirePourTestDossier = @"game\SD\"; // Remplace avec le chemin relatif de ton répertoire

            // Obtient le chemin complet du fichier dans le répertoire spécifié
             string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);


            if (!File.Exists(cheminFichierTestDemarrageLanceur))// si la personne n'a pas de jeux on lui fait telecharger
            {
                Form4 sw = new Form4();
                sw.StartPosition = FormStartPosition.CenterScreen; // Centre la nouvelle fenêtre sur l'écran
                sw.ShowDialog(); // Affiche la fenêtre en premier plan (fenêtre modale)

            }
            else // si elle à le jeux on cherche radmin et on modie le patch
            {

                foreach (var name in value)  // on cherche si la personne a bien radmin vpn sur son pc
                {
                    if (name == "Radmin VPN")
                    {
                        radminok = 1;
                    }
                }



                //test si le fichier txt est present
                if (!File.Exists(cheminfichier))
                {
                    //MessageBox.Show("fichier non present");


                    if (radminok == 0) // si il la pas on  l'avertie de l'installer
                    {
                        MessageBox.Show(Pasradmin);
                    }
                    else
                    {
                        File.WriteAllText(cheminfichier, "Radmin VPN");
                        File.WriteAllText(cheminfichier2, "Radmin VPN");
                    }

                }

            }





        }










        // variable global
        int radminok = 0; //radmin vpn installer
        string messageboxLangue = "";
        string messageboxNoVideo = "game intro videos have been disabled";
        string messageboxOkVideo = "the game's intro videos have been reactivated";
        string Choixcard = " well was to select";
        string Pasradmin = "we have detected that you do not have Radmin Vpn installed. This program is required to play the game online";
        string CopieNomReseau = "the network name has been copied to the clipboard";
        string CopieMdpReseau = "the network passord has been copied to the clipboard";
        string onlinetestgreen = "You are ready to play online on the official network";
        string onlinetestorange = "Radmin Vpn is ok I detected more launcher is on the good card";
        string onlinetestred = "Radmin Vpn is not detected and the launcher is not on the good card !!";
        string Incompletskin = "the skin is missing files. Unable to select it";
        string skindoublon = "another player has already been configured in the same place!!";
        string ReiniSkin = "Are you sure you want to reset the skins?";
        string ActivDesaSKINsdHD = "once a skin has been modified in sd or hd it is no longer possible to change position. You have to re-insulate the skin to modify the quality of the texture.";
        string Vertionajour = "you have the most recent version";
        string vertionpasajour = "You don't have the latest version. Do you want to download it?";
        string pasverifmaj = "I can't check your version. Can you check your internet connection?";
        string skinincomplet = "the skin you have chosen is incomplete. It therefore cannot be loaded. Do you want to reset the skins? (if not the program will stop).";
        string resolutionwarnning = "this resolution is not supported by the game. The launcher will adapt it as best as possible. For best results select a supported resolution";



        string Ongletskin = "0";
        string Skinhdsd = "0";
        string Gamehdsd = "0";
        string ResoGame = "0";
        string Screenmode = "0";
        string Videomode = "0";
        string LangueGame = "0";
        string Manettevib = "0";
        string ResoAuto = "1";
        string Langueauto = "1";

        //variable skinperso


        string Nomjoueur1 = "";
        string emplacementjoueur1 = "99";
        string skinjoueueur1 = "99";

        string Nomjoueur2 = "";
        string emplacementjoueur2 = "99";
        string skinjoueueur2 = "99";

        string Nomjoueur3 = "";
        string emplacementjoueur3 = "99";
        string skinjoueueur3 = "99";


        string Nomjoueur4 = "";
        string emplacementjoueur4 = "99";
        string skinjoueueur4 = "99";



        string nomdelexe = "R_Arena.exe";




        // partie qui permet de detecter toutes les résolution pris en charge
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        // fin partie qui detect toute les résolution prise en charge




        //Partie Resolution d'écran automatqiue



        // partie verif hd version 

        public void verifhd() {

            string fichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
            string CheminRepertoirePourTestDossier = @"game\HD\\";
            string CheminFichierTestDemarrageLanceur = Path.Combine(CheminRepertoirePourTestDossier, fichierSDJeuxPourTestDossier);

            if (!File.Exists(CheminFichierTestDemarrageLanceur))
            {
                checkBox1.Enabled = false;
                Gamehdsd = "0";
                VerifHdok = 1;
                HDRADIO.Enabled = false;
                SDRADIO.Checked = true;
                
            }


        }


        public static string GetBestResolution()
        {
            // Obtenir la résolution actuelle de l'écran de l'utilisateur
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Définir les résolutions prédéfinies à tester
            int[,] resolutions = new int[,] {  { 800, 600 }, { 1152, 864 }, { 1024, 768 }, { 1280, 960 }, { 1280, 720 }, { 1280, 768 }, { 1280, 800 }, { 1280, 960 }, { 1280, 1024 }, { 1360, 768 }, { 1366, 768 }, { 1440, 900 }, { 1600, 900 }, { 1600, 1024 }, { 1680, 1050 }, { 1600, 1200 }, { 1920, 1080 }, { 1920, 1200 } };

            // Initialiser la meilleure résolution à la première résolution de la liste
            int bestResolutionWidth = resolutions[0, 0];
            int bestResolutionHeight = resolutions[0, 1];

            // Parcourir la liste des résolutions prédéfinies et trouver celle qui convient le mieux
            for (int i = 0; i < resolutions.GetLength(0); i++)
            {
                int resolutionWidth = resolutions[i, 0];
                int resolutionHeight = resolutions[i, 1];

                // Vérifier si la résolution prédéfinie actuelle est plus adaptée que la meilleure résolution actuelle
                if (screenWidth >= resolutionWidth && screenHeight >= resolutionHeight)
                {
                    if (resolutionWidth >= bestResolutionWidth && resolutionHeight >= bestResolutionHeight)
                    {
                        bestResolutionWidth = resolutionWidth;
                        bestResolutionHeight = resolutionHeight;
                    }
                }
            }

            // Retourner la meilleure résolution trouvée sous forme de chaîne

            //MessageBox.Show(bestResolutionWidth + "x" + bestResolutionHeight);
            return bestResolutionWidth + " x " + bestResolutionHeight;
        }



        // fin partie resolution automatique











        public void lecturexml()
        {
            try
            {
                string cheminFichierXML = Path.Combine(Application.StartupPath, "Root.xml");

                if (File.Exists(cheminFichierXML))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(cheminFichierXML);

                    XmlNodeList nodes = xdoc.SelectNodes("//lesjoueur/param");

                    foreach (XmlNode node4 in nodes)
                    {
                        XmlNode ongletskin = node4.SelectSingleNode("ongletskin");
                        Ongletskin = ongletskin.InnerText;

                        XmlNode skinhdsd = node4.SelectSingleNode("skinhdsd");
                        Skinhdsd = skinhdsd.InnerText;

                        XmlNode gamehdsd = node4.SelectSingleNode("gamehdsd");
                        Gamehdsd = gamehdsd.InnerText;

                        XmlNode resoGame = node4.SelectSingleNode("resoGame");
                        ResoGame = resoGame.InnerText;

                        XmlNode videomode = node4.SelectSingleNode("videomode");
                        Videomode = videomode.InnerText;

                        XmlNode screenmode = node4.SelectSingleNode("screenmode");
                        Screenmode = screenmode.InnerText;

                        XmlNode langueGame = node4.SelectSingleNode("langueGame ");
                        LangueGame = langueGame.InnerText;

                        XmlNode manettevib = node4.SelectSingleNode("manettevib");
                        Manettevib = manettevib.InnerText;

                        XmlNode resoAuto = node4.SelectSingleNode("resoAuto");
                        ResoAuto = resoAuto.InnerText;

                        XmlNode langueauto = node4.SelectSingleNode("langueauto");
                        Langueauto = langueauto.InnerText;
                    }

                    XmlNodeList joueurNodes1 = xdoc.SelectNodes("//lesjoueur/joueur1");
                    foreach (XmlNode node1 in joueurNodes1)
                    {
                        XmlNode nomduperso1 = node1.SelectSingleNode("nomduperso");
                        Nomjoueur1 = nomduperso1.InnerText;

                        XmlNode emplacement1 = node1.SelectSingleNode("emplacement");
                        emplacementjoueur1 = emplacement1.InnerText;

                        XmlNode skin1 = node1.SelectSingleNode("skin");
                        skinjoueueur1 = skin1.InnerText;
                    }

                    XmlNodeList joueurNodes2 = xdoc.SelectNodes("//lesjoueur/joueur2");
                    foreach (XmlNode node2 in joueurNodes2)
                    {
                        XmlNode nomduperso2 = node2.SelectSingleNode("nomduperso");
                        Nomjoueur2 = nomduperso2.InnerText;

                        XmlNode emplacement2 = node2.SelectSingleNode("emplacement");
                        emplacementjoueur2 = emplacement2.InnerText;

                        XmlNode skin2 = node2.SelectSingleNode("skin");
                        skinjoueueur2 = skin2.InnerText;
                    }

                    XmlNodeList joueurNodes3 = xdoc.SelectNodes("//lesjoueur/joueur3");
                    foreach (XmlNode node3 in joueurNodes3)
                    {
                        XmlNode nomduperso3 = node3.SelectSingleNode("nomduperso");
                        Nomjoueur3 = nomduperso3.InnerText;

                        XmlNode emplacement3 = node3.SelectSingleNode("emplacement");
                        emplacementjoueur3 = emplacement3.InnerText;

                        XmlNode skin3 = node3.SelectSingleNode("skin");
                        skinjoueueur3 = skin3.InnerText;
                    }

                    XmlNodeList joueurNodes4 = xdoc.SelectNodes("//lesjoueur/joueur4");
                    foreach (XmlNode node4 in joueurNodes4)
                    {
                        XmlNode nomduperso4 = node4.SelectSingleNode("nomduperso");
                        Nomjoueur4 = nomduperso4.InnerText;

                        XmlNode emplacement4 = node4.SelectSingleNode("emplacement");
                        emplacementjoueur4 = emplacement4.InnerText;

                        XmlNode skin4 = node4.SelectSingleNode("skin");
                        skinjoueueur4 = skin4.InnerText;
                    }
                }
                else
                {
                    // MessageBox.Show("Le fichier Root.xml n'existe pas à cet emplacement.", "Fichier introuvable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la lecture du fichier XML : {ex.Message}. Suppression du fichier XML en cours.", "Erreur de lecture", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Supprimer le fichier XML
                string cheminFichierXML = Path.Combine(Application.StartupPath, "Root.xml");
                if (File.Exists(cheminFichierXML))
                {
                    try
                    {
                        File.Delete(cheminFichierXML);
                        // MessageBox.Show("Le fichier XML a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception deleteEx)
                    {
                        MessageBox.Show($"Erreur lors de la suppression du fichier XML : {deleteEx.Message}", "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Redémarrer l'application
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur inattendue s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void majselectjoueur()
        {








            int tempemplacementjoueur1 = Int32.Parse(emplacementjoueur1);
            //  int tempskinjoueueur1 = Int32.Parse(skinjoueueur1); 


            int tempemplacementjoueur2 = Int32.Parse(emplacementjoueur2);
            // int tempskinjoueueur2 = Int32.Parse(skinjoueueur2);

            int tempemplacementjoueur3 = Int32.Parse(emplacementjoueur3);
            // int tempskinjoueueur3 = Int32.Parse(skinjoueueur3);

            int tempemplacementjoueur4 = Int32.Parse(emplacementjoueur4);
            //  int tempskinjoueueur4 = Int32.Parse(skinjoueueur4);


            int tempposperso1 = 0;
            int tempposperso2 = 0;
            int tempposperso3 = 0;
            int tempposperso4 = 0;

            if (Nomjoueur1 == "rayman") { tempposperso1 = 0; }
            if (Nomjoueur1 == "razor") { tempposperso1 = 1; }
            if (Nomjoueur1 == "razorwife") { tempposperso1 = 2; }
            if (Nomjoueur1 == "globox") { tempposperso1 = 3; }
            if (Nomjoueur1 == "huchman") { tempposperso1 = 4; }
            if (Nomjoueur1 == "ptizetre") { tempposperso1 = 5; }
            if (Nomjoueur1 == "tily") { tempposperso1 = 6; }
            if (Nomjoueur1 == "huch10000") { tempposperso1 = 7; }

            if (Nomjoueur2 == "rayman") { tempposperso2 = 0; }
            if (Nomjoueur2 == "razor") { tempposperso2 = 1; }
            if (Nomjoueur2 == "razorwife") { tempposperso2 = 2; }
            if (Nomjoueur2 == "globox") { tempposperso2 = 3; }
            if (Nomjoueur2 == "huchman") { tempposperso2 = 4; }
            if (Nomjoueur2 == "ptizetre") { tempposperso2 = 5; }
            if (Nomjoueur2 == "tily") { tempposperso2 = 6; }
            if (Nomjoueur2 == "huch10000") { tempposperso2 = 7; }

            if (Nomjoueur3 == "rayman") { tempposperso3 = 0; }
            if (Nomjoueur3 == "razor") { tempposperso3 = 1; }
            if (Nomjoueur3 == "razorwife") { tempposperso3 = 2; }
            if (Nomjoueur3 == "globox") { tempposperso3 = 3; }
            if (Nomjoueur3 == "huchman") { tempposperso3 = 4; }
            if (Nomjoueur3 == "ptizetre") { tempposperso3 = 5; }
            if (Nomjoueur3 == "tily") { tempposperso3 = 6; }
            if (Nomjoueur3 == "huch10000") { tempposperso3 = 7; }

            if (Nomjoueur4 == "rayman") { tempposperso4 = 0; }
            if (Nomjoueur4 == "razor") { tempposperso4 = 1; }
            if (Nomjoueur4 == "razorwife") { tempposperso4 = 2; }
            if (Nomjoueur4 == "globox") { tempposperso4 = 3; }
            if (Nomjoueur4 == "huchman") { tempposperso4 = 4; }
            if (Nomjoueur4 == "ptizetre") { tempposperso4 = 5; }
            if (Nomjoueur4 == "tily") { tempposperso4 = 6; }
            if (Nomjoueur4 == "huch10000") { tempposperso4 = 7; }






            // string nomskincusom = "0";

            //  DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
            //  DirectoryInfo[] diArr = di.GetDirectories();
            //  foreach (DirectoryInfo dri in diArr)
            //  {
            //      if (dri.Name == tempskinjoueueur1) { nomskincusom = "1"; }
            //  }








            if (Nomjoueur1 == "")
            {

                Choixperso1.Text = "Rayman";
                Choixperso1.Items.Insert(0, "Rayman");
                Choixperso1.SelectedIndex = 0;
                empl1.SelectedIndex = 0;
                skin1.SelectedIndex = 0;
            }
            else if (Nomjoueur1 == "aucun")
            {

                Choixperso1.Text = "Rayman";
                Choixperso1.Items.Insert(0, "Rayman");
                Choixperso1.SelectedIndex = 0;
                empl1.SelectedIndex = 0;
                skin1.SelectedIndex = 0;

            }
            else
            {
                Choixperso1.Text = "Rayman";
                Choixperso1.Items.Insert(0, "Rayman");
                Choixperso1.SelectedIndex = tempposperso1;
                empl1.SelectedIndex = tempemplacementjoueur1;
                skin1.Text = skinjoueueur1;

            }








            if (Nomjoueur2 == "")
            {

                Choixperso2.Text = "Rayman";
                Choixperso2.Items.Insert(0, "Rayman");
                Choixperso2.SelectedIndex = 0;
                empl2.SelectedIndex = 0;
                skin2.SelectedIndex = 0;
            }

            else if (Nomjoueur2 == "aucun")
            {

                Choixperso2.Text = "Rayman";
                Choixperso2.Items.Insert(0, "Rayman");
                Choixperso2.SelectedIndex = 0;
                empl2.SelectedIndex = 0;
                skin2.SelectedIndex = 0;

            }



            else
            {

                Choixperso2.Text = "Rayman";
                Choixperso2.Items.Insert(0, "Rayman");
                Choixperso2.SelectedIndex = tempposperso2;
                empl2.SelectedIndex = tempemplacementjoueur2;
                skin2.Text = skinjoueueur2;

            }






            if (Nomjoueur3 == "")
            {
                Choixperso3.Text = "Rayman";
                Choixperso3.Items.Insert(0, "Rayman");
                Choixperso3.SelectedIndex = 0;
                empl3.SelectedIndex = 0;
                skin3.SelectedIndex = 0;
            }

            else if (Nomjoueur3 == "aucun")
            {

                Choixperso3.Text = "Rayman";
                Choixperso3.Items.Insert(0, "Rayman");
                Choixperso3.SelectedIndex = 0;
                empl3.SelectedIndex = 0;
                skin3.SelectedIndex = 0;

            }

            else
            {
                Choixperso3.Text = "Rayman";
                Choixperso3.Items.Insert(0, "Rayman");
                Choixperso3.SelectedIndex = tempposperso3;
                empl3.SelectedIndex = tempemplacementjoueur3;
                skin3.Text = skinjoueueur3;


            }

            if (Nomjoueur4 == "")
            {

                Choixperso4.Text = "Rayman";
                Choixperso4.Items.Insert(0, "Rayman");
                Choixperso4.SelectedIndex = 0;
                empl4.SelectedIndex = 0;
                skin4.SelectedIndex = 0;

            }

            else if (Nomjoueur4 == "aucun")
            {

                Choixperso4.Text = "Rayman";
                Choixperso4.Items.Insert(0, "Rayman");
                Choixperso4.SelectedIndex = 0;
                empl4.SelectedIndex = 0;
                skin4.SelectedIndex = 0;

            }


            else
            {

                Choixperso4.Text = "Rayman";
                Choixperso4.Items.Insert(0, "Rayman");
                Choixperso4.SelectedIndex = tempposperso4;
                empl4.SelectedIndex = tempemplacementjoueur4;
                skin4.Text = skinjoueueur4;




            }


        }














        public void majselectjoueurencour()
        {


            int tempemplacementjoueur1 = Int32.Parse(emplacementjoueur1);
            //  int tempskinjoueueur1 = Int32.Parse(skinjoueueur1); 


            int tempemplacementjoueur2 = Int32.Parse(emplacementjoueur2);
            // int tempskinjoueueur2 = Int32.Parse(skinjoueueur2);

            int tempemplacementjoueur3 = Int32.Parse(emplacementjoueur3);
            // int tempskinjoueueur3 = Int32.Parse(skinjoueueur3);

            int tempemplacementjoueur4 = Int32.Parse(emplacementjoueur4);
            //  int tempskinjoueueur4 = Int32.Parse(skinjoueueur4);


            int tempposperso1 = 0;
            int tempposperso2 = 0;
            int tempposperso3 = 0;
            int tempposperso4 = 0;

            if (Nomjoueur1 == "rayman") { tempposperso1 = 0; }
            if (Nomjoueur1 == "razor") { tempposperso1 = 1; }
            if (Nomjoueur1 == "razorwife") { tempposperso1 = 2; }
            if (Nomjoueur1 == "globox") { tempposperso1 = 3; }
            if (Nomjoueur1 == "huchman") { tempposperso1 = 4; }
            if (Nomjoueur1 == "ptizetre") { tempposperso1 = 5; }
            if (Nomjoueur1 == "tily") { tempposperso1 = 6; }
            if (Nomjoueur1 == "huch10000") { tempposperso1 = 7; }

            if (Nomjoueur2 == "rayman") { tempposperso2 = 0; }
            if (Nomjoueur2 == "razor") { tempposperso2 = 1; }
            if (Nomjoueur2 == "razorwife") { tempposperso2 = 2; }
            if (Nomjoueur2 == "globox") { tempposperso2 = 3; }
            if (Nomjoueur2 == "huchman") { tempposperso2 = 4; }
            if (Nomjoueur2 == "ptizetre") { tempposperso2 = 5; }
            if (Nomjoueur2 == "tily") { tempposperso2 = 6; }
            if (Nomjoueur2 == "huch10000") { tempposperso2 = 7; }

            if (Nomjoueur3 == "rayman") { tempposperso3 = 0; }
            if (Nomjoueur3 == "razor") { tempposperso3 = 1; }
            if (Nomjoueur3 == "razorwife") { tempposperso3 = 2; }
            if (Nomjoueur3 == "globox") { tempposperso3 = 3; }
            if (Nomjoueur3 == "huchman") { tempposperso3 = 4; }
            if (Nomjoueur3 == "ptizetre") { tempposperso3 = 5; }
            if (Nomjoueur3 == "tily") { tempposperso3 = 6; }
            if (Nomjoueur3 == "huch10000") { tempposperso3 = 7; }

            if (Nomjoueur4 == "rayman") { tempposperso4 = 0; }
            if (Nomjoueur4 == "razor") { tempposperso4 = 1; }
            if (Nomjoueur4 == "razorwife") { tempposperso4 = 2; }
            if (Nomjoueur4 == "globox") { tempposperso4 = 3; }
            if (Nomjoueur4 == "huchman") { tempposperso4 = 4; }
            if (Nomjoueur4 == "ptizetre") { tempposperso4 = 5; }
            if (Nomjoueur4 == "tily") { tempposperso4 = 6; }
            if (Nomjoueur4 == "huch10000") { tempposperso4 = 7; }






            // string nomskincusom = "0";

            //  DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
            //  DirectoryInfo[] diArr = di.GetDirectories();
            //  foreach (DirectoryInfo dri in diArr)
            //  {
            //      if (dri.Name == tempskinjoueueur1) { nomskincusom = "1"; }
            //  }








            if (Nomjoueur1 == "")
            {

                Choixperso1.SelectedIndex = 0;
                empl1.SelectedIndex = 0;
                skin1.SelectedIndex = 0;
            }
            else if (Nomjoueur1 == "aucun")
            {


                Choixperso1.SelectedIndex = 0;
                empl1.SelectedIndex = 0;
                skin1.SelectedIndex = 0;

            }
            else
            {

                Choixperso1.SelectedIndex = tempposperso1;
                empl1.SelectedIndex = tempemplacementjoueur1;
                skin1.Text = skinjoueueur1;

            }








            if (Nomjoueur2 == "")
            {


                Choixperso2.SelectedIndex = 0;
                empl2.SelectedIndex = 0;
                skin2.SelectedIndex = 0;
            }

            else if (Nomjoueur2 == "aucun")
            {


                Choixperso2.SelectedIndex = 0;
                empl2.SelectedIndex = 0;
                skin2.SelectedIndex = 0;

            }



            else
            {


                Choixperso2.SelectedIndex = tempposperso2;
                empl2.SelectedIndex = tempemplacementjoueur2;
                skin2.Text = skinjoueueur2;

            }






            if (Nomjoueur3 == "")
            {

                Choixperso3.SelectedIndex = 0;
                empl3.SelectedIndex = 0;
                skin3.SelectedIndex = 0;
            }

            else if (Nomjoueur3 == "aucun")
            {

                Choixperso3.SelectedIndex = 0;
                empl3.SelectedIndex = 0;
                skin3.SelectedIndex = 0;

            }

            else
            {

                Choixperso3.SelectedIndex = tempposperso3;
                empl3.SelectedIndex = tempemplacementjoueur3;
                skin3.Text = skinjoueueur3;


            }

            if (Nomjoueur4 == "")
            {


                Choixperso4.SelectedIndex = 0;
                empl4.SelectedIndex = 0;
                skin4.SelectedIndex = 0;

            }

            else if (Nomjoueur4 == "aucun")
            {

                Choixperso4.SelectedIndex = 0;
                empl4.SelectedIndex = 0;
                skin4.SelectedIndex = 0;

            }


            else
            {

                Choixperso4.SelectedIndex = tempposperso4;
                empl4.SelectedIndex = tempemplacementjoueur4;
                skin4.Text = skinjoueueur4;




            }


        }










        void modifini(string contenue)
        {

            string filePatch = @"C:\Windows\Ubisoft\ubi.ini";

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePatch).ToList();


            foreach (string line in lines)
            {

                Console.WriteLine(line);

            }


            if (contenue == "EN") { lines[14] = "Language =English"; }
            else if (contenue == "FR") { lines[14] = "Language =French"; }
            else if (contenue == "ES") { lines[14] = "Language =Spanish"; }


            else if (contenue == "1600 x 1024" || contenue == "1280 x 1024" || contenue == "1280 x 768")
            {

                //4:3 non pris en charge

                lines[1] = "Gli_Mode =1 - 800 x 600 x 32";



            }

            else if (contenue == "1024 x 576m" | contenue == "2560 x 1440m" | contenue == "3840 x 2160m")
            {
                //16:9 non pris en charge
                lines[1] = "Gli_Mode =1 - 1280 x 720 x 32";
                MessageBox.Show(resolutionwarnning);

            }
            // else if (contenue == "1920 x 1200" | contenue == "2560 x 1600")
            else if (contenue == "2560 x 1600m")
            {
                //16:10 non pris en charge
                lines[1] = "Gli_Mode =1 - 1280 x 800 x 32";
                MessageBox.Show(resolutionwarnning);


            }
   
            else if (contenue == "1920 x 1080") {
               // MessageBox.Show("testnn");
                lines[1] = "Gli_Mode =1 - 1920 x 1080 x 32";
                //MessageBox.Show(resolutionwarnning);
                

            }

            else if (contenue == "2560 x 1080m" | contenue == "3440 x 1440m" | contenue == "5120 x 2160m")
            {
                //21:9 non pris en charge

                lines[1] = "Gli_Mode =1 - 800 x 600 x 32";
                MessageBox.Show(resolutionwarnning);


            }



            else
            {



                lines[1] = "Gli_Mode =1 - " + contenue + " x 32";



            }


            File.WriteAllLines(filePatch, lines);

/*
            filePatch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"VirtualStore\Windows\Ubisoft\ubi.ini");


            List<string> lines2 = new List<string>();
            lines2 = File.ReadAllLines(filePatch).ToList();


            foreach (string line in lines2)
            {

                Console.WriteLine(line);

            }


            if (contenue == "EN") { lines2[14] = "Language =English"; }
            else if (contenue == "FR") { lines2[14] = "Language =French"; }
            else if (contenue == "ES") { lines2[14] = "Language =Spanish"; }
            else
            {

                lines2[1] = "Gli_Mode =1 - " + contenue + " x 32";
            }


            File.WriteAllLines(filePatch, lines2);


*/


        }



        public  string  voirskin1 () {

            string test = "";

            skin4.SelectedText = test;

            return test;


        }

        void ActivationResoAuto() 
        {

            if (ButtonresoAuto.Checked == true)
            {
                comboBox2.Enabled = false;
                string bestResolution = GetBestResolution();

                //MessageBox.Show(bestResolution);

                comboBox2.SelectedItem = bestResolution;

              //  if (bestResolution == "800 x 600") { comboBox2.SelectedIndex = 1; }
                //else if (bestResolution == "1152 x 864") { comboBox2.SelectedIndex = 2; }
                //else if (bestResolution == "1024 x 768") { comboBox2.SelectedIndex = 3; }
                //else if (bestResolution == "1280 x 960") { comboBox2.SelectedIndex = 4; }
                //else if (bestResolution == "1280 x 720") { comboBox2.SelectedIndex = 5; }
                //else if (bestResolution == "1280 x 768") { comboBox2.SelectedIndex = 6; }
                //else if (bestResolution == "1280 x 800") { comboBox2.SelectedIndex = 7; }
                //else if (bestResolution == "1280 x 960") { comboBox2.SelectedIndex = 8; }
                //else if (bestResolution == "1280 x 1024") { comboBox2.SelectedIndex = 9; }
                //else if (bestResolution == "1360 x 768") { comboBox2.SelectedIndex = 10; }
                //else if (bestResolution == "1366 x 768") { comboBox2.SelectedIndex = 11; }
                //else if (bestResolution == "1440 x 900") { comboBox2.SelectedIndex = 12; }
                //else if (bestResolution == "1600 x 900") { comboBox2.SelectedIndex = 13; }
                //else if (bestResolution == "1600 x 1024") { comboBox2.SelectedIndex = 14; }
                //else if (bestResolution == "1680 x 1050") { comboBox2.SelectedIndex = 15; }
                //else if (bestResolution == "1600 x 1200") { comboBox2.SelectedIndex = 16; }
                //else if (bestResolution == "1920 x 1080") { comboBox2.SelectedIndex = 17; }
                //else if (bestResolution == "1920 x 1200") { comboBox2.SelectedIndex = 18; }


            }
            else

            {

                comboBox2.Enabled = true;


            }



        }


        void LanseurRatio(string contenue)
        {

            if (comboBox2.Text == "640 x 480" || comboBox2.Text == "800 x 600" || comboBox2.Text == "960 x 720" || comboBox2.Text == "1024 x 768" || comboBox2.Text == "1024 x 728" || comboBox2.Text == "1152 x 864" || comboBox2.Text == "1280 x 960" || comboBox2.Text == "1400 x 1050" || comboBox2.Text == "1440 x 1080" || comboBox2.Text == "1600 x 1200" || comboBox2.Text == "1856 x 1392" || comboBox2.Text == "1920 x 1440" || comboBox2.Text == "2048 x 1536")
            {
               // MessageBox.Show("4:3");
                //4:3

                if (contenue == "SD") {

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\SD\R_Arena.exe";
                    Process.Start(startInfo);

                }
                if (contenue == "HD") {

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\HD\R_Arena.exe";
                    Process.Start(startInfo);




                }



                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    nomdelexe = "R_Arena.exe";
                    checkBox2.Checked = true;

                }
                else {

                    nomdelexe = "R_Arena.exe";

                }

                    

            }

            if (comboBox2.Text == "3840 x 2160" || comboBox2.Text == "2560 x 1440" || comboBox2.Text == "1920 x 1080" || comboBox2.Text == "1600 x 900" || comboBox2.Text == "1366 x 768" || comboBox2.Text == "1280 x 720" || comboBox2.Text == "1024 x 576" || comboBox2.Text == "1360 x 768")
            {

                //16:9
               // MessageBox.Show("16:9");

                if (contenue == "SD") { 


                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\SD\R_Arena16x9.exe";
                    Process.Start(startInfo);




                }
                if (contenue == "HD") {

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\HD\R_Arena16x9.exe";
                    Process.Start(startInfo);





                }


                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    nomdelexe = "R_Arena16x9.exe";
                    checkBox2.Checked = true;

                }
                else
                {

                    nomdelexe = "R_Arena16x9.exe";

                }

               


            }

            if (comboBox2.Text == "1280 x 800" || comboBox2.Text == "1440 x 900" || comboBox2.Text == "1680 x 1050" || comboBox2.Text == "1920 x 1200" || comboBox2.Text == "2560 x 1600")
            {

                //16:10

                if (contenue == "SD") { //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena16x10.exe");


                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\SD\R_Arena16x10.exe";
                    Process.Start(startInfo);

                }
                if (contenue == "HD") { //System.Diagnostics.Process.Start("cmd", @"/c start game\HD\R_Arena16x10.exe");


                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\HD\R_Arena16x10.exe";
                    Process.Start(startInfo);


                }


                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    nomdelexe = "R_Arena16x10.exe";
                    checkBox2.Checked = true;

                }
                else
                {

                    nomdelexe = "R_Arena16x10.exe";

                }

                

            }

            if (comboBox2.Text == "2560 x 1080" || comboBox2.Text == "3440 x 1440" || comboBox2.Text == "5120 x 2160")
            {

                //21:9

                //  if (contenue == "SD") { System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena21x9.exe"); }
                //  if (contenue == "HD") { System.Diagnostics.Process.Start("cmd", @"/c start game\HD\R_Arena21x9.exe"); }


                if (contenue == "SD") { //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena.exe");

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\SD\R_Arena.exe";
                    Process.Start(startInfo);


                }
                if (contenue == "HD") { //System.Diagnostics.Process.Start("cmd", @"/c start game\HD\R_Arena.exe");

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\HD\R_Arena.exe";
                    Process.Start(startInfo);



                }

                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    nomdelexe = "R_Arena.exe";
                    checkBox2.Checked = true;

                }
                else
                {

                    nomdelexe = "R_Arena.exe";

                }

            }

            if (comboBox2.Text == "1600 x 1024" || comboBox2.Text == "1280 x 1024" || comboBox2.Text == "1280 x 768")
            {

                //4:3 resolution ratio anormal

                MessageBox.Show(resolutionwarnning);

                if (contenue == "SD") { //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena.exe");


                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\SD\R_Arena.exe";
                    Process.Start(startInfo);


                }
                if (contenue == "HD") {// System.Diagnostics.Process.Start("cmd", @"/c start game\HD\R_Arena.exe");

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"game\HD\R_Arena.exe";
                    Process.Start(startInfo);

                }

                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    nomdelexe = "R_Arena.exe";
                    checkBox2.Checked = true;

                }
                else
                {

                    nomdelexe = "R_Arena.exe";

                }

            }





        }



        void modidgvoodo(string contenue, string hauteur, string largeur)
        {

            //string filePatch = @"%APPDATA%\dgVoodoo\dgVoodoo.conf";

            var filePatch = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), @"dgVoodoo\dgVoodoo.conf");



            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePatch).ToList();


            foreach (string line in lines)
            {

                Console.WriteLine(line);

            }


            if (contenue == "FULL")
            {

                lines[27] = "FullScreenMode                       = true";
                lines[28] = "ScalingMode                          = unspecified";
                lines[38] = "CaptureMouse                         = true";

            }
            else if (contenue == "WIN")
            {
                lines[27] = "FullScreenMode                       = false";
                lines[28] = "ScalingMode                          = centered";
                lines[38] = "CaptureMouse                         = false";
            }



            lines[177] = "Resolution                          = h:" + hauteur + ", v:" + largeur + "";
            File.WriteAllLines(filePatch, lines);

        }





        public bool Testconnexioninternet()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("8.8.8.8", 2000); // Envoie une requête de ping à l'adresse IP 8.8.8.8 (un serveur Google DNS) avec un délai d'attente de 2 secondes
                    return result.Status == IPStatus.Success; // Renvoie vrai si la réponse est un succès (c'est-à-dire si l'ordinateur est connecté à Internet)
                }
            }
            catch
            {
                return false;
            }
        }




        async void verifmaj(int demarrage)

        {
            if (Testconnexioninternet())
            {
                //Console.WriteLine("L'ordinateur est connecté à Internet.");
                string version = File.ReadAllText(cheminfichierversion);
                UriHostNameType hostNameType;

                hostNameType = Uri.CheckHostName("raymanarenaonline.eundilmako.com");
                if (hostNameType == UriHostNameType.Dns)
                {
                   // MessageBox.Show(" dns ok");



                    HttpClient client = new HttpClient();



                    HttpResponseMessage response = client.GetAsync("https://raymanarenaonline.eundilmako.com/maj/test.php?name=" + version).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string page = response.Content.ReadAsStringAsync().Result;




                        string maj = client.GetStringAsync("https://raymanarenaonline.eundilmako.com/maj/test.php?name=" + version).Result;

                        //MessageBox.Show(maj);


                        // double vertion = double.Parse(maj);


                        if (maj == "ajour")
                        {
                            if (demarrage == 1)
                            {

                                MessageBox.Show(Vertionajour);
                            }
                            else { }

                        }
                        else
                        {

                            string message = vertionpasajour;
                            string title = "Update confirmation";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show(message, title, buttons);
                            if (result == DialogResult.Yes)
                            {

                                if (maj == "grandmaj")
                                { // maj complete

                                    Process.Start(@"https://raymanarenaonline.eundilmako.com/download/");
                                }
                                else if (maj == "petitmaj")
                                {

                                    Process.Start(@"update.exe");
                                    Environment.Exit(0);


                                }


                            }
                            else { }


                            // return "Successfully load page";
                        }
                    }
                    else
                    {

                        //  return "Invalid Page url requested";

                        MessageBox.Show(pasverifmaj);
                    }

                }
                else
                {
                    MessageBox.Show(pasverifmaj);
                }


            }
            else
            {
                MessageBox.Show(pasverifmaj);
                //Console.WriteLine("L'ordinateur n'est pas connecté à Internet.");
            }

           






        }





        void MajXML()
        {

            if (Nomjoueur1 == "" && Nomjoueur2 == "" && Nomjoueur3 == "" && Nomjoueur4 == "")
            {

                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),

                        new XElement("lesjoueur",
                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                       ))));
                doc.Save("Root.xml");

            }






            if (Nomjoueur1 != "" && Nomjoueur2 != "" && Nomjoueur3 != "" && Nomjoueur4 != "")
            {


                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", Nomjoueur1),
                        new XElement("emplacement", emplacementjoueur1),
                        new XElement("skin", skinjoueueur1)
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", Nomjoueur2),
                        new XElement("emplacement", emplacementjoueur2),
                        new XElement("skin", skinjoueueur2)

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", Nomjoueur3),
                        new XElement("emplacement", emplacementjoueur3),
                        new XElement("skin", skinjoueueur3)

                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", Nomjoueur4),
                        new XElement("emplacement", emplacementjoueur4),
                        new XElement("skin", skinjoueueur4)

                          ),

                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                        )));
                doc.Save("Root.xml");


            }


            if (Nomjoueur1 != "" && Nomjoueur2 == "" && Nomjoueur3 == "" && Nomjoueur4 == "")
            {

                File.Delete("Root.xml");

                XDocument doc = new XDocument(


                            new XElement("lesjoueur",
                            new XElement("joueur1",
                            new XElement("nomduperso", Nomjoueur1),
                            new XElement("emplacement", emplacementjoueur1),
                            new XElement("skin", skinjoueueur1)



                          ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),


                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)



                            )));
                doc.Save("Root.xml");


            }


            if (Nomjoueur1 == "" && Nomjoueur2 != "" && Nomjoueur3 == "" && Nomjoueur4 == "")
            {

                File.Delete("Root.xml");
                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")
                        ),


                            new XElement("joueur2",
                            new XElement("nomduperso", Nomjoueur2),
                            new XElement("emplacement", emplacementjoueur2),
                            new XElement("skin", skinjoueueur2)


                          ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),


                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)


                            )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 == "" && Nomjoueur2 == "" && Nomjoueur3 != "" && Nomjoueur4 == "")
            {

                File.Delete("Root.xml");
                XDocument doc = new XDocument(

                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),


                        new XElement("joueur3",
                        new XElement("nomduperso", Nomjoueur3),
                        new XElement("emplacement", emplacementjoueur3),
                        new XElement("skin", skinjoueueur3)



                          ),


                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),



                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)


                        )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 == "" && Nomjoueur2 == "" && Nomjoueur3 == "" && Nomjoueur4 != "")
            {

                File.Delete("Root.xml");
                XDocument doc = new XDocument(


                                            new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                    new XElement("joueur4",
                    new XElement("nomduperso", Nomjoueur4),
                    new XElement("emplacement", emplacementjoueur4),
                    new XElement("skin", skinjoueueur4)


                          ),

                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)


                    )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 == "" && Nomjoueur2 == "" && Nomjoueur3 != "" && Nomjoueur4 != "")
            {

                File.Delete("Root.xml");
                XDocument doc = new XDocument(

                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", Nomjoueur3),
                        new XElement("emplacement", emplacementjoueur3),
                        new XElement("skin", skinjoueueur3)
                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", Nomjoueur4),
                        new XElement("emplacement", emplacementjoueur4),
                        new XElement("skin", skinjoueueur4)



                          ),

                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                        )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 != "" && Nomjoueur2 != "" && Nomjoueur3 == "" && Nomjoueur4 == "")
            {
                File.Delete("Root.xml");
                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", Nomjoueur1),
                        new XElement("emplacement", emplacementjoueur1),
                        new XElement("skin", skinjoueueur1)
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", Nomjoueur2),
                        new XElement("emplacement", emplacementjoueur2),
                        new XElement("skin", skinjoueueur2)




                          ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),




                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                        )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 != "" && Nomjoueur2 == "" && Nomjoueur3 == "" && Nomjoueur4 != "")
            {
                File.Delete("Root.xml");
                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", Nomjoueur1),
                        new XElement("emplacement", emplacementjoueur1),
                        new XElement("skin", skinjoueueur1)
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),

                        new XElement("joueur3",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),


                        new XElement("joueur4",
                        new XElement("nomduperso", Nomjoueur4),
                        new XElement("emplacement", emplacementjoueur4),
                        new XElement("skin", skinjoueueur4)


                          ),

                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                        )));
                doc.Save("Root.xml");
            }

            if (Nomjoueur1 != "" && Nomjoueur2 == "" && Nomjoueur3 != "" && Nomjoueur4 == "")
            {
                File.Delete("Root.xml");
                XDocument doc = new XDocument(


                        new XElement("lesjoueur",
                        new XElement("joueur1",
                        new XElement("nomduperso", Nomjoueur1),
                        new XElement("emplacement", emplacementjoueur1),
                        new XElement("skin", skinjoueueur1)
                        ),

                        new XElement("joueur2",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                        ),


                        new XElement("joueur3",
                        new XElement("nomduperso", Nomjoueur3),
                        new XElement("emplacement", emplacementjoueur3),
                        new XElement("skin", skinjoueueur3)



                          ),

                        new XElement("joueur4",
                        new XElement("nomduperso", "aucun"),
                        new XElement("emplacement", "99"),
                        new XElement("skin", "0")

                         ),



                        new XElement("param",
                        new XElement("ongletskin", Ongletskin),
                        new XElement("skinhdsd", Skinhdsd),
                        new XElement("gamehdsd", Gamehdsd),
                        new XElement("resoGame", ResoGame),
                        new XElement("videomode", Videomode),
                        new XElement("screenmode", Screenmode),
                        new XElement("langueGame", LangueGame),
                        new XElement("manettevib", Manettevib),
                        new XElement("resoAuto", ResoAuto),
                        new XElement("langueauto", Langueauto)

                        )));
                doc.Save("Root.xml");
            }







        }



        string Doublonskin(string Numjoueur, string Choixperso, string empl, string skin)
        {
            string ok = "oui";

            if (Choixperso == "0") { Choixperso = "rayman"; }
            if (Choixperso == "1") { Choixperso = "razor"; }
            if (Choixperso == "2") { Choixperso = "razorwife"; }
            if (Choixperso == "3") { Choixperso = "globox"; }
            if (Choixperso == "4") { Choixperso = "huchman"; }
            if (Choixperso == "5") { Choixperso = "ptizetre"; }
            if (Choixperso == "6") { Choixperso = "tily"; }
            if (Choixperso == "7") { Choixperso = "huch10000"; }


            if (skin != "0")
            {



                if (Numjoueur == "1")

                {

                    if (Choixperso == Nomjoueur2 && empl == emplacementjoueur2) { ok = "non"; }
                    if (Choixperso == Nomjoueur3 && empl == emplacementjoueur3) { ok = "non"; }
                    if (Choixperso == Nomjoueur4 && empl == emplacementjoueur4) { ok = "non"; }

                }

                if (Numjoueur == "2")

                {
                    if (Choixperso == Nomjoueur1 && empl == emplacementjoueur1) { ok = "non"; }
                    if (Choixperso == Nomjoueur3 && empl == emplacementjoueur3) { ok = "non"; }
                    if (Choixperso == Nomjoueur4 && empl == emplacementjoueur4) { ok = "non"; }

                }

                if (Numjoueur == "3")

                {
                    if (Choixperso == Nomjoueur2 && empl == emplacementjoueur2) { ok = "non"; }
                    if (Choixperso == Nomjoueur1 && empl == emplacementjoueur1) { ok = "non"; }
                    if (Choixperso == Nomjoueur4 && empl == emplacementjoueur4) { ok = "non"; }

                }

                if (Numjoueur == "4")

                {
                    if (Choixperso == Nomjoueur2 && empl == emplacementjoueur2) { ok = "non"; }
                    if (Choixperso == Nomjoueur3 && empl == emplacementjoueur3) { ok = "non"; }
                    if (Choixperso == Nomjoueur1 && empl == emplacementjoueur1) { ok = "non"; }

                }
            }
            else {



                if (Numjoueur == "1")

                {
                    if (emplacementjoueur1 == "99" && skin == "0") { ok = "non"; }

                }

                if (Numjoueur == "2")

                {
                    if (emplacementjoueur2 == "99" && skin == "0") { ok = "non"; }

                }

                if (Numjoueur == "3")

                {
                    if (emplacementjoueur3 == "99" && skin == "0") { ok = "non"; }

                }

                if (Numjoueur == "4")

                {
                    if (emplacementjoueur4 == "99" && skin == "0") { ok = "non"; }

                }



            }


            //MessageBox.Show("emplacementjoueur1");
            // MessageBox.Show(emplacementjoueur1);
            //MessageBox.Show("skin");
            // MessageBox.Show(skin);
            //  MessageBox.Show("empl");
            //  MessageBox.Show(empl);
            //  MessageBox.Show("emplacementjoueur2");
            //  MessageBox.Show(emplacementjoueur2);

            return ok;
        }


        string verificationfichierskin(string rayman, string chemainskinfichier, string nomfichier)
        {



            string validation = "oui";

            if ((!File.Exists(chemainskinfichier + nomfichier + @"\demo.jpg")) || (!File.Exists(chemainskinfichier + nomfichier + @"\skinhd.gf")) || (!File.Exists(chemainskinfichier + nomfichier + @"\skinsd.gf")))
            {
                validation = "non";
            }

            if (rayman == "rayman") {

                if ((!File.Exists(chemainskinfichier + nomfichier + @"\skinhdhelice.gf")) || (!File.Exists(chemainskinfichier + nomfichier + @"\skinsdhelice.gf")))
                {
                    validation = "non";
                }

            }


            string test = (chemainskinfichier + nomfichier + @"\demo6.jpg");

            //MessageBox.Show(test);
            // MessageBox.Show(validation);




            return validation;
        }

        void onlinetest()
        {

            string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
            string cheminRepertoirePourTestDossier = @"game\SD\"; // Remplace avec le chemin relatif de ton répertoire

            // Obtient le chemin complet du fichier dans le répertoire spécifié
            string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);


            if (!File.Exists(cheminFichierTestDemarrageLanceur))// si le fichier sd est vide la fonction fait rien
            { }
            else
            {

                string path = cheminfichier2;
                using (StreamReader readtext = new StreamReader(path))
                {
                    string readText = readtext.ReadLine();
                    if (readText == "Radmin VPN")
                    {
                        if (radminok == 1)
                        { //MessageBox.Show("carte ok fichier ok"); } // le fichier et bien sur radmin et on a detecter que la carte est ok

                            label14.ForeColor = Color.Green;

                            label14.Text = onlinetestgreen;

                        }
                        else
                        { //MessageBox.Show("carte pas ok fichier ok"); le fichier et bien sur radmin et on a detecter que la carte pas  ok
                            label14.ForeColor = Color.Red;
                            label14.Text = onlinetestred;
                        }

                    }
                    else
                    {

                        if (radminok == 1)
                        { //MessageBox.Show("carte ok fichier pas ok ");
                            label14.ForeColor = Color.Orange;
                            label14.Text = onlinetestorange;
                        }
                        else
                        { //MessageBox.Show("carte pas ok fichier pas  ok"); le fichier et pas  sur radmin et on a detecter que la carte est ok
                            label14.ForeColor = Color.Red;
                            label14.Text = onlinetestred;
                        }
                    }

                }

            }

        }

        void modifpersoSD(string personnage2, string emplacement, string skinemp)
        {


            string chemainskinfichier = "";

            if (personnage2 == "rayman")
            {
                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\RaymanT.gf", @"fils\texture\Original\SD\textures_perso\RaymanT.gf"),
                           (@"textures_perso\Helice.gf", @"fils\texture\Original\SD\textures_perso\Helice.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\RaymanT.gf", @"fils\texture\Original\SD\textures_perso\RaymanT.gf"),
                           (@"textures_perso\Helice.gf", @"fils\texture\Original\SD\textures_perso\Helice.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\RaymanT\RaymanT.gf", @"fils\texture\Original\SD\textures_perso\RaymanT.gf"),
                           (@"actor\RaymanT\Helice.gf", @"fils\texture\Original\SD\textures_perso\Helice.gf"),

                        });




                    }

                }
                else {



                    chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                    ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                      {
                           (@"textures_perso\RaymanT.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),
                           (@"textures_perso\Helice.gf", chemainskinfichier + skinemp + @"\skinsdhelice.gf"),

                        });

                    ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                    {
                           (@"textures_perso\RaymanT.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),
                           (@"textures_perso\Helice.gf",  chemainskinfichier + skinemp + @"\skinsdhelice.gf"),

                        });


                    ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                    {
                           (@"actor\RaymanT\RaymanT.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),
                           (@"actor\RaymanT\Helice.gf", chemainskinfichier + skinemp + @"\skinsdhelice.gf"),

                        });



                }



            }

            //choix razor
            if (personnage2 == "razor")
            {

                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razor.gf", @"fils\texture\Original\SD\textures_perso\Razor.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razor.gf", @"fils\texture\Original\SD\textures_perso\Razor.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\pirate_barbu\Razor.gf", @"fils\texture\Original\SD\textures_perso\Razor.gf"),

                        });
                    }

                }
                else
                {

                    chemainskinfichier = @"fils\texture\customskin\Razor\";


                    ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                      {

                        (@"textures_perso\Razor.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                    ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                    {

                         (@"textures_perso\Razor.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),


                        });


                    ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                    {

                        (@"actor\pirate_barbu\Razor.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),


                        });

                }
            }



            //choix razorwife
            if (personnage2 == "razorwife")
            {


                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razorwife.gf", @"fils\texture\Original\SD\textures_perso\Razorwife.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razorwife.gf", @"fils\texture\Original\SD\textures_perso\Razorwife.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\razorwife\Razorwife.gf", @"fils\texture\Original\SD\textures_perso\Razorwife.gf"),

                        });

                    }
                    else
                    {



                        chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\razorwife\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                    }
                }


            }
            //choix globox
            if (personnage2 == "globox")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox.gf", @"fils\texture\Original\SD\textures_perso\globox.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox.gf", @"fils\texture\Original\SD\textures_perso\globox.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox.gf", @"fils\texture\Original\SD\textures_perso\globox.gf"),

                        });


                    }
                    else
                    {




                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }


                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {



                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxfraise.gf", @"fils\texture\Original\SD\textures_perso\globoxfraise.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxfraise.gf", @"fils\texture\Original\SD\textures_perso\globoxfraise.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_m.gf", @"fils\texture\Original\SD\textures_perso\globoxfraise.gf"),

                        });

                    } else
                    {



                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxfraise.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxfraise.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_m.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }

                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {




                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxray.gf", @"fils\texture\Original\SD\textures_perso\globoxray.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxray.gf", @"fils\texture\Original\SD\textures_perso\globoxray.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_r.gf.gf", @"fils\texture\Original\SD\textures_perso\globoxray.gf"),

                        });


                    }
                    else

                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxray.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxray.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_r.gf.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }

                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox_veg.gf", @"fils\texture\Original\SD\textures_perso\globox_veg.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox_veg.gf", @"fils\texture\Original\SD\textures_perso\globox_veg.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_veg.gf", @"fils\texture\Original\SD\textures_perso\globox_veg.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }


                }





            }
            //choix huchman
            if (personnage2 == "huchman")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman.gf", @"fils\texture\Original\SD\textures_perso\Hunchman.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman.gf", @"fils\texture\Original\SD\textures_perso\Hunchman.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunchman.gf", @"fils\texture\Original\SD\textures_perso\Hunchman.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }






                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_beast.gf", @"fils\texture\Original\SD\textures_perso\Hunch_beast.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_beast.gf", @"fils\texture\Original\SD\textures_perso\Hunch_beast.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\HunchmanBeast.gf", @"fils\texture\Original\SD\textures_perso\Hunch_beast.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_beast.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_beast.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\HunchmanBeast.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }




                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_gold.gf", @"fils\texture\Original\SD\textures_perso\Hunch_gold.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_gold.gf", @"fils\texture\Original\SD\textures_perso\Hunch_gold.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_gold.gf", @"fils\texture\Original\SD\textures_perso\Hunch_gold.gf"),

                        });



                    }
                    else

                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_wood.gf", @"fils\texture\Original\SD\textures_perso\Hunch_wood.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_wood.gf", @"fils\texture\Original\SD\textures_perso\Hunch_wood.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_wood.gf", @"fils\texture\Original\SD\textures_perso\Hunch_wood.gf"),

                        });




                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }

                }

            }
            //choix ptizetre
            if (personnage2 == "ptizetre")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teensies.gf", @"fils\texture\Original\SD\textures_perso\ptizetre.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teensies.gf", @"fils\texture\Original\SD\textures_perso\ptizetre.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teensies.gf", @"fils\texture\Original\SD\textures_perso\ptizetre.gf"),

                        });

                    }
                    else
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
   {
                           (@"textures_perso\teensies.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teensies.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teensies.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });



                    }

                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teens_indian.gf", @"fils\texture\Original\SD\textures_perso\teens_indian.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_indian.gf", @"fils\texture\Original\SD\textures_perso\teens_indian.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_indian.gf", @"fils\texture\Original\SD\textures_perso\teens_indian.gf"),

                        });

                    }
                    else
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teens_indian.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_indian.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_indian.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                    }


                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {
                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_blu.gf", @"fils\texture\Original\SD\textures_perso\teens_blu.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_blu.gf", @"fils\texture\Original\SD\textures_perso\teens_blu.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_blu.gf", @"fils\texture\Original\SD\textures_perso\teens_blu.gf"),

                        });
                    }
                    else
                    {
                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_blu.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_blu.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_blu.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });
                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {
                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_afro.gf", @"fils\texture\Original\SD\textures_perso\teens_afro.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_afro.gf", @"fils\texture\Original\SD\textures_perso\teens_afro.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_afro.gf", @"fils\texture\Original\SD\textures_perso\teens_afro.gf"),

                        });
                    }
                    else
                    {
                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_afro.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_afro.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_afro.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });
                    }



                }


            }

            //choix tily
            if (personnage2 == "tily")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";




                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {
                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"Actor\Tily\Tily.gf", @"fils\texture\Original\SD\textures_perso\Tily.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"Actor\tily\Tily.gf", @"fils\texture\Original\SD\textures_perso\Tily.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\tily\Tily.gf", @"fils\texture\Original\SD\textures_perso\Tily.gf"),

                        });
                    }

                }
                else {



                    ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"Actor\Tily\Tily.gf",chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                    ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                    {
                           (@"Actor\tily\Tily.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                    {
                           (@"actor\tily\Tily.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                }
            }




            if (personnage2 == "huch10000")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman2.gf", @"fils\texture\Original\SD\textures_perso\Hunchman2.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman2.gf", @"fils\texture\Original\SD\textures_perso\Hunchman2.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunchman2.gf", @"fils\texture\Original\SD\textures_perso\Hunchman2.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }






                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_young.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_young.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_young.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_young.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_young.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_young.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }




                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_roman.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_roman.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_roman.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_roman.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_roman.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_roman.gf"),

                        });



                    }
                    else

                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_cuoio.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_cuoio.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_cuoio.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_cuoio.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_cuoio.gf", @"fils\texture\Original\SD\textures_perso\Hunch2_cuoio.gf"),

                        });




                    }
                    else
                    {


                        ReplaceContainedFile(@"game\SD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\SD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\SD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }

                }


            }


            //









        }









        void modifpersoHD(string personnage2, string emplacement, string skinemp)
        {


            string chemainskinfichier = "";

            if (personnage2 == "rayman")
            {
                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\RaymanT.gf", @"fils\texture\Original\HD\textures_perso\RaymanT.gf"),
                           (@"textures_perso\Helice.gf", @"fils\texture\Original\HD\textures_perso\Helice.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\RaymanT.gf", @"fils\texture\Original\HD\textures_perso\RaymanT.gf"),
                           (@"textures_perso\Helice.gf", @"fils\texture\Original\HD\textures_perso\Helice.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\RaymanT\RaymanT.gf", @"fils\texture\Original\HD\textures_perso\RaymanT.gf"),
                           (@"actor\RaymanT\Helice.gf", @"fils\texture\Original\HD\textures_perso\Helice.gf"),

                        });




                    }

                }
                else
                {



                    chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                    ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                      {
                           (@"textures_perso\RaymanT.gf", chemainskinfichier + skinemp + @"\skinsd.gf"),
                           (@"textures_perso\Helice.gf", chemainskinfichier + skinemp + @"\skinhdhelice.gf"),

                        });

                    ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                    {
                           (@"textures_perso\RaymanT.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),
                           (@"textures_perso\Helice.gf",  chemainskinfichier + skinemp + @"\skinhdhelice.gf"),

                        });


                    ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                    {
                           (@"actor\RaymanT\RaymanT.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),
                           (@"actor\RaymanT\Helice.gf", chemainskinfichier + skinemp + @"\skinhdhelice.gf"),

                        });



                }



            }

            //choix razor
            if (personnage2 == "razor")
            {

                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razor.gf", @"fils\texture\Original\HD\textures_perso\Razor.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razor.gf", @"fils\texture\Original\HD\textures_perso\Razor.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\pirate_barbu\Razor.gf", @"fils\texture\Original\HD\textures_perso\Razor.gf"),

                        });
                    }

                }
                else
                {

                    chemainskinfichier = @"fils\texture\customskin\Razor\";


                    ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                      {

                        (@"textures_perso\Razor.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                    ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                    {

                         (@"textures_perso\Razor.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),


                        });


                    ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                    {

                        (@"actor\pirate_barbu\Razor.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),


                        });

                }
            }



            //choix razorwife
            if (personnage2 == "razorwife")
            {


                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razorwife.gf", @"fils\texture\Original\HD\textures_perso\Razorwife.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razorwife.gf", @"fils\texture\Original\HD\textures_perso\Razorwife.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\razorwife\Razorwife.gf", @"fils\texture\Original\HD\textures_perso\Razorwife.gf"),

                        });

                    }
                    else
                    {



                        chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\razorwife\Razorwife.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                    }
                }


            }
            //choix globox
            if (personnage2 == "globox")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox.gf", @"fils\texture\Original\HD\textures_perso\globox.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox.gf", @"fils\texture\Original\HD\textures_perso\globox.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox.gf", @"fils\texture\Original\HD\textures_perso\globox.gf"),

                        });


                    }
                    else
                    {




                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }


                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {



                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxfraise.gf", @"fils\texture\Original\HD\textures_perso\globoxfraise.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxfraise.gf", @"fils\texture\Original\HD\textures_perso\globoxfraise.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_m.gf", @"fils\texture\Original\HD\textures_perso\globoxfraise.gf"),

                        });

                    }
                    else
                    {



                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxfraise.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxfraise.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_m.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }

                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {




                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxray.gf", @"fils\texture\Original\HD\textures_perso\globoxray.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxray.gf", @"fils\texture\Original\HD\textures_perso\globoxray.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_r.gf.gf", @"fils\texture\Original\HD\textures_perso\globoxray.gf"),

                        });


                    }
                    else

                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globoxray.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globoxray.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_r.gf.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }

                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox_veg.gf", @"fils\texture\Original\HD\textures_perso\globox_veg.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox_veg.gf", @"fils\texture\Original\HD\textures_perso\globox_veg.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_veg.gf", @"fils\texture\Original\HD\textures_perso\globox_veg.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\globox\globox_veg.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }


                }





            }
            //choix huchman
            if (personnage2 == "huchman")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman.gf", @"fils\texture\Original\HD\textures_perso\Hunchman.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman.gf", @"fils\texture\Original\HD\textures_perso\Hunchman.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunchman.gf", @"fils\texture\Original\HD\textures_perso\Hunchman.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunchman.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }






                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_beast.gf", @"fils\texture\Original\HD\textures_perso\Hunch_beast.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_beast.gf", @"fils\texture\Original\HD\textures_perso\Hunch_beast.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\HunchmanBeast.gf", @"fils\texture\Original\HD\textures_perso\Hunch_beast.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_beast.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_beast.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\HunchmanBeast.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }




                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_gold.gf", @"fils\texture\Original\HD\textures_perso\Hunch_gold.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_gold.gf", @"fils\texture\Original\HD\textures_perso\Hunch_gold.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_gold.gf", @"fils\texture\Original\HD\textures_perso\Hunch_gold.gf"),

                        });



                    }
                    else

                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_gold.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_wood.gf", @"fils\texture\Original\HD\textures_perso\Hunch_wood.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_wood.gf", @"fils\texture\Original\HD\textures_perso\Hunch_wood.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_wood.gf", @"fils\texture\Original\HD\textures_perso\Hunch_wood.gf"),

                        });




                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman\Hunch_wood.gf",  chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    }

                }



            }
            //choix ptizetre
            if (personnage2 == "ptizetre")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teensies.gf", @"fils\texture\Original\HD\textures_perso\ptizetre.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teensies.gf", @"fils\texture\Original\HD\textures_perso\ptizetre.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teensies.gf", @"fils\texture\Original\HD\textures_perso\ptizetre.gf"),

                        });

                    }
                    else
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
   {
                           (@"textures_perso\teensies.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teensies.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teensies.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });



                    }

                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teens_indian.gf", @"fils\texture\Original\HD\textures_perso\teens_indian.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_indian.gf", @"fils\texture\Original\HD\textures_perso\teens_indian.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_indian.gf", @"fils\texture\Original\HD\textures_perso\teens_indian.gf"),

                        });

                    }
                    else
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\teens_indian.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_indian.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_indian.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                    }


                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {
                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_blu.gf", @"fils\texture\Original\HD\textures_perso\teens_blu.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_blu.gf", @"fils\texture\Original\HD\textures_perso\teens_blu.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_blu.gf", @"fils\texture\Original\HD\textures_perso\teens_blu.gf"),

                        });
                    }
                    else
                    {
                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_blu.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_blu.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_blu.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });
                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {
                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_afro.gf", @"fils\texture\Original\HD\textures_perso\teens_afro.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_afro.gf", @"fils\texture\Original\HD\textures_perso\teens_afro.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_afro.gf", @"fils\texture\Original\HD\textures_perso\teens_afro.gf"),

                        });
                    }
                    else
                    {
                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
                {
                           (@"textures_perso\teens_afro.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\teens_afro.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\teensies\teens_afro.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });
                    }
                }


            }

            //choix tily
            if (personnage2 == "tily")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";




                if (skinemp == "0")
                {
                    if (emplacement == "0")
                    {
                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"Actor\Tily\Tily.gf", @"fils\texture\Original\HD\textures_perso\Tily.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"Actor\tily\Tily.gf", @"fils\texture\Original\HD\textures_perso\Tily.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\tily\Tily.gf", @"fils\texture\Original\HD\textures_perso\Tily.gf"),

                        });
                    }

                }
                else
                {



                    ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"Actor\Tily\Tily.gf",chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                    ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                    {
                           (@"Actor\tily\Tily.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });


                    ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                    {
                           (@"actor\tily\Tily.gf", chemainskinfichier + skinemp + @"\skinhd.gf"),

                        });

                }
            }


            if (personnage2 == "huch10000")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (emplacement == "0")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman2.gf", @"fils\texture\Original\HD\textures_perso\Hunchman2.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman2.gf", @"fils\texture\Original\HD\textures_perso\Hunchman2.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunchman2.gf", @"fils\texture\Original\HD\textures_perso\Hunchman2.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunchman2.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }






                }

                else if (emplacement == "1")
                {
                    if (skinemp == "0")
                    {

                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_young.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_young.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_young.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_young.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_young.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_young.gf"),

                        });


                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_young.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }




                }

                else if (emplacement == "2")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_roman.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_roman.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_roman.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_roman.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_roman.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_roman.gf"),

                        });



                    }
                    else

                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_roman.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }


                }

                else if (emplacement == "3")
                {
                    if (skinemp == "0")
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_cuoio.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_cuoio.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_cuoio.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_cuoio.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_cuoio.gf", @"fils\texture\Original\HD\textures_perso\Hunch2_cuoio.gf"),

                        });




                    }
                    else
                    {


                        ReplaceContainedFile(@"game\HD\MenuBin\tex32.cnt", new[]
{
                           (@"textures_perso\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });

                        ReplaceContainedFile(@"game\HD\FishBin\tex32.cnt", new[]
                        {
                           (@"textures_perso\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                        ReplaceContainedFile(@"game\HD\TribeBin\tex32.cnt", new[]
                        {
                           (@"actor\hunchman2\Hunch2_cuoio.gf",  chemainskinfichier + skinemp + @"\skinsd.gf"),

                        });


                    }

                }


            }




        }







        async void reinisiliatation(int position)
        {

            if (position == 0) // 0 = reinisinalisation avec le bouton  1 = erreur skin incomplet
            {

                string message = ReiniSkin;
                string title = "Confirmation reinisialisation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    position = 1;
                }
                else
                {
                    // Do something  
                }

            }


            if (position == 1)
            {

                lecturexml();

                Hide();

                Form3 form3 = new Form3();
                form3.Show();



                await Task.Run(() =>
                {




                    MajPerso("1", Nomjoueur1, emplacementjoueur1, "resto");
                    MajPerso("2", Nomjoueur2, emplacementjoueur2, "resto");
                    MajPerso("3", Nomjoueur3, emplacementjoueur3, "resto");
                    MajPerso("4", Nomjoueur4, emplacementjoueur4, "resto");

                });

                Skinhdsd = "3";
                MajXML();

                form3.Close(); // ferme la fenetre d'attente
                acceuil acceuil = new acceuil();  // appel la fentre acceuil
                acceuil.Show(); // rafiche le luncher



            }


            verifhd();

        }













        void MajPerso(string numerodejoueur, string personnage2, string emplacement, string skinemp)
        {

            string resto = "0";




            if (numerodejoueur == "1")
            {
                Nomjoueur1 = personnage2;
                emplacementjoueur1 = emplacement;
                skinjoueueur1 = skinemp;
            }
            if (numerodejoueur == "2")
            {
                Nomjoueur2 = personnage2;
                emplacementjoueur2 = emplacement;
                skinjoueueur2 = skinemp;
            }
            if (numerodejoueur == "3")
            {
                Nomjoueur3 = personnage2;
                emplacementjoueur3 = emplacement;
                skinjoueueur3 = skinemp;
            }
            if (numerodejoueur == "4")
            {
                Nomjoueur4 = personnage2;
                emplacementjoueur4 = emplacement;
                skinjoueueur4 = skinemp;
            }


            if (skinemp == "resto")
            {

                resto = "1";

                skinemp = "0";

            }


            Ongletskin = "1";









            // partie detection seulement hd ou les 2

            if (checkBox1.Checked == false)
            { // si décocher le hd ce déclanche

                modifpersoHD(personnage2, emplacement, skinemp);
                Skinhdsd = "2";

            }
            else {

                Skinhdsd = "1";


            }




            modifpersoSD(personnage2, emplacement, skinemp);


            if (resto == "1")//si la restoration est activer on remet les valeur a zero sur xml
            {

                Nomjoueur1 = "aucun";
                emplacementjoueur1 = "99";
                skinjoueueur1 = "0";
                Nomjoueur2 = "aucun";
                emplacementjoueur2 = "99";
                skinjoueueur2 = "0";
                Nomjoueur3 = "aucun";
                emplacementjoueur3 = "99";
                skinjoueueur3 = "0";
                Nomjoueur4 = "aucun";
                emplacementjoueur4 = "99";
                skinjoueueur4 = "0";

            }



          MajXML();


        }




        void ModifImageskinUbi(int numskin)
        {
            if (numskin == 1) {


                if (Choixperso1.SelectedIndex.ToString() == "3") //globbox
                {

                    skin1.Items.Clear();
                    skin1.Items.Insert(0, "Original");
                    skin1.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin1.Items.Add(dri.Name);



                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        photoskin1.Image = Properties.Resources.g5;
                    }
                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        photoskin1.Image = Properties.Resources.globox1;
                    }
                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        photoskin1.Image = Properties.Resources.globox2;
                    }
                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        photoskin1.Image = Properties.Resources.globox3;
                    }


                }

                if (Choixperso1.SelectedIndex.ToString() == "4") //huchman
                {

                    skin1.Items.Clear();
                    skin1.Items.Insert(0, "Original");
                    skin1.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin1.Items.Add(dri.Name);



                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        photoskin1.Image = Properties.Resources.h3;
                    }
                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        photoskin1.Image = Properties.Resources.oh1;
                    }
                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        photoskin1.Image = Properties.Resources.oh2;
                    }
                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        photoskin1.Image = Properties.Resources.oh3;
                    }

                }

                if (Choixperso1.SelectedIndex.ToString() == "5") //chnou
                {

                    skin1.Items.Clear();
                    skin1.Items.Insert(0, "Original");
                    skin1.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin1.Items.Add(dri.Name);




                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        photoskin1.Image = Properties.Resources.p3;
                    }
                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        photoskin1.Image = Properties.Resources.op1;
                    }
                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        photoskin1.Image = Properties.Resources.op2;
                    }
                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        photoskin1.Image = Properties.Resources.op3;
                    }


                }





                if (Choixperso1.SelectedIndex.ToString() == "7") //huchman 10000
                {

                    skin1.Items.Clear();
                    skin1.Items.Insert(0, "Original");
                    skin1.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin1.Items.Add(dri.Name);




                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        photoskin1.Image = Properties.Resources.huch10000;
                    }
                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        photoskin1.Image = Properties.Resources.huch10001;
                    }
                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        photoskin1.Image = Properties.Resources.huch10002;
                    }
                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        photoskin1.Image = Properties.Resources.huch10003;
                    }


                }








            }

            if (numskin == 2)
            {



                if (Choixperso2.SelectedIndex.ToString() == "3") //globbox
                {

                    skin2.Items.Clear();
                    skin2.Items.Insert(0, "Original");
                    skin2.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin2.Items.Add(dri.Name);



                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        photoskin2.Image = Properties.Resources.g5;
                    }
                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        photoskin2.Image = Properties.Resources.globox1;
                    }
                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        photoskin2.Image = Properties.Resources.globox2;
                    }
                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        photoskin2.Image = Properties.Resources.globox3;
                    }

                }

                if (Choixperso2.SelectedIndex.ToString() == "4") //huchman
                {

                    skin2.Items.Clear();
                    skin2.Items.Insert(0, "Original");
                    skin2.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin2.Items.Add(dri.Name);



                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        photoskin2.Image = Properties.Resources.h3;
                    }
                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        photoskin2.Image = Properties.Resources.oh1;
                    }
                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        photoskin2.Image = Properties.Resources.oh2;
                    }
                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        photoskin2.Image = Properties.Resources.oh3;
                    }

                }

                if (Choixperso2.SelectedIndex.ToString() == "5") //chnou
                {

                    skin2.Items.Clear();
                    skin2.Items.Insert(0, "Original");
                    skin2.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin2.Items.Add(dri.Name);




                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        photoskin2.Image = Properties.Resources.p3;
                    }
                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        photoskin2.Image = Properties.Resources.op1;
                    }
                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        photoskin2.Image = Properties.Resources.op2;
                    }
                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        photoskin2.Image = Properties.Resources.op3;
                    }


                }




                if (Choixperso2.SelectedIndex.ToString() == "7") //huchman 10000
                {

                    skin2.Items.Clear();
                    skin2.Items.Insert(0, "Original");
                    skin2.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin2.Items.Add(dri.Name);




                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        photoskin2.Image = Properties.Resources.huch10000;
                    }
                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        photoskin2.Image = Properties.Resources.huch10001;
                    }
                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        photoskin2.Image = Properties.Resources.huch10002;
                    }
                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        photoskin2.Image = Properties.Resources.huch10003;
                    }


                }












            }

            if (numskin == 3)
            {


                if (Choixperso3.SelectedIndex.ToString() == "3") //globbox
                {

                    skin3.Items.Clear();
                    skin3.Items.Insert(0, "Original");
                    skin3.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin3.Items.Add(dri.Name);



                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        photoskin3.Image = Properties.Resources.g5;
                    }
                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        photoskin3.Image = Properties.Resources.globox1;
                    }
                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        photoskin3.Image = Properties.Resources.globox2;
                    }
                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        photoskin3.Image = Properties.Resources.globox3;
                    }

                }

                if (Choixperso3.SelectedIndex.ToString() == "4") //huchman
                {

                    skin3.Items.Clear();
                    skin3.Items.Insert(0, "Original");
                    skin3.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin3.Items.Add(dri.Name);



                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        photoskin3.Image = Properties.Resources.h3;
                    }
                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        photoskin3.Image = Properties.Resources.oh1;
                    }
                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        photoskin3.Image = Properties.Resources.oh2;
                    }
                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        photoskin3.Image = Properties.Resources.oh3;
                    }

                }

                if (Choixperso3.SelectedIndex.ToString() == "5") //chnou
                {

                    skin3.Items.Clear();
                    skin3.Items.Insert(0, "Original");
                    skin3.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin3.Items.Add(dri.Name);




                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        photoskin3.Image = Properties.Resources.p3;
                    }
                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        photoskin3.Image = Properties.Resources.op1;
                    }
                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        photoskin3.Image = Properties.Resources.op2;
                    }
                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        photoskin3.Image = Properties.Resources.op3;
                    }


                }





                if (Choixperso3.SelectedIndex.ToString() == "7") //huchman 10000
                {

                    skin3.Items.Clear();
                    skin3.Items.Insert(0, "Original");
                    skin3.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin3.Items.Add(dri.Name);




                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        photoskin3.Image = Properties.Resources.huch10000;
                    }
                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        photoskin3.Image = Properties.Resources.huch10001;
                    }
                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        photoskin3.Image = Properties.Resources.huch10002;
                    }
                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        photoskin3.Image = Properties.Resources.huch10003;
                    }


                }














            }

            if (numskin == 4)
            {



                if (Choixperso4.SelectedIndex.ToString() == "3") //globbox
                {

                    skin4.Items.Clear();
                    skin4.Items.Insert(0, "Original");
                    skin4.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin4.Items.Add(dri.Name);



                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        photoskin4.Image = Properties.Resources.g5;
                    }
                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        photoskin4.Image = Properties.Resources.globox1;
                    }
                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        photoskin4.Image = Properties.Resources.globox2;
                    }
                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        photoskin4.Image = Properties.Resources.globox3;
                    }

                }

                if (Choixperso4.SelectedIndex.ToString() == "4") //huchman
                {

                    skin4.Items.Clear();
                    skin4.Items.Insert(0, "Original");
                    skin4.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin4.Items.Add(dri.Name);




                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        photoskin4.Image = Properties.Resources.h3;
                    }
                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        photoskin4.Image = Properties.Resources.oh1;
                    }
                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        photoskin4.Image = Properties.Resources.oh2;
                    }
                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        photoskin4.Image = Properties.Resources.oh3;
                    }

                }

                if (Choixperso4.SelectedIndex.ToString() == "5") //chnou
                {


                    skin4.Items.Clear();
                    skin4.Items.Insert(0, "Original");
                    skin4.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin4.Items.Add(dri.Name);




                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        photoskin4.Image = Properties.Resources.p3;
                    }
                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        photoskin4.Image = Properties.Resources.op1;
                    }
                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        photoskin4.Image = Properties.Resources.op2;
                    }
                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        photoskin4.Image = Properties.Resources.op3;
                    }


                }




                if (Choixperso4.SelectedIndex.ToString() == "7") //huchman 10000
                {

                    skin4.Items.Clear();
                    skin4.Items.Insert(0, "Original");
                    skin4.SelectedIndex = 0;

                    DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                    DirectoryInfo[] diArr = di.GetDirectories();
                    foreach (DirectoryInfo dri in diArr)
                        skin4.Items.Add(dri.Name);




                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        photoskin4.Image = Properties.Resources.huch10000;
                    }
                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        photoskin4.Image = Properties.Resources.huch10001;
                    }
                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        photoskin4.Image = Properties.Resources.huch10002;
                    }
                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        photoskin4.Image = Properties.Resources.huch10003;
                    }


                }




            }

        }


        void verificationmessage()
        {


            string message = skinincomplet;
            string title = "Skin incomplete";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                reinisiliatation(1);
            }
            else
            {
                Application.Exit();
            }



        }

        void Choiximagetexturecustom()
        {






            string verifskin;
            string nomfichier = "";


            if (skin1.SelectedIndex.ToString() == "-1")
            { nomfichier = skinjoueueur1; }
            else { nomfichier = skin1.Text.ToString(); }




            skin1.SelectedIndex.ToString();
            string chemainskinfichier = @"";
            //choix rayman
            if (Choixperso1.SelectedIndex.ToString() == "0")
            {


                chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.r5;
                }
                else {

                    verifskin = (verificationfichierskin("rayman", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }


            }




            //choix razor
            if (Choixperso1.SelectedIndex.ToString() == "1")
            {
                chemainskinfichier = @"fils\texture\customskin\Razor\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.ra5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix razorwife
            if (Choixperso1.SelectedIndex.ToString() == "2")
            {
                chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.rw4;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix globox
            if (Choixperso1.SelectedIndex.ToString() == "3")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.g5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { MessageBox.Show(Incompletskin); //skin1.SelectedIndex = 0;

                    }
                }

            }
            //choix huchman
            if (Choixperso1.SelectedIndex.ToString() == "4")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.h3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix ptizetre
            if (Choixperso1.SelectedIndex.ToString() == "5")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.p3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix tily
            if (Choixperso1.SelectedIndex.ToString() == "6")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.t5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }

                }

            }


            //choix hunchman 10000
            if (Choixperso1.SelectedIndex.ToString() == "7")
            {

                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (skin1.SelectedIndex == 0)
                {
                    photoskin1.Image = Properties.Resources.huch10000;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin1.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else {
                        MessageBox.Show(Incompletskin); Application.Exit();


                    }

                }

            }


        }

        void Choiximagetexturecustom2()
        {
            string verifskin;
            string nomfichier = "";


            if (skin2.SelectedIndex.ToString() == "-1")
            { nomfichier = skinjoueueur1; }
            else { nomfichier = skin2.Text.ToString(); }




            skin2.SelectedIndex.ToString();
            string chemainskinfichier = @"";
            //choix rayman
            if (Choixperso2.SelectedIndex.ToString() == "0")
            {


                chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.r5;
                }
                else
                {

                    verifskin = (verificationfichierskin("rayman", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }


            }




            //choix razor
            if (Choixperso2.SelectedIndex.ToString() == "1")
            {
                chemainskinfichier = @"fils\texture\customskin\Razor\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.ra5;
                }
                else
                {

                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix razorwife
            if (Choixperso2.SelectedIndex.ToString() == "2")
            {
                chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.rw4;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix globox
            if (Choixperso2.SelectedIndex.ToString() == "3")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.g5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix huchman
            if (Choixperso2.SelectedIndex.ToString() == "4")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.h3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix ptizetre
            if (Choixperso2.SelectedIndex.ToString() == "5")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.p3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix tily
            if (Choixperso2.SelectedIndex.ToString() == "6")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.t5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }



            if (Choixperso2.SelectedIndex.ToString() == "7")
            {

                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (skin2.SelectedIndex == 0)
                {
                    photoskin2.Image = Properties.Resources.huch10000;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin2.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else
                    {
                        MessageBox.Show(Incompletskin); Application.Exit();


                    }

                }

            }



        }


        void Choiximagetexturecustom3()
        {
            string verifskin;
            string nomfichier = "";


            if (skin3.SelectedIndex.ToString() == "-1")
            { nomfichier = skinjoueueur1; }
            else { nomfichier = skin3.Text.ToString(); }




            skin3.SelectedIndex.ToString();
            string chemainskinfichier = @"";
            //choix rayman
            if (Choixperso3.SelectedIndex.ToString() == "0")
            {


                chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.r5;
                }
                else
                {


                    verifskin = (verificationfichierskin("rayman", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }

                }


            }




            //choix razor
            if (Choixperso3.SelectedIndex.ToString() == "1")
            {
                chemainskinfichier = @"fils\texture\customskin\Razor\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.ra5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix razorwife
            if (Choixperso3.SelectedIndex.ToString() == "2")
            {
                chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.rw4;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix globox
            if (Choixperso3.SelectedIndex.ToString() == "3")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.g5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix huchman
            if (Choixperso3.SelectedIndex.ToString() == "4")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.h3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix ptizetre
            if (Choixperso3.SelectedIndex.ToString() == "5")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.p3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix tily
            if (Choixperso3.SelectedIndex.ToString() == "6")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.t5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }



            if (Choixperso3.SelectedIndex.ToString() == "7")
            {

                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (skin3.SelectedIndex == 0)
                {
                    photoskin3.Image = Properties.Resources.huch10000;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin3.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else
                    {
                        MessageBox.Show(Incompletskin); Application.Exit();


                    }

                }

            }






        }

        void Choiximagetexturecustom4()
        {
            string verifskin;
            string nomfichier = "";


            if (skin4.SelectedIndex.ToString() == "-1")
            { nomfichier = skinjoueueur1; }
            else { nomfichier = skin4.Text.ToString(); }




            skin4.SelectedIndex.ToString();
            string chemainskinfichier = @"";
            //choix rayman
            if (Choixperso4.SelectedIndex.ToString() == "0")
            {


                chemainskinfichier = @"fils\texture\customskin\RaymanT\";


                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.r5;
                }
                else
                {


                    verifskin = (verificationfichierskin("rayman", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }

                }


            }




            //choix razor
            if (Choixperso4.SelectedIndex.ToString() == "1")
            {
                chemainskinfichier = @"fils\texture\customskin\Razor\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.ra5;
                }
                else
                {

                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix razorwife
            if (Choixperso4.SelectedIndex.ToString() == "2")
            {
                chemainskinfichier = @"fils\texture\customskin\Razorwife\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.rw4;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix globox
            if (Choixperso4.SelectedIndex.ToString() == "3")
            {
                chemainskinfichier = @"fils\texture\customskin\globox\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.g5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix huchman
            if (Choixperso4.SelectedIndex.ToString() == "4")
            {
                chemainskinfichier = @"fils\texture\customskin\Henchman\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.h3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }
            //choix ptizetre
            if (Choixperso4.SelectedIndex.ToString() == "5")
            {

                chemainskinfichier = @"fils\texture\customskin\Teensies\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.p3;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }

            //choix tily
            if (Choixperso4.SelectedIndex.ToString() == "6")
            {

                chemainskinfichier = @"fils\texture\customskin\Tily\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.t5;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else { verificationmessage(); }
                }

            }



            if (Choixperso4.SelectedIndex.ToString() == "7")
            {

                chemainskinfichier = @"fils\texture\customskin\Henchman1000\";

                if (skin4.SelectedIndex == 0)
                {
                    photoskin4.Image = Properties.Resources.huch10000;
                }
                else
                {
                    verifskin = (verificationfichierskin("0", chemainskinfichier, nomfichier));

                    if (verifskin == "oui")
                    {
                        photoskin4.Image = Image.FromFile(chemainskinfichier + nomfichier + @"\demo.jpg");
                    }
                    else
                    {
                        MessageBox.Show(Incompletskin); Application.Exit();


                    }

                }

            }




        }



        private void BtnLuncheurGameFull_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        public void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }






        private async void acceuil_Load(object sender, EventArgs e)
        {





        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sourceFilePath = @"fils\dgVoodoo\full\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);

            string sourceFilePath2 = @"fils\dgVoodoo\full\dgVoodooSetupPaths.dat";
            string appDataPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath2 = Path.Combine(appDataPath2, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath2, destinationFilePath2, true);

            if (Gamehdsd == "0")
            {

                // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
                // System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"game\SD\R_Arena.exe";
                Process.Start(startInfo);
                Application.Exit();

            }
            else {

               // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
               // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
               // System.Diagnostics.Process.Start("cmd", @"/c start game\HD\R_Arena.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"game\HD\R_Arena.exe";
                Process.Start(startInfo);
                Application.Exit();

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.radmin-vpn.com/");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/sQMXyNQA");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string sourceFilePath = @"fils\dgVoodoo\fenetre1\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);


             sourceFilePath = @"fils\dgVoodoo\fenetre1\dgVoodooSetupPaths.dat";
             appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
             destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath, destinationFilePath, true);


            // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre1\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre1\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"game\SD\R_Arena.exe";
            Process.Start(startInfo);


           // System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena.exe");
            Application.Exit();
        }



        private void button11_Click(object sender, EventArgs e)
        {

            string sourceFilePath = @"fils\dgVoodoo\full\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);

            sourceFilePath = @"fils\dgVoodoo\full\dgVoodooSetupPaths.dat";
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath, destinationFilePath, true);

            // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\full\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
            //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arena.exe");

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"game\SD\R_Arena.exe";
            Process.Start(startInfo);


            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            string sourceFilePath = "fils\\video\\vierge\\Videos\\Intro.bik";
            string sdDestinationFilePath = "game\\SD\\Videos\\Intro.bik";
            string hdDestinationFilePath = "game\\HD\\Videos\\Intro.bik";

            File.Copy(sourceFilePath, sdDestinationFilePath, true);
            File.Copy(sourceFilePath, hdDestinationFilePath, true);

            sourceFilePath = "fils\\video\\vierge\\Videos\\Outro.bik";
            sdDestinationFilePath = "game\\SD\\Videos\\Outro.bik";
            hdDestinationFilePath = "game\\HD\\Videos\\Outro.bik";

            File.Copy(sourceFilePath, sdDestinationFilePath, true);
            File.Copy(sourceFilePath, hdDestinationFilePath, true);

            sourceFilePath = "fils\\video\\vierge\\Videos\\Ubi.bik";
            sdDestinationFilePath = "game\\SD\\Videos\\Ubi.bik";
            hdDestinationFilePath = "game\\HD\\Videos\\Ubi.bik";

            File.Copy(sourceFilePath, sdDestinationFilePath, true);
            File.Copy(sourceFilePath, hdDestinationFilePath, true);



            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Intro.bik game\SD\Videos\Intro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Outro.bik game\SD\Videos\Outro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Ubi.bik game\SD\Videos\Ubi.bik");

           //
           //
           //
           //
           //("cmd", @"/c copy fils\video\vierge\Videos\Intro.bik game\HD\Videos\Intro.bik");
           //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Outro.bik game\HD\Videos\Outro.bik");
           //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Ubi.bik game\HD\Videos\Ubi.bik");
            MessageBox.Show(messageboxNoVideo);
        }

        private void button12_Click(object sender, EventArgs e)
        {

            string introSourcePath = @"fils\video\normal\Videos\Intro.bik";
            string outroSourcePath = @"fils\video\normal\Videos\Outro.bik";
            string ubiSourcePath = @"fils\video\normal\Videos\Ubi.bik";

            string sdIntroDestPath = @"game\SD\Videos\Intro.bik";
            string sdOutroDestPath = @"game\SD\Videos\Outro.bik";
            string sdUbiDestPath = @"game\SD\Videos\Ubi.bik";

            string hdIntroDestPath = @"game\HD\Videos\Intro.bik";
            string hdOutroDestPath = @"game\HD\Videos\Outro.bik";
            string hdUbiDestPath = @"game\HD\Videos\Ubi.bik";

            // Copy files to SD folder
            File.Copy(introSourcePath, sdIntroDestPath, true);
            File.Copy(outroSourcePath, sdOutroDestPath, true);
            File.Copy(ubiSourcePath, sdUbiDestPath, true);

            // Copy files to HD folder
            File.Copy(introSourcePath, hdIntroDestPath, true);
            File.Copy(outroSourcePath, hdOutroDestPath, true);
            File.Copy(ubiSourcePath, hdUbiDestPath, true);

            // System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Intro.bik game\SD\Videos\Intro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Outro.bik game\SD\Videos\Outro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Ubi.bik game\SD\Videos\Ubi.bik");


            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Intro.bik game\HD\Videos\Intro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Outro.bik game\HD\Videos\Outro.bik");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Ubi.bik game\HD\Videos\Ubi.bik");
            MessageBox.Show(messageboxOkVideo);



        }



        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(@"fils\RaymanControlPanel.exe");
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Process.Start(@"game\SD\RM_Setup_DX8.exe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Process proc = new Process(); proc.StartInfo.FileName = @"game\SD\dgVoodooCpl.exe"; proc.StartInfo.UseShellExecute = true; proc.StartInfo.Verb = "runas"; proc.Start(); 

            //System.Diagnostics.Process.Start("cmd", @"/c cd game\SD\ & start dgVoodooCpl.exe");

            Process.Start(@"dgVoodooCpl.exe");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string sourceFilePath = @"fils\dgVoodoo\fenetre3\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);

             sourceFilePath = @"fils\dgVoodoo\fenetre3\dgVoodooSetupPaths.dat";
             appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
             destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath, destinationFilePath, true);

           // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre3\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre3\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
            //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arenaadmin");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"game\SD\R_Arenaadmin.exe";
            Process.Start(startInfo);
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sourceFilePath = @"fils\dgVoodoo\fenetre2\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);

             sourceFilePath = @"fils\dgVoodoo\fenetre2\dgVoodooSetupPaths.dat";
             appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
             destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath, destinationFilePath, true);



           // System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre2\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre2\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
            //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arenaadmin");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"game\SD\R_Arenaadmin.exe";
            Process.Start(startInfo);

            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string sourceFilePath = @"fils\dgVoodoo\fenetre4\dgVoodoo.conf";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodoo.conf");
            File.Copy(sourceFilePath, destinationFilePath, true);

             sourceFilePath = @"fils\dgVoodoo\fenetre4\dgVoodooSetupPaths.dat";
             appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
             destinationFilePath = Path.Combine(appDataPath, @"dgVoodoo\dgVoodooSetupPaths.dat");
            File.Copy(sourceFilePath, destinationFilePath, true);

            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre4\dgVoodoo.conf %APPDATA%\dgVoodoo\dgVoodoo.conf");
            //System.Diagnostics.Process.Start("cmd", @"/c copy fils\dgVoodoo\fenetre4\dgVoodooSetupPaths.dat %APPDATA%\dgVoodoo\dgVoodooSetupPaths.dat");
            //System.Diagnostics.Process.Start("cmd", @"/c start game\SD\R_Arenaadmin");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"game\SD\R_Arenaadmin.exe";
            Process.Start(startInfo);
            Application.Exit();
        }

        private void changelangue_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (changelangue.SelectedIndex == 0)
            {

                File.WriteAllText(cheminfichierLangue, "EN");

            }
            else if (changelangue.SelectedIndex == 1)
            {

                File.WriteAllText(cheminfichierLangue, "FR");


            }
            else if (changelangue.SelectedIndex == 2)
            {

                File.WriteAllText(cheminfichierLangue, "ES");

            }
            else if (changelangue.SelectedIndex == 3)
            {

                File.WriteAllText(cheminfichierLangue, "RU");

            }
            choixlangue();

        }



        void choixlangue() {

            if (changelangue.SelectedIndex.ToString() == "0")
            {
                messageboxLangue = "the game is now in English !!";
                CopieNomReseau = "the name of the network was copied to the clipboard";
                CopieMdpReseau = "the network password has been copied to the clipboard";

                onlinetestgreen = "🌐 Ready To play";
                onlinetestorange = "Radmin Vpn is ok I detected more launcher is on the good card";
                onlinetestred = "Radmin Vpn is not detected and the launcher is not on the good card !!";

                ReiniSkin = "Are you sure you want to reset the skins?";

                //MessageBox.Show(messageboxLangue);
                //changement de langue 

                label8.Text = "Multiplayer Settings";
                label20.Text = "Launcher Menu Language";
                label17.Text = "Game language";
                label10.Text = "Download RadminVpn (if you don't already have it)";
                label24.Text = "Install it on your PC and run it";
                label11.Text = "Press on the 'Network' Tab and Join an Existing Network";
                label88.Text = "Or press  ' + '  and Join the following Private Network:";
                label12.Text = "The Rayman Arena Multiplayer mode was originally designed for local matches.";
                label54.Text = "You have to install a VPN client that enables you to join online lobbies.";
                label13.Text = "";
                label21.Text = "choose the network card with which you play online";
                label7.Text = "Server Name:";
                label25.Text = "Server Password:";
                label44.Text = "Only SD";
                label46.Text = "Game Resolution";
                label29.Text = "Controller Fix";
                label15.Text = "Advanced Configurations";
                radioButton2.Text = "Vibration Off";
                radioButton1.Text = "Vibration On (Windows 10/11 Support Only)";

                label60.Text = "External Utility Tools";
                toolTip1.SetToolTip(radioButton2, "If you check this box, you will no longer have any controller vibration during your game. normal vibrations do not work on older versions of Windows so it is recommended to check this box if you are using an older version of Windows...");

                label31.Text = "Select Network Adapter Radmin VPN.";
                label21.Text = "You may choose different Network adapter";
                label79.Text = "in case you decide using different LAN  Client.";
                label74.Text = "Configuration Checker:";
                label81.Text = "Launch the game and select LAN GAME at the Main Menu.";
                label93.Text = "Skin Texture Editing Mode";

                button16.BackgroundImage = Properties.Resources.Button003; //laucher

                label89.Text = "Player 1";
                label90.Text = "Player 2";
                label91.Text = "Player 3";
                label92.Text = "Player 4";
                label34.Text = "Custom Skin";
                label35.Text = "Custom Skin";
                label38.Text = "Custom Skin";
                label41.Text = "Custom Skin";

                label32.Text = "Character";
                label37.Text = "Character";
                label40.Text = "Character";
                label43.Text = "Character";
                label55.Text = "Multiplayer  Instructions :";

                label33.Text = "Skin Slot";
                label36.Text = "Skin Slot";
                label39.Text = "Skin Slot";
                label42.Text = "Skin Slot";

                label61.Text = "dgVoodo is a graphic wrapper that fixes many compatibility ";
                label62.Text = "issues  when running old games on modern systems.";

                label66.Text = "Rayman Control Panel is a utility tool made by RayCarrot ";
                label65.Text = "for easily access settings and fixes for various Rayman titles,";
                label64.Text = "the Archive Explorer utility for Texture replacement and more.";

                label69.Text = "DX Setup is the official Ubisoft setup tool for the game.";
                label68.Text = "It configs the Graphics, Video and modem options.";

                label72.Text = "UBI.INI is the file where the DX Setup stores its settings.";
                label78.Text = "Network adapter";


                btnValidskin1.BackgroundImage = Properties.Resources.EditSkin01;
                btnValidskin2.BackgroundImage = Properties.Resources.EditSkin01;
                btnValidskin3.BackgroundImage = Properties.Resources.EditSkin01;
                btnValidskin4.BackgroundImage = Properties.Resources.EditSkin01;

                Modifier.BackgroundImage = Properties.Resources.Apply001;

                comboBox2.Text = "choose the resolution";
                label75.Text = "Screen Mode";
                label76.Text = "Game Intro";
                label77.Text = "Texture Mode";
                FullScreen.Text = "Fullscreen";
                Windowsscreen.Text = "Windowed";
                linkLabel1.Text = "How to add new skins";
                button3.BackgroundImage = Properties.Resources.AddNewSkins;


                button21.BackgroundImage = Properties.Resources.ResetSkins001;

                //modifer les boite de dialogue

                messageboxNoVideo = "game intro videos have been disabled";
                messageboxOkVideo = "the game's intro videos have been reactivated";
                Choixcard = " well was to select";
                Pasradmin = "we have detected that you do not have Radmin Vpn installed. This program is required to play the game online";
                Incompletskin = "the skin is missing files. Unable to select it";
                skindoublon = "another player has already been configured in the same place!!";
                ActivDesaSKINsdHD = "once a skin has been modified in sd or hd it is no longer possible to change position. You have to re-insulate the skin to modify the quality of the texture.";

                Vertionajour = "you have the most recent version";
                vertionpasajour = "You don't have the latest version. Do you want to download it?";
                pasverifmaj = "I can't check your version. Can you check your internet connection?";
                skinincomplet = "the skin you have chosen is incomplete. It therefore cannot be loaded. Do you want to reset the skins? (if not the program will stop).";

                resolutionwarnning = "this resolution is not supported by the game. The launcher will adapt it as best as possible. For best results select a supported resolution";

                ButtonresoAuto.Text = "Automatically detects the optimal resolution";

                tabPage1.Text = "Game";
                tabPage2.Text = "Skin";
                tabPage3.Text = "Multiplayer ";
                tabPage4.Text = "Config ";
                tabPage5.Text = "About";

                ouvertureform4.Text = "Opening of the download center";

                Reinisialiastaion.Text = "Reset";


                //position

                label17.Location = new Point(198, 223); // game language
                label75.Location = new Point(204, 357); // preszntation du jeu
                label76.Location = new Point(207, 460); // intro
                label77.Location = new Point(200, 407); // Texture mode
                label46.Location = new Point(188, 289); // resolution mode
                Windowsscreen.Location = new Point(246, 14);
                FullScreen.Location = new Point(114, 14);

                label8.Location = new Point(115, 27);
                label93.Location = new Point(98, 11);

                label60.Location = new Point(170, 237); // resolution mode
                label15.Location = new Point(99, 18);

                label12.Location = new Point(48, 79);
                label54.Location = new Point(74, 94);

                label89.Location = new Point(257, -5);
                label90.Location = new Point(257, -4);
                label91.Location = new Point(255, -5);
                label92.Location = new Point(255, -6);

                label14.Location = new Point(293, 537);

                label20.Location = new Point(194, 102);
                label29.Location = new Point(206, 171);
                label60.Location = new Point(156, 237);

            }
            else if (changelangue.SelectedIndex.ToString() == "1")
            {


                messageboxLangue = "le jeu est maintenant en français !!";
                //MessageBox.Show(messageboxLangue);
                CopieNomReseau = "le nom du réseau à été copié dans le presse-papiers";
                CopieMdpReseau = "le mot de passe réseau a été copié dans le presse-papiers";

                onlinetestgreen = "🌐 Prêt à jouer";
                onlinetestorange = "Radmin Vpn est bien détécter mais le luncher est pas sur la bonne carte";
                onlinetestred = "Radmin Vpn n'est pas détecté et le launcher n'est pas sur la bonne carte !!";
                ReiniSkin = "Etes-vous sur de vouloir réinitialiser les peau ?";


                //changement de langue 


                label8.Text = "Paramètres multijoueur";
                label20.Text = "Langue du menu du lanceur";
                label17.Text = "Langue du jeu";
                label10.Text = "Téléchargez RadminVpn (si vous ne l'avez pas déjà)";
                label24.Text = "Installer le sur votre PC";
                label11.Text = "Rejoindre le reseau privé suivant:";
                label12.Text = "Le mode multijoueur Rayman Arena a été conçu à l'origine pour les matchs locaux.";
                label54.Text = "Vous devez installer un client VPN qui vous permet de rejoindre des lobbies en ligne.";
                label13.Text = "";
                label21.Text = "choisir la carte réseaux avec la qu'elle vous jouer en ligne ";
                label7.Text = "Nom du serveur:";
                label25.Text = "Mot de passe serveur :";
                label44.Text = "Uniquement SD";
                label29.Text = "Correctif de contrôle";
                label15.Text = "Configurations avancées";
                label60.Text = "Outils utilitaires externes";
                radioButton2.Text = "Arrêter Les Vibrations";
                radioButton1.Text = "Vibration ok (Windows 10/11 uniquement)";
                label46.Text = "Resolution du jeu";
                label93.Text = "Mode d'Edition De Skin";

                toolTip1.SetToolTip(radioButton2, "Si vous cochez cette case, vous n'aurez plus aucune vibration de la manette pendant votre partie. les vibrations normales ne fonctionnent pas sur les anciennes versions de Windows, il est donc recommandé de cocher cette case si vous utilisez une ancienne version de Windows...");

                button16.BackgroundImage = Properties.Resources.Button003FR; //laucher


                label89.Text = "Joueur 1";
                label90.Text = "Joueur 2";
                label91.Text = "Joueur 3";
                label92.Text = "Joueur 4";
                label34.Text = "Skin Personnalisée";
                label35.Text = "Skin Personnalisée";
                label38.Text = "Skin Personnalisée";
                label41.Text = "Skin Personnalisée";

                label32.Text = "Personnage";
                label37.Text = "Personnage";
                label40.Text = "Personnage";
                label43.Text = "Personnage";

                label33.Text = "Position";
                label36.Text = "Position";
                label39.Text = "Position";
                label42.Text = "Position";
                label55.Text = "Instructions en ligne :";




                label61.Text = "dgVoodoo est un wrapper graphique qui corrige de nombreuses compatibilités";
                label62.Text = "problèmes lors de l'exécution de vieux jeux sur des systèmes modernes.";

                label66.Text = "Rayman Control Panel est un outil utilitaire créé par RayCarrot";
                label65.Text = "pour accéder facilement aux paramètres et correctifs de divers titres Rayman, ";
                label64.Text = "l'utilitaire Archive Explorer pour le remplacement de texture et plus encore.";

                label69.Text = "DX Setup est l'outil de configuration officiel d'Ubisoft pour le jeu.";
                label68.Text = "Il configure les options graphiques, vidéo et modem.";

                label72.Text = "UBI.INI est le fichier dans lequel la configuration DX stocke ses paramètres.";



                btnValidskin1.BackgroundImage = Properties.Resources.EditSkin01FR;
                btnValidskin2.BackgroundImage = Properties.Resources.EditSkin01FR;
                btnValidskin3.BackgroundImage = Properties.Resources.EditSkin01FR;
                btnValidskin4.BackgroundImage = Properties.Resources.EditSkin01FR;
                Modifier.BackgroundImage = Properties.Resources.ApplyFR;

                button21.BackgroundImage = Properties.Resources.ResetSkins001FR;
                comboBox2.Text = "choisissez votre résolution";
                label75.Text = "Mode Écran";
                label76.Text = "Présentation du jeu";
                label77.Text = "Mode Texturé";
                FullScreen.Text = "Plein Écran";
                Windowsscreen.Text = "Fenêtre";
                linkLabel1.Text = "Comment ajouter de nouveaux skins";
                button3.BackgroundImage = Properties.Resources.AddNewSkinsFR;


                label31.Text = "Sélectionnez la carte réseau Radmin VPN.";
                label21.Text = "Vous pouvez choisir un adaptateur réseau différent";
                label79.Text = "au cas où vous décidez d'utiliser un client LAN différent";
                label74.Text = "Vérificateur de configuration :";
                label81.Text = "Lancez le jeu et sélectionnez LAN GAME dans le menu principal";
                label78.Text = "Adaptateur de réseau";


                //modifie les toltip
                // toolTip1.SetToolTip(button17, "pour les utilisateur avancer qui on crée leur prpore config");



                //modifer les boite de dialogue

                messageboxNoVideo = "les vidéos d'introduction du jeu ont été désactivées";
                messageboxOkVideo = "les vidéos d'introduction du jeu ont été réactivées";
                Choixcard = " bien a été sélectionné";
                Pasradmin = "nous avons détecté que vous n'avez pas installé Radmin Vpn. Ce programme est nécessaire pour jouer au jeu en ligne";
                Incompletskin = "il manque des fichiers au skin.Impossible de le selectionner";
                skindoublon = "un autre joueur a déjà été configuré au même endroit!!";
                ActivDesaSKINsdHD = "une fois un skin modifier en sd ou hd il n'est plus possible de changer de position. Vous etes obliger de reinisilaiser la peau pour modifier la qualite de la texture.";



                Vertionajour = "tu as la version la plus récente :)";
                vertionpasajour = "Vous n'avez pas la dernière version. Voulez-vous le télécharger ?";
                pasverifmaj = "Je ne peux pas vérifier votre version. Pouvez-vous vérifier votre connexion Internet ?";

                skinincomplet = "le skin que vous avez choisi est incomplet. Il ne peut donc pas être chargé. Voulez-vous réinitialiser les skins ? (sinon le programme s'arrêtera).";

                resolutionwarnning = "this resolution is not supported by the game. The launcher will adapt it as best as possible. For best results select a supported resolution";


                tabPage1.Text = "jeu";
                tabPage2.Text = "Skin";
                tabPage3.Text = "Multijoueur ";
                tabPage4.Text = "Config ";
                tabPage5.Text = "à propos";

                ButtonresoAuto.Text = "Détecte automatiquement la résolution optimale";

                ouvertureform4.Text = "Ouverture du centre de téléchargement";

                Reinisialiastaion.Text = "Réinitialisation";

                //position

                label17.Location = new Point(198, 223); // game language
                label75.Location = new Point(210, 357); // mode ecran
                label76.Location = new Point(175, 460); // intro
                label77.Location = new Point(200, 407); // Texture mode
                label46.Location = new Point(188, 289); // resolution mode
                Windowsscreen.Location = new Point(246, 14);
                FullScreen.Location = new Point(114, 14);

                label8.Location = new Point(115, 27);
                label93.Location = new Point(100, 11);

                label60.Location = new Point(170, 237); // config mode
                label15.Location = new Point(99, 18);

                label12.Location = new Point(48, 79);
                label54.Location = new Point(74, 94);

                label89.Location = new Point(257, -5);
                label90.Location = new Point(257, -4);
                label91.Location = new Point(255, -5);
                label92.Location = new Point(255, -6);

                label14.Location = new Point(293, 537);
                label20.Location = new Point(164, 102);
                label29.Location = new Point(206, 171);
                label60.Location = new Point(156, 237);

            }
            else if (changelangue.SelectedIndex.ToString() == "2")
            {



                messageboxLangue = "el juego ahora esta en español !! !!";
                // MessageBox.Show(messageboxLangue);
                CopieNomReseau = "el nombre de la red se ha copiado en el portapapeles";
                CopieMdpReseau = "la contraseña de la red se ha copiado en el portapapeles";


                onlinetestgreen = "🌐 Lista para jugar";
                onlinetestorange = "Radmin Vpn está bien. Detecté que hay más lanzadores en la tarjeta buena.";
                onlinetestred = "¡Radmin Vpn no se detecta y el iniciador no está en la tarjeta buena!";
                ReiniSkin = "¿Está seguro de que desea restablecer las máscaras?";

                //changement de langue 

                label8.Text = "Configuración multijugador";
                label20.Text = "Idioma del menú del lanzador";
                label17.Text = "Ludlingvo";
                //label20.Location = new Point(264, 102);
                label10.Text = "Elŝutu Radmin Vpn (se vi ne jam havas ĝin)";
                label24.Text = "Instálalo en tu PC";
                label11.Text = "Unete a la siguiente red privada:";
                label12.Text = "El modo multijugador Rayman Arena se diseñó originalmente para partidos locales.";
                label54.Text = "Debe instalar un cliente VPN que le permita unirse a grupos de presión en línea.";
                label13.Text = "";
                label21.Text = "elige la tarjeta de red con la que te jugará online ";
                label7.Text = "Servilo Nomo:";
                label25.Text = "Pasvorto de Servilo:";
                label44.Text = "Solo SD";
                label29.Text = "Corrección de control";
                label15.Text = "Configuraciones avanzadas";
                label60.Text = "Herramientas de utilidad externa";
                radioButton2.Text = "Detener La Vibración";
                radioButton1.Text = "Vibración ok (solo compatible con Windows 10/11)";
                label46.Text = "Resolución Del Juego";
                label93.Text = "Modificación de la Skin";

                toolTip1.SetToolTip(radioButton2, "Si marca esta casilla, ya no tendrá ninguna vibración del controlador durante su juego. las vibraciones normales no funcionan en versiones anteriores de Windows, por lo que se recomienda marcar esta casilla si está utilizando una versión anterior de Windows...");


                button16.BackgroundImage = Properties.Resources.Button003SP;  //laucher


                label61.Text = "dgVoodoo es un envoltorio gráfico que corrige muchas compatibilidades";
                label62.Text = "problemas al ejecutar juegos antiguos en sistemas modernos.";

                label66.Text = "Rayman Control Panel es una herramienta de utilidad hecha por RayCarrot";
                label65.Text = "para acceder fácilmente a la configuración y arreglos para varios títulos de";
                label64.Text = "Rayman, la utilidad Archive Explorer para el reemplazo de texturas y más.";

                label69.Text = "DX Setup es la herramienta de configuración oficial de Ubisoft para el juego.";
                label68.Text = "Configura las opciones de Gráficos, Video y módem.";

                label72.Text = "UBI.INI es el archivo donde DX Setup almacena su configuración.";



                label89.Text = "Jugador 1";
                label90.Text = "Jugador 2";
                label91.Text = "Jugador 3";
                label92.Text = "Jugador 4";
                label34.Text = "Skin Personalizada";
                label35.Text = "Skin Personalizada";
                label38.Text = "Skin Personalizada";
                label41.Text = "Skin Personalizada";

                label32.Text = "Prsonaje";
                label37.Text = "Prsonaje";
                label40.Text = "Prsonaje";
                label43.Text = "Prsonaje";
                label55.Text = "Retaj instrukcioj :";


                label33.Text = "Stio";
                label36.Text = "Stio";
                label39.Text = "Stio";
                label42.Text = "Stio";


                btnValidskin1.BackgroundImage = Properties.Resources.EditSkin01SP;
                btnValidskin2.BackgroundImage = Properties.Resources.EditSkin01SP;
                btnValidskin3.BackgroundImage = Properties.Resources.EditSkin01SP;
                btnValidskin4.BackgroundImage = Properties.Resources.EditSkin01SP;

                Modifier.BackgroundImage = Properties.Resources.ApplySP;



                button21.BackgroundImage = Properties.Resources.ResetSkins001ESP;
                comboBox2.Text = "Elige Tu Resolución";
                label75.Text = "Modo De Pantalla";
                label76.Text = "Presentación Del Juego";
                label77.Text = "Modo de Textura";
                FullScreen.Text = "Pantalla Comleta";
                Windowsscreen.Text = "Con Ventana";
                linkLabel1.Text = "Cómo agregar nuevas máscaras";
                button3.BackgroundImage = Properties.Resources.AddNewSkinsSP;


                label31.Text = "Seleccione el adaptador de red Radmin VPN.";
                label21.Text = "Puede elegir un adaptador de red diferente";
                label79.Text = "en caso de que decida utilizar un cliente LAN diferente";
                label74.Text = "Comprobador de configuración:";
                label81.Text = "Inicie el juego y seleccione LAN GAME en el menú principal";
                label78.Text = "Adaptador de red";



                //modifer les boite de dialogue

                messageboxNoVideo = "Se han desactivado los vídeos de introducción al juego.";
                messageboxOkVideo = "Se reactivaron los videos de introducción del juego.";
                Choixcard = " bien fue seleccionado";
                Pasradmin = "Hemos detectado que no tiene Radmin Vpn instalado. Este programa es necesario para jugar el juego en línea.";
                Incompletskin = "Faltan archivos en la máscara. No se puede seleccionar.";
                skindoublon = "ya se ha configurado otro jugador en el mismo lugar!!";
                ActivDesaSKINsdHD = "una vez que se ha modificado un skin en sd o hd ya no es posible cambiar de posición. Hay que volver a aislar la piel para modificar la calidad de la textura.";

                Vertionajour = "tienes la versión más reciente";
                vertionpasajour = "No tienes la última versión. ¿Quieres descargarlo?";
                pasverifmaj = "No puedo comprobar tu versión. ¿Puedes comprobar tu conexión a Internet?";


                skinincomplet = "el aspecto que ha elegido está incompleto. Por lo tanto, no se puede cargar. ¿Quieres restablecer las máscaras? (si no, el programa se detendrá).";


                resolutionwarnning = "esta resolución no es compatible con el juego. El lanzador la adaptará lo mejor posible. Para obtener los mejores resultados, seleccione una resolución compatible";


                tabPage1.Text = "juego";
                tabPage2.Text = "Skin";
                tabPage3.Text = "Multijugadora ";
                tabPage4.Text = "Config ";
                tabPage5.Text = "Sobre";


                ButtonresoAuto.Text = "Detecta automáticamente la resolución óptima";

                ouvertureform4.Text = "Apertura del centro de descargas";

                Reinisialiastaion.Text = "Reinisialiastación";


                //position

                label17.Location = new Point(213, 223); // game language
                label75.Location = new Point(180, 357); // mode ecran
                label76.Location = new Point(165, 460); // intro
                label77.Location = new Point(185, 407); // Texture mode
                label46.Location = new Point(173, 289); // resolution mode
                Windowsscreen.Location = new Point(246, 14);
                FullScreen.Location = new Point(90, 14);

                label8.Location = new Point(115, 27);
                label93.Location = new Point(100, 11);

                label15.Location = new Point(99, 18);
                label60.Location = new Point(146, 237); // resolution mode

                label12.Location = new Point(48, 79);
                label54.Location = new Point(74, 94);

                label89.Location = new Point(257, -5);
                label90.Location = new Point(257, -4);
                label91.Location = new Point(255, -5);
                label92.Location = new Point(255, -6);

                label14.Location = new Point(293, 537);

                label20.Location = new Point(164, 102);
                label29.Location = new Point(206, 171);
                label60.Location = new Point(156, 237);

            }



            else if (changelangue.SelectedIndex.ToString() == "3")
            {

                messageboxLangue = "Теперь игра на английском языке!!";
                CopieNomReseau = "Название сети скопировано в буфер обмена";
                CopieMdpReseau = "Пароль сети скопирован в буфер обмена";

                onlinetestgreen = "🌐 Всё готово";
                onlinetestorange = "Radmin Vpn в норме, сетевая карта лаунчера настроена";
                onlinetestred = "Radmin Vpn не найден, сетевая карта лаунчера не настроена!!";

                ReiniSkin = "Вы уверены, что хотите сбросить скины?";

                //MessageBox.Show(messageboxLangue);
                //changement de langue 

                label8.Text = "Настройки мультиплеера";
                label20.Text = "Язык лаунчера";
                label17.Text = "Язык игры";
                label10.Text = "Скачайте Radmin Vpn (если у Вас его еще нет)";
                label24.Text = "Установите его на свой компьютер и запустите";
                label11.Text = "Нажмите на вкладку 'Network' и присоединитесь к существующей сети";
                label88.Text = "Либо нажмите на '+' и присоединитесь к данной частной сети:";
                label12.Text = "Многопользовательский режим Rayman Arena изначально был разработан";
                label54.Text = "Для локальных матчей. Вам необходимо установить VPN-клиент";
                label63.Text = "который позволит Вам присоединиться к онлайн-лобби.";
                label13.Text = "";
                label21.Text = "Выберите сетевую карту, с которой вы играете онлайн";
                label7.Text = "Название сервера:";
                label25.Text = "Пароль сервера:";
                label44.Text = "Только SD";
                label46.Text = "Разрешение игры";
                label29.Text = "Фикс контроллера";
                label15.Text = "Дополнительные настройки";
                radioButton2.Text = "Без вибрации";
                radioButton1.Text = "С вибрацией (Только для Windows 10/11)";

                label60.Text = "Внешние Утилиты";
                toolTip1.SetToolTip(radioButton2, "Если вы выберете этот параметр, у вас не будет вибрировать контроллер во время игры. Стандартная вибрация не работает в более старых версиях Windows, поэтому рекомендуется установить этот параметр, если вы используете более старую версию Windows...");

                label31.Text = "Выберите в качестве сетевого адаптера Radmin VPN.";
                label21.Text = "Вы можете выбрать другой сетевой адаптер,";
                label79.Text = "если вы решите использовать другой LAN-клиент.";
                label74.Text = "Проверка конфигурации:";
                label81.Text = "Запустите игру и выберите LAN GAME в главном меню.";
                label93.Text = "Режим редактирования скинов";

                button16.BackgroundImage = Properties.Resources.LaunchButtonRus; //laucher

                label89.Text = "Игрок 1";
                label90.Text = "Игрок 2";
                label91.Text = "Игрок 3";
                label92.Text = "Игрок 4";
                label34.Text = "Скин";
                label35.Text = "Скин";
                label38.Text = "Скин";
                label41.Text = "Скин";

                label32.Text = "Персонаж";
                label37.Text = "Персонаж";
                label40.Text = "Персонаж";
                label43.Text = "Персонаж";
                label55.Text = "Инструкция по настройке мультиплеера:";

                label33.Text = "Ячейка для скина";
                label36.Text = "Ячейка для скина";
                label39.Text = "Ячейка для скина";
                label42.Text = "Ячейка для скина";

                label61.Text = "dgVoodoo - это графическая оболочка, исправляющая большинство";
                label62.Text = "проблем совместимости при запуске старых игр на современных системах.";

                label66.Text = "Rayman Control Panel - это утилита от RayCarrot ";
                label65.Text = "для быстрого доступа к настройкам и патчам различных игр про Рэймана,";
                label64.Text = "а также к утилите Archive Explorer для замены текстур и многого другого.";

                label69.Text = "DX Setup - это официальный инструмент конфигурации игры от Ubisoft.";
                label68.Text = "Он устанавливает параметры графики, модема и видео.";

                label72.Text = "UBI.INI - это файл, в котором DX Setup хранит свои параметры.";
                label78.Text = "Сетевой адаптер";

                btnValidskin1.BackgroundImage = Properties.Resources.EditSkinRus;
                btnValidskin2.BackgroundImage = Properties.Resources.EditSkinRus;
                btnValidskin3.BackgroundImage = Properties.Resources.EditSkinRus;
                btnValidskin4.BackgroundImage = Properties.Resources.EditSkinRus;

                Modifier.BackgroundImage = Properties.Resources.Apply001RUS;

                comboBox2.Text = "Выберите разрешение";
                label75.Text = "Режим экрана";
                label76.Text = "Интро игры";
                label77.Text = "Режим текстур";
                FullScreen.Text = "Полноэкранный";
                Windowsscreen.Text = "Оконный";
                linkLabel1.Text = "Как добавить новые скины";
                button3.BackgroundImage = Properties.Resources.AddNewSkinsRUS;






                button21.BackgroundImage = Properties.Resources.ResetSkins001RUS;

                //modifer les boite de dialogue

                messageboxNoVideo = "Вступительные игровые ролики отключены";
                messageboxOkVideo = "Вступительные игровые ролики повторно активированы";
                Choixcard = " успешно выбрана";
                Pasradmin = "Лаунчер обнаружил, что у вас не установлен Admin Vpn. Эта программа необходима для того, чтобы играть онлайн";
                Incompletskin = "Файлы скина отсутствуют. Скин недоступен для выбора";
                skindoublon = "Другой игрок уже установлен здесь!!";
                ActivDesaSKINsdHD = "После того, как скин был отконвертирован в sd или hd, восстановить его уже невозможно. Вы должны повторно установить скин, чтобы модифицировать качество текстур.";

                Vertionajour = "Ваша версия является самой свежей";
                vertionpasajour = "Новая версия уже доступна. Хотите скачать её?";
                pasverifmaj = "Не удалось проверить наличие обновлений. Проверьте своё подключение к Интернету";
                skinincomplet = "Выбранный Вами скин является неполным, из-за чего не может быть загружен. Хотите сбросить скины? (в противном случае работа программы остановится).";

                resolutionwarnning = "Данное разрешение не поддерживается игрой. Лаунчер адаптирует его в наилучший вариант. Для наилучшего результата выберите поддерживаемое разрешение";

                ouvertureform4.Text = "Открытие центра загрузок";

                tabPage1.Text = "Игра";
                tabPage2.Text = "Скин";
                tabPage3.Text = "Мультиплеер ";
                tabPage4.Text = "Настройки ";
                tabPage5.Text = "О Лаунчере";

                Reinisialiastaion.Text = "Реинисиалиастайон";


                ButtonresoAuto.Text = "Автоматически определяет оптимальное разрешение";


                //position

                label17.Location = new Point(213, 223); // game language
                label75.Location = new Point(192, 360); // mode ecran
                label76.Location = new Point(205, 460); // intro
                label77.Location = new Point(188, 410); // Texture mode
                label46.Location = new Point(180, 289); // resolution mode
                Windowsscreen.Location = new Point(246, 14);
                FullScreen.Location = new Point(90, 14);


                label93.Location = new Point(40, 11);
                label93.Location = new Point(40, 18);

                label8.Location = new Point(105, 27);
                label15.Location = new Point(60, 18);
                label60.Location = new Point(146, 237); // resolution mode


                label12.Location = new Point(48, 79);
                label54.Location = new Point(74, 94);


                label89.Location = new Point(257, 20);
                label90.Location = new Point(257, 20);
                label91.Location = new Point(255, 20);
                label92.Location = new Point(255, 20);

                label14.Location = new Point(310, 537);

                label20.Location = new Point(180, 102);
                label29.Location = new Point(170, 171);
                label60.Location = new Point(170, 237);




            }





            onlinetest();

        }





        public static void ReplaceContainedFile(string cntFilePath, (string gfFullPath, string gfReplacementFilePath)[] gfFiles)
        {
            OpenSpaceSettings settings = OpenSpaceSettings.GetDefaultSettings(OpenSpaceGame.RaymanArena, Platform.PC);
            string tmpFilePath = $"{cntFilePath}.tmp";

            using (Stream archiveStream = File.OpenRead(cntFilePath))
            {
                // Load the .cnt file
                OpenSpaceCntData cnt = BinarySerializableHelpers.ReadFromStream<OpenSpaceCntData>(archiveStream, settings);

                // Create a generator for the files
                IArchiveFileGenerator<OpenSpaceCntFileEntry> srcGenerator = cnt.GetArchiveContent(archiveStream);

                // Create a temp file to write to
                using (Stream outputFileStream = File.Create(tmpFilePath))
                {
                    // Create the destination file generator
                    using (var dstGenerator = new ArchiveFileGenerator<OpenSpaceCntFileEntry>())
                    {
                        // Set the current pointer position to the header size
                        uint pointer = cnt.GetHeaderSize(settings);

                        // Disable checksum and xor keys
                        cnt.IsChecksumUsed = false;
                        cnt.DirChecksum = 0;
                        cnt.XORKey = 0;

                        // Enumerate each file
                        foreach (OpenSpaceCntFileEntry file in cnt.Files)
                        {
                            string filePath = file.GetFullPath(cnt.Directories);

                            // Reset checksum and XOR key
                            file.Checksum = 0;
                            file.XORKey = 0;

                            // Add to the generator
                            dstGenerator.Add(file, () =>
                            {
                                    // Get the file stream to write to the archive
                                    Stream fileStream = null;

                                foreach (var f in gfFiles)
                                {
                                    if (filePath == f.gfFullPath)
                                    {
                                        fileStream = File.OpenRead(f.gfReplacementFilePath);
                                        file.Size = (uint)fileStream.Length;
                                        file.FileXORKey = new byte[4];
                                        break;
                                    }
                                }

                                if (fileStream == null)
                                    fileStream = srcGenerator.GetFileStream(file);


                                    // Set the pointer
                                    file.Pointer = pointer;

                                    // Update the pointer by the file size
                                    pointer += file.Size;

                                return fileStream;
                            });
                        }

                        // Write the files
                        cnt.WriteArchiveContent(outputFileStream, dstGenerator);

                        outputFileStream.Position = 0;

                        // Serialize the data
                        BinarySerializableHelpers.WriteToStream(cnt, outputFileStream, settings);
                    }
                }
            }

            // Replace the original cnt with the temp one
            File.Delete(cntFilePath);
            File.Move(tmpFilePath, cntFilePath);
        }





        private void BtnChangeLangue_Click(object sender, EventArgs e)
        {

            choixlangue();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            //MessageBox.Show("the function is not yet supported. ");
            //MessageBox.Show("Please choose your card once the game has started. ");

        }

        private void Choixperso1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Choixperso1.SelectedIndex.ToString() == "0")
            {
                // emplacement skin jeu

                string[] rayman = { };
                empl1.Items.Clear();
                empl1.Items.AddRange(rayman);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso

                

                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);



            }
            else if (Choixperso1.SelectedIndex.ToString() == "1")
            {
                // emplacement skin jeu

                string[] Razor = { };
                empl1.Items.Clear();
                empl1.Items.AddRange(Razor);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso

                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razor");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);

            }
            else if (Choixperso1.SelectedIndex.ToString() == "2")
            {
                // emplacement skin jeu

                string[] Razorwife = { };
                empl1.Items.Clear();
                empl1.Items.AddRange(Razorwife);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;


                //skin perso
                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razorwife");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);

            }
            else if (Choixperso1.SelectedIndex.ToString() == "3")
            {
                // emplacement skin jeu
                Choiximagetexturecustom();
                string[] globox = { "2", "3", "4" };
                empl1.Items.Clear();
                empl1.Items.AddRange(globox);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso
                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);

            }
            else if (Choixperso1.SelectedIndex.ToString() == "4")
            {
                // emplacement skin jeu

                string[] Hunchman = { "2", "3", "4" };
                empl1.Items.Clear();
                empl1.Items.AddRange(Hunchman);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso
                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);
            }
            else if (Choixperso1.SelectedIndex.ToString() == "5")
            {
                // emplacement skin jeu

                string[] ptizetre = { "2", "3", "4" };
                empl1.Items.Clear();
                empl1.Items.AddRange(ptizetre);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;


                //skin perso
                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);
            }
            else if (Choixperso1.SelectedIndex.ToString() == "6")
            {


                // emplacement skin jeu

                string[] Tily = { };
                empl1.Items.Clear();
                empl1.Items.AddRange(Tily);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso

                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Tily");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);


            }


            else if (Choixperso1.SelectedIndex.ToString() == "7")
            {


                string[] Hucman1000 = { "2", "3", "4" };
                empl1.Items.Clear();
                empl1.Items.AddRange(Hucman1000);
                empl1.Text = "1";
                empl1.Items.Insert(0, "1");
                empl1.SelectedIndex = 0;

                //skin perso

                skin1.Items.Clear();
                skin1.Items.Insert(0, "Original");
                skin1.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin1.Items.Add(dri.Name);



            }





        }

        private void empl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ModifImageskinUbi(1);






        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void skin1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choiximagetexturecustom();
        }

        private void photoskin1_Click(object sender, EventArgs e)
        {
        }

        private void Choixperso2_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (Choixperso2.SelectedIndex.ToString() == "0")
            {
                // emplacement skin jeu

                string[] rayman = { };
                empl2.Items.Clear();
                empl2.Items.AddRange(rayman);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);

            }
            else if (Choixperso2.SelectedIndex.ToString() == "1")
            {
                // emplacement skin jeu

                string[] Razor = { };
                empl2.Items.Clear();
                empl2.Items.AddRange(Razor);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razor");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);
            }
            else if (Choixperso2.SelectedIndex.ToString() == "2")
            {
                // emplacement skin jeu

                string[] Razorwife = { };
                empl2.Items.Clear();
                empl2.Items.AddRange(Razorwife);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razorwife");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);
            }
            else if (Choixperso2.SelectedIndex.ToString() == "3")
            {
                // emplacement skin jeu

                string[] globox = { "2", "3", "4" };
                empl2.Items.Clear();
                empl2.Items.AddRange(globox);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso
                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);
            }
            else if (Choixperso2.SelectedIndex.ToString() == "4")
            {
                // emplacement skin jeu
                string[] Hunchman = { "2", "3", "4" };
                empl2.Items.Clear();
                empl2.Items.AddRange(Hunchman);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso
                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);
            }
            else if (Choixperso2.SelectedIndex.ToString() == "5")
            {
                // emplacement skin jeu
                string[] ptizetre = { "2", "3", "4" };
                empl2.Items.Clear();
                empl2.Items.AddRange(ptizetre);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;


                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);
            }
            else if (Choixperso2.SelectedIndex.ToString() == "6")
            {
                // emplacement skin jeu

                string[] Tily = { };
                empl2.Items.Clear();
                empl2.Items.AddRange(Tily);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Tily");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);



            }


            else if (Choixperso2.SelectedIndex.ToString() == "7")
            {


                string[] Hucman1000 = { "2", "3", "4" };
                empl2.Items.Clear();
                empl2.Items.AddRange(Hucman1000);
                empl2.Text = "1";
                empl2.Items.Insert(0, "1");
                empl2.SelectedIndex = 0;

                //skin perso

                skin2.Items.Clear();
                skin2.Items.Insert(0, "Original");
                skin2.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin2.Items.Add(dri.Name);



            }







        }

        private void empl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ModifImageskinUbi(2);



        }

        private void skin2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choiximagetexturecustom2();
        }

        private void skin3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choiximagetexturecustom3();
        }

        private void skin4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Choiximagetexturecustom4();

            string test = "";

            skin4.SelectedText = test;

        }

        private void Choixperso3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choixperso3.SelectedIndex.ToString() == "0")
            {
                // emplacement skin jeu

                string[] rayman = { };
                empl3.Items.Clear();
                empl3.Items.AddRange(rayman);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso

                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);

            }
            else if (Choixperso3.SelectedIndex.ToString() == "1")
            {
                // emplacement skin jeu

                string[] Razor = { };
                empl3.Items.Clear();
                empl3.Items.AddRange(Razor);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso

                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razor");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);

            }
            else if (Choixperso3.SelectedIndex.ToString() == "2")
            {
                // emplacement skin jeu

                string[] Razorwife = { };
                empl3.Items.Clear();
                empl3.Items.AddRange(Razorwife);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso

                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razorwife");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);
            }
            else if (Choixperso3.SelectedIndex.ToString() == "3")
            {
                // emplacement skin jeu

                string[] globox = { "2", "3", "4" };
                empl3.Items.Clear();
                empl3.Items.AddRange(globox);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso
                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);
            }
            else if (Choixperso3.SelectedIndex.ToString() == "4")
            {
                // emplacement skin jeu
                string[] Hunchman = { "2", "3", "4" };
                empl3.Items.Clear();
                empl3.Items.AddRange(Hunchman);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso
                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);
            }
            else if (Choixperso3.SelectedIndex.ToString() == "5")
            {
                // emplacement skin jeu

                string[] ptizetre = { "2", "3", "4" };
                empl3.Items.Clear();
                empl3.Items.AddRange(ptizetre);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;


                //skin perso
                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);
            }
            else if (Choixperso3.SelectedIndex.ToString() == "6")
            {
                // emplacement skin jeu

                string[] Tily = { };
                empl3.Items.Clear();
                empl3.Items.AddRange(Tily);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso

                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Tily");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);



            }


            else if (Choixperso3.SelectedIndex.ToString() == "7")
            {


                string[] Hucman1000 = { "2", "3", "4" };
                empl3.Items.Clear();
                empl3.Items.AddRange(Hucman1000);
                empl3.Text = "1";
                empl3.Items.Insert(0, "1");
                empl3.SelectedIndex = 0;

                //skin perso

                skin3.Items.Clear();
                skin3.Items.Insert(0, "Original");
                skin3.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin3.Items.Add(dri.Name);



            }














        }




        public void skinazerotemp()
        {
            Choixperso1.SelectedIndex = 0;
            empl1.SelectedIndex = 0;
            skin1.SelectedIndex = 0;
            Choixperso2.SelectedIndex = 0;
            empl2.SelectedIndex = 0;
            skin2.SelectedIndex = 0;
            Choixperso3.SelectedIndex = 0;
            empl3.SelectedIndex = 0;
            skin3.SelectedIndex = 0;
            Choixperso4.SelectedIndex = 0;
            empl4.SelectedIndex = 0;
            skin4.SelectedIndex = 0;
        }









        private void Choixperso4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choixperso4.SelectedIndex.ToString() == "0")
            {
                // emplacement skin jeu

                string[] rayman = { };
                empl4.Items.Clear();
                empl4.Items.AddRange(rayman);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso

                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\RaymanT");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);

            }
            else if (Choixperso4.SelectedIndex.ToString() == "1")
            {
                // emplacement skin jeu

                string[] Razor = { };
                empl4.Items.Clear();
                empl4.Items.AddRange(Razor);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso

                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razor");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);

            }
            else if (Choixperso4.SelectedIndex.ToString() == "2")
            {
                // emplacement skin jeu

                string[] Razorwife = { };
                empl4.Items.Clear();
                empl4.Items.AddRange(Razorwife);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso

                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Razorwife");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);

            }
            else if (Choixperso4.SelectedIndex.ToString() == "3")
            {
                // emplacement skin jeu

                string[] globox = { "2", "3", "4" };
                empl4.Items.Clear();
                empl4.Items.AddRange(globox);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso
                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\globox");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);

            }
            else if (Choixperso4.SelectedIndex.ToString() == "4")
            {
                // emplacement skin jeu


                string[] Hunchman = { "2", "3", "4" };
                empl4.Items.Clear();
                empl4.Items.AddRange(Hunchman);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso
                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);
            }
            else if (Choixperso4.SelectedIndex.ToString() == "5")
            {
                // emplacement skin jeu
                string[] ptizetre = { "2", "3", "4" };
                empl4.Items.Clear();
                empl4.Items.AddRange(ptizetre);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;



                //skin perso
                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Teensies");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);
            }
            else if (Choixperso4.SelectedIndex.ToString() == "6")
            {
                // emplacement skin jeu
                string[] Tily = { };
                empl4.Items.Clear();
                empl4.Items.AddRange(Tily);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso
                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Tily");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);
            }

            else if (Choixperso4.SelectedIndex.ToString() == "7")
            {


                string[] Hucman1000 = { "2", "3", "4" };
                empl4.Items.Clear();
                empl4.Items.AddRange(Hucman1000);
                empl4.Text = "1";
                empl4.Items.Insert(0, "1");
                empl4.SelectedIndex = 0;

                //skin perso

                skin4.Items.Clear();
                skin4.Items.Insert(0, "Original");
                skin4.SelectedIndex = 0;

                DirectoryInfo di = new DirectoryInfo(@"fils\texture\customskin\Henchman1000");
                DirectoryInfo[] diArr = di.GetDirectories();
                foreach (DirectoryInfo dri in diArr)
                    skin4.Items.Add(dri.Name);



            }



        }






        private async void btnValidskin1_Click(object sender, EventArgs e)
        {
            string testdoublonskin;

            //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena.exe");
            // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x9.exe");
            // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x10.exe");
            // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena21x9.exe");

            string[] processNames = { "R_Arena.exe", "R_Arena16x9.exe", "R_Arena16x10.exe", "R_Arena21x9.exe" };

            foreach (string processName in processNames)
            {
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (Process process in processes)
                {
                    try
                    {
                        process.CloseMainWindow();
                        process.WaitForExit(5000); // Attends 5 secondes pour la fermeture
                        if (!process.HasExited)
                        {
                            process.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de la fermeture de {processName}: {ex.Message}");
                    }
                }
            }

                    testdoublonskin = (Doublonskin("1", Choixperso1.SelectedIndex.ToString(), empl1.SelectedIndex.ToString(), skin1.SelectedIndex.ToString()));


            if (testdoublonskin == "oui")
            {

                string NomskinCustome = skin1.Text.ToString();
                Hide();

                Form3 form3 = new Form3();
                form3.Show();






                //reinisialisation de l'ancien skin avant de mettre un nouveau
                await Task.Run(() =>
                {
                    MajPerso("1", Nomjoueur1, emplacementjoueur1, "0");
                });


                if (Choixperso1.SelectedIndex.ToString() == "0")
                {







                    if (skin1.SelectedIndex == 0)
                    {
                        if (empl1.SelectedIndex.ToString() == "0")
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "rayman", "0", "0");

                            });

                        }



                    }
                    else
                    {



                        await Task.Run(() =>
                        {

                            MajPerso("1", "rayman", "0", NomskinCustome);

                        });

                    }
                }

                //choix razor
                if (Choixperso1.SelectedIndex.ToString() == "1")
                {

                    if (skin1.SelectedIndex == 0)
                    {
                        if (empl1.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("1", "razor", "0", "0");
                            });

                        }

                    }
                    else
                    {
                        await Task.Run(() =>
                        {

                            MajPerso("1", "razor", "0", NomskinCustome);

                        });
                    }
                }

                //choix razorwife
                if (Choixperso1.SelectedIndex.ToString() == "2")
                {

                    if (skin1.SelectedIndex == 0)
                    {
                        if (empl1.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("1", "razorwife", "0", "0");

                            });
                        }

                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            MajPerso("1", "razorwife", "0", NomskinCustome);

                        });
                    }

                }
                //choix globox
                if (Choixperso1.SelectedIndex.ToString() == "3")
                {

                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "0", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "0", NomskinCustome);

                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "1", "0");

                            });

                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "1", NomskinCustome);

                            });
                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "2", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "2", NomskinCustome);
                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("1", "globox", "3", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "3", NomskinCustome);

                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "4")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "globox", "4", NomskinCustome);
                            });
                        }
                    }



                }
                //choix huchman
                if (Choixperso1.SelectedIndex.ToString() == "4")
                {

                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("1", "huchman", "0", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "0", NomskinCustome);
                            });


                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "1", NomskinCustome);
                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "2", NomskinCustome);
                            });


                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "3", NomskinCustome);
                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "4")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huchman", "4", NomskinCustome);
                            });

                        }
                    }

                }
                //choix ptizetre
                if (Choixperso1.SelectedIndex.ToString() == "5")
                {

                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "0", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "1", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("1", "ptizetre", "3", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "4")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "ptizetre", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("1", "ptizetre", "4", NomskinCustome);
                            });
                        }

                    }
                }

                //choix tily
                if (Choixperso1.SelectedIndex.ToString() == "6")
                {

                    if (skin1.SelectedIndex == 0)
                    {
                        if (empl1.SelectedIndex.ToString() == "0")
                        {
                            MajPerso("1", "tily", "0", "0");
                        }

                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            MajPerso("1", "tily", "0", NomskinCustome);
                        });
                    }

                }

                // hunchman 1000
                if (Choixperso1.SelectedIndex.ToString() == "7")
                {

                    if (empl1.SelectedIndex.ToString() == "0")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "0", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "1")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "1", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "2")
                    {
                        if (skin1.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl1.SelectedIndex.ToString() == "3")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("1", "huch10000", "3", NomskinCustome);
                            });
                        }

                    }

                    else if (empl1.SelectedIndex.ToString() == "4")
                    {
                        if (skin1.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("1", "huch10000", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("1", "huch10000", "4", NomskinCustome);
                            });
                        }

                    }

                }







                form3.Close(); // ferme la fenetre d'attente
                acceuil acceuil = new acceuil();  // appel la fentre acceuil
                MajXML();
                lecturexml();
                majselectjoueur();
                majselectjoueurencour();
                acceuil.Show(); // rafiche le luncher



            }
            else {

                MessageBox.Show(skindoublon);

            }


        }



        private async void btnValidskin2_Click(object sender, EventArgs e)
        {
            string testdoublonskin;
            testdoublonskin = (Doublonskin("2", Choixperso2.SelectedIndex.ToString(), empl2.SelectedIndex.ToString(), skin2.SelectedIndex.ToString()));

            if (testdoublonskin == "oui")
            {


                string[] processNames = { "R_Arena.exe", "R_Arena16x9.exe", "R_Arena16x10.exe", "R_Arena21x9.exe" };

                foreach (string processName in processNames)
                {
                    Process[] processes = Process.GetProcessesByName(processName);

                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.CloseMainWindow();
                            process.WaitForExit(5000); // Attends 5 secondes pour la fermeture
                            if (!process.HasExited)
                            {
                                process.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur lors de la fermeture de {processName}: {ex.Message}");
                        }
                    }
                }
            

               // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x9.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x10.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena21x9.exe");



                string NomskinCustome = skin2.Text.ToString();

                Hide();

                Form3 form3 = new Form3();
                form3.Show();
                //reinisialisation de l'ancien skin avant de mettre un nouveau

                await Task.Run(() =>
                {
                    MajPerso("2", Nomjoueur2, emplacementjoueur2, "0");
                });

                if (Choixperso2.SelectedIndex.ToString() == "0")
                {

                    if (skin2.SelectedIndex == 0)
                    {
                        if (empl2.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "rayman", "0", "0");
                            });
                        }

                    }
                    else {

                        await Task.Run(() =>
                        {

                            MajPerso("2", "rayman", "0", NomskinCustome);
                        });

                    }
                }

                //choix razor
                if (Choixperso2.SelectedIndex.ToString() == "1")
                {

                    if (skin2.SelectedIndex == 0)
                    {
                        if (empl2.SelectedIndex.ToString() == "0")
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "razor", "0", "0");
                            });

                        }

                    }
                    else {



                        await Task.Run(() =>
                        {

                            MajPerso("2", "razor", "0", NomskinCustome);
                        });


                    }
                }

                //choix razorwife
                if (Choixperso2.SelectedIndex.ToString() == "2")
                {

                    if (skin2.SelectedIndex == 0)
                    {
                        if (empl2.SelectedIndex.ToString() == "0")
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "razorwife", "0", "0");
                            });
                        }

                    }
                    else {


                        await Task.Run(() =>
                        {

                            MajPerso("2", "razorwife", "0", NomskinCustome);

                        });

                    }

                }
                //choix globox
                if (Choixperso2.SelectedIndex.ToString() == "3")
                {

                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "0", "0");
                            });

                        }
                        else {


                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "0", NomskinCustome);

                            });

                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "globox", "1", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "1", NomskinCustome);

                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "2", "0");

                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "3", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "3", NomskinCustome);
                            });


                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "4")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "globox", "4", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "globox", "4", NomskinCustome);

                            });

                        }
                    }



                }
                //choix huchman
                if (Choixperso2.SelectedIndex.ToString() == "4")
                {

                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "huchman", "0", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "0", NomskinCustome);

                            });
                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "1", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "1", NomskinCustome);
                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "2", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "2", NomskinCustome);
                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "huchman", "3", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "3", NomskinCustome);
                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "4")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("2", "huchman", "4", "0");

                            });


                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "huchman", "4", NomskinCustome);
                            });

                        }
                    }

                }
                //choix ptizetre
                if (Choixperso2.SelectedIndex.ToString() == "5")
                {

                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "0", "0");
                            });
                        }
                        else {


                            await Task.Run(() =>
                            {

                                MajPerso("2", "ptizetre", "0", NomskinCustome);
                            });

                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        if (skin2.SelectedIndex == 0)
                        {


                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "1", "0");
                            });



                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "1", NomskinCustome);

                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "2", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "2", NomskinCustome);
                            });


                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "3", "0");
                            });



                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "3", NomskinCustome);
                            });


                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "4")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "ptizetre", "3", "0");
                            });


                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "ptizetre", "3", NomskinCustome);
                            });


                        }
                    }
                }

                //choix tily
                if (Choixperso2.SelectedIndex.ToString() == "6")
                {

                    if (skin2.SelectedIndex == 0)
                    {
                        if (empl2.SelectedIndex.ToString() == "0")
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "tily", "0", "0");

                            });

                        }

                    }
                    else {

                        await Task.Run(() =>
                        {

                            MajPerso("2", "tily", "0", NomskinCustome);

                        });


                    }

                }




                //hucman 1000
                if (Choixperso2.SelectedIndex.ToString() == "7")
                {





                    if (empl2.SelectedIndex.ToString() == "0")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "0", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "1")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "1", NomskinCustome);
                            });
                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "2")
                    {
                        if (skin2.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                //MessageBox.Show(Nomjoueur2);
                                MajPerso("2", "huch10000", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl2.SelectedIndex.ToString() == "3")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huch10000", "3", NomskinCustome);
                            });
                        }

                    }

                    else if (empl2.SelectedIndex.ToString() == "4")
                    {
                        if (skin2.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("2", "huch10000", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("2", "huch10000", "4", NomskinCustome);
                            });
                        }

                    }

                }















                MajXML();


                form3.Close(); // ferme la fenetre d'attente
                acceuil acceuil = new acceuil();  // appel la fentre acceuil
                acceuil.Show(); // rafiche le luncher


            }
            else
            {

                MessageBox.Show(skindoublon);

            }


        }

        private async void btnValidskin3_Click(object sender, EventArgs e)
        {

            string testdoublonskin;

            testdoublonskin = (Doublonskin("3", Choixperso3.SelectedIndex.ToString(), empl3.SelectedIndex.ToString(), skin3.SelectedIndex.ToString()));

            if (testdoublonskin == "oui")
            {


                string[] processNames = { "R_Arena.exe", "R_Arena16x9.exe", "R_Arena16x10.exe", "R_Arena21x9.exe" };

                foreach (string processName in processNames)
                {
                    Process[] processes = Process.GetProcessesByName(processName);

                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.CloseMainWindow();
                            process.WaitForExit(5000); // Attends 5 secondes pour la fermeture
                            if (!process.HasExited)
                            {
                                process.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur lors de la fermeture de {processName}: {ex.Message}");
                        }
                    }
                }

               // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x9.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x10.exe");
               //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena21x9.exe");


                string NomskinCustome = skin3.Text.ToString();


                Hide();

                Form3 form3 = new Form3();
                form3.Show();
                //reinisialisation de l'ancien skin avant de mettre un nouveau

                await Task.Run(() =>
                {
                    MajPerso("3", Nomjoueur3, emplacementjoueur3, "0");
                });

                if (Choixperso3.SelectedIndex.ToString() == "0")
                {

                    if (skin3.SelectedIndex == 0)
                    {
                        if (empl3.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "rayman", "0", "0");
                            });
                        }

                    }
                    else {

                        await Task.Run(() =>
                        {
                            MajPerso("3", "rayman", "0", NomskinCustome);
                        });

                    }
                }

                //choix razor
                if (Choixperso3.SelectedIndex.ToString() == "1")
                {

                    if (skin3.SelectedIndex == 0)
                    {
                        if (empl3.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "razor", "0", "0");
                            });
                        }

                    }
                    else {

                        await Task.Run(() =>
                        {

                            MajPerso("3", "razor", "0", NomskinCustome);
                        });

                    }
                }

                //choix razorwife
                if (Choixperso3.SelectedIndex.ToString() == "2")
                {

                    if (skin3.SelectedIndex == 0)
                    {
                        if (empl3.SelectedIndex.ToString() == "0")
                        {


                            await Task.Run(() =>
                            {

                                MajPerso("3", "razorwife", "0", "0");
                            });

                        }

                    }
                    else {


                        await Task.Run(() =>
                        {

                            MajPerso("3", "razorwife", "0", NomskinCustome);

                        });

                    }

                }
                //choix globox
                if (Choixperso3.SelectedIndex.ToString() == "3")
                {

                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "globox", "0", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "0", NomskinCustome);
                            });
                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "1", "0");
                            });

                        }
                        else {


                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "1", NomskinCustome);
                            });


                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "globox", "2", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "2", NomskinCustome);

                            });
                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "globox", "3", "0");

                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "3", NomskinCustome);

                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "4")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {

                                MajPerso("3", "globox", "4", "0");

                            });

                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("3", "globox", "4", NomskinCustome);

                            });

                        }
                    }



                }
                //choix huchman
                if (Choixperso3.SelectedIndex.ToString() == "4")
                {

                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "0", "0");
                            });
                        }
                        else {
                            await Task.Run(() =>
                            {

                                MajPerso("3", "huchman", "0", NomskinCustome);

                            });
                        }

                    }

                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "1", "0");

                            });
                        }
                        else {



                            await Task.Run(() =>
                            {

                                MajPerso("3", "huchman", "1", NomskinCustome);
                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "2", "0");

                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "huchman", "2", NomskinCustome);


                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "3", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "huchman", "3", NomskinCustome);

                            });
                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "4")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "4", "0");
                            });

                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("3", "huchman", "4", NomskinCustome);

                            });
                        }
                    }

                }
                //choix ptizetre
                if (Choixperso3.SelectedIndex.ToString() == "5")
                {

                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "0", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "ptizetre", "0", NomskinCustome);
                            });

                        }

                    }

                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "1", "0");
                            });

                        }
                        else {
                            await Task.Run(() =>
                            {

                                MajPerso("3", "ptizetre", "1", NomskinCustome);
                            });
                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "2", "0");
                            });
                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "2", NomskinCustome);
                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "3", "0");

                            });

                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "3", NomskinCustome);
                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "4")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "4", "0");
                            });
                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("3", "ptizetre", "4", NomskinCustome);
                            });


                        }
                    }
                }

                //choix tily
                if (Choixperso3.SelectedIndex.ToString() == "6")
                {

                    if (skin3.SelectedIndex == 0)
                    {
                        if (empl3.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "tily", "0", "0");
                            });
                        }

                    }
                    else {
                        await Task.Run(() =>
                        {
                            MajPerso("3", "tily", "0", NomskinCustome);

                        });
                    }

                }


                if (Choixperso3.SelectedIndex.ToString() == "7")
                {

                    if (empl3.SelectedIndex.ToString() == "0")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "0", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl3.SelectedIndex.ToString() == "1")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "1", NomskinCustome);
                            });
                        }

                    }

                    else if (empl3.SelectedIndex.ToString() == "2")
                    {
                        if (skin3.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl3.SelectedIndex.ToString() == "3")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "huch10000", "3", NomskinCustome);
                            });
                        }

                    }

                    else if (empl3.SelectedIndex.ToString() == "4")
                    {
                        if (skin3.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("3", "huch10000", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("3", "huch10000", "4", NomskinCustome);
                            });
                        }

                    }

                }


                MajXML();


                form3.Close(); // ferme la fenetre d'attente
                acceuil acceuil = new acceuil();  // appel la fentre acceuil
                acceuil.Show(); // rafiche le luncher


            }
            else
            {

                MessageBox.Show(skindoublon);

            }


        }

        private async void btnValidskin4_Click(object sender, EventArgs e)
        {

            string testdoublonskin;

            testdoublonskin = (Doublonskin("4", Choixperso4.SelectedIndex.ToString(), empl4.SelectedIndex.ToString(), skin4.SelectedIndex.ToString()));

            if (testdoublonskin == "oui")
            {


                // System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena.exe");
                //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x9.exe");
                //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena16x10.exe");
                //System.Diagnostics.Process.Start("cmd", @"/c taskkill /IM R_Arena21x9.exe");

                string[] processNames = { "R_Arena.exe", "R_Arena16x9.exe", "R_Arena16x10.exe", "R_Arena21x9.exe" };

                foreach (string processName in processNames)
                {
                    Process[] processes = Process.GetProcessesByName(processName);

                    foreach (Process process in processes)
                    {
                        try
                        {
                            process.CloseMainWindow();
                            process.WaitForExit(5000); // Attends 5 secondes pour la fermeture
                            if (!process.HasExited)
                            {
                                process.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur lors de la fermeture de {processName}: {ex.Message}");
                        }
                    }
                }
            












                string NomskinCustome = skin4.Text.ToString();

                Hide();

                Form3 form3 = new Form3();
                form3.Show();
                //reinisialisation de l'ancien skin avant de mettre un nouveau
                await Task.Run(() =>
                {
                    MajPerso("4", Nomjoueur4, emplacementjoueur4, "0");
                });

                if (Choixperso4.SelectedIndex.ToString() == "0")
                {

                    if (skin4.SelectedIndex == 0)
                    {
                        if (empl4.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "rayman", "0", "0");
                            });
                        }

                    }
                    else {


                        await Task.Run(() =>
                        {
                            MajPerso("4", "rayman", "0", NomskinCustome);
                        });

                    }
                }

                //choix razor
                if (Choixperso4.SelectedIndex.ToString() == "1")
                {

                    if (skin4.SelectedIndex == 0)
                    {
                        if (empl4.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "razor", "0", "0");

                            });

                        }

                    }
                    else {

                        await Task.Run(() =>
                        {
                            MajPerso("4", "razor", "0", NomskinCustome);
                        });

                    }
                }

                //choix razorwife
                if (Choixperso4.SelectedIndex.ToString() == "2")
                {

                    if (skin4.SelectedIndex == 0)
                    {
                        if (empl4.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "razorwife", "0", "0");
                            });

                        }

                    }
                    else {
                        await Task.Run(() =>
                        {
                            MajPerso("4", "razorwife", "0", NomskinCustome);

                        });

                    }

                }
                //choix globox
                if (Choixperso4.SelectedIndex.ToString() == "3")
                {

                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "0", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "0", NomskinCustome);
                            });

                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "1", "0");
                            });


                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "1", NomskinCustome);
                            });


                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "2", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "2", NomskinCustome);
                            });
                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "3", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "3", NomskinCustome);

                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "4")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "globox", "4", "0");

                            });
                        }
                        else {
                            await Task.Run(() =>
                            {

                                MajPerso("4", "globox", "4", NomskinCustome);

                            });

                        }
                    }



                }
                //choix huchman
                if (Choixperso4.SelectedIndex.ToString() == "4")
                {

                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "0", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "0", NomskinCustome);

                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "1", "0");

                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "huchman", "1", NomskinCustome);

                            });
                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "2", "0");
                            });
                        }
                        else {
                            await Task.Run(() =>
                            {

                                MajPerso("4", "huchman", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "3", "0");

                            });

                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "3", NomskinCustome);

                            });
                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "4")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "4", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huchman", "4", NomskinCustome);
                            });

                        }
                    }

                }
                //choix ptizetre
                if (Choixperso4.SelectedIndex.ToString() == "5")
                {

                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "0", "0");
                            });

                        }
                        else {


                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "1", "0");

                            });


                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "ptizetre", "1", NomskinCustome);

                            });

                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "2", "0");

                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "ptizetre", "2", NomskinCustome);

                            });
                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "3", "0");
                            });

                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "ptizetre", "3", NomskinCustome);

                            });
                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "4")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "ptizetre", "4", "0");
                            });
                        }
                        else {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "ptizetre", "4", NomskinCustome);

                            });


                        }
                    }
                }

                //choix tily
                if (Choixperso4.SelectedIndex.ToString() == "6")
                {

                    if (skin4.SelectedIndex == 0)
                    {
                        if (empl4.SelectedIndex.ToString() == "0")
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "tily", "0", "0");
                            });
                        }

                    }
                    else {



                        await Task.Run(() =>
                        {
                            MajPerso("4", "tily", "0", NomskinCustome);
                        });

                    }

                }





                if (Choixperso4.SelectedIndex.ToString() == "7")
                {

                    if (empl4.SelectedIndex.ToString() == "0")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "0", "0");

                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "0", NomskinCustome);
                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "1")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "1", "0");
                            });
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "1", NomskinCustome);
                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "2")
                    {
                        if (skin4.SelectedIndex == 0)
                        {
                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "2", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "2", NomskinCustome);

                            });

                        }
                    }

                    else if (empl4.SelectedIndex.ToString() == "3")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "3", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "huch10000", "3", NomskinCustome);
                            });
                        }

                    }

                    else if (empl4.SelectedIndex.ToString() == "4")
                    {
                        if (skin4.SelectedIndex == 0)
                        {

                            await Task.Run(() =>
                            {
                                MajPerso("4", "huch10000", "4", "0");
                            });
                        }
                        else
                        {

                            await Task.Run(() =>
                            {

                                MajPerso("4", "huch10000", "4", NomskinCustome);
                            });
                        }

                    }

                }








                MajXML();


                form3.Close(); // ferme la fenetre d'attente
                acceuil acceuil = new acceuil();  // appel la fentre acceuil
                acceuil.Show(); // rafiche le luncher


            }
            else
            {

                MessageBox.Show(skindoublon);

            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/8uw93DNHnz");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/8uw93DNHnz");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/RaymanCommunity");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Process.Start("https://codepen.io/yaclive/pen/EayLYO");
            MessageBox.Show("we don't have an instagram account yet");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.reddit.com/user/RaymanArenaDiscord/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/user/pokemonfreakful");
        }

        private async void webView21_Click_2(object sender, EventArgs e)

        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }







        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        private void webView22_Click(object sender, EventArgs e)
        {

        }



        public class Adapters
        {
            public System.Collections.Generic.List<String> net_adapters()
            {
                List<String> values = new List<String>();
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {

                    values.Add(nic.Name);
                }
                return values;
            }
        }


        private void button16_Click_1(object sender, EventArgs e)
        {


            File.WriteAllText(cheminfichier, curItem);
            File.WriteAllText(cheminfichier2, curItem);
            MessageBox.Show(curItem + Choixcard);

            onlinetest();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem = comboBox1.SelectedItem.ToString();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\ProgramData\Caphyon\Advanced Installer\{7D1F742E-99DE-46EE-98AF-BAEAD9861FFF}\Rayman Arena The Definitive Edition Online.exe")) { Process.Start(@"C:\ProgramData\Caphyon\Advanced Installer\{7D1F742E-99DE-46EE-98AF-BAEAD9861FFF}\Rayman Arena The Definitive Edition Online.exe"); }
            else { MessageBox.Show("I can't find the uninstall file on the computer. Please uninstall it from control panel"); }
        }
        private void BtnNomReseau_Click(object sender, EventArgs e)
        {
            string BtnNomReseauString = BtnNomReseau.Text;
            Clipboard.SetText(BtnNomReseauString);
            MessageBox.Show(CopieNomReseau);
        }

        private void BtnMdpReseau_Click(object sender, EventArgs e)
        {
            string BtnMdpReseauString = BtnMdpReseau.Text;
            Clipboard.SetText(BtnMdpReseauString);
            MessageBox.Show(CopieMdpReseau);

        }

        private void empl3_SelectedIndexChanged(object sender, EventArgs e)
        {


            ModifImageskinUbi(3);



        }

        private void empl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifImageskinUbi(4);






        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            modifini(comboBox2.Text);

            ResoGame = comboBox2.SelectedIndex.ToString();
            MajXML();

        }

        private async void button21_Click(object sender, EventArgs e)
        {

            reinisiliatation(0);

        }

        private void label44_Click(object sender, EventArgs e)
        {


            if (checkBox1.Enabled == Enabled)
            {

                if (checkBox1.Checked == false)
                {

                    checkBox1.Checked = true;

                }
                else
                {

                    checkBox1.Checked = false;

                }
            }
            else {


                MessageBox.Show(ActivDesaSKINsdHD);

            }


        }

        private void SDRADIO_CheckedChanged(object sender, EventArgs e)
        {
            Gamehdsd = "0";


        }

        private void HDRADIO_CheckedChanged(object sender, EventArgs e)
        {
            Gamehdsd = "1";

        }

        private void button16_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(Gamehdsd);
            string longeur;
            string latgeur;
            string merde = comboBox2.Text;

            string[] subs = merde.Split(' ');

            foreach (var sub in subs)
            {
                Console.WriteLine(sub);
            }

            longeur = subs[0];
            latgeur = subs[2];

            if (Videomode == "1")
            {
                //  System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Intro.bik game\SD\Videos\Intro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Outro.bik game\SD\Videos\Outro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Ubi.bik game\SD\Videos\Ubi.bik");

                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Intro.bik game\HD\Videos\Intro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Outro.bik game\HD\Videos\Outro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\normal\Videos\Ubi.bik game\HD\Videos\Ubi.bik");

                string sourceFolderPath = Path.Combine("fils", "video", "normal", "Videos");

                string destinationSDFolderPath = Path.Combine("game", "SD", "Videos");
                File.Copy(Path.Combine(sourceFolderPath, "Intro.bik"), Path.Combine(destinationSDFolderPath, "Intro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Outro.bik"), Path.Combine(destinationSDFolderPath, "Outro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Ubi.bik"), Path.Combine(destinationSDFolderPath, "Ubi.bik"), true);

                if (VerifHdok == 0)
                {
                    string destinationHDFolderPath = Path.Combine("game", "HD", "Videos");
                    File.Copy(Path.Combine(sourceFolderPath, "Intro.bik"), Path.Combine(destinationHDFolderPath, "Intro.bik"), true);
                    File.Copy(Path.Combine(sourceFolderPath, "Outro.bik"), Path.Combine(destinationHDFolderPath, "Outro.bik"), true);
                    File.Copy(Path.Combine(sourceFolderPath, "Ubi.bik"), Path.Combine(destinationHDFolderPath, "Ubi.bik"), true);
                }
                Videomode = "3";
                MajXML();
            }
            else if (Videomode == "0") {

                //  System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Intro.bik game\SD\Videos\Intro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Outro.bik game\SD\Videos\Outro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Ubi.bik game\SD\Videos\Ubi.bik");

                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Intro.bik game\HD\Videos\Intro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Outro.bik game\HD\Videos\Outro.bik");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\video\vierge\Videos\Ubi.bik game\HD\Videos\Ubi.bik");

                string sourceFolderPath = "fils\\video\\vierge\\Videos";
                string destinationSDFolderPath = "game\\SD\\Videos";
                string destinationHDFolderPath = "game\\HD\\Videos";

                File.Copy(Path.Combine(sourceFolderPath, "Intro.bik"), Path.Combine(destinationSDFolderPath, "Intro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Outro.bik"), Path.Combine(destinationSDFolderPath, "Outro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Ubi.bik"), Path.Combine(destinationSDFolderPath, "Ubi.bik"), true);

                if (VerifHdok == 0)
                {
                    File.Copy(Path.Combine(sourceFolderPath, "Intro.bik"), Path.Combine(destinationHDFolderPath, "Intro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Outro.bik"), Path.Combine(destinationHDFolderPath, "Outro.bik"), true);
                File.Copy(Path.Combine(sourceFolderPath, "Ubi.bik"), Path.Combine(destinationHDFolderPath, "Ubi.bik"), true);
                }


                Videomode = "4";
                MajXML();

            }









            if (Screenmode == "0" || Screenmode == "2")
            {



                if (Gamehdsd == "0") // plein ecran hd ou sd
                {

                    modidgvoodo("FULL", longeur, latgeur);
                    LanseurRatio("SD");
                    //Application.Exit();
                    this.WindowState = FormWindowState.Minimized;

                }
                else
                {

                    modidgvoodo("FULL", longeur, latgeur);

                    LanseurRatio("HD");
                    //Application.Exit();
                    this.WindowState = FormWindowState.Minimized;

                }

            }


            if (Screenmode == "1" || Screenmode == "3") // mode fenetre
            {
                if (Screenmode == "1")
                {

                    modidgvoodo("WIN", longeur, latgeur);

                }


                if (Gamehdsd == "0")
                {

                    LanseurRatio("SD");

                }
                else if (Gamehdsd == "1")
                {
                    LanseurRatio("HD");
                }


                // Application.Exit();


            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OnGameIntro_CheckedChanged(object sender, EventArgs e)
        {
            Videomode = "1";


        }

        private void OffGameIntro_CheckedChanged(object sender, EventArgs e)
        {
            Videomode = "0";
        }

        private void FullScreen_CheckedChanged(object sender, EventArgs e)
        {
            Screenmode = "0";
        }

        private void Windowsscreen_CheckedChanged(object sender, EventArgs e)
        {
            Screenmode = "1";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Process.Start("https://www.radmin-vpn.com/");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("explorer.exe", string.Format(@"/select,fils\texture\customskin\RaymanT"));
            //skinazerotemp();

            if (Testconnexioninternet())
            {
                //Console.WriteLine("L'ordinateur est connecté à Internet.");
                addskin sw = new addskin();
                sw.Show();
            }
            else
            {
                MessageBox.Show(pasverifmaj);
                //Console.WriteLine("L'ordinateur n'est pas connecté à Internet.");
            }






        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://raymanarenaonline.eundilmako.com/addskin/");
            //MessageBox.Show("Hurry up KingEngine :) !!!");
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter_1(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0) { modifini("EN"); LangueGame = "0"; }//anglais
            else if (comboBox3.SelectedIndex == 1) { modifini("FR"); LangueGame = "1"; } //french

            else if (comboBox3.SelectedIndex == 2) { modifini("ES"); LangueGame = "2"; } //espagnol

            MajXML();
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\Ubisoft\ubi.ini");
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start(@"https://raymanarenaonline.eundilmako.com");
            MessageBox.Show("Hurry up KingEngine :) !!!");










        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Hurry up KingEngine :) !!!");
            verifmaj(1);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            modifini(comboBox2.Text);

            ResoGame = comboBox2.SelectedIndex.ToString();
            MajXML();
        }


        void FillScreenResolutions()
        {
            // Créer une requête WMI pour récupérer les résolutions d'écran
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM CIM_VideoControllerResolution");

            // Créer une liste pour stocker les résolutions uniques
            List<string> resolutions = new List<string>();

            // Parcourir toutes les résolutions d'écran prises en charge
            foreach (ManagementObject resolution in searcher.Get())
            {
                // Obtenir la largeur et la hauteur de la résolution
                int width = int.Parse(resolution["HorizontalResolution"].ToString());
                int height = int.Parse(resolution["VerticalResolution"].ToString());

                // Vérifier si la résolution est supérieure ou égale à 800x600 et si elle n'a pas déjà été ajoutée à la liste
                if (width >= 800 && height >= 600 && !resolutions.Contains(width + " x " + height))
                {
                    // Ajouter la résolution au format "Largeur x Hauteur"
                    resolutions.Add($"{width} x {height}");
                }
            }

            // Trier les résolutions numériquement
            resolutions.Sort((res1, res2) =>
            {
                int[] dimensions1 = res1.Split('x').Select(int.Parse).ToArray();
                int[] dimensions2 = res2.Split('x').Select(int.Parse).ToArray();

                // Comparer d'abord les largeurs, puis les hauteurs
                if (dimensions1[0] != dimensions2[0])
                    return dimensions1[0].CompareTo(dimensions2[0]);
                else
                    return dimensions1[1].CompareTo(dimensions2[1]);
            });

            // Ajouter les résolutions triées au ComboBox
            foreach (var resolution in resolutions)
            {
                comboBox2.Items.Add(resolution);
            }
        }






        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            Color col = e.Index == 0 ? Color.Aqua : Color.Yellow;
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void groupBox6_Enter_2(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://raymanarenaonline.eundilmako.com");

        }

        private void label19_Click_1(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (Manettevib != "3" | Manettevib != "2")
            {

                Manettevib = "2";
                MajXML();
                // System.Diagnostics.Process.Start("cmd", @"/c copy fils\basefile\manette\novib\dinput8.dll game\SD\dinput8.dll");
                //System.Diagnostics.Process.Start("cmd", @"/c copy fils\basefile\manette\novib\dinput8.dll game\HD\dinput8.dll");

                string sourceFilePath = Path.Combine("fils", "basefile", "manette", "novib", "dinput8.dll");
                string appDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                string sdDestinationFilePath = Path.Combine(appDirectoryPath, "game", "SD", "dinput8.dll");

                File.Copy(sourceFilePath, sdDestinationFilePath, true);

                if (VerifHdok == 0)
                {
                    string hdDestinationFilePath = Path.Combine(appDirectoryPath, "game", "HD", "dinput8.dll");
                    File.Copy(sourceFilePath, hdDestinationFilePath, true);
                }

                
              

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Manettevib != "4" | Manettevib != "0")
            {
                Manettevib = "0";
                MajXML();
                string sourceFilePath = Path.Combine("fils", "basefile", "manette", "vib", "dinput8.dll");
                string sdDestinationFilePath = Path.Combine("game", "SD", "dinput8.dll");
                if (VerifHdok == 0)
                {
                    string hdDestinationFilePath = Path.Combine("game", "HD", "dinput8.dll");
                }
               // System.Diagnostics.Process.Start("cmd", $"/c copy \"{sourceFilePath}\" \"{sdDestinationFilePath}\"");
                //System.Diagnostics.Process.Start("cmd", $"/c copy \"{sourceFilePath}\" \"{hdDestinationFilePath}\"");

            }
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void BETA_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void photoskin4_Click(object sender, EventArgs e)
        {

        }

        private void photoskin2_Click(object sender, EventArgs e)
        {

        }

        private void photoskin3_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label91_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }


     
















        // string m11 = "R_Arena.exe+0x0025C3CC,8C,18,FC,C,4,8,B44";
        // string m7 = "R_Arena.exe+0x050EAF68,94,14,0,18,4,F2C";
        //  string m5 = "R_Arena.exe+0x0025C3CC,8C,1B,FC,C,4,8,B44";
        // string m4 = "R_Arena.exe+0x003A9EB4,A0,1C,8,0,20,54,F80";
        // string m3 = "R_Arena.exe+0x003BCE00,9C,14,8C,18,220,88,ECC";






        async void brulage()
        {
            Mem meme = new Mem();


    
            string SelecteurArme = nomdelexe +"+0x003A9BDC,90,84,7C,8,1C8";





            Random aleatoire = new Random();



            while (checkBox2.Checked)
            {
                // MessageBox.Show("position 0");
                Thread.Sleep(2000);


                int arme = aleatoire.Next(1, 11); //Génère un entier compris entre 0 et 9
                string stringarme = arme.ToString();


                int PID = meme.GetProcIdFromName(nomdelexe);


                if (PID > 0)
                {




                    meme.OpenProcess(PID);
                    // timer1.Start();
                    meme.WriteMemory(SelecteurArme, "int", stringarme);


                    // TEST LECTURE variable

                    //int test = meme.ReadInt(SelecteurArme);
                   // string numString = test.ToString();
                    //MessageBox.Show(numString);



                }
                else { brulage(); }


    
            }
            meme.CloseProcess();
            if (!checkBox2.Checked) { return; }
        }




        async void brulage2(int postionjoueur)
        {
            Mem meme = new Mem();

            string SelecteurArme = nomdelexe + "+0x003A9BDC,90,84,7C,8,1C8";

            string a1 = nomdelexe + "+0x003A9984,2C,8C,0,2C,148,148,C";
            string a2 = nomdelexe + "+0x003A9B98,160,0,14,14,4,9C,F80";
            string a3 = nomdelexe + "+0x003BCE00,48,C,0,C,84,8C,B60";
            string a4 = nomdelexe + "+0x003A9EB4,A0,1C,8,0,20,54,F80";


            string m1 = nomdelexe + "+0x003A9BD8,2DC,4,C,30,150,148,10";
            string m2 = nomdelexe + "+0x003A9954,8C,18,504,14,14,24,F84";
            string m6 = nomdelexe + "+0x003A992C,24,68,8C,7DC";
            string m8 = nomdelexe + "+0x051E7690,20,90,33C,4,2C,EF8";
            string m9 = nomdelexe + "+0x003A9954,8C,18,504,14,14,24,F84";
            string m10 = nomdelexe + "+0x003A9EB0,14,94,74,0,4,4,F30";
            string m11 = nomdelexe + "+0x0025C3CC,84,74,18,140,48C,8C,B64";




            if (checkBox2.Checked)
            {

                //MessageBox.Show("position 1");
                Thread.Sleep(400);

                Random aleatoire = new Random();
                int feuoutableau = aleatoire.Next(1, 6); //Génère un entier compris entre 0 et 2

                int PID = meme.GetProcIdFromName(nomdelexe);


                if (PID > 0)
                {
                    

                    meme.OpenProcess(PID);

                    meme.WriteMemory(SelecteurArme, "int", "0");


                    int INTa1 = meme.ReadInt(a1);
                   // int INTa2 = meme.ReadInt(a2);
                  //  int INTa3 = meme.ReadInt(a3);
                  //  int INTa4 = meme.ReadInt(a4);



                    if (INTa1 == 7)
                    {

                        if (postionjoueur == 0)
                        {


                            if (feuoutableau >= 3)
                            {

                                meme.WriteMemory(a1, "int", "2");
                                meme.WriteMemory(m1, "int", "3");

                            }
                            else
                            {

                                piege();
                                void piege()
                                {
                                    INTa1 = meme.ReadInt(a1);
                                    // MessageBox.Show("tableau");
                                    Thread.Sleep(100);
                                    if (INTa1 != 7) { brulage2(postionjoueur); }
                                    else { piege(); }
                                }
                            }

                        }
                        if (postionjoueur == 1)
                        {

                            if (feuoutableau >= 3)
                            {

                                meme.WriteMemory(a1, "int", "2");
                                meme.WriteMemory(m6, "int", "3");

                            }
                            else
                            {

                                piege();
                                void piege()
                                {
                                    INTa1 = meme.ReadInt(a1);
                                    // MessageBox.Show("tableau");
                                    Thread.Sleep(100);
                                    if (INTa1 != 7) { brulage2(postionjoueur); }
                                    else { piege(); }
                                }
                            }

                        }
                    }

                  //  majvariable();


                }


                else { brulage2(postionjoueur); }


                meme.CloseProcess();

                if (!checkBox2.Checked) { return; }

                brulage2(postionjoueur);
            }


        }




        async void brulage3()
        {

            Mem meme = new Mem();



            string SelecteurArme = nomdelexe +"+0x003A9BDC,90,84,7C,8,1C8";

            Random aleatoire = new Random();

            while (checkBox2.Checked)
            {

                //MessageBox.Show("position 1");
                Thread.Sleep(5000);

  
                int feuoutableau = aleatoire.Next(1, 3); //Génère un entier compris entre 0 et 2

                int PID = meme.GetProcIdFromName(nomdelexe);




                if (PID > 0)
                {

                    meme.OpenProcess(PID);

                    meme.WriteMemory(SelecteurArme, "int", "0");


                    if (feuoutableau == 2)
                    {
                        meme.WriteMemory(SelecteurArme, "int", "2");
                        Thread.Sleep(4000);
                        meme.WriteMemory(SelecteurArme, "int", "0");
                        Thread.Sleep(8000);
                    }

                }
                else { brulage3(); }
            }
           

            meme.CloseProcess();

            if (!checkBox2.Checked) { return; }
            
            }


    



     /*   async void pouactualiservariable()
        {



            //MessageBox.Show("position 1");
            Thread.Sleep(3000);
                Random aleatoire = new Random();


                int arme = aleatoire.Next(1, 11); //Génère un entier compris entre 0 et 9
                string stringarme = arme.ToString();


                int PID = meme.GetProcIdFromName("R_Arena.exe");


                if (PID > 0)
                {


                    meme.OpenProcess(PID);


                    majvariable();


                }
                else { pouactualiservariable(); }






                pouactualiservariable();
            

        }
         void majvariable () {

            vm1.Invoke(new MethodInvoker(delegate
            {

                int INTm1 = meme.ReadInt(m1);
            string m1string = INTm1.ToString();
            vm1.Text = m1string;

            }));


            vm2.Invoke(new MethodInvoker(delegate
            {

                int INTm2 = meme.ReadInt(m2);
            string m2string = INTm2.ToString();
            vm2.Text = m2string;

            }));





            vm6.Invoke(new MethodInvoker(delegate
           {

                                int INTm6 = meme.ReadInt(m6);
            string m6string = INTm6.ToString();
            vm6.Text = m6string;

           }));



            vm10.Invoke(new MethodInvoker(delegate
            {
                int INTm10 = meme.ReadInt(m10);
                string m10string = INTm10.ToString();
                vm10.Text = m10string;

            }));

            vm11.Invoke(new MethodInvoker(delegate
            {
                int INTm11 = meme.ReadInt(m11);
                string m11string = INTm11.ToString();
                vm11.Text = m11string;

            }));




            va1.Invoke(new MethodInvoker(delegate
            {
                int INTa1 = meme.ReadInt(a1);
                string a1string = INTa1.ToString();
                va1.Text = a1string;

            }));
            va2.Invoke(new MethodInvoker(delegate
            {
                int INTa2 = meme.ReadInt(a2);
                string a2string = INTa2.ToString();
                va2.Text = a2string;

            }));
            va3.Invoke(new MethodInvoker(delegate
            {
                int INTa3 = meme.ReadInt(a3);
                string a3string = INTa3.ToString();
                va3.Text = a3string;

            }));
            va4.Invoke(new MethodInvoker(delegate
            {
                int INTa4 = meme.ReadInt(a4);
                string a4string = INTa4.ToString();
                va4.Text = a4string;

            }));


        }
       */



        async void selectionmoddig() {

   
                //pouactualiservariable();
         



            if (checkBox2.Checked)
            {

                {

                        if (comboBox4.SelectedIndex.ToString() == "0")

                    {
                        await Task.Run(() =>
                        {
                            brulage();
                        });

                        
                          


                            }
                              
               


                    else if (comboBox4.SelectedIndex.ToString() == "1")
                    {

                        int positiondujoueur = 99;

                        if (positionplayeur.SelectedIndex.ToString() == "0")
                        {
                            positiondujoueur = 0;
                            await Task.Run(() =>
                            {
                                brulage2(positiondujoueur);
                            });

                            
                          
                        }

                        if (positionplayeur.SelectedIndex.ToString() == "1")
                        {
                            positiondujoueur = 1;
                            await Task.Run(() =>
                            {
                                brulage2(positiondujoueur);
                            });
                            
                            
                        }



                        if (positiondujoueur == 99)
                        {
                            checkBox2.Invoke(new MethodInvoker(delegate
                            {
                                MessageBox.Show("You did not select the configuration of the game");
                                checkBox2.Checked = false;
                            }));
                        }





                    }

                    else if (comboBox4.SelectedIndex.ToString() == "2")
                    {
                        await Task.Run(() =>
                        {
                            brulage3();
                        });
                       
                    
                    }

                    else
                    {

                            checkBox2.Invoke(new MethodInvoker(delegate
                            {
                                MessageBox.Show("You did not select a mode");
                                checkBox2.Checked = false;
                            }));
                     
                    }
                   

                    }

            }
            
        }






        async private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            selectionmoddig();





        }
            private void timer1_Tick(object sender, EventArgs e)
       {            
        }

        async private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex.ToString() == "1")
            {
                positionplayeur.Visible = Enabled;
                typejoueur.Visible = Enabled;

            }
            else {

                positionplayeur.Visible = false;
                typejoueur.Visible = false;

            }

            if (checkBox2.Checked == true)  // si la case est cocher tu la décoche et recoche
            {
                checkBox2.Checked = false;
                Thread.Sleep(5000);
                checkBox2.Checked = true;

            }
           


        }

        private void positionplayeur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resoDetect_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (ButtonresoAuto.Checked == true)
            {

                ResoAuto = "1";
                MajXML();
                ActivationResoAuto();

            }
            else {

                ResoAuto = "0";
                MajXML();
                ActivationResoAuto();


            }
        }

        private void ouvertureform4_Click(object sender, EventArgs e)
        {

            // Cacher la fenêtre principale (Form1)
            this.Hide();

            // Créer une nouvelle instance de la deuxième fenêtre (Form2)
            Form4 form4 = new Form4();
            form4.StartPosition = FormStartPosition.CenterScreen; // Centre la nouvelle fenêtre sur l'écran

            // Associer le gestionnaire d'événements FormClosed
            form4.FormClosed += Form4_FormClosed;

            // Afficher la deuxième fenêtre (Form2)
            form4.Show();

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Afficher à nouveau la fenêtre principale (Form1) lors de la fermeture de la deuxième fenêtre (Form2)
            this.Show();
        }


        public void langageautomatique()
        {
            if (langueautomatique.Checked == true) {

                CultureInfo culture = CultureInfo.InstalledUICulture;
                string langueUtilisateur = culture.TwoLetterISOLanguageName; // Obtient le code de langue (ex: "en", "fr", "es", "ru")

                switch (langueUtilisateur)
                {
                    case "en":
                        // Langue anglaise
                        changelangue.SelectedIndex = 0;
                        break;
                    case "fr":
                        // Langue française
                        changelangue.SelectedIndex = 1;
                        break;
                    case "es":
                        // Langue espagnole
                        changelangue.SelectedIndex = 2;
                        break;
                    case "ru":
                        // Langue russe
                        changelangue.SelectedIndex = 3;
                        break;
                    // Ajoutez d'autres cas pour gérer d'autres langues au besoin
                    default:
                        changelangue.SelectedIndex = 0;
                        break;
                }

            }
        }

        private void langueautomatique_CheckedChanged(object sender, EventArgs e)
        {
    
              if (langueautomatique.Checked == true)
            {

                Langueauto = "1";
                MajXML();
                langageautomatique();

            }
            else
            {

                Langueauto = "0";
                MajXML();
                langageautomatique();


            }
        }

        private void Reinisialiastaion_Click(object sender, EventArgs e)
        {
           
            string cheminFichierARemove = Path.Combine(Application.StartupPath, "Root.xml");

            

            if (File.Exists(cheminFichierARemove))
            {
                try
                {
                    File.Delete(cheminFichierARemove);
                    //  MessageBox.Show("Le fichier root.xml a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la suppression du fichier : " + ex.Message, "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //  MessageBox.Show("Le fichier root.xml n'existe pas à cet emplacement.", "Fichier introuvable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


           


           cheminFichierARemove = @"C:\Windows\Ubisoft\ubi.ini";

            if (File.Exists(cheminFichierARemove))
            {
                    try
                {
                    File.Delete(cheminFichierARemove);
                     // MessageBox.Show("Le fichier ubi.ini a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la suppression du fichier : " + ex.Message, "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                  MessageBox.Show("Le fichier ubi.ini n'existe pas à cet emplacement.", "Fichier introuvable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Restart();
            Environment.Exit(0); // Termine le processus actuel de l'application

        }








            public void MajRadminServeurName()
        {
            try
            {
                // Charger le fichier XML depuis l'URL
                XmlDocument monfichier = new XmlDocument();
                monfichier.Load("https://raymanarenaonline.eundilmako.com/skin/voirservradmin.php");

                // Sélectionner tous les éléments "serveur" dans le XML
                XmlNodeList serveurs = monfichier.SelectNodes("//serveur");

                // Assurez-vous qu'il y a au moins un élément "serveur" dans le XML
                if (serveurs.Count > 0)
                {
                    // Prendre le premier serveur (à adapter si vous avez plusieurs serveurs)
                    XmlNode serveur = serveurs[0];

                    // Récupérer le nom du serveur
                    XmlNode nomNode = serveur.SelectSingleNode("nom");
                    string nomString = nomNode.InnerText;

                    // Récupérer le mot de passe du serveur
                    XmlNode mdpradminNode = serveur.SelectSingleNode("mdp");
                    string mdpradminString = mdpradminNode.InnerText;

                    // Mettre à jour les boutons avec les valeurs récupérées
                    BtnNomReseau.Text = nomString;
                    BtnMdpReseau.Text = mdpradminString;
                }
                else
                {
                    // Gérer le cas où aucun serveur n'est trouvé dans le XML
                    // (vous pouvez afficher un message d'erreur, par exemple)
                    MessageBox.Show("Aucun serveur trouvé dans le XML.");
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception (par exemple, afficher un message d'erreur)
                MessageBox.Show($"Erreur lors du chargement du fichier XML : {ex.Message}");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string BtnNomReseauString = BtnNomReseau.Text;
            Clipboard.SetText(BtnNomReseauString);
            MessageBox.Show(CopieNomReseau);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string BtnMdpReseauString = BtnMdpReseau.Text;
            Clipboard.SetText(BtnMdpReseauString);
            MessageBox.Show(CopieMdpReseau);
        }
    }
}
