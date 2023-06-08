using System.Windows;
using System;
using System.Data;
using System.IO;
using NAudio.Wave;
using System.Collections.Generic;

namespace InnoWeeks_MediaPlayer
{

    public partial class MainWindow : Window
    {
        private List<string> fichiersMP3;

        public MainWindow()
        {
            InitializeComponent();
            fichiersMP3 = new List<string>();
        }

        // Méthode appelée lorsqu'un fichier est déposé dans la fenêtre
        private void Fenetre_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fichiersDeposes = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (fichiersDeposes.Length > 0)
                {
                    foreach (string cheminFichier in fichiersDeposes)
                    {
                        if (EstFichierMP3(cheminFichier))
                        {
                            string nomFichier = Path.GetFileName(cheminFichier);

                            // Ajouter le chemin du fichier MP3 à la liste
                            fichiersMP3.Add(cheminFichier);

                            // Mettre à jour l'élément visuel approprié pour afficher les noms des fichiers (par exemple, une ListBox nommée "maListBox")
                            listeFichiers.Items.Add(nomFichier);
                        }
                    }
                }
            }
        }

        // Vérifier si un fichier est un fichier MP3
        private bool EstFichierMP3(string cheminFichier)
        {
            return Path.GetExtension(cheminFichier).Equals(".mp3", StringComparison.OrdinalIgnoreCase);
        }
    }
}
