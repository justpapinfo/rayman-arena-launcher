using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace luncher_rayman_aréna
{




    public partial class Form4 : Form
    {
        string chemintrelatiffichier = @"game\SD\";

        string MessageErreurproduit ;

        string MessageDossierIntrouvable ;

        string MessageSuppHDAnnul ;

        string MessageSuppHDOk ;

        string MessageSurDeDecohHd;

        string MessageConfirmation;

        string MessageAvertissementHdNonDL;

        string MessageErreurDL;

        string MessageErreurDLEtDecompressOk;

        string MessageDecompressErreur;

        string MessageTelEnCour ;

        string passuffespace2go ="";
        string passuffespace6go;


        public Form4()
        {

            InitializeComponent();
            choixlangue();

            string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
            string cheminRepertoirePourTestDossier = @"game\SD\"; // Remplace avec le chemin relatif de ton répertoire

            // Obtient le chemin complet du fichier dans le répertoire spécifié
            string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);


            if (!File.Exists(cheminFichierTestDemarrageLanceur))
            {
                //si pas     de jeux dans SD
                //
                BoutonValidaton.Visible = false;


            }
            else
            {
                // si oui
                BoutonValidaton.Visible = true;
            }

            cheminRepertoirePourTestDossier = @"game\HD\"; // Remplace avec le chemin relatif de ton répertoire
            cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);

            if (!File.Exists(cheminFichierTestDemarrageLanceur))
            {

            }
            else
            {
                CaseHDVersion.Checked = true;
                //MessageBox.Show("test");
                // si oui

            }

        }




        public void MettreAJourLabel(string texte)
        {
            this.LabMessageTel.Text = texte;
        }



        private void button1_Click(object sender, EventArgs e)
        {


            string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
            string cheminRepertoirePourTestDossier = @"game\SD\";
            string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);


            if (!File.Exists(cheminFichierTestDemarrageLanceur))
            {
                Application.Exit(); // Ferme l'application
            }
            else
            {

                this.Close(); // Ferme la fenêtre actuelle

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
            string cheminRepertoirePourTestDossier = @"game\HD\";
            string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);

            if (CaseHDVersion.Checked)
            {

                if (!File.Exists(cheminFichierTestDemarrageLanceur))
                {
                    MessageBox.Show(MessageAvertissementHdNonDL);
                }
                else
                {
                    Application.Restart();
                    Environment.Exit(0); // Termine le processus actuel de l'application

                }


            }
            else
            {


                if (File.Exists(cheminFichierTestDemarrageLanceur))
                {

                    try
                    {
                        if (Directory.Exists(cheminRepertoirePourTestDossier))
                        {
                            DialogResult confirmation = MessageBox.Show(MessageSurDeDecohHd, MessageConfirmation, MessageBoxButtons.YesNo);

                            if (confirmation == DialogResult.Yes)
                            {
                                DirectoryInfo di = new DirectoryInfo(cheminRepertoirePourTestDossier);
                                foreach (FileInfo fichier in di.GetFiles())
                                {
                                    fichier.Delete();
                                }

                                foreach (DirectoryInfo sousDossier in di.GetDirectories())
                                {
                                    sousDossier.Delete(true);
                                }

                                Directory.CreateDirectory(cheminRepertoirePourTestDossier);
                                MessageBox.Show(MessageSuppHDOk);
                            }
                            else
                            {
                                MessageBox.Show(MessageSuppHDAnnul);
                            }
                        }
                        else
                        {
                            MessageBox.Show(MessageDossierIntrouvable);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(MessageErreurproduit + ex.Message);
                    }
                }











                Application.Restart();
                Environment.Exit(0); // Termine le processus actuel de l'application

            }

            
        }



        private void BoutonTelchargement_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LabMessageTel.Visible = true;
            progressBar1.Visible = true;


            GestionFichierZIP gestionnaireFichierZIP = new GestionFichierZIP(this);
            gestionnaireFichierZIP.Avantdl();
            
        }

        public class GestionFichierZIP
        {
            private Form4 _form4;
            private string _sousDossierDestination;
            private string cheminfichier = @"";


            public GestionFichierZIP(Form4 form)
            {
                _form4 = form;
            }

            public void TelechargerEtDecompresser(string urlDuFichierZip, string cheminDossierDestination)
            {
                
                WebClient webClient = new WebClient();

                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                webClient.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error != null)
                    {
                        _form4.Invoke((MethodInvoker)delegate
                        {
                            _form4.LabMessageTel.Text = _form4.MessageErreurDL + e.Error.Message;
                        });
                    }
                    else
                    {
                        try
                        {
                            string fichierTemporaire = Path.Combine(cheminDossierDestination, "fichier_temporaire.zip");

                            // Décompressez le fichier temporaire dans le dossier de destination
                            ZipFile.ExtractToDirectory(fichierTemporaire, cheminDossierDestination);
                            File.Delete(fichierTemporaire); // Supprimez le fichier temporaire après la décompression

                            _form4.Invoke((MethodInvoker)delegate
                            {
                                _form4.LabMessageTel.Text = _form4.MessageErreurDLEtDecompressOk;

                                //_form4.BoutonValidaton.Visible = true;

                            });
                        }
                        catch (Exception ex)
                        {
                            _form4.Invoke((MethodInvoker)delegate
                            {
                                _form4.LabMessageTel.Text = _form4.MessageDecompressErreur + ex.Message;
                            });
                        }
                    }
                };

                try
                {
                    _form4.Invoke((MethodInvoker)delegate
                    {
                        _form4.LabMessageTel.Text = _form4.MessageTelEnCour;
                        _form4.progressBar1.Visible = true;
                    });

                    string fichierTemporaire = Path.Combine(cheminDossierDestination, "fichier_temporaire.zip");
                    webClient.DownloadFileAsync(new Uri(urlDuFichierZip), fichierTemporaire);
                }
                catch (Exception ex)
                {
                    _form4.Invoke((MethodInvoker)delegate
                    {
                        _form4.LabMessageTel.Text = _form4.MessageErreurDL + ex.Message;
                    });
                }
               
            }

            private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                _form4.Invoke((MethodInvoker)delegate
                {
                    _form4.progressBar1.Value = e.ProgressPercentage;
                    if (_form4.progressBar1.Value == 100)
                    {

                        _form4.BoutonValidaton.Visible = true;

                    }

                    if (_form4.progressBar1.Value == 1)
                    {

                        _form4.BoutonValidaton.Visible = false;

                    }


                });
            }






            public bool VerifTailleDispoDisque(long tailleFichierAtelecharger)
            {
                string lecteurApplication = Path.GetPathRoot(Application.StartupPath);
                DriveInfo driveInfo = new DriveInfo(lecteurApplication);

                if (driveInfo.IsReady)
                {
                    long espaceLibre = driveInfo.AvailableFreeSpace;

                    if (espaceLibre >= tailleFichierAtelecharger)
                    {
                        //MessageBox.Show(_form4.passuffespace2go);
                        return true; // Il y a suffisamment d'espace disponible
                    }
                    else
                    {
                        MessageBox.Show("Il n'y a pas assez d'espace disponible pour télécharger le fichier de 2 Go.");
                        return false; // Il n'y a pas assez d'espace disponible
                    }
                }
                else
                {
                    MessageBox.Show("Le lecteur spécifié n'est pas prêt ou n'existe pas.");
                    return false; // Le lecteur n'est pas prêt ou n'existe pas
                }
            }




            public void Avantdl()
            {
                _form4.BoutonValidaton.Visible = false;

                string FichierSDJeuxPourTestDossier = "R_Arena.exe"; // Remplace avec le nom de ton fichier spécifique
                string cheminRepertoirePourTestDossier = @"game\HD\";
                string cheminFichierTestDemarrageLanceur = Path.Combine(cheminRepertoirePourTestDossier, FichierSDJeuxPourTestDossier);

                GestionFichierZIP gestionnaireFichierZIP = new GestionFichierZIP(_form4);

                if (_form4.CaseHDVersion.Checked)
                {
                   
                    if (!File.Exists(cheminFichierTestDemarrageLanceur))
                    {

                        if (!File.Exists(cheminFichierTestDemarrageLanceur))
                        {
                            long tailleFichierAtelecharger = 6442450944; // Taille du fichier en octets (2 Go)

                            if (VerifTailleDispoDisque(tailleFichierAtelecharger))
                            {
                               

                                // Télécharger le fichier car l'espace disque est suffisant

                                // Téléchargement et décompression pour HD
                                string urlHD = "https://raymanarenaonline.eundilmako.com/filsdownload/HD.zip"; // Remplacez par l'URL du fichier HD
                                string cheminHD = @"game\SD\"; // Remplacez par le chemin relatif pour HD
                                gestionnaireFichierZIP.TelechargerEtDecompresser(urlHD, cheminHD);
                            }
                            else
                            {
                                // Afficher un message indiquant que l'espace disque est insuffisant
                                MessageBox.Show(_form4.passuffespace2go);
                            }
                        }

                    }
                    else //case pas coché
                    {
                       
                        // Jeu HD déjà présent
                    }

                    // Si la case HD est cochée, télécharger également la version HD
                    if (!File.Exists(cheminFichierTestDemarrageLanceur))
                    {
                        long tailleFichierAtelecharger = 6442450944; // Taille du fichier en octets (6 Go)

                        if (VerifTailleDispoDisque(tailleFichierAtelecharger))
                        {
                            
                            // Télécharger le fichier car l'espace disque est suffisant
                            string urlHD = "https://raymanarenaonline.eundilmako.com/filsdownload/HD.zip"; // Remplacez par l'URL du fichier SD
                            string cheminHD = @"game\HD\"; // Remplacez par le chemin relatif pour SD
                            gestionnaireFichierZIP.TelechargerEtDecompresser(urlHD, cheminHD);
                        }
                        else
                        {
                            // Afficher un message indiquant que l'espace disque est insuffisant
                            MessageBox.Show(_form4.passuffespace6go);
                        }
                    }
                    else
                    {
                        
                        _form4.button1.Enabled = true;
                        _form4.LabMessageTel.Visible = false;
                        _form4.progressBar1.Visible = false;
                        _form4.BoutonValidaton.Visible = true;
                        MessageBox.Show("La version HD et SD sont deja telecharger");
                    }
                }
                else
                {
                    if (!File.Exists(cheminFichierTestDemarrageLanceur))
                    {

                        long tailleFichierAtelecharger = 2147483648; // Taille du fichier en octets (2 Go)

                        if (VerifTailleDispoDisque(tailleFichierAtelecharger))
                        {

                            // Télécharger le fichier car l'espace disque est suffisant
                            string urlSD = "https://raymanarenaonline.eundilmako.com/filsdownload/SD.zip"; // Remplacez par l'URL du fichier SD
                            string cheminSD = @"game\SD\"; // Remplacez par le chemin relatif pour SD
                            gestionnaireFichierZIP.TelechargerEtDecompresser(urlSD, cheminSD);
                        }
                        else
                        {
                            // Afficher un message indiquant que l'espace disque est insuffisant
                           MessageBox.Show(_form4.passuffespace2go);
                        }


                        // Téléchargement et décompression pour SD

                    }
                    else
                    {
                        //MessageBox.Show("La version SD et deja telecharger");
                        // Jeu SD déjà présent
                    }
                }




            }
        }

        private void CaseHDVersion_CheckedChanged(object sender, EventArgs e)
        {

        }

        void choixlangue()
        {
            string cheminfichierLangue = @"fils\Langue.txt "; //chemin fichier txt

            if (!File.Exists(cheminfichierLangue))
            {
                File.WriteAllText(cheminfichierLangue, "EN");
            }
            else
            {
                string lecture = File.ReadAllText(cheminfichierLangue);

                if (lecture == "EN")
                {
                    label1.Text = "Please choose the version(s) of the game you ";
                    label2.Text = "wish to download";
                    label5.Text = "Normal version (SD)";
                    CaseHDVersion.Text = "HD version";
                    label4.Text = "Download center";
                    BoutonTelchargement.Text = "Download";
                    BoutonValidaton.Text = "OK";
                    MessageErreurproduit = "An error occurred: ";
                    MessageDossierIntrouvable = "The specified folder does not exist.";
                    MessageSuppHDAnnul = "Deletion of the HD version was canceled.";
                    MessageSuppHDOk = "The HD version has been successfully deleted.";
                    MessageSurDeDecohHd = "You have unchecked the HD option. Are you sure you want to delete the HD version?";
                    MessageConfirmation = "Confirmation";
                    MessageAvertissementHdNonDL = "The HD version has not been downloaded yet. Please click Download or uncheck the option.";
                    MessageErreurDL = "Error during download:";
                    MessageErreurDLEtDecompressOk = "Download and decompression completed.";
                    MessageDecompressErreur = "Error during decompression:";
                    MessageTelEnCour = "Download in progress...";
                    groupBox1.Text = "Download Version";
                    button1.Text = "Close";
                    passuffespace2go = "insufficient disk space to download the sd version (2go)";
                    passuffespace6go = "insufficient disk space to download the sd version (6go)";

                }
                else if (lecture == "FR")
                {
                    label1.Text = "Veuillez choisir la ou les version du jeu que vous ";
                    label2.Text = "désirez télécharger";
                    label5.Text = "Version normale (SD)";
                    CaseHDVersion.Text = "Version HD";
                    label4.Text = "Centre de téléchargement";
                    BoutonTelchargement.Text = "Téléchargement";
                    BoutonValidaton.Text = "OK";
                    MessageErreurproduit = "Une erreur s'est produite : ";
                    MessageDossierIntrouvable = "Le dossier spécifié n'existe pas.";
                    MessageSuppHDAnnul = "La suppression de la version HD a été annulée.";
                    MessageSuppHDOk = "La version HD a bien été supprimée.";
                    MessageSurDeDecohHd = "Vous avez décoché la case HD. Êtes-vous sûr de vouloir supprimer la version HD ?";
                    MessageConfirmation = "Confirmation";
                    MessageAvertissementHdNonDL = "La version HD n'a pas encore été téléchargée. Veuillez cliquer sur Télécharger ou décocher la case.";
                    MessageErreurDL = "Erreur lors du téléchargement :";
                    MessageErreurDLEtDecompressOk = "Téléchargement et décompression terminés.";
                    MessageDecompressErreur = "Erreur lors de la décompression :";
                    MessageTelEnCour = "Téléchargement en cours...";
                    groupBox1.Text = "Version à telecharger";
                    button1.Text = "Fermer";
                    passuffespace2go = "espace disque est insuffisant pour télécharger la version sd (2go)";
                    passuffespace6go = "espace disque est insuffisant pour télécharger la version sd (6go)";
                }
                else if (lecture == "ES")
                {
                    label1.Text = "Por favor, elija la versión o las versiones del juego que desea ";
                    label2.Text = "descargar";
                    label5.Text = "Versión normal (SD)";
                    CaseHDVersion.Text = "Versión HD";
                    label4.Text = "Centro de descargas";
                    BoutonTelchargement.Text = "Descarga";
                    BoutonValidaton.Text = "OK";
                    MessageErreurproduit = "Se ha producido un error: ";
                    MessageDossierIntrouvable = "La carpeta especificada no existe.";
                    MessageSuppHDAnnul = "La eliminación de la versión HD ha sido cancelada.";
                    MessageSuppHDOk = "La versión HD se ha eliminado correctamente.";
                    MessageSurDeDecohHd = "Has desmarcado la casilla HD. ¿Estás seguro de querer eliminar la versión HD?";
                    MessageConfirmation = "Confirmación";
                    MessageAvertissementHdNonDL = "La versión HD aún no ha sido descargada. Por favor, haga clic en Descargar o desmarque la casilla.";
                    MessageErreurDL = "Error durante la descarga :";
                    MessageErreurDLEtDecompressOk = "Descarga y descompresión completadas.";
                    MessageDecompressErreur = "Error durante la descompresión :";
                    MessageTelEnCour = "Descarga en curso...";
                    groupBox1.Text = "Versión para descargar";
                    button1.Text = "Cerrar";
                    passuffespace2go = "espacio en disco insuficiente para descargar la versión SD (2go)";
                    passuffespace6go = "espacio en disco insuficiente para descargar la versión SD (6go)";
                }
                else if (lecture == "RU")
                {
                    label1.Text = "Пожалуйста, выберите версию или версии игры, которую вы ";
                    label2.Text = "хотите загрузить";
                    label5.Text = "Обычная версия (SD)";
                    CaseHDVersion.Text = "Версия HD";
                    label4.Text = "Центр загрузки";
                    BoutonTelchargement.Text = "Загрузка";
                    BoutonValidaton.Text = "OK";
                    MessageErreurproduit = "Произошла ошибка: ";
                    MessageDossierIntrouvable = "Указанная папка не существует.";
                    MessageSuppHDAnnul = "Удаление версии HD отменено.";
                    MessageSuppHDOk = "Версия HD успешно удалена.";
                    MessageSurDeDecohHd = "Вы сняли отметку с HD. Вы уверены, что хотите удалить версию HD?";
                    MessageConfirmation = "Подтверждение";
                    MessageAvertissementHdNonDL = "Версия HD еще не загружена. Пожалуйста, нажмите Загрузить или снимите отметку.";
                    MessageErreurDL = "Ошибка загрузки:";
                    MessageErreurDLEtDecompressOk = "Загрузка и распаковка завершены.";
                    MessageDecompressErreur = "Ошибка распаковки:";
                    MessageTelEnCour = "Загрузка в процессе...";
                    groupBox1.Text = "Версия для загрузки";
                    button1.Text = "Закрыть";
                    passuffespace2go = "недостаточно места на диске для загрузки SD-версии (2go)";
                    passuffespace6go = "недостаточно места на диске для загрузки SD-версии (6go)";
                }
            }



            }





    }
}


